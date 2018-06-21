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
            req.Timeout = 10 * 1000;
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
            


            //progressBar.Value = 0;            
            //bool flag = false;
            ////打开上次下载的文件
            //long SPosition = 0;
            ////实例化流对象
            //FileStream FStream;
            ////判断要下载的文件夹是否存在
            //if (File.Exists(filePath))
            //{
            //    //打开要下载的文件
            //    FStream = File.OpenWrite(filePath);
            //    //获取已经下载的长度
            //    SPosition = FStream.Length;
            //    FStream.Seek(SPosition, SeekOrigin.Current);
            //}
            //else
            //{
            //    //文件不保存创建一个文件
            //    FStream = new FileStream(filePath, FileMode.Create);
            //    SPosition = 0;
            //}
            //try
            //{
            //    //打开网络连接,filerecv为网站虚拟目录,file为文件名加后缀
            //    HttpWebRequest myRequest = (HttpWebRequest)HttpWebRequest.Create(fileURL);
            //    if (SPosition > 0)
            //        myRequest.AddRange((int)SPosition);             //设置Range值
            //    //向服务器请求,获得服务器的回应数据流
            //    Stream myStream = myRequest.GetResponse().GetResponseStream();               
            //    //定义一个字节数据
            //    byte[] btContent = new byte[512];
            //    int intSize = 0;
            //    intSize = myStream.Read(btContent, 0, 512);
            //    //progressBar.Maximum = intSize;
            //    while (intSize > 0)
            //    {
            //        FStream.Write(btContent, 0, intSize);
            //        intSize = myStream.Read(btContent, 0, 512);
            //        //progressBar.Value = intSize;
            //    }
            //    //关闭流
            //    FStream.Close();
            //    myStream.Close();
            //    flag = true;        //返回true下载成功
            //}
            //catch (Exception)
            //{
            //    FStream.Close();
            //    flag = false;       //返回false下载失败
            //}
            //return flag;
        }
       
    }
}
