namespace ModelEditor
{
    partial class EditorWindow
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EditorWindow));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openMostRecentMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.recentMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.saveMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveACopyMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.quitMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.undoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.redoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.cutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.copyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pasteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.selectAllMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.selectProblemNodesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.editHistoryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.nodeMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.componentToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newSubmodelItem = new System.Windows.Forms.ToolStripMenuItem();
            this.removeSubmodelItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator8 = new System.Windows.Forms.ToolStripSeparator();
            this.extractSubmodelItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.outputDescriptionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.subcomponentsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.debugToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showAllEditorsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator7 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripProgressBar1 = new System.Windows.Forms.ToolStripProgressBar();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.rootDiagramPanel = new System.Windows.Forms.TabPage();
            this.rightTabs = new System.Windows.Forms.TabControl();
            this.propertiesPanel = new System.Windows.Forms.TabPage();
            this.editorFlowLayout = new System.Windows.Forms.FlowLayoutPanel();
            this.pathsPanel = new System.Windows.Forms.TabPage();
            this.pathsView1 = new ModelEditor.forms.PathsView();
            this.outputPanel = new System.Windows.Forms.TabPage();
            this.outputView1 = new ModelEditor.forms.OutputView();
            this.issuesPanel = new System.Windows.Forms.TabPage();
            this.issuesView1 = new ModelEditor.forms.IssuesView();
            this.menuStrip1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.tabControl.SuspendLayout();
            this.rightTabs.SuspendLayout();
            this.propertiesPanel.SuspendLayout();
            this.pathsPanel.SuspendLayout();
            this.outputPanel.SuspendLayout();
            this.issuesPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.editToolStripMenuItem,
            this.nodeMenu,
            this.componentToolStripMenuItem,
            this.viewToolStripMenuItem,
            this.debugToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1161, 24);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newMenuItem,
            this.openMenuItem,
            this.openMostRecentMenuItem,
            this.recentMenuItem,
            this.toolStripSeparator3,
            this.saveMenuItem,
            this.saveACopyMenuItem,
            this.toolStripSeparator4,
            this.quitMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // newMenuItem
            // 
            this.newMenuItem.Name = "newMenuItem";
            this.newMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N)));
            this.newMenuItem.Size = new System.Drawing.Size(244, 22);
            this.newMenuItem.Text = "New model";
            this.newMenuItem.Click += new System.EventHandler(this.newMenuItem_Click);
            // 
            // openMenuItem
            // 
            this.openMenuItem.Name = "openMenuItem";
            this.openMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.openMenuItem.Size = new System.Drawing.Size(244, 22);
            this.openMenuItem.Text = "Open";
            this.openMenuItem.Click += new System.EventHandler(this.openMenuItem_Click);
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
            // recentMenuItem
            // 
            this.recentMenuItem.Name = "recentMenuItem";
            this.recentMenuItem.Size = new System.Drawing.Size(244, 22);
            this.recentMenuItem.Text = "Recent";
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(241, 6);
            // 
            // saveMenuItem
            // 
            this.saveMenuItem.Name = "saveMenuItem";
            this.saveMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.saveMenuItem.Size = new System.Drawing.Size(244, 22);
            this.saveMenuItem.Text = "Save";
            this.saveMenuItem.Click += new System.EventHandler(this.saveMenuItem_Click);
            // 
            // saveACopyMenuItem
            // 
            this.saveACopyMenuItem.Name = "saveACopyMenuItem";
            this.saveACopyMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.S)));
            this.saveACopyMenuItem.Size = new System.Drawing.Size(244, 22);
            this.saveACopyMenuItem.Text = "Save a copy";
            this.saveACopyMenuItem.Click += new System.EventHandler(this.saveACopyMenuItem_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(241, 6);
            // 
            // quitMenuItem
            // 
            this.quitMenuItem.Name = "quitMenuItem";
            this.quitMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.F4)));
            this.quitMenuItem.Size = new System.Drawing.Size(244, 22);
            this.quitMenuItem.Text = "Quit";
            this.quitMenuItem.Click += new System.EventHandler(this.quitMenuItem_Click);
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.undoToolStripMenuItem,
            this.redoToolStripMenuItem,
            this.toolStripSeparator1,
            this.cutToolStripMenuItem,
            this.copyToolStripMenuItem,
            this.pasteToolStripMenuItem,
            this.toolStripSeparator2,
            this.selectAllMenuItem,
            this.selectProblemNodesToolStripMenuItem,
            this.toolStripSeparator5,
            this.editHistoryToolStripMenuItem});
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(39, 20);
            this.editToolStripMenuItem.Text = "Edit";
            // 
            // undoToolStripMenuItem
            // 
            this.undoToolStripMenuItem.Name = "undoToolStripMenuItem";
            this.undoToolStripMenuItem.Size = new System.Drawing.Size(188, 22);
            this.undoToolStripMenuItem.Text = "Undo";
            // 
            // redoToolStripMenuItem
            // 
            this.redoToolStripMenuItem.Name = "redoToolStripMenuItem";
            this.redoToolStripMenuItem.Size = new System.Drawing.Size(188, 22);
            this.redoToolStripMenuItem.Text = "Redo";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(185, 6);
            // 
            // cutToolStripMenuItem
            // 
            this.cutToolStripMenuItem.Name = "cutToolStripMenuItem";
            this.cutToolStripMenuItem.Size = new System.Drawing.Size(188, 22);
            this.cutToolStripMenuItem.Text = "Cut";
            // 
            // copyToolStripMenuItem
            // 
            this.copyToolStripMenuItem.Name = "copyToolStripMenuItem";
            this.copyToolStripMenuItem.Size = new System.Drawing.Size(188, 22);
            this.copyToolStripMenuItem.Text = "Copy";
            // 
            // pasteToolStripMenuItem
            // 
            this.pasteToolStripMenuItem.Name = "pasteToolStripMenuItem";
            this.pasteToolStripMenuItem.Size = new System.Drawing.Size(188, 22);
            this.pasteToolStripMenuItem.Text = "Paste";
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(185, 6);
            // 
            // selectAllMenuItem
            // 
            this.selectAllMenuItem.Name = "selectAllMenuItem";
            this.selectAllMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.A)));
            this.selectAllMenuItem.Size = new System.Drawing.Size(188, 22);
            this.selectAllMenuItem.Text = "Select all";
            this.selectAllMenuItem.Click += new System.EventHandler(this.selectAllMenuItem_Click);
            // 
            // selectProblemNodesToolStripMenuItem
            // 
            this.selectProblemNodesToolStripMenuItem.Name = "selectProblemNodesToolStripMenuItem";
            this.selectProblemNodesToolStripMenuItem.Size = new System.Drawing.Size(188, 22);
            this.selectProblemNodesToolStripMenuItem.Text = "Select problem nodes";
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(185, 6);
            // 
            // editHistoryToolStripMenuItem
            // 
            this.editHistoryToolStripMenuItem.Name = "editHistoryToolStripMenuItem";
            this.editHistoryToolStripMenuItem.Size = new System.Drawing.Size(188, 22);
            this.editHistoryToolStripMenuItem.Text = "View history";
            // 
            // nodeMenu
            // 
            this.nodeMenu.Name = "nodeMenu";
            this.nodeMenu.Size = new System.Drawing.Size(48, 20);
            this.nodeMenu.Text = "Node";
            // 
            // componentToolStripMenuItem
            // 
            this.componentToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newSubmodelItem,
            this.removeSubmodelItem,
            this.toolStripSeparator8,
            this.extractSubmodelItem});
            this.componentToolStripMenuItem.Name = "componentToolStripMenuItem";
            this.componentToolStripMenuItem.Size = new System.Drawing.Size(83, 20);
            this.componentToolStripMenuItem.Text = "Component";
            // 
            // newSubmodelItem
            // 
            this.newSubmodelItem.Name = "newSubmodelItem";
            this.newSubmodelItem.Size = new System.Drawing.Size(148, 22);
            this.newSubmodelItem.Text = "Create new";
            this.newSubmodelItem.Click += new System.EventHandler(this.newSubmodelItem_Click);
            // 
            // removeSubmodelItem
            // 
            this.removeSubmodelItem.Name = "removeSubmodelItem";
            this.removeSubmodelItem.Size = new System.Drawing.Size(148, 22);
            this.removeSubmodelItem.Text = "Remove";
            this.removeSubmodelItem.Click += new System.EventHandler(this.removeSubmodelItem_Click);
            // 
            // toolStripSeparator8
            // 
            this.toolStripSeparator8.Name = "toolStripSeparator8";
            this.toolStripSeparator8.Size = new System.Drawing.Size(145, 6);
            // 
            // extractSubmodelItem
            // 
            this.extractSubmodelItem.Name = "extractSubmodelItem";
            this.extractSubmodelItem.Size = new System.Drawing.Size(148, 22);
            this.extractSubmodelItem.Text = "Extract to new";
            // 
            // viewToolStripMenuItem
            // 
            this.viewToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.outputDescriptionToolStripMenuItem,
            this.toolStripSeparator6,
            this.subcomponentsToolStripMenuItem});
            this.viewToolStripMenuItem.Name = "viewToolStripMenuItem";
            this.viewToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.viewToolStripMenuItem.Text = "View";
            // 
            // outputDescriptionToolStripMenuItem
            // 
            this.outputDescriptionToolStripMenuItem.Name = "outputDescriptionToolStripMenuItem";
            this.outputDescriptionToolStripMenuItem.Size = new System.Drawing.Size(174, 22);
            this.outputDescriptionToolStripMenuItem.Text = "Output description";
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            this.toolStripSeparator6.Size = new System.Drawing.Size(171, 6);
            // 
            // subcomponentsToolStripMenuItem
            // 
            this.subcomponentsToolStripMenuItem.Name = "subcomponentsToolStripMenuItem";
            this.subcomponentsToolStripMenuItem.Size = new System.Drawing.Size(174, 22);
            this.subcomponentsToolStripMenuItem.Text = "Sub-components";
            // 
            // debugToolStripMenuItem
            // 
            this.debugToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.showAllEditorsToolStripMenuItem});
            this.debugToolStripMenuItem.Name = "debugToolStripMenuItem";
            this.debugToolStripMenuItem.Size = new System.Drawing.Size(54, 20);
            this.debugToolStripMenuItem.Text = "Debug";
            // 
            // showAllEditorsToolStripMenuItem
            // 
            this.showAllEditorsToolStripMenuItem.Name = "showAllEditorsToolStripMenuItem";
            this.showAllEditorsToolStripMenuItem.Size = new System.Drawing.Size(157, 22);
            this.showAllEditorsToolStripMenuItem.Text = "Show all editors";
            // 
            // toolStrip1
            // 
            this.toolStrip1.AllowItemReorder = true;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton1,
            this.toolStripSeparator7,
            this.toolStripProgressBar1,
            this.toolStripLabel1});
            this.toolStrip1.Location = new System.Drawing.Point(0, 24);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1161, 25);
            this.toolStrip1.TabIndex = 4;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton1.Image")));
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton1.Text = "toolStripButton1";
            // 
            // toolStripSeparator7
            // 
            this.toolStripSeparator7.Name = "toolStripSeparator7";
            this.toolStripSeparator7.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripProgressBar1
            // 
            this.toolStripProgressBar1.Name = "toolStripProgressBar1";
            this.toolStripProgressBar1.Size = new System.Drawing.Size(40, 22);
            this.toolStripProgressBar1.Value = 50;
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.ForeColor = System.Drawing.Color.Red;
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(47, 22);
            this.toolStripLabel1.Text = "5 issues";
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 49);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.tabControl);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.rightTabs);
            this.splitContainer1.Size = new System.Drawing.Size(1161, 573);
            this.splitContainer1.SplitterDistance = 804;
            this.splitContainer1.TabIndex = 5;
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.rootDiagramPanel);
            this.tabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl.Location = new System.Drawing.Point(0, 0);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(804, 573);
            this.tabControl.TabIndex = 0;
            // 
            // rootDiagramPanel
            // 
            this.rootDiagramPanel.Location = new System.Drawing.Point(4, 22);
            this.rootDiagramPanel.Name = "rootDiagramPanel";
            this.rootDiagramPanel.Padding = new System.Windows.Forms.Padding(3);
            this.rootDiagramPanel.Size = new System.Drawing.Size(796, 547);
            this.rootDiagramPanel.TabIndex = 0;
            this.rootDiagramPanel.Text = "Root component";
            this.rootDiagramPanel.UseVisualStyleBackColor = true;
            // 
            // rightTabs
            // 
            this.rightTabs.Alignment = System.Windows.Forms.TabAlignment.Left;
            this.rightTabs.Controls.Add(this.propertiesPanel);
            this.rightTabs.Controls.Add(this.pathsPanel);
            this.rightTabs.Controls.Add(this.outputPanel);
            this.rightTabs.Controls.Add(this.issuesPanel);
            this.rightTabs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rightTabs.Location = new System.Drawing.Point(0, 0);
            this.rightTabs.Multiline = true;
            this.rightTabs.Name = "rightTabs";
            this.rightTabs.SelectedIndex = 0;
            this.rightTabs.Size = new System.Drawing.Size(353, 573);
            this.rightTabs.TabIndex = 2;
            // 
            // propertiesPanel
            // 
            this.propertiesPanel.Controls.Add(this.editorFlowLayout);
            this.propertiesPanel.Location = new System.Drawing.Point(23, 4);
            this.propertiesPanel.Name = "propertiesPanel";
            this.propertiesPanel.Padding = new System.Windows.Forms.Padding(3);
            this.propertiesPanel.Size = new System.Drawing.Size(326, 565);
            this.propertiesPanel.TabIndex = 0;
            this.propertiesPanel.Text = "Properties";
            this.propertiesPanel.UseVisualStyleBackColor = true;
            // 
            // editorFlowLayout
            // 
            this.editorFlowLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.editorFlowLayout.Location = new System.Drawing.Point(3, 3);
            this.editorFlowLayout.Name = "editorFlowLayout";
            this.editorFlowLayout.Size = new System.Drawing.Size(320, 559);
            this.editorFlowLayout.TabIndex = 0;
            // 
            // pathsPanel
            // 
            this.pathsPanel.Controls.Add(this.pathsView1);
            this.pathsPanel.Location = new System.Drawing.Point(23, 4);
            this.pathsPanel.Name = "pathsPanel";
            this.pathsPanel.Size = new System.Drawing.Size(326, 565);
            this.pathsPanel.TabIndex = 3;
            this.pathsPanel.Text = "Pathts";
            this.pathsPanel.UseVisualStyleBackColor = true;
            // 
            // pathsView1
            // 
            this.pathsView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pathsView1.Location = new System.Drawing.Point(0, 0);
            this.pathsView1.Model = null;
            this.pathsView1.Name = "pathsView1";
            this.pathsView1.Size = new System.Drawing.Size(326, 565);
            this.pathsView1.TabIndex = 0;
            // 
            // outputPanel
            // 
            this.outputPanel.Controls.Add(this.outputView1);
            this.outputPanel.Location = new System.Drawing.Point(23, 4);
            this.outputPanel.Name = "outputPanel";
            this.outputPanel.Padding = new System.Windows.Forms.Padding(3);
            this.outputPanel.Size = new System.Drawing.Size(326, 565);
            this.outputPanel.TabIndex = 1;
            this.outputPanel.Text = "Output";
            this.outputPanel.UseVisualStyleBackColor = true;
            // 
            // outputView1
            // 
            this.outputView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.outputView1.Location = new System.Drawing.Point(3, 3);
            this.outputView1.Model = null;
            this.outputView1.Name = "outputView1";
            this.outputView1.Size = new System.Drawing.Size(320, 559);
            this.outputView1.TabIndex = 0;
            // 
            // issuesPanel
            // 
            this.issuesPanel.Controls.Add(this.issuesView1);
            this.issuesPanel.Location = new System.Drawing.Point(23, 4);
            this.issuesPanel.Name = "issuesPanel";
            this.issuesPanel.Padding = new System.Windows.Forms.Padding(3);
            this.issuesPanel.Size = new System.Drawing.Size(326, 565);
            this.issuesPanel.TabIndex = 2;
            this.issuesPanel.Text = "Issues";
            this.issuesPanel.UseVisualStyleBackColor = true;
            // 
            // issuesView1
            // 
            this.issuesView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.issuesView1.Location = new System.Drawing.Point(3, 3);
            this.issuesView1.Name = "issuesView1";
            this.issuesView1.Size = new System.Drawing.Size(320, 559);
            this.issuesView1.TabIndex = 0;
            // 
            // EditorWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1161, 622);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "EditorWindow";
            this.Text = "EditorWindow";
            this.Load += new System.EventHandler(this.EditorWindow_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.tabControl.ResumeLayout(false);
            this.rightTabs.ResumeLayout(false);
            this.propertiesPanel.ResumeLayout(false);
            this.pathsPanel.ResumeLayout(false);
            this.outputPanel.ResumeLayout(false);
            this.issuesPanel.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openMenuItem;
        private System.Windows.Forms.ToolStripMenuItem recentMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem saveMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveACopyMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripMenuItem quitMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem undoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem redoToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem cutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem copyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pasteToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem selectAllMenuItem;
        private System.Windows.Forms.ToolStripMenuItem selectProblemNodesToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripMenuItem editHistoryToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem nodeMenu;
        private System.Windows.Forms.ToolStripMenuItem viewToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem debugToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem showAllEditorsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem outputDescriptionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openMostRecentMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
        private System.Windows.Forms.ToolStripMenuItem subcomponentsToolStripMenuItem;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator7;
        private System.Windows.Forms.ToolStripProgressBar toolStripProgressBar1;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage rootDiagramPanel;
        private System.Windows.Forms.TabControl rightTabs;
        private System.Windows.Forms.TabPage propertiesPanel;
        private System.Windows.Forms.FlowLayoutPanel editorFlowLayout;
        private System.Windows.Forms.TabPage pathsPanel;
        private forms.PathsView pathsView1;
        private System.Windows.Forms.TabPage outputPanel;
        private forms.OutputView outputView1;
        private System.Windows.Forms.TabPage issuesPanel;
        private System.Windows.Forms.ToolStripMenuItem componentToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newSubmodelItem;
        private System.Windows.Forms.ToolStripMenuItem removeSubmodelItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator8;
        private System.Windows.Forms.ToolStripMenuItem extractSubmodelItem;
        private forms.IssuesView issuesView1;


    }
}