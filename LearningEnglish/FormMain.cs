using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.IO;
using System.Text.RegularExpressions;
using System.Collections;

namespace LearningEnglish
{
    public partial class la : Form
    {
        private ArrayList VOAItemList;
        private ArrayList voaDownloadList;
        public la()
        {
            InitializeComponent();
            VOA.ClassConfig classConfig = new VOA.ClassConfig();
            if (!VOA.ClassConfig.ReadConfigFile())
            {
                //MessageBox.Show("读取配置文件失败。");
                MessageBox.Show("读取配置文件失败，将使用默认配置值。", "配置错误",
         MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }                        
            goBackWorkerGetVoaList();     
        }

        public Boolean getVoaList()
        {
            try
            {
                int TypeIsDownloadNum = 0;
                VOAItemList = new ArrayList();
                ////进度条操作
                //this.toolStripProgressBar.Value = 1;
                //this.toolStripProgressBar.Maximum = VOA.ClassConfig.configVOATypeList.Count;
                ////操作结束
                for (int i = 0; i < VOA.ClassConfig.configVOATypeList.Count; i++)
                {
                    VOA.ClassConfigVOAType config = (VOA.ClassConfigVOAType)VOA.ClassConfig.configVOATypeList[i];
                    if (config.TpyeIsDownload)
                    {
                        TypeIsDownloadNum++;
                    }
                }
                for (int i = 0; i < VOA.ClassConfig.configVOATypeList.Count; i++)
                {
                    VOA.ClassConfigVOAType config = (VOA.ClassConfigVOAType)VOA.ClassConfig.configVOATypeList[i];
                    if (config.TpyeIsDownload)
                    {
                        VOA.ClassHTML classHtml = new VOA.ClassHTML();
                        classHtml.Url = config.TypeURL;
                        classHtml.GetHTML();
                        ArrayList temp = classHtml.GetVOAList(60 / TypeIsDownloadNum, config.TypeName);
                        for (int j = 0; j < temp.Count; j++)
                        {
                            VOAItemList.Add(temp[j]);
                        }
                    }
                    this.backWorkerGetVoaList.ReportProgress(i+1);
                    ////进度条操作
                    //this.toolStripProgressBar.Value = i + 1;
                    ////操作结束
                }

                this.checkedListBoxMain.Items.Clear();
                if (VOAItemList.Count == 0)
                {
                    return false;
                }
                for (int i = 0; i < VOAItemList.Count; i++)
                {
                    ClassVOA voa = (ClassVOA)VOAItemList[i];
                    CheckBox cb = new CheckBox();
                    this.checkedListBoxMain.Items.Add(voa.Type + "-" + voa.Name + " (" + voa.Date.ToString("yyyy-MM-dd") + ")");
                }
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        private void buttonSelectAll_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < this.checkedListBoxMain.Items.Count; i++)
            {
                this.checkedListBoxMain.SetItemChecked(i, true);
            }
        }

        private void buttonSelectFirst20_Click(object sender, EventArgs e)
        {
            int num = this.checkedListBoxMain.Items.Count >= 20 ? 20 : this.checkedListBoxMain.Items.Count;
            for (int i = 0; i < this.checkedListBoxMain.Items.Count; i++)
            {
                if (i < num)
                {
                    this.checkedListBoxMain.SetItemChecked(i, true);
                }
                else
                {
                    this.checkedListBoxMain.SetItemChecked(i, false);
                }
            }
        }     

        private void buttonSelectNone_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < this.checkedListBoxMain.Items.Count; i++)
            {
                this.checkedListBoxMain.SetItemChecked(i, false);
            }
        }

        private void buttonDownload_Click(object sender, EventArgs e)
        {
            //StringBuilder str = new StringBuilder();
            //for (int i = 0; i < VOAItemList.Count; i++)
            //{
            //    ClassVOA voa = (ClassVOA)VOAItemList[i];
            //    str.Append(voa.Type + "-" + voa.Name + " (" + voa.Date.ToString("yyyy-MM-dd") + ")----" + voa.HtmlUrl +"\n");
            //}
            ////MessageBox.Show(str.ToString());


            voaDownloadList = new ArrayList();
            for (int i = 0; i < this.checkedListBoxMain.Items.Count; i++)
            {
              if (this.checkedListBoxMain.GetItemChecked(i))
              {
                  ClassVOA voa = (ClassVOA)VOAItemList[i];
                  voaDownloadList.Add(voa);
              }
            }
            if (voaDownloadList.Count == 0)
            {
                MessageBox.Show("请选择需要下载的文件。", "提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else 
            {                
                //提取下载文件的MP3链接
                this.buttonDownload.Enabled = false;
                this.buttonFresh.Enabled = false;
                this.toolStripMenuItemConfig.Enabled = false;
                this.toolStripStatus.Text = "正在提取文件地址...";
                this.toolStripProgressBar.Value = 0;
                this.toolStripProgressBar.Maximum = voaDownloadList.Count;
                this.backWorkerGetVoaUrls.RunWorkerAsync();
            }
          
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            VOA.FormAbout fmAbout = new VOA.FormAbout();            
            fmAbout.ShowDialog();
        }

        private void helpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            VOA.FormHelp fmHelp = new VOA.FormHelp();
            fmHelp.Show();
        }       

        private void toolStripMenuItemConfig_Click(object sender, EventArgs e)
        {
            VOA.FormConfig fmConfig = new VOA.FormConfig();
            fmConfig.ShowDialog();
            
        }     

        private void backWorkerGetVoaList_DoWork(object sender, DoWorkEventArgs e)
        {           
            getVoaList();           
        }      

        private void backWorkerGetVoaList_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (this.checkedListBoxMain.Items.Count == 0)
            {
                MessageBox.Show("获取文件更新列表失败，原因可能如下：\n1、您的计算机没有连接到Internet。\n2、您所选择的文件类别当前没有更新。\n如果经确认上面两个原因都不可能，请不妨联系开发者，\n我们会在最短时间内解决。", 
                    "提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            this.buttonDownload.Enabled = true;
            this.buttonFresh.Enabled = true;
            this.toolStripMenuItemConfig.Enabled = true;       
            this.toolStripStatus.Text = "就绪";
            this.toolStripProgressBar.Value=0;            
        }

        private void goBackWorkerGetVoaList() 
        {            
            this.buttonDownload.Enabled = false;
            this.buttonFresh.Enabled = false;
            this.toolStripMenuItemConfig.Enabled = false;
            this.toolStripStatus.Text = "正在获取文件更新列表...";
            this.toolStripProgressBar.Value = 0;
            this.toolStripProgressBar.Maximum = VOA.ClassConfig.configVOATypeList.Count;
            this.backWorkerGetVoaList.RunWorkerAsync();
        }

        private void buttonFresh_Click(object sender, EventArgs e)
        {
            goBackWorkerGetVoaList();
        }

        private void backWorkerGetVoaList_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            this.toolStripProgressBar.Value = e.ProgressPercentage; 
        }

        private void backWorkerGetVoaUrls_DoWork(object sender, DoWorkEventArgs e)
        {
            //根据下载当天日期创建文件夹
            DateTime dtNow = DateTime.Now;
            string path = VOA.ClassConfig.configSavePath + "\\" + dtNow.ToString("yyyy-MM-dd");
            System.IO.Directory.CreateDirectory(path);
            //遍历下载列表，提取下载文件的地址
            for (int i = 0; i < voaDownloadList.Count; i++)
            {
                ClassVOA voa = (ClassVOA)voaDownloadList[i];
                VOA.ClassHTML classHtml = new VOA.ClassHTML();
                classHtml.Url = voa.HtmlUrl;
                classHtml.GetHTML();
                voa.Mp3Url = classHtml.GetVOAUrl();
                voa.LrcUrl = classHtml.GetLRCUrl();
                voa.Path = path + "\\" + deleteInvalidChars(voa.Type + "-" + voa.Name + " (" + voa.Date.ToString("yyyy-MM-dd") + ")") + ".mp3";
                //this.richTextBox1.AppendText(voa.Name + "\n----Mp3Url:   " + voa.Mp3Url + "\n----Mp3Path:   " + voa.Path + "\n----HtmlUrl:   " + voa.HtmlUrl + "\n----type:   " + voa.Type + "\n----date:   " + voa.Date + "\n\n");                                      
                this.backWorkerGetVoaUrls.ReportProgress(i + 1);
            }     
        }

        private string deleteInvalidChars(string filename)
        {
            return filename.Replace("/", "-").Replace("\\", "-").Replace(":", "-").Replace("*", "-").Replace("?", "-").Replace("\"", "-").Replace("<", "-").Replace(">", "-").Replace("|", "-");           
        }

        private void backWorkerGetVoaUrls_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            this.toolStripProgressBar.Value = e.ProgressPercentage;
        }

        private void backWorkerGetVoaUrls_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            this.toolStripProgressBar.Value = 0;
            this.toolStripStatus.Text = "正在下载...(1/" + voaDownloadList.Count + ")";
            //this.buttonCancelDownload.Visible = true;
            this.backWorkerDownloadFiles.RunWorkerAsync();
            ////Test code
            //this.richTextBox1.Text = "";
            //for (int i = 0; i < voaDownloadList.Count; i++)
            //{
            //    ClassVOA voa = (ClassVOA)voaDownloadList[i];
            //    this.richTextBox1.AppendText(voa.Name + "\n----Mp3Url:   " + voa.Mp3Url + "\n----Mp3Path:   " + voa.Path + "\n----HtmlUrl:   " + voa.HtmlUrl + "\n----type:   " + voa.Type + "\n----date:   " + voa.Date + "\n\n");
            //}     
        }

        private void backWorkerDownloadFiles_DoWork(object sender, DoWorkEventArgs e)
        {
            //遍历下载列表，下载文件
            for (int i = 0; i < voaDownloadList.Count; i++)
            {
                this.backWorkerDownloadFiles.ReportProgress(i + 1);
                ClassVOA voa = (ClassVOA)voaDownloadList[i];
                //this.richTextBox1.AppendText(voa.Mp3Url + "   LRC: " + voa.LrcUrl + "\n");
                try
                {
                    if (VOA.ClassConfig.configIsHtmlDownload)
                    {
                        voa.DownloadHTML(this.toolStripProgressBar);
                    }
                    if (VOA.ClassConfig.configIsMP3Download)
                    {
                        voa.DownloadMP3(this.toolStripProgressBar);
                        voa.DownloadLRC(this.toolStripProgressBar);
                    }
                    if (VOA.ClassConfig.configIsTXTDownload)
                    {
                        voa.DownloadTXT(this.toolStripProgressBar);
                    }          
                }
                catch (Exception)
                { 
                    //下载失败
                }
            }     
        }

        private void backWorkerDownloadFiles_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            this.toolStripStatus.Text = "正在下载...(" + e.ProgressPercentage + "/" + voaDownloadList.Count + ")";
            //this.toolStripProgressBar.Value = e.ProgressPercentage * 100 / voaDownloadList.Count;
        }

        private void backWorkerDownloadFiles_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            //this.buttonCancelDownload.Visible = false;
            this.buttonDownload.Enabled = true;
            this.buttonFresh.Enabled = true;
            this.toolStripMenuItemConfig.Enabled = true;
            this.toolStripStatus.Text = "下载完成";
        }

        private void buttonCancelDownload_Click(object sender, EventArgs e)
        {
            this.backWorkerDownloadFiles.CancelAsync();
        }            
      
    }
}