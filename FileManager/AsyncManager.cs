using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Windows.Forms;


namespace FindFileManager
{
    public class UpdateStatusArgs:EventArgs
    {
        public bool HasError
        {
            get
            {
                return error == null ? false : true;
            }
        }

        public string status
        {
            get { return m_status; }
            set { m_status = value; }
        }

        public object result
        {
            get { return m_result; }
            set { m_result = value; }
        }

        public Exception error
        {
            get { return m_error; }
            set { m_error = value; }
        }

        private string m_status;
        private object m_result;
        private Exception m_error;
    }

    ///Provides threading support for the project

    public class AsyncManager
    {
        public delegate void UpdateStatusEventHandler(object sender, UpdateStatusArgs e);
        public event UpdateStatusEventHandler m_updateStatusHandler;
        public delegate void CompletedStatusEventHandler(object sender, UpdateStatusArgs e);
        public event CompletedStatusEventHandler m_completedStatusHandler;
        public delegate void UpdateStatusbarEventHandler(object sender, UpdateStatusArgs e);
        public event UpdateStatusbarEventHandler m_updateStatusbarHandler;

        public AsyncManager()
        {
            m_eventArgs = new UpdateStatusArgs();
            worker.ProgressChanged += ProgressChanged;
            worker.WorkerReportsProgress = true;
            worker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(runWorkerCompleted);
        }

        #region Public Event Handler Methods
        /// <summary>
        /// Adds and UpdateStatusEventHandler
        /// </summary>
        /// <param name="handler">UpdateStatusEventHandler</param>
        public void AddUpdateStatusEventHandler(UpdateStatusEventHandler handler)
        {
            m_updateStatusHandler += handler;
        }

        public void RemoveUpdateStatusEventHandler(UpdateStatusEventHandler handler)
        {
            m_updateStatusHandler -= handler;
        }

        public void AddCompletedStatusEventHandler(CompletedStatusEventHandler handler)
        {
            m_completedStatusHandler += handler;
        }

        public void RemoveCompletedStatusEventHandler(CompletedStatusEventHandler handler)
        {
            m_completedStatusHandler -= handler;
        }

        public void AddUpdateStatusbarEventHandler(UpdateStatusbarEventHandler handler)
        {
            m_updateStatusbarHandler += handler;
        }

        public void RemoveUpdateStatusbarEventHandler(UpdateStatusbarEventHandler handler)
        {
            m_updateStatusbarHandler -= handler;
        }
        #endregion

        protected void updateStatus(string msg)
        {
            if(m_updateStatusHandler != null)
            {
                m_eventArgs.status = msg;
                m_updateStatusHandler.Invoke(this, m_eventArgs);
            }
        }
        protected void updateStatusBar(string msg)
        {
            if(m_updateStatusbarHandler != null)
            {
                m_eventArgs.status = msg;
                m_updateStatusbarHandler.Invoke(this, m_eventArgs);
            }
        }

        protected void completedEvent(UpdateStatusArgs e)
        {

        }

        protected void ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            m_eventArgs.status = (string)e.UserState;
            m_updateStatusHandler.Invoke(this, m_eventArgs);            
        }

        protected void runWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            m_eventArgs.error = e.Error;
            if (e.Error != null)
            {
                m_eventArgs.status = "Error: ";
            }
            else
            {
                m_eventArgs.status = "Completed";
                m_eventArgs.result = e.Result;
            }

            m_completedStatusHandler.Invoke(this, m_eventArgs);
        }

        protected readonly BackgroundWorker worker = new BackgroundWorker();
        protected UpdateStatusArgs m_eventArgs;
    }
}
