namespace FindFileManager
{
    partial class CustomFindFile
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.chkSearchSubfolders = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtExtension = new System.Windows.Forms.TextBox();
            this.btnFindFolder = new System.Windows.Forms.Button();
            this.txtTextToFind = new System.Windows.Forms.TextBox();
            this.txtFolderPath = new System.Windows.Forms.TextBox();
            this.txtResults = new System.Windows.Forms.TextBox();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.btnFind = new System.Windows.Forms.Button();
            this.folderBrowserDlg = new System.Windows.Forms.FolderBrowserDialog();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(237, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(217, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Find files with specific extension and content";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(19, 69);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(85, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Folder to Search";
            // 
            // chkSearchSubfolders
            // 
            this.chkSearchSubfolders.AutoSize = true;
            this.chkSearchSubfolders.Location = new System.Drawing.Point(131, 68);
            this.chkSearchSubfolders.Name = "chkSearchSubfolders";
            this.chkSearchSubfolders.Size = new System.Drawing.Size(113, 17);
            this.chkSearchSubfolders.TabIndex = 2;
            this.chkSearchSubfolders.Text = "Search Subfolders";
            this.chkSearchSubfolders.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(282, 68);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(25, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Ext,";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(503, 68);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(63, 13);
            this.label4.TabIndex = 4;
            this.label4.Text = "Text to find:";
            // 
            // txtExtension
            // 
            this.txtExtension.Location = new System.Drawing.Point(343, 65);
            this.txtExtension.Name = "txtExtension";
            this.txtExtension.Size = new System.Drawing.Size(100, 20);
            this.txtExtension.TabIndex = 5;
            // 
            // btnFindFolder
            // 
            this.btnFindFolder.Location = new System.Drawing.Point(676, 103);
            this.btnFindFolder.Name = "btnFindFolder";
            this.btnFindFolder.Size = new System.Drawing.Size(30, 23);
            this.btnFindFolder.TabIndex = 6;
            this.btnFindFolder.Text = "...";
            this.btnFindFolder.UseVisualStyleBackColor = true;
            this.btnFindFolder.Click += new System.EventHandler(this.btnFindFolder_Click);
            // 
            // txtTextToFind
            // 
            this.txtTextToFind.Location = new System.Drawing.Point(583, 65);
            this.txtTextToFind.Name = "txtTextToFind";
            this.txtTextToFind.Size = new System.Drawing.Size(123, 20);
            this.txtTextToFind.TabIndex = 7;
            // 
            // txtFolderPath
            // 
            this.txtFolderPath.Location = new System.Drawing.Point(22, 106);
            this.txtFolderPath.Name = "txtFolderPath";
            this.txtFolderPath.Size = new System.Drawing.Size(648, 20);
            this.txtFolderPath.TabIndex = 8;
            // 
            // txtResults
            // 
            this.txtResults.Location = new System.Drawing.Point(0, 161);
            this.txtResults.Multiline = true;
            this.txtResults.Name = "txtResults";
            this.txtResults.Size = new System.Drawing.Size(729, 247);
            this.txtResults.TabIndex = 9;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStatus});
            this.statusStrip1.Location = new System.Drawing.Point(0, 406);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(729, 22);
            this.statusStrip1.TabIndex = 10;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStatus
            // 
            this.toolStatus.Name = "toolStatus";
            this.toolStatus.Size = new System.Drawing.Size(39, 17);
            this.toolStatus.Text = "Ready";
            // 
            // btnFind
            // 
            this.btnFind.Location = new System.Drawing.Point(22, 132);
            this.btnFind.Name = "btnFind";
            this.btnFind.Size = new System.Drawing.Size(75, 23);
            this.btnFind.TabIndex = 11;
            this.btnFind.Text = "Find";
            this.btnFind.UseVisualStyleBackColor = true;
            this.btnFind.Click += new System.EventHandler(this.btnFind_Click);
            // 
            // CustomFindFile
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(729, 428);
            this.Controls.Add(this.btnFind);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.txtResults);
            this.Controls.Add(this.txtFolderPath);
            this.Controls.Add(this.txtTextToFind);
            this.Controls.Add(this.btnFindFolder);
            this.Controls.Add(this.txtExtension);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.chkSearchSubfolders);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "CustomFindFile";
            this.Text = "Custom Find File";
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox chkSearchSubfolders;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtExtension;
        private System.Windows.Forms.Button btnFindFolder;
        private System.Windows.Forms.TextBox txtTextToFind;
        private System.Windows.Forms.TextBox txtFolderPath;
        private System.Windows.Forms.TextBox txtResults;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStatus;
        private System.Windows.Forms.Button btnFind;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDlg;
    }
}

