namespace LearningEnglish
{
    partial class la
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(la));
            this.toolStripMenuItemConfig = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.toolStripLabelTitle = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabelTitleProcess = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripProgressBar = new System.Windows.Forms.ToolStripProgressBar();
            this.panelFormMainButton = new System.Windows.Forms.Panel();
            this.buttonCancelDownload = new System.Windows.Forms.Button();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.buttonFresh = new System.Windows.Forms.Button();
            this.buttonSelectAll = new System.Windows.Forms.Button();
            this.buttonSelectFirst20 = new System.Windows.Forms.Button();
            this.buttonDownload = new System.Windows.Forms.Button();
            this.buttonSelectNone = new System.Windows.Forms.Button();
            this.backWorkerGetVoaList = new System.ComponentModel.BackgroundWorker();
            this.checkedListBoxMain = new System.Windows.Forms.CheckedListBox();
            this.backWorkerGetVoaUrls = new System.ComponentModel.BackgroundWorker();
            this.backWorkerDownloadFiles = new System.ComponentModel.BackgroundWorker();
            this.menuStrip.SuspendLayout();
            this.statusStrip.SuspendLayout();
            this.panelFormMainButton.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStripMenuItemConfig
            // 
            this.toolStripMenuItemConfig.Name = "toolStripMenuItemConfig";
            resources.ApplyResources(this.toolStripMenuItemConfig, "toolStripMenuItemConfig");
            this.toolStripMenuItemConfig.Click += new System.EventHandler(this.toolStripMenuItemConfig_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            resources.ApplyResources(this.helpToolStripMenuItem, "helpToolStripMenuItem");
            this.helpToolStripMenuItem.Click += new System.EventHandler(this.helpToolStripMenuItem_Click);
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            resources.ApplyResources(this.aboutToolStripMenuItem, "aboutToolStripMenuItem");
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // menuStrip
            // 
            this.menuStrip.BackColor = System.Drawing.SystemColors.MenuBar;
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItemConfig,
            this.helpToolStripMenuItem,
            this.aboutToolStripMenuItem});
            resources.ApplyResources(this.menuStrip, "menuStrip");
            this.menuStrip.Name = "menuStrip";
            // 
            // statusStrip
            // 
            this.statusStrip.BackColor = System.Drawing.SystemColors.MenuBar;
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabelTitle,
            this.toolStripStatus,
            this.toolStripStatusLabelTitleProcess,
            this.toolStripProgressBar});
            resources.ApplyResources(this.statusStrip, "statusStrip");
            this.statusStrip.Name = "statusStrip";
            // 
            // toolStripLabelTitle
            // 
            this.toolStripLabelTitle.Name = "toolStripLabelTitle";
            resources.ApplyResources(this.toolStripLabelTitle, "toolStripLabelTitle");
            // 
            // toolStripStatus
            // 
            resources.ApplyResources(this.toolStripStatus, "toolStripStatus");
            this.toolStripStatus.Name = "toolStripStatus";
            // 
            // toolStripStatusLabelTitleProcess
            // 
            this.toolStripStatusLabelTitleProcess.Name = "toolStripStatusLabelTitleProcess";
            resources.ApplyResources(this.toolStripStatusLabelTitleProcess, "toolStripStatusLabelTitleProcess");
            // 
            // toolStripProgressBar
            // 
            this.toolStripProgressBar.Name = "toolStripProgressBar";
            resources.ApplyResources(this.toolStripProgressBar, "toolStripProgressBar");
            // 
            // panelFormMainButton
            // 
            this.panelFormMainButton.Controls.Add(this.buttonCancelDownload);
            this.panelFormMainButton.Controls.Add(this.richTextBox1);
            this.panelFormMainButton.Controls.Add(this.buttonFresh);
            this.panelFormMainButton.Controls.Add(this.buttonSelectAll);
            this.panelFormMainButton.Controls.Add(this.buttonSelectFirst20);
            this.panelFormMainButton.Controls.Add(this.buttonDownload);
            this.panelFormMainButton.Controls.Add(this.buttonSelectNone);
            resources.ApplyResources(this.panelFormMainButton, "panelFormMainButton");
            this.panelFormMainButton.Name = "panelFormMainButton";
            // 
            // buttonCancelDownload
            // 
            resources.ApplyResources(this.buttonCancelDownload, "buttonCancelDownload");
            this.buttonCancelDownload.Name = "buttonCancelDownload";
            this.buttonCancelDownload.UseVisualStyleBackColor = true;
            this.buttonCancelDownload.Click += new System.EventHandler(this.buttonCancelDownload_Click);
            // 
            // richTextBox1
            // 
            resources.ApplyResources(this.richTextBox1, "richTextBox1");
            this.richTextBox1.Name = "richTextBox1";
            // 
            // buttonFresh
            // 
            resources.ApplyResources(this.buttonFresh, "buttonFresh");
            this.buttonFresh.Name = "buttonFresh";
            this.buttonFresh.UseVisualStyleBackColor = true;
            this.buttonFresh.Click += new System.EventHandler(this.buttonFresh_Click);
            // 
            // buttonSelectAll
            // 
            resources.ApplyResources(this.buttonSelectAll, "buttonSelectAll");
            this.buttonSelectAll.Name = "buttonSelectAll";
            this.buttonSelectAll.UseVisualStyleBackColor = true;
            this.buttonSelectAll.Click += new System.EventHandler(this.buttonSelectAll_Click);
            // 
            // buttonSelectFirst20
            // 
            resources.ApplyResources(this.buttonSelectFirst20, "buttonSelectFirst20");
            this.buttonSelectFirst20.Name = "buttonSelectFirst20";
            this.buttonSelectFirst20.UseVisualStyleBackColor = true;
            this.buttonSelectFirst20.Click += new System.EventHandler(this.buttonSelectFirst20_Click);
            // 
            // buttonDownload
            // 
            resources.ApplyResources(this.buttonDownload, "buttonDownload");
            this.buttonDownload.Name = "buttonDownload";
            this.buttonDownload.UseVisualStyleBackColor = true;
            this.buttonDownload.Click += new System.EventHandler(this.buttonDownload_Click);
            // 
            // buttonSelectNone
            // 
            resources.ApplyResources(this.buttonSelectNone, "buttonSelectNone");
            this.buttonSelectNone.Name = "buttonSelectNone";
            this.buttonSelectNone.UseVisualStyleBackColor = true;
            this.buttonSelectNone.Click += new System.EventHandler(this.buttonSelectNone_Click);
            // 
            // backWorkerGetVoaList
            // 
            this.backWorkerGetVoaList.WorkerReportsProgress = true;
            this.backWorkerGetVoaList.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backWorkerGetVoaList_DoWork);
            this.backWorkerGetVoaList.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.backWorkerGetVoaList_ProgressChanged);
            this.backWorkerGetVoaList.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backWorkerGetVoaList_RunWorkerCompleted);
            // 
            // checkedListBoxMain
            // 
            this.checkedListBoxMain.CheckOnClick = true;
            this.checkedListBoxMain.FormattingEnabled = true;
            resources.ApplyResources(this.checkedListBoxMain, "checkedListBoxMain");
            this.checkedListBoxMain.Name = "checkedListBoxMain";
            // 
            // backWorkerGetVoaUrls
            // 
            this.backWorkerGetVoaUrls.WorkerReportsProgress = true;
            this.backWorkerGetVoaUrls.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backWorkerGetVoaUrls_DoWork);
            this.backWorkerGetVoaUrls.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.backWorkerGetVoaUrls_ProgressChanged);
            this.backWorkerGetVoaUrls.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backWorkerGetVoaUrls_RunWorkerCompleted);
            // 
            // backWorkerDownloadFiles
            // 
            this.backWorkerDownloadFiles.WorkerReportsProgress = true;
            this.backWorkerDownloadFiles.WorkerSupportsCancellation = true;
            this.backWorkerDownloadFiles.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backWorkerDownloadFiles_DoWork);
            this.backWorkerDownloadFiles.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.backWorkerDownloadFiles_ProgressChanged);
            this.backWorkerDownloadFiles.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backWorkerDownloadFiles_RunWorkerCompleted);
            // 
            // la
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panelFormMainButton);
            this.Controls.Add(this.checkedListBoxMain);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.menuStrip);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MainMenuStrip = this.menuStrip;
            this.MaximizeBox = false;
            this.Name = "la";
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.panelFormMainButton.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemConfig;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel toolStripLabelTitle;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatus;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabelTitleProcess;
        private System.Windows.Forms.ToolStripProgressBar toolStripProgressBar;
        private System.Windows.Forms.Panel panelFormMainButton;
        private System.Windows.Forms.Button buttonSelectAll;
        private System.Windows.Forms.Button buttonSelectFirst20;
        private System.Windows.Forms.Button buttonDownload;
        private System.Windows.Forms.Button buttonSelectNone;
        private System.ComponentModel.BackgroundWorker backWorkerGetVoaList;
        private System.Windows.Forms.Button buttonFresh;
        private System.Windows.Forms.CheckedListBox checkedListBoxMain;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.ComponentModel.BackgroundWorker backWorkerGetVoaUrls;
        private System.ComponentModel.BackgroundWorker backWorkerDownloadFiles;
        private System.Windows.Forms.Button buttonCancelDownload;
    }
}

