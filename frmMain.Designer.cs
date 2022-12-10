namespace WARCFileViewer
{
    partial class frmMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.tsMenuBar = new System.Windows.Forms.ToolStrip();
            this.tsFile = new System.Windows.Forms.ToolStripDropDownButton();
            this.tsFileOpen = new System.Windows.Forms.ToolStripMenuItem();
            this.tsExtractCurrenSelect = new System.Windows.Forms.ToolStripMenuItem();
            this.tsExtractAllSelected = new System.Windows.Forms.ToolStripMenuItem();
            this.tsExtractAll = new System.Windows.Forms.ToolStripMenuItem();
            this.dtgResult = new System.Windows.Forms.DataGridView();
            this.lblFileContents = new System.Windows.Forms.Label();
            this.bgwParseFile = new System.ComponentModel.BackgroundWorker();
            this.pictItem = new System.Windows.Forms.PictureBox();
            this.grpFileInfo = new System.Windows.Forms.GroupBox();
            this.tbcProperties = new System.Windows.Forms.TabControl();
            this.tpFileProperties = new System.Windows.Forms.TabPage();
            this.tpWarcHeaders = new System.Windows.Forms.TabPage();
            this.tpHttpHeaders = new System.Windows.Forms.TabPage();
            this.lblNoPreview = new System.Windows.Forms.Label();
            this.fdbExportLocation = new System.Windows.Forms.FolderBrowserDialog();
            this.prgProgress = new System.Windows.Forms.ProgressBar();
            this.lblProgressInfo = new System.Windows.Forms.Label();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.lblSearch = new System.Windows.Forms.Label();
            this.lblFilter = new System.Windows.Forms.Label();
            this.chbxWebpages = new System.Windows.Forms.CheckBox();
            this.chbxImages = new System.Windows.Forms.CheckBox();
            this.chbxAll = new System.Windows.Forms.CheckBox();
            this.chbxAudio = new System.Windows.Forms.CheckBox();
            this.chbxVideo = new System.Windows.Forms.CheckBox();
            this.chbxCustom = new System.Windows.Forms.CheckBox();
            this.txtCustom = new System.Windows.Forms.TextBox();
            this.sfdCurrentFile = new System.Windows.Forms.SaveFileDialog();
            this.bgwExportItems = new System.ComponentModel.BackgroundWorker();
            this.lblFileInfo = new System.Windows.Forms.Label();
            this.tsMenuBar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgResult)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictItem)).BeginInit();
            this.grpFileInfo.SuspendLayout();
            this.tbcProperties.SuspendLayout();
            this.tpFileProperties.SuspendLayout();
            this.SuspendLayout();
            // 
            // tsMenuBar
            // 
            this.tsMenuBar.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.tsMenuBar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsFile});
            this.tsMenuBar.Location = new System.Drawing.Point(0, 0);
            this.tsMenuBar.Name = "tsMenuBar";
            this.tsMenuBar.Size = new System.Drawing.Size(1712, 27);
            this.tsMenuBar.TabIndex = 0;
            this.tsMenuBar.Text = "toolStrip1";
            // 
            // tsFile
            // 
            this.tsFile.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsFileOpen,
            this.tsExtractCurrenSelect,
            this.tsExtractAllSelected,
            this.tsExtractAll});
            this.tsFile.Image = ((System.Drawing.Image)(resources.GetObject("tsFile.Image")));
            this.tsFile.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsFile.Name = "tsFile";
            this.tsFile.Size = new System.Drawing.Size(46, 24);
            this.tsFile.Text = "File";
            // 
            // tsFileOpen
            // 
            this.tsFileOpen.Name = "tsFileOpen";
            this.tsFileOpen.Size = new System.Drawing.Size(300, 26);
            this.tsFileOpen.Text = "Open...";
            this.tsFileOpen.Click += new System.EventHandler(this.tsFileOpen_Click);
            // 
            // tsExtractCurrenSelect
            // 
            this.tsExtractCurrenSelect.Name = "tsExtractCurrenSelect";
            this.tsExtractCurrenSelect.Size = new System.Drawing.Size(300, 26);
            this.tsExtractCurrenSelect.Text = "Extract currently selected item...";
            this.tsExtractCurrenSelect.Click += new System.EventHandler(this.tsExtractCurrenSelect_Click);
            // 
            // tsExtractAllSelected
            // 
            this.tsExtractAllSelected.Name = "tsExtractAllSelected";
            this.tsExtractAllSelected.Size = new System.Drawing.Size(300, 26);
            this.tsExtractAllSelected.Text = "Extract all selected items...";
            this.tsExtractAllSelected.Click += new System.EventHandler(this.tsExtractAllSelected_Click);
            // 
            // tsExtractAll
            // 
            this.tsExtractAll.Name = "tsExtractAll";
            this.tsExtractAll.Size = new System.Drawing.Size(300, 26);
            this.tsExtractAll.Text = "Extract all...";
            this.tsExtractAll.Click += new System.EventHandler(this.tsExtractAll_Click);
            // 
            // dtgResult
            // 
            this.dtgResult.AllowUserToAddRows = false;
            this.dtgResult.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dtgResult.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgResult.Location = new System.Drawing.Point(13, 94);
            this.dtgResult.Name = "dtgResult";
            this.dtgResult.RowHeadersWidth = 51;
            this.dtgResult.RowTemplate.Height = 24;
            this.dtgResult.Size = new System.Drawing.Size(1234, 723);
            this.dtgResult.TabIndex = 1;
            this.dtgResult.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgResult_CellContentClick);
            this.dtgResult.SelectionChanged += new System.EventHandler(this.dtgResult_SelectionChanged);
            this.dtgResult.KeyUp += new System.Windows.Forms.KeyEventHandler(this.dtgResult_KeyUp);
            // 
            // lblFileContents
            // 
            this.lblFileContents.AutoSize = true;
            this.lblFileContents.Location = new System.Drawing.Point(12, 74);
            this.lblFileContents.Name = "lblFileContents";
            this.lblFileContents.Size = new System.Drawing.Size(117, 17);
            this.lblFileContents.TabIndex = 2;
            this.lblFileContents.Text = "Archive contents:";
            // 
            // bgwParseFile
            // 
            this.bgwParseFile.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgwParseFile_DoWork);
            this.bgwParseFile.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgwParseFile_RunWorkerCompleted);
            // 
            // pictItem
            // 
            this.pictItem.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pictItem.Location = new System.Drawing.Point(1254, 27);
            this.pictItem.Name = "pictItem";
            this.pictItem.Size = new System.Drawing.Size(446, 372);
            this.pictItem.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictItem.TabIndex = 6;
            this.pictItem.TabStop = false;
            // 
            // grpFileInfo
            // 
            this.grpFileInfo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.grpFileInfo.Controls.Add(this.tbcProperties);
            this.grpFileInfo.Location = new System.Drawing.Point(1254, 410);
            this.grpFileInfo.Name = "grpFileInfo";
            this.grpFileInfo.Size = new System.Drawing.Size(446, 407);
            this.grpFileInfo.TabIndex = 7;
            this.grpFileInfo.TabStop = false;
            this.grpFileInfo.Text = "File info";
            // 
            // tbcProperties
            // 
            this.tbcProperties.Controls.Add(this.tpFileProperties);
            this.tbcProperties.Controls.Add(this.tpWarcHeaders);
            this.tbcProperties.Controls.Add(this.tpHttpHeaders);
            this.tbcProperties.Location = new System.Drawing.Point(12, 27);
            this.tbcProperties.Name = "tbcProperties";
            this.tbcProperties.SelectedIndex = 0;
            this.tbcProperties.Size = new System.Drawing.Size(434, 374);
            this.tbcProperties.TabIndex = 1;
            // 
            // tpFileProperties
            // 
            this.tpFileProperties.Controls.Add(this.lblFileInfo);
            this.tpFileProperties.Location = new System.Drawing.Point(4, 25);
            this.tpFileProperties.Name = "tpFileProperties";
            this.tpFileProperties.Padding = new System.Windows.Forms.Padding(3);
            this.tpFileProperties.Size = new System.Drawing.Size(426, 345);
            this.tpFileProperties.TabIndex = 0;
            this.tpFileProperties.Text = "File properties";
            this.tpFileProperties.UseVisualStyleBackColor = true;
            // 
            // tpWarcHeaders
            // 
            this.tpWarcHeaders.Location = new System.Drawing.Point(4, 25);
            this.tpWarcHeaders.Name = "tpWarcHeaders";
            this.tpWarcHeaders.Padding = new System.Windows.Forms.Padding(3);
            this.tpWarcHeaders.Size = new System.Drawing.Size(426, 345);
            this.tpWarcHeaders.TabIndex = 1;
            this.tpWarcHeaders.Text = "WARC Headers";
            this.tpWarcHeaders.UseVisualStyleBackColor = true;
            // 
            // tpHttpHeaders
            // 
            this.tpHttpHeaders.Location = new System.Drawing.Point(4, 25);
            this.tpHttpHeaders.Name = "tpHttpHeaders";
            this.tpHttpHeaders.Size = new System.Drawing.Size(426, 345);
            this.tpHttpHeaders.TabIndex = 2;
            this.tpHttpHeaders.Text = "HTTP Headers";
            this.tpHttpHeaders.UseVisualStyleBackColor = true;
            // 
            // lblNoPreview
            // 
            this.lblNoPreview.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblNoPreview.AutoSize = true;
            this.lblNoPreview.Location = new System.Drawing.Point(1393, 210);
            this.lblNoPreview.Name = "lblNoPreview";
            this.lblNoPreview.Size = new System.Drawing.Size(138, 17);
            this.lblNoPreview.TabIndex = 8;
            this.lblNoPreview.Text = "No preview available";
            // 
            // prgProgress
            // 
            this.prgProgress.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.prgProgress.Location = new System.Drawing.Point(12, 823);
            this.prgProgress.Name = "prgProgress";
            this.prgProgress.Size = new System.Drawing.Size(1417, 23);
            this.prgProgress.TabIndex = 11;
            this.prgProgress.Visible = false;
            // 
            // lblProgressInfo
            // 
            this.lblProgressInfo.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblProgressInfo.AutoSize = true;
            this.lblProgressInfo.Location = new System.Drawing.Point(1435, 823);
            this.lblProgressInfo.Name = "lblProgressInfo";
            this.lblProgressInfo.Size = new System.Drawing.Size(0, 17);
            this.lblProgressInfo.TabIndex = 12;
            // 
            // txtSearch
            // 
            this.txtSearch.Location = new System.Drawing.Point(1074, 27);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(173, 22);
            this.txtSearch.TabIndex = 13;
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
            // 
            // lblSearch
            // 
            this.lblSearch.AutoSize = true;
            this.lblSearch.Location = new System.Drawing.Point(1016, 33);
            this.lblSearch.Name = "lblSearch";
            this.lblSearch.Size = new System.Drawing.Size(57, 17);
            this.lblSearch.TabIndex = 14;
            this.lblSearch.Text = "Search:";
            // 
            // lblFilter
            // 
            this.lblFilter.AutoSize = true;
            this.lblFilter.Location = new System.Drawing.Point(12, 32);
            this.lblFilter.Name = "lblFilter";
            this.lblFilter.Size = new System.Drawing.Size(51, 17);
            this.lblFilter.TabIndex = 15;
            this.lblFilter.Text = "Select:";
            // 
            // chbxWebpages
            // 
            this.chbxWebpages.AutoSize = true;
            this.chbxWebpages.Location = new System.Drawing.Point(346, 31);
            this.chbxWebpages.Name = "chbxWebpages";
            this.chbxWebpages.Size = new System.Drawing.Size(98, 21);
            this.chbxWebpages.TabIndex = 16;
            this.chbxWebpages.Text = "Webpages";
            this.chbxWebpages.UseVisualStyleBackColor = true;
            // 
            // chbxImages
            // 
            this.chbxImages.AutoSize = true;
            this.chbxImages.Location = new System.Drawing.Point(193, 32);
            this.chbxImages.Name = "chbxImages";
            this.chbxImages.Size = new System.Drawing.Size(75, 21);
            this.chbxImages.TabIndex = 17;
            this.chbxImages.Text = "Images";
            this.chbxImages.UseVisualStyleBackColor = true;
            // 
            // chbxAll
            // 
            this.chbxAll.AutoSize = true;
            this.chbxAll.Location = new System.Drawing.Point(70, 32);
            this.chbxAll.Name = "chbxAll";
            this.chbxAll.Size = new System.Drawing.Size(45, 21);
            this.chbxAll.TabIndex = 18;
            this.chbxAll.Text = "All";
            this.chbxAll.UseVisualStyleBackColor = true;
            this.chbxAll.CheckedChanged += new System.EventHandler(this.chbxAll_CheckedChanged);
            // 
            // chbxAudio
            // 
            this.chbxAudio.AutoSize = true;
            this.chbxAudio.Location = new System.Drawing.Point(121, 32);
            this.chbxAudio.Name = "chbxAudio";
            this.chbxAudio.Size = new System.Drawing.Size(66, 21);
            this.chbxAudio.TabIndex = 19;
            this.chbxAudio.Text = "Audio";
            this.chbxAudio.UseVisualStyleBackColor = true;
            // 
            // chbxVideo
            // 
            this.chbxVideo.AutoSize = true;
            this.chbxVideo.Location = new System.Drawing.Point(274, 32);
            this.chbxVideo.Name = "chbxVideo";
            this.chbxVideo.Size = new System.Drawing.Size(66, 21);
            this.chbxVideo.TabIndex = 20;
            this.chbxVideo.Text = "Video";
            this.chbxVideo.UseVisualStyleBackColor = true;
            // 
            // chbxCustom
            // 
            this.chbxCustom.AutoSize = true;
            this.chbxCustom.Location = new System.Drawing.Point(451, 31);
            this.chbxCustom.Name = "chbxCustom";
            this.chbxCustom.Size = new System.Drawing.Size(81, 21);
            this.chbxCustom.TabIndex = 21;
            this.chbxCustom.Text = "Custom:";
            this.chbxCustom.UseVisualStyleBackColor = true;
            // 
            // txtCustom
            // 
            this.txtCustom.Enabled = false;
            this.txtCustom.Location = new System.Drawing.Point(538, 30);
            this.txtCustom.Name = "txtCustom";
            this.txtCustom.Size = new System.Drawing.Size(143, 22);
            this.txtCustom.TabIndex = 22;
            this.txtCustom.Text = "Enter mimetype";
            // 
            // bgwExportItems
            // 
            this.bgwExportItems.WorkerReportsProgress = true;
            this.bgwExportItems.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgwExportItems_DoWork);
            this.bgwExportItems.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.bgwExportItems_ProgressChanged);
            this.bgwExportItems.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgwExportItems_RunWorkerCompleted);
            // 
            // lblFileInfo
            // 
            this.lblFileInfo.AutoSize = true;
            this.lblFileInfo.Location = new System.Drawing.Point(16, 12);
            this.lblFileInfo.Name = "lblFileInfo";
            this.lblFileInfo.Size = new System.Drawing.Size(0, 17);
            this.lblFileInfo.TabIndex = 23;
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1712, 858);
            this.Controls.Add(this.txtCustom);
            this.Controls.Add(this.chbxCustom);
            this.Controls.Add(this.chbxVideo);
            this.Controls.Add(this.chbxAudio);
            this.Controls.Add(this.chbxAll);
            this.Controls.Add(this.chbxImages);
            this.Controls.Add(this.chbxWebpages);
            this.Controls.Add(this.lblFilter);
            this.Controls.Add(this.lblSearch);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.lblProgressInfo);
            this.Controls.Add(this.prgProgress);
            this.Controls.Add(this.lblNoPreview);
            this.Controls.Add(this.grpFileInfo);
            this.Controls.Add(this.pictItem);
            this.Controls.Add(this.lblFileContents);
            this.Controls.Add(this.dtgResult);
            this.Controls.Add(this.tsMenuBar);
            this.KeyPreview = true;
            this.Name = "frmMain";
            this.Text = "WARC File Viewer";
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmMain_KeyDown);
            this.tsMenuBar.ResumeLayout(false);
            this.tsMenuBar.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgResult)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictItem)).EndInit();
            this.grpFileInfo.ResumeLayout(false);
            this.tbcProperties.ResumeLayout(false);
            this.tpFileProperties.ResumeLayout(false);
            this.tpFileProperties.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip tsMenuBar;
        private System.Windows.Forms.ToolStripDropDownButton tsFile;
        private System.Windows.Forms.ToolStripMenuItem tsFileOpen;
        private System.Windows.Forms.DataGridView dtgResult;
        private System.Windows.Forms.Label lblFileContents;
        private System.ComponentModel.BackgroundWorker bgwParseFile;
        private System.Windows.Forms.PictureBox pictItem;
        private System.Windows.Forms.GroupBox grpFileInfo;
        private System.Windows.Forms.Label lblNoPreview;
        private System.Windows.Forms.FolderBrowserDialog fdbExportLocation;
        private System.Windows.Forms.ProgressBar prgProgress;
        private System.Windows.Forms.Label lblProgressInfo;
        private System.Windows.Forms.TabControl tbcProperties;
        private System.Windows.Forms.TabPage tpFileProperties;
        private System.Windows.Forms.TabPage tpWarcHeaders;
        private System.Windows.Forms.TabPage tpHttpHeaders;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Label lblSearch;
        private System.Windows.Forms.Label lblFilter;
        private System.Windows.Forms.CheckBox chbxWebpages;
        private System.Windows.Forms.CheckBox chbxImages;
        private System.Windows.Forms.CheckBox chbxAll;
        private System.Windows.Forms.CheckBox chbxAudio;
        private System.Windows.Forms.CheckBox chbxVideo;
        private System.Windows.Forms.CheckBox chbxCustom;
        private System.Windows.Forms.TextBox txtCustom;
        private System.Windows.Forms.ToolStripMenuItem tsExtractCurrenSelect;
        private System.Windows.Forms.ToolStripMenuItem tsExtractAllSelected;
        private System.Windows.Forms.ToolStripMenuItem tsExtractAll;
        private System.Windows.Forms.SaveFileDialog sfdCurrentFile;
        private System.ComponentModel.BackgroundWorker bgwExportItems;
        private System.Windows.Forms.Label lblFileInfo;
    }
}

