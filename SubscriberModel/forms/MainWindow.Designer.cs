namespace OntologyEditor
{
    partial class MainWindow
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.newMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openRecentMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.saveMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.makeCopyMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.quitMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.toolsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.insStdClassesMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editorsMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.formsMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.testEditorMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.actionEditorMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.diagnosisEditorMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.treatmentsEditorMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.clientPreviewMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileMenu,
            this.editMenu,
            this.toolsToolStripMenuItem,
            this.editorsMenu});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1020, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileMenu
            // 
            this.fileMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newMenuItem,
            this.openMenuItem,
            this.openRecentMenu,
            this.toolStripSeparator1,
            this.saveMenuItem,
            this.makeCopyMenuItem,
            this.toolStripSeparator2,
            this.quitMenuItem});
            this.fileMenu.Name = "fileMenu";
            this.fileMenu.Size = new System.Drawing.Size(37, 20);
            this.fileMenu.Text = "File";
            // 
            // newMenuItem
            // 
            this.newMenuItem.Name = "newMenuItem";
            this.newMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N)));
            this.newMenuItem.Size = new System.Drawing.Size(198, 22);
            this.newMenuItem.Text = "&New ontology";
            this.newMenuItem.Click += new System.EventHandler(this.newMenuItem_Click);
            // 
            // openMenuItem
            // 
            this.openMenuItem.Name = "openMenuItem";
            this.openMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.openMenuItem.Size = new System.Drawing.Size(198, 22);
            this.openMenuItem.Text = "&Open";
            this.openMenuItem.Click += new System.EventHandler(this.openMenuItem_Click);
            // 
            // openRecentMenu
            // 
            this.openRecentMenu.Name = "openRecentMenu";
            this.openRecentMenu.Size = new System.Drawing.Size(198, 22);
            this.openRecentMenu.Text = "Open recent";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(195, 6);
            // 
            // saveMenuItem
            // 
            this.saveMenuItem.Name = "saveMenuItem";
            this.saveMenuItem.ShortcutKeyDisplayString = "Ctrl+S";
            this.saveMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.saveMenuItem.Size = new System.Drawing.Size(198, 22);
            this.saveMenuItem.Text = "&Save";
            this.saveMenuItem.Click += new System.EventHandler(this.saveMenuItem_Click);
            // 
            // makeCopyMenuItem
            // 
            this.makeCopyMenuItem.Name = "makeCopyMenuItem";
            this.makeCopyMenuItem.ShortcutKeyDisplayString = "Ctrl-Shift-S";
            this.makeCopyMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.S)));
            this.makeCopyMenuItem.Size = new System.Drawing.Size(198, 22);
            this.makeCopyMenuItem.Text = "Make copy";
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(195, 6);
            // 
            // quitMenuItem
            // 
            this.quitMenuItem.Name = "quitMenuItem";
            this.quitMenuItem.ShortcutKeyDisplayString = "Ctrl+Q";
            this.quitMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Q)));
            this.quitMenuItem.Size = new System.Drawing.Size(198, 22);
            this.quitMenuItem.Text = "&Quit";
            this.quitMenuItem.Click += new System.EventHandler(this.quitMenuItem_Click);
            // 
            // editMenu
            // 
            this.editMenu.Name = "editMenu";
            this.editMenu.Size = new System.Drawing.Size(39, 20);
            this.editMenu.Text = "Edit";
            // 
            // toolsToolStripMenuItem
            // 
            this.toolsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.insStdClassesMenuItem});
            this.toolsToolStripMenuItem.Name = "toolsToolStripMenuItem";
            this.toolsToolStripMenuItem.Size = new System.Drawing.Size(47, 20);
            this.toolsToolStripMenuItem.Text = "Tools";
            // 
            // insStdClassesMenuItem
            // 
            this.insStdClassesMenuItem.Name = "insStdClassesMenuItem";
            this.insStdClassesMenuItem.Size = new System.Drawing.Size(191, 22);
            this.insStdClassesMenuItem.Text = "Insert standard classes";
            this.insStdClassesMenuItem.Click += new System.EventHandler(this.insStdClassesMenuItem_Click);
            // 
            // editorsMenu
            // 
            this.editorsMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.formsMenuItem,
            this.testEditorMenuItem,
            this.actionEditorMenuItem,
            this.diagnosisEditorMenuItem,
            this.treatmentsEditorMenuItem,
            this.toolStripSeparator3,
            this.clientPreviewMenuItem});
            this.editorsMenu.Name = "editorsMenu";
            this.editorsMenu.Size = new System.Drawing.Size(55, 20);
            this.editorsMenu.Text = "Editors";
            // 
            // formsMenuItem
            // 
            this.formsMenuItem.Name = "formsMenuItem";
            this.formsMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.F)));
            this.formsMenuItem.Size = new System.Drawing.Size(222, 22);
            this.formsMenuItem.Text = "Forms";
            this.formsMenuItem.Click += new System.EventHandler(this.formsMenuItem_Click);
            // 
            // testEditorMenuItem
            // 
            this.testEditorMenuItem.Name = "testEditorMenuItem";
            this.testEditorMenuItem.ShortcutKeyDisplayString = "Ctrl+T";
            this.testEditorMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.T)));
            this.testEditorMenuItem.Size = new System.Drawing.Size(222, 22);
            this.testEditorMenuItem.Text = "&Tests";
            this.testEditorMenuItem.Click += new System.EventHandler(this.testEditorMenuItem_Click);
            // 
            // actionEditorMenuItem
            // 
            this.actionEditorMenuItem.Name = "actionEditorMenuItem";
            this.actionEditorMenuItem.ShortcutKeyDisplayString = "Ctrl+A";
            this.actionEditorMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.A)));
            this.actionEditorMenuItem.Size = new System.Drawing.Size(222, 22);
            this.actionEditorMenuItem.Text = "&Actions";
            this.actionEditorMenuItem.Click += new System.EventHandler(this.actionEditorMenuItem_Click);
            // 
            // diagnosisEditorMenuItem
            // 
            this.diagnosisEditorMenuItem.Name = "diagnosisEditorMenuItem";
            this.diagnosisEditorMenuItem.ShortcutKeyDisplayString = "Ctrl+D";
            this.diagnosisEditorMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.D)));
            this.diagnosisEditorMenuItem.Size = new System.Drawing.Size(222, 22);
            this.diagnosisEditorMenuItem.Text = "&Diagnosis";
            // 
            // treatmentsEditorMenuItem
            // 
            this.treatmentsEditorMenuItem.Name = "treatmentsEditorMenuItem";
            this.treatmentsEditorMenuItem.ShortcutKeyDisplayString = "Ctrl+R";
            this.treatmentsEditorMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.R)));
            this.treatmentsEditorMenuItem.Size = new System.Drawing.Size(222, 22);
            this.treatmentsEditorMenuItem.Text = "T&reatments";
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(219, 6);
            // 
            // clientPreviewMenuItem
            // 
            this.clientPreviewMenuItem.Name = "clientPreviewMenuItem";
            this.clientPreviewMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.B)));
            this.clientPreviewMenuItem.Size = new System.Drawing.Size(222, 22);
            this.clientPreviewMenuItem.Text = "Client Preview";
            this.clientPreviewMenuItem.Click += new System.EventHandler(this.clientPreviewMenuItem_Click);
            // 
            // statusStrip
            // 
            this.statusStrip.Location = new System.Drawing.Point(0, 652);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(1020, 22);
            this.statusStrip.TabIndex = 1;
            this.statusStrip.Text = "statusStrip1";
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(1020, 674);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.menuStrip1);
            this.DoubleBuffered = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainWindow";
            this.Text = "CBox Ontology Editor v0.1";
            this.Load += new System.EventHandler(this.MainWindow_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileMenu;
        private System.Windows.Forms.ToolStripMenuItem quitMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editMenu;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripMenuItem saveMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editorsMenu;
        private System.Windows.Forms.ToolStripMenuItem testEditorMenuItem;
        private System.Windows.Forms.ToolStripMenuItem actionEditorMenuItem;
        private System.Windows.Forms.ToolStripMenuItem makeCopyMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem diagnosisEditorMenuItem;
        private System.Windows.Forms.ToolStripMenuItem treatmentsEditorMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem newMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openRecentMenu;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem clientPreviewMenuItem;
        private System.Windows.Forms.ToolStripMenuItem formsMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem insStdClassesMenuItem;
    }
}