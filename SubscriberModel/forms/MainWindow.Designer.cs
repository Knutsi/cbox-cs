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
            this.openMostRecentMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.saveMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.makeCopyMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.exportClientPackageMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exportClientPackagAgainToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.quitMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.toolsMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.serverMenuIItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.indexURLMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.clipackURLMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.randomCaseURLMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.advancedToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
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
            this.testImportMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileMenu,
            this.editMenu,
            this.toolsMenu,
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
            this.openMostRecentMenuItem,
            this.toolStripSeparator1,
            this.saveMenuItem,
            this.makeCopyMenuItem,
            this.toolStripSeparator4,
            this.exportClientPackageMenuItem,
            this.exportClientPackagAgainToolStripMenuItem,
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
            this.newMenuItem.Size = new System.Drawing.Size(244, 22);
            this.newMenuItem.Text = "&New ontology";
            this.newMenuItem.Click += new System.EventHandler(this.newMenuItem_Click);
            // 
            // openMenuItem
            // 
            this.openMenuItem.Name = "openMenuItem";
            this.openMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.openMenuItem.Size = new System.Drawing.Size(244, 22);
            this.openMenuItem.Text = "&Open";
            this.openMenuItem.Click += new System.EventHandler(this.openMenuItem_Click);
            // 
            // openRecentMenu
            // 
            this.openRecentMenu.Name = "openRecentMenu";
            this.openRecentMenu.Size = new System.Drawing.Size(244, 22);
            this.openRecentMenu.Text = "Open recent";
            // 
            // openMostRecentMenuItem
            // 
            this.openMostRecentMenuItem.Name = "openMostRecentMenuItem";
            this.openMostRecentMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.O)));
            this.openMostRecentMenuItem.Size = new System.Drawing.Size(244, 22);
            this.openMostRecentMenuItem.Text = "Open most recent";
            this.openMostRecentMenuItem.Click += new System.EventHandler(this.openMostRecentMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(241, 6);
            // 
            // saveMenuItem
            // 
            this.saveMenuItem.Name = "saveMenuItem";
            this.saveMenuItem.ShortcutKeyDisplayString = "Ctrl+S";
            this.saveMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.saveMenuItem.Size = new System.Drawing.Size(244, 22);
            this.saveMenuItem.Text = "&Save";
            this.saveMenuItem.Click += new System.EventHandler(this.saveMenuItem_Click);
            // 
            // makeCopyMenuItem
            // 
            this.makeCopyMenuItem.Name = "makeCopyMenuItem";
            this.makeCopyMenuItem.ShortcutKeyDisplayString = "Ctrl-Shift-S";
            this.makeCopyMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.S)));
            this.makeCopyMenuItem.Size = new System.Drawing.Size(244, 22);
            this.makeCopyMenuItem.Text = "Make copy";
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(241, 6);
            // 
            // exportClientPackageMenuItem
            // 
            this.exportClientPackageMenuItem.Name = "exportClientPackageMenuItem";
            this.exportClientPackageMenuItem.Size = new System.Drawing.Size(244, 22);
            this.exportClientPackageMenuItem.Text = "Export clipack";
            this.exportClientPackageMenuItem.Click += new System.EventHandler(this.exportClientPackageMenuItem_Click);
            // 
            // exportClientPackagAgainToolStripMenuItem
            // 
            this.exportClientPackagAgainToolStripMenuItem.Name = "exportClientPackagAgainToolStripMenuItem";
            this.exportClientPackagAgainToolStripMenuItem.Size = new System.Drawing.Size(244, 22);
            this.exportClientPackagAgainToolStripMenuItem.Text = "Export clipack again";
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(241, 6);
            // 
            // quitMenuItem
            // 
            this.quitMenuItem.Name = "quitMenuItem";
            this.quitMenuItem.ShortcutKeyDisplayString = "Ctrl+Q";
            this.quitMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Q)));
            this.quitMenuItem.Size = new System.Drawing.Size(244, 22);
            this.quitMenuItem.Text = "&Quit";
            this.quitMenuItem.Click += new System.EventHandler(this.quitMenuItem_Click);
            // 
            // editMenu
            // 
            this.editMenu.Name = "editMenu";
            this.editMenu.Size = new System.Drawing.Size(39, 20);
            this.editMenu.Text = "Edit";
            // 
            // toolsMenu
            // 
            this.toolsMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.serverMenuIItem,
            this.toolStripSeparator5,
            this.indexURLMenuItem,
            this.clipackURLMenuItem,
            this.randomCaseURLMenuItem,
            this.toolStripSeparator6,
            this.advancedToolStripMenuItem});
            this.toolsMenu.Name = "toolsMenu";
            this.toolsMenu.Size = new System.Drawing.Size(47, 20);
            this.toolsMenu.Text = "Tools";
            // 
            // serverMenuIItem
            // 
            this.serverMenuIItem.Name = "serverMenuIItem";
            this.serverMenuIItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.S)));
            this.serverMenuIItem.Size = new System.Drawing.Size(226, 22);
            this.serverMenuIItem.Text = "Internal server";
            this.serverMenuIItem.Click += new System.EventHandler(this.serverMenuIItem_Click);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(223, 6);
            // 
            // indexURLMenuItem
            // 
            this.indexURLMenuItem.Name = "indexURLMenuItem";
            this.indexURLMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F1;
            this.indexURLMenuItem.Size = new System.Drawing.Size(226, 22);
            this.indexURLMenuItem.Text = "/lib/view/play.html";
            this.indexURLMenuItem.Click += new System.EventHandler(this.OpenURLFromMenuItemText);
            // 
            // clipackURLMenuItem
            // 
            this.clipackURLMenuItem.Name = "clipackURLMenuItem";
            this.clipackURLMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F2;
            this.clipackURLMenuItem.Size = new System.Drawing.Size(226, 22);
            this.clipackURLMenuItem.Text = "/asset/dynamic/clipack";
            this.clipackURLMenuItem.Click += new System.EventHandler(this.OpenURLFromMenuItemText);
            // 
            // randomCaseURLMenuItem
            // 
            this.randomCaseURLMenuItem.Name = "randomCaseURLMenuItem";
            this.randomCaseURLMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F3;
            this.randomCaseURLMenuItem.Size = new System.Drawing.Size(226, 22);
            this.randomCaseURLMenuItem.Text = "/asset/dynamic/interface";
            this.randomCaseURLMenuItem.Click += new System.EventHandler(this.OpenURLFromMenuItemText);
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            this.toolStripSeparator6.Size = new System.Drawing.Size(223, 6);
            // 
            // advancedToolStripMenuItem
            // 
            this.advancedToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.insStdClassesMenuItem});
            this.advancedToolStripMenuItem.Name = "advancedToolStripMenuItem";
            this.advancedToolStripMenuItem.Size = new System.Drawing.Size(226, 22);
            this.advancedToolStripMenuItem.Text = "Quick fixes";
            // 
            // insStdClassesMenuItem
            // 
            this.insStdClassesMenuItem.Name = "insStdClassesMenuItem";
            this.insStdClassesMenuItem.Size = new System.Drawing.Size(191, 22);
            this.insStdClassesMenuItem.Text = "Insert standard classes";
            // 
            // editorsMenu
            // 
            this.editorsMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.formsMenuItem,
            this.testEditorMenuItem,
            this.testImportMenuItem,
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
            this.formsMenuItem.Size = new System.Drawing.Size(231, 22);
            this.formsMenuItem.Text = "Forms";
            this.formsMenuItem.Click += new System.EventHandler(this.formsMenuItem_Click);
            // 
            // testEditorMenuItem
            // 
            this.testEditorMenuItem.Name = "testEditorMenuItem";
            this.testEditorMenuItem.ShortcutKeyDisplayString = "Ctrl+T";
            this.testEditorMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.T)));
            this.testEditorMenuItem.Size = new System.Drawing.Size(231, 22);
            this.testEditorMenuItem.Text = "&Tests";
            this.testEditorMenuItem.Click += new System.EventHandler(this.testEditorMenuItem_Click);
            // 
            // actionEditorMenuItem
            // 
            this.actionEditorMenuItem.Name = "actionEditorMenuItem";
            this.actionEditorMenuItem.ShortcutKeyDisplayString = "Ctrl+A";
            this.actionEditorMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.A)));
            this.actionEditorMenuItem.Size = new System.Drawing.Size(231, 22);
            this.actionEditorMenuItem.Text = "&Actions";
            this.actionEditorMenuItem.Click += new System.EventHandler(this.actionEditorMenuItem_Click);
            // 
            // diagnosisEditorMenuItem
            // 
            this.diagnosisEditorMenuItem.Name = "diagnosisEditorMenuItem";
            this.diagnosisEditorMenuItem.ShortcutKeyDisplayString = "Ctrl+D";
            this.diagnosisEditorMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.D)));
            this.diagnosisEditorMenuItem.Size = new System.Drawing.Size(231, 22);
            this.diagnosisEditorMenuItem.Text = "&Diagnosis";
            // 
            // treatmentsEditorMenuItem
            // 
            this.treatmentsEditorMenuItem.Name = "treatmentsEditorMenuItem";
            this.treatmentsEditorMenuItem.ShortcutKeyDisplayString = "Ctrl+R";
            this.treatmentsEditorMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.R)));
            this.treatmentsEditorMenuItem.Size = new System.Drawing.Size(231, 22);
            this.treatmentsEditorMenuItem.Text = "T&reatments";
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(228, 6);
            // 
            // clientPreviewMenuItem
            // 
            this.clientPreviewMenuItem.Name = "clientPreviewMenuItem";
            this.clientPreviewMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.B)));
            this.clientPreviewMenuItem.Size = new System.Drawing.Size(231, 22);
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
            // testImportMenuItem
            // 
            this.testImportMenuItem.Name = "testImportMenuItem";
            this.testImportMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.T)));
            this.testImportMenuItem.Size = new System.Drawing.Size(231, 22);
            this.testImportMenuItem.Text = "Test import tool";
            this.testImportMenuItem.Click += new System.EventHandler(this.testImportMenuItem_Click);
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
            this.IsMdiContainer = true;
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
        private System.Windows.Forms.ToolStripMenuItem toolsMenu;
        private System.Windows.Forms.ToolStripMenuItem exportClientPackageMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripMenuItem exportClientPackagAgainToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem serverMenuIItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripMenuItem advancedToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem insStdClassesMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openMostRecentMenuItem;
        private System.Windows.Forms.ToolStripMenuItem clipackURLMenuItem;
        private System.Windows.Forms.ToolStripMenuItem indexURLMenuItem;
        private System.Windows.Forms.ToolStripMenuItem randomCaseURLMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
        private System.Windows.Forms.ToolStripMenuItem testImportMenuItem;
    }
}