using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace FindFileManager
{
    public partial class CustomFindFile : Form
    {
        //This delegate enables asynchonous calls for setting the text property on a TextBox control.
        delegate void SetTextCallback(string text);

        public CustomFindFile()
        {
            InitializeComponent();
        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            FindFileManager find = new FindFileManager();

            find.AddCompletedStatusEventHandler(CompletedStatusEventHandler);
            find.AddUpdateStatusbarEventHandler(UpdateStatusbarEventHandler);
            find.AddUpdateStatusEventHandler(UpdateStatusEventHandler);

            FindFileArgs args = new FindFileArgs();
            args.searchPath = txtFolderPath.Text;
            args.searchSubFolders = chkSearchSubfolders.Checked;
            args.extension = txtExtension.Text;
            args.findString = txtTextToFind.Text;
            Cursor = Cursors.WaitCursor;
            m_curState = STATE.BUSY;

            updateUI();
            find.findFilesAsync(args);
        }

        private void UpdateStatusbarEventHandler(object sender, UpdateStatusArgs e)
        {
            updateStatusLabel(e.status);
        }

        private void UpdateStatusEventHandler(object sender, UpdateStatusArgs e)
        {
            updateStatus(e.status);
        }

        ///Handles complete event
        ///Uses the custom class UpdateStatusArgs.

        private void CompletedStatusEventHandler(object sender, UpdateStatusArgs e)
        {
            FindFileManager finder = (FindFileManager)sender;
            List<FileInfo> list = finder.fileList;

            foreach (FileInfo file in list)
            {
                updateStatus(file.FullName);
            }

            Cursor = Cursors.Default;

            m_curState = STATE.READY;
            updateUI();
        }

        private void updateStatusLabel(string msg)
        {
            try
            {
                toolStatus.Text = msg;
            }
            catch(InvalidOperationException ex)
            {
                updateStatus(ex.Message);
            }
        }

        private void updateStatus(string msg)
        {
            SetText(msg);
        }

        private void SetText(string text)
        {
            //InvokeRequired compares the thread ID of the
            //calling thread to the thread ID of the creating thread.
            //If these threads are different, it returns true.
            if (this.txtResults.InvokeRequired)
            {
                SetTextCallback d = new SetTextCallback(SetText);
                this.Invoke(d, new object[] { text });
            }
            else
            {
                this.txtResults.Text += text + Environment.NewLine;
                txtResults.SelectionStart = txtResults.Text.Length;
                txtResults.ScrollToCaret();
            }
        }

        private void btnFindFolder_Click(object sender, EventArgs e)
        {
            if(txtFolderPath.Text != "")
            {
                folderBrowserDlg.SelectedPath = txtFolderPath.Text; 
            }
            if(folderBrowserDlg.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                txtFolderPath.Text = folderBrowserDlg.SelectedPath;
            }
        }

        private void updateUI()
        {
            switch (m_curState)
            {
                case STATE.BUSY: btnFind.Enabled = false;
                    break;
                case STATE.READY: btnFind.Enabled = true;
                    break;
            }
        }

        enum STATE
        {
            READY,
            BUSY
        }

        private STATE m_curState = STATE.READY;

    }
}
