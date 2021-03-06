using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.Text.RegularExpressions;
using System.IO;
using System.Windows.Forms;

namespace LearningEnglish
{
    class ClassVOA
    {

        private string htmlUrl;

        public string HtmlUrl
        {
            get { return htmlUrl; }
            set { htmlUrl = value; }
        }

        private string mp3Url;

        public string Mp3Url
        {
            get { return mp3Url; }
            set { mp3Url = value; }
        }

        private string lrcUrl;

        public string LrcUrl
        {
            get { return lrcUrl; }
            set { lrcUrl = value; }
        }

        private string name;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        private string type;

        public string Type
        {
            get { return type; }
            set { type = value; }
        }

        private DateTime date;

        public DateTime Date
        {
            get { return date; }
            set { date = value; }
        }

        private string path;

        public string Path
        {
            get { return path; }
            set { path = value; }
        }

        public bool DownloadMP3(ToolStripProgressBar progressBar)
        {
            return DownloadFile(path, mp3Url, progressBar);
        }

        public bool DownloadHTML(ToolStripProgressBar progressBar)
        {
            return DownloadFile(path.Replace(".mp3", ".html"), htmlUrl, progressBar);
        }

        public bool DownloadTXT(ToolStripProgressBar progressBar)
        {
            return DownloadTXTFile(path.Replace(".mp3", ".txt"), htmlUrl, progressBar);
        }

        public bool DownloadLRC(ToolStripProgressBar progressBar)
        {
            if (lrcUrl != null)
            {
                return DownloadFile(path.Replace(".mp3", ".lrc"), lrcUrl, progressBar);
            }
            else
            {
                return false;
            }
        }

        //下载TXT文件方法
        private bool DownloadTXTFile(string filePath, string fileURL, ToolStripProgressBar progressBar)
        {
            progressBar.Value = 0;
            progressBar.Maximum =100;   
            System.Net.WebClient client = new WebClient();
            byte[] page = client.DownloadData(fileURL);
            string content = System.Text.Encoding.UTF8.GetString(page);
            progressBar.Value = 40;
            Match m_Content = Regex.Match(content, "<div id=\"menubar\">.*<div id=\"list\">", RegexOptions.Singleline);
            if (m_Content.Success)
            {
                content = m_Content.ToString();
            }
            progressBar.Value = 50;
            Regex rbr = new Regex("<br.*?/>|<br.*?>|</p>|</div>", RegexOptions.IgnoreCase);
            content = rbr.Replace(content, "##########");
            progressBar.Value = 60;
            Regex rspce = new Regex("<a href.*?</a>|<.*?>|&nbsp;", RegexOptions.IgnoreCase);
            content = rspce.Replace(content, " ");
            progressBar.Value = 70;
            Regex rremovebr = new Regex("\\s+", RegexOptions.IgnoreCase);
            content = rremovebr.Replace(content, " ");
            progressBar.Value = 80;
            Regex rbaddbr = new Regex("##########", RegexOptions.IgnoreCase);
            content = rbaddbr.Replace(content, "\r\n");
            progressBar.Value = 90;
            System.IO.FileStream fs = new System.IO.FileStream(filePath, System.IO.FileMode.Create);
            System.IO.StreamWriter sw = new System.IO.StreamWriter(fs, System.Text.Encoding.UTF8);
            sw.WriteLine(content);
            sw.Close();
            fs.Close();
            progressBar.Value = 100;
            return true;
        }

        /// <summary>
        /// 下载文件方法
        /// </summary>
        /// <param name="strFileName">文件保存路径和文件名</param>
        /// <param name="file">返回服务器文件名</param>
        /// <returns></returns>
        private bool DownloadFile(string filePath, string fileURL, ToolStripProgressBar progressBar)
        {

            long Filelength = 0;
            long ThisLength = 0;
            HttpWebRequest req = HttpWebRequest.Create(fileURL) as HttpWebRequest;
            req.Timeout = 60 * 1000;
            req.AllowAutoRedirect = true;
            //label1.Text = "=> 正在检测 " + FileSavePath + "...";
            try
            {
                HttpWebResponse res = req.GetResponse() as HttpWebResponse;
                System.IO.Stream stream = res.GetResponseStream();
                Filelength = res.ContentLength;
                progressBar.Value = 0;
                progressBar.Maximum = (int)Filelength;                
                int allk = (int)(Filelength / 1024);
                //label1.Text = "=> 正在下载 " + FileSavePath + "...";
                byte[] b = new byte[1024];
                int nReadSize = 0;
                nReadSize = stream.Read(b, 0, 1024);

                System.IO.FileStream fs = System.IO.File.Create(filePath);
                try
                {

                    while (nReadSize > 0)
                    {
                        //label1.Refresh();
                        progressBar.Value += nReadSize;
                        ThisLength += nReadSize;
                        //label1.Text = "=> 正在下载 " + FileSavePath + "(" + (int)(ThisLength / 1024) + "K/" + allk + "K)";
                        fs.Write(b, 0, nReadSize);
                        nReadSize = stream.Read(b, 0, 1024);
                    }
                }
                finally
                {
                    fs.Close();
                }
                progressBar.Value = 0;
                progressBar.Maximum = 0;
                //label1.Text = "";
                res.Close();
                stream.Close();
                progressBar.Value = 0;
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
       
    }
}
