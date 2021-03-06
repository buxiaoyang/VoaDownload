using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections;

namespace VOA
{
    public partial class FormConfig : Form
    {
        //ArrayList checkBoxConfigList;

        public FormConfig()
        {
            InitializeComponent();
            LoadConfigFormClass();
        }

        private Boolean LoadConfigFormClass()
        {
            try
            {
                this.textBoxSavePath.Text = VOA.ClassConfig.configSavePath;
                this.checkBoxFileTypeHTML.Checked = VOA.ClassConfig.configIsHtmlDownload;
                this.checkBoxFileTypeMP3.Checked = VOA.ClassConfig.configIsMP3Download;
                this.checkBoxFileTypeTXT.Checked = VOA.ClassConfig.configIsTXTDownload;
                for (int i = 0; i < VOA.ClassConfig.configVOATypeList.Count; i++)
                {
                    VOA.ClassConfigVOAType configType = (VOA.ClassConfigVOAType)VOA.ClassConfig.configVOATypeList[i];
                    for (int j = 0; j < this.checkBoxConfigList.Count; j++)
                    {
                        System.Windows.Forms.CheckBox checkBox = (System.Windows.Forms.CheckBox)this.checkBoxConfigList[j];
                        if (checkBox.Text == configType.TypeName)
                        {
                            checkBox.Checked = configType.TpyeIsDownload;
                        }
                    }
                }
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
            
        }

        private Boolean saveConfigToClass()
        {
            try
            {
                VOA.ClassConfig.configSavePath = this.textBoxSavePath.Text;
                VOA.ClassConfig.configIsHtmlDownload = this.checkBoxFileTypeHTML.Checked;
                VOA.ClassConfig.configIsTXTDownload = this.checkBoxFileTypeTXT.Checked;
                VOA.ClassConfig.configIsMP3Download = this.checkBoxFileTypeMP3.Checked;
                for (int i = 0; i < VOA.ClassConfig.configVOATypeList.Count; i++)
                {
                    VOA.ClassConfigVOAType configType = (VOA.ClassConfigVOAType)VOA.ClassConfig.configVOATypeList[i];
                    for (int j = 0; j < this.checkBoxConfigList.Count; j++)
                    {
                        System.Windows.Forms.CheckBox checkBox = (System.Windows.Forms.CheckBox)this.checkBoxConfigList[j];
                        if (checkBox.Text == configType.TypeName)
                        {
                            configType.TpyeIsDownload = checkBox.Checked;
                        }
                    }
                }
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }

        }

        private int DataValidation()
        { 
            // code 1: 保存路径不合法  
            // code 2: 请至少选择一个下载文件类别 
            // code 3: 请至少选择一种下载文件类型
            // code 4: 数据合法
            if (!System.IO.Directory.Exists(this.textBoxSavePath.Text))
            {
                return 1;
            }
            bool isAtLeastOneTypeDown = false;
            for(int i=0;i<this.checkBoxConfigList.Count;i++)
            {
                CheckBox checkBox = (CheckBox)this.checkBoxConfigList[i];
                isAtLeastOneTypeDown = isAtLeastOneTypeDown || checkBox.Checked;
            }
            if(!isAtLeastOneTypeDown)
            {
                return 2;
            }
            if (!(this.checkBoxFileTypeHTML.Checked || this.checkBoxFileTypeMP3.Checked || this.checkBoxFileTypeTXT.Checked))
            {
                return 3;
            }
            return 4;
        }

        private void buttonBrowseSavePath_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();
            folderBrowserDialog.Description = "请选择下载文件的保存路径：";
            folderBrowserDialog.ShowNewFolderButton = true;
            //folderBrowserDialog.RootFolder = Environment.SpecialFolder.Personal;
            DialogResult result = folderBrowserDialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                string folderName = folderBrowserDialog.SelectedPath;
                if (folderName != "")
                {
                    this.textBoxSavePath.Text = folderName;
                }
            }
        }

        private void buttonSaveConfig_Click(object sender, EventArgs e)
        {
            int code = DataValidation();
            if (code == 1)
            {         
                MessageBox.Show("保存路径不存在，请选择有效路径。", "配置错误",
         MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else if (code == 2)
            {
                MessageBox.Show("请至少选择一种下载文件“类别”。", "配置错误",
         MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else if (code == 3)
            {
                MessageBox.Show("请至少选择一种下载文件“类型”。", "配置错误",
         MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                saveConfigToClass();
                if (!VOA.ClassConfig.SaveConfigFile())
                {                    
                    MessageBox.Show("写入配置文件失败。", "配置错误",
        MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else
                {
                    //MessageBox.Show("保存配置成功。");
                    this.Close();
                }          
            }             
        }

        private void buttonCancelConfig_Click(object sender, EventArgs e)
        {
            this.Close();
        }

     }
}