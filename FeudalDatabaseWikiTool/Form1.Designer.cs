namespace FeudalDatabaseWikiTool
{
    partial class Form1
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
            this.components = new System.ComponentModel.Container();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.lblFilter = new System.Windows.Forms.Label();
            this.tbxFilter = new System.Windows.Forms.TextBox();
            this.dgvDatabase = new System.Windows.Forms.DataGridView();
            this.btnBrowseFolder = new System.Windows.Forms.Button();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.lblBrowseFolder = new System.Windows.Forms.Label();
            this.lblBrowsePath = new System.Windows.Forms.Label();
            this.cmsRightClick = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.cmsRightClickCopy = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.cmsRightClickItemTemplate = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsRightClickBuildingTemplate = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDatabase)).BeginInit();
            this.cmsRightClick.SuspendLayout();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox1.Location = new System.Drawing.Point(3, 3);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBox1.Size = new System.Drawing.Size(410, 457);
            this.textBox1.TabIndex = 2;
            this.textBox1.WordWrap = false;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer1.Location = new System.Drawing.Point(12, 41);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.lblFilter);
            this.splitContainer1.Panel1.Controls.Add(this.tbxFilter);
            this.splitContainer1.Panel1.Controls.Add(this.dgvDatabase);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.textBox1);
            this.splitContainer1.Size = new System.Drawing.Size(630, 463);
            this.splitContainer1.SplitterDistance = 210;
            this.splitContainer1.TabIndex = 3;
            // 
            // lblFilter
            // 
            this.lblFilter.AutoSize = true;
            this.lblFilter.Location = new System.Drawing.Point(3, 6);
            this.lblFilter.Name = "lblFilter";
            this.lblFilter.Size = new System.Drawing.Size(32, 13);
            this.lblFilter.TabIndex = 3;
            this.lblFilter.Text = "Filter:";
            // 
            // tbxFilter
            // 
            this.tbxFilter.Location = new System.Drawing.Point(41, 3);
            this.tbxFilter.Name = "tbxFilter";
            this.tbxFilter.Size = new System.Drawing.Size(166, 20);
            this.tbxFilter.TabIndex = 4;
            this.tbxFilter.TextChanged += new System.EventHandler(this.tbxFilter_TextChanged);
            // 
            // dgvDatabase
            // 
            this.dgvDatabase.AllowUserToAddRows = false;
            this.dgvDatabase.AllowUserToDeleteRows = false;
            this.dgvDatabase.AllowUserToOrderColumns = true;
            this.dgvDatabase.AllowUserToResizeRows = false;
            this.dgvDatabase.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvDatabase.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvDatabase.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvDatabase.Location = new System.Drawing.Point(3, 29);
            this.dgvDatabase.Name = "dgvDatabase";
            this.dgvDatabase.ReadOnly = true;
            this.dgvDatabase.RowHeadersVisible = false;
            this.dgvDatabase.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dgvDatabase.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDatabase.Size = new System.Drawing.Size(204, 431);
            this.dgvDatabase.StandardTab = true;
            this.dgvDatabase.TabIndex = 3;
            this.dgvDatabase.CellMouseDown += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvDatabase_CellMouseDown);
            this.dgvDatabase.SortCompare += new System.Windows.Forms.DataGridViewSortCompareEventHandler(this.dgvDatabase_SortCompare);
            this.dgvDatabase.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dgvDatabase_KeyDown);
            // 
            // btnBrowseFolder
            // 
            this.btnBrowseFolder.Location = new System.Drawing.Point(12, 12);
            this.btnBrowseFolder.Name = "btnBrowseFolder";
            this.btnBrowseFolder.Size = new System.Drawing.Size(75, 23);
            this.btnBrowseFolder.TabIndex = 4;
            this.btnBrowseFolder.Text = "Browse...";
            this.btnBrowseFolder.UseVisualStyleBackColor = true;
            this.btnBrowseFolder.Click += new System.EventHandler(this.btnBrowseFolder_Click);
            // 
            // folderBrowserDialog1
            // 
            this.folderBrowserDialog1.RootFolder = System.Environment.SpecialFolder.MyComputer;
            this.folderBrowserDialog1.ShowNewFolderButton = false;
            // 
            // lblBrowseFolder
            // 
            this.lblBrowseFolder.AutoSize = true;
            this.lblBrowseFolder.Location = new System.Drawing.Point(93, 17);
            this.lblBrowseFolder.Name = "lblBrowseFolder";
            this.lblBrowseFolder.Size = new System.Drawing.Size(135, 13);
            this.lblBrowseFolder.TabIndex = 5;
            this.lblBrowseFolder.Text = "Life is Feudal Game Folder:";
            // 
            // lblBrowsePath
            // 
            this.lblBrowsePath.AutoSize = true;
            this.lblBrowsePath.Location = new System.Drawing.Point(234, 17);
            this.lblBrowsePath.Name = "lblBrowsePath";
            this.lblBrowsePath.Size = new System.Drawing.Size(16, 13);
            this.lblBrowsePath.TabIndex = 5;
            this.lblBrowsePath.Text = "...";
            // 
            // cmsRightClick
            // 
            this.cmsRightClick.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cmsRightClickCopy,
            this.toolStripSeparator1,
            this.cmsRightClickItemTemplate,
            this.cmsRightClickBuildingTemplate});
            this.cmsRightClick.Name = "cmsRightClick";
            this.cmsRightClick.Size = new System.Drawing.Size(208, 76);
            this.cmsRightClick.Opening += new System.ComponentModel.CancelEventHandler(this.cmsRightClick_Opening);
            // 
            // cmsRightClickCopy
            // 
            this.cmsRightClickCopy.Name = "cmsRightClickCopy";
            this.cmsRightClickCopy.Size = new System.Drawing.Size(207, 22);
            this.cmsRightClickCopy.Text = "Copy";
            this.cmsRightClickCopy.Click += new System.EventHandler(this.cmsRightClickCopy_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(204, 6);
            // 
            // cmsRightClickItemTemplate
            // 
            this.cmsRightClickItemTemplate.Name = "cmsRightClickItemTemplate";
            this.cmsRightClickItemTemplate.Size = new System.Drawing.Size(207, 22);
            this.cmsRightClickItemTemplate.Text = "Create Item Template";
            this.cmsRightClickItemTemplate.Click += new System.EventHandler(this.cmsRightClickItemTemplate_Click);
            // 
            // cmsRightClickBuildingTemplate
            // 
            this.cmsRightClickBuildingTemplate.Name = "cmsRightClickBuildingTemplate";
            this.cmsRightClickBuildingTemplate.Size = new System.Drawing.Size(207, 22);
            this.cmsRightClickBuildingTemplate.Text = "Create Building Template";
            this.cmsRightClickBuildingTemplate.Click += new System.EventHandler(this.cmsRightClickBuildingTemplate_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(654, 516);
            this.Controls.Add(this.lblBrowsePath);
            this.Controls.Add(this.lblBrowseFolder);
            this.Controls.Add(this.btnBrowseFolder);
            this.Controls.Add(this.splitContainer1);
            this.Name = "Form1";
            this.Text = "FeudalDatabaseWikiTool";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDatabase)).EndInit();
            this.cmsRightClick.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Button btnBrowseFolder;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.Label lblBrowseFolder;
        private System.Windows.Forms.Label lblBrowsePath;
        private System.Windows.Forms.DataGridView dgvDatabase;
        private System.Windows.Forms.ContextMenuStrip cmsRightClick;
        private System.Windows.Forms.ToolStripMenuItem cmsRightClickCopy;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem cmsRightClickItemTemplate;
        private System.Windows.Forms.ToolStripMenuItem cmsRightClickBuildingTemplate;
        private System.Windows.Forms.Label lblFilter;
        private System.Windows.Forms.TextBox tbxFilter;
    }
}

