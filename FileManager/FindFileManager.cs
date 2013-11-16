using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Text;
using System.Threading;

namespace FindFileManager
{
    public class FindFileArgs
    {
        public string searchPath { get; set; }
        public bool searchSubFolders { get; set; }
        public string extension {get; set;}
        public string findString { get; set; }
    }
    class FindFileManager : AsyncManager
    {
        public FindFileManager()
        {
            worker.DoWork += doWork;
        }

        public void findFilesAsync(FindFileArgs args)
        {
            worker.RunWorkerAsync(args);
        }

        public List<FileInfo> fileList
        {
            get { return m_list; }
        }

        private void doWork(object sender, DoWorkEventArgs e)
        {
            string path = @"C:\";
            bool searchSubDir = true;
            string ext = "";
            string fileContent = "";

            updateStatusBar("Starting search...");
            m_start = DateTime.Now;

            if(e.Argument is FindFileArgs)
            {
                FindFileArgs args = (FindFileArgs)e.Argument;
                path = args.searchPath;
                searchSubDir = args.searchSubFolders;
                ext = args.extension;
                fileContent = args.findString;
            }

            findFiles(path, searchSubDir, ext, fileContent);
            m_end = DateTime.Now;
            string completed = string.Format("Completed search. Found {0} matches", m_list.Count);
            TimeSpan span = m_end - m_start;
            string done = string.Format("{0}\r\nElapsed Time; {1} ms", completed, span.TotalMilliseconds);
            updateStatusBar(completed);
            updateStatus(done);
        }

        private void findFiles(string path, bool searchSubFolders, string ext, string find)
        {
            if(path.Length > 0)
            {
                m_list = new List<FileInfo>();
                SearchOption option = searchSubFolders ? SearchOption.AllDirectories : SearchOption.TopDirectoryOnly;
                try
                {
                    string[] files = Directory.GetFiles(path, ext, option);

                    foreach(string filePath in files)
                    {   // load files to see if there is a string match
                        FileInfo info = new FileInfo(filePath);
                        if(find != "")
                        {
                            if(scanFile(info, find))
                            {
                                m_list.Add(info);
                            }
                        }
                        else
                        {   //just looking for file extensions
                            m_list.Add(info);
                        }
                    }
                }
                catch(UnauthorizedAccessException ex)
                {
                    updateStatus("Error: " + ex.Message);
                }
            }
        }

        private bool scanFile(FileInfo info, string find)
        {
            bool found = false;
            updateStatusBar(string.Format("Scanning file {0} for {1}", info.Name, find));

            using (StreamReader reader = info.OpenText())
            {
                try
                {
                    string data = reader.ReadToEnd();
                    if(data.Contains(find))
                    {
                        found = true;
                    }
                }
                catch(IOException ex)
                {
                    updateStatus(string.Format("Error processing file {0} Exception: {1}", info.FullName, ex.Message.Trim()));
                }
            }
            return found;
        }

        List<FileInfo> m_list;
        DateTime m_start;
        DateTime m_end;
    }
}
