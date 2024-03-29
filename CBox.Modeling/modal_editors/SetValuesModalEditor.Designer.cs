﻿namespace cbox.modelling.editors
{
    partial class SetValuesModalEditor
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.closeButton = new System.Windows.Forms.Button();
            this.entryList = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.entryListContextMeny = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.cutMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.copyMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pasteMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label2 = new System.Windows.Forms.Label();
            this.actionCombobox = new System.Windows.Forms.ComboBox();
            this.addYieldButton = new System.Windows.Forms.Button();
            this.setterEditorPanel = new System.Windows.Forms.Panel();
            this.removeButton = new System.Windows.Forms.Button();
            this.classLabel = new System.Windows.Forms.Label();
            this.useDefaultDataCheckbox = new System.Windows.Forms.CheckBox();
            this.keyLabel = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.policySelect = new System.Windows.Forms.ComboBox();
            this.testPicker = new cbox.modelling.TestPicker();
            this.panel1.SuspendLayout();
            this.entryListContextMeny.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.SystemColors.ControlLight;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.closeButton);
            this.panel1.Location = new System.Drawing.Point(-2, 765);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1120, 46);
            this.panel1.TabIndex = 0;
            // 
            // closeButton
            // 
            this.closeButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.closeButton.Location = new System.Drawing.Point(1013, 7);
            this.closeButton.Name = "closeButton";
            this.closeButton.Size = new System.Drawing.Size(90, 27);
            this.closeButton.TabIndex = 0;
            this.closeButton.Text = "Close";
            this.closeButton.UseVisualStyleBackColor = true;
            this.closeButton.Click += new System.EventHandler(this.closeButton_Click);
            // 
            // entryList
            // 
            this.entryList.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.entryList.CheckBoxes = true;
            this.entryList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3});
            this.entryList.ContextMenuStrip = this.entryListContextMeny;
            this.entryList.Location = new System.Drawing.Point(12, 32);
            this.entryList.Name = "entryList";
            this.entryList.Size = new System.Drawing.Size(556, 399);
            this.entryList.TabIndex = 1;
            this.entryList.UseCompatibleStateImageBehavior = false;
            this.entryList.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Key";
            this.columnHeader1.Width = 246;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Title";
            this.columnHeader2.Width = 176;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Form";
            this.columnHeader3.Width = 99;
            // 
            // entryListContextMeny
            // 
            this.entryListContextMeny.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.entryListContextMeny.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cutMenuItem,
            this.copyMenuItem,
            this.pasteMenuItem});
            this.entryListContextMeny.Name = "entryListContextMeny";
            this.entryListContextMeny.Size = new System.Drawing.Size(170, 82);
            // 
            // cutMenuItem
            // 
            this.cutMenuItem.Name = "cutMenuItem";
            this.cutMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.X)));
            this.cutMenuItem.Size = new System.Drawing.Size(169, 26);
            this.cutMenuItem.Text = "Cut";
            // 
            // copyMenuItem
            // 
            this.copyMenuItem.Name = "copyMenuItem";
            this.copyMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.C)));
            this.copyMenuItem.Size = new System.Drawing.Size(169, 26);
            this.copyMenuItem.Text = "Copy";
            this.copyMenuItem.Click += new System.EventHandler(this.copyMenuItem_Click);
            // 
            // pasteMenuItem
            // 
            this.pasteMenuItem.Name = "pasteMenuItem";
            this.pasteMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.V)));
            this.pasteMenuItem.Size = new System.Drawing.Size(169, 26);
            this.pasteMenuItem.Text = "Paste";
            this.pasteMenuItem.Click += new System.EventHandler(this.pasteMenuItem_Click);
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 722);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(108, 17);
            this.label2.TabIndex = 5;
            this.label2.Text = "Add to full yield:";
            // 
            // actionCombobox
            // 
            this.actionCombobox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.actionCombobox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.actionCombobox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.actionCombobox.FormattingEnabled = true;
            this.actionCombobox.Location = new System.Drawing.Point(127, 718);
            this.actionCombobox.Name = "actionCombobox";
            this.actionCombobox.Size = new System.Drawing.Size(360, 24);
            this.actionCombobox.TabIndex = 6;
            // 
            // addYieldButton
            // 
            this.addYieldButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.addYieldButton.Location = new System.Drawing.Point(493, 719);
            this.addYieldButton.Name = "addYieldButton";
            this.addYieldButton.Size = new System.Drawing.Size(75, 23);
            this.addYieldButton.TabIndex = 7;
            this.addYieldButton.Text = "Add";
            this.addYieldButton.UseVisualStyleBackColor = true;
            // 
            // setterEditorPanel
            // 
            this.setterEditorPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.setterEditorPanel.BackColor = System.Drawing.SystemColors.ControlLight;
            this.setterEditorPanel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.setterEditorPanel.Location = new System.Drawing.Point(574, 59);
            this.setterEditorPanel.Name = "setterEditorPanel";
            this.setterEditorPanel.Size = new System.Drawing.Size(528, 686);
            this.setterEditorPanel.TabIndex = 8;
            // 
            // removeButton
            // 
            this.removeButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.removeButton.Location = new System.Drawing.Point(12, 437);
            this.removeButton.Name = "removeButton";
            this.removeButton.Size = new System.Drawing.Size(141, 23);
            this.removeButton.TabIndex = 9;
            this.removeButton.Text = "Remove marked";
            this.removeButton.UseVisualStyleBackColor = true;
            this.removeButton.Click += new System.EventHandler(this.removeButton_Click);
            // 
            // classLabel
            // 
            this.classLabel.AutoSize = true;
            this.classLabel.Location = new System.Drawing.Point(9, 9);
            this.classLabel.Name = "classLabel";
            this.classLabel.Size = new System.Drawing.Size(93, 17);
            this.classLabel.TabIndex = 11;
            this.classLabel.Text = "<No classes>";
            // 
            // useDefaultDataCheckbox
            // 
            this.useDefaultDataCheckbox.AutoSize = true;
            this.useDefaultDataCheckbox.Checked = true;
            this.useDefaultDataCheckbox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.useDefaultDataCheckbox.Location = new System.Drawing.Point(328, 439);
            this.useDefaultDataCheckbox.Name = "useDefaultDataCheckbox";
            this.useDefaultDataCheckbox.Size = new System.Drawing.Size(240, 21);
            this.useDefaultDataCheckbox.TabIndex = 12;
            this.useDefaultDataCheckbox.Text = "Copy ontology setter data on add";
            this.useDefaultDataCheckbox.UseVisualStyleBackColor = true;
            // 
            // keyLabel
            // 
            this.keyLabel.AutoSize = true;
            this.keyLabel.ForeColor = System.Drawing.Color.DarkOliveGreen;
            this.keyLabel.Location = new System.Drawing.Point(865, 32);
            this.keyLabel.Name = "keyLabel";
            this.keyLabel.Size = new System.Drawing.Size(46, 17);
            this.keyLabel.TabIndex = 13;
            this.keyLabel.Text = "label1";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(574, 32);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(98, 17);
            this.label3.TabIndex = 14;
            this.label3.Text = "Conflict policy:";
            // 
            // policySelect
            // 
            this.policySelect.FormattingEnabled = true;
            this.policySelect.Items.AddRange(new object[] {
            "DEFAULT",
            "CLEAR"});
            this.policySelect.Location = new System.Drawing.Point(678, 29);
            this.policySelect.Name = "policySelect";
            this.policySelect.Size = new System.Drawing.Size(181, 24);
            this.policySelect.TabIndex = 15;
            // 
            // testPicker
            // 
            this.testPicker.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.testPicker.LimitToClasses = null;
            this.testPicker.Location = new System.Drawing.Point(12, 466);
            this.testPicker.Name = "testPicker";
            this.testPicker.Ontology = null;
            this.testPicker.SelectedTest = null;
            this.testPicker.Size = new System.Drawing.Size(556, 246);
            this.testPicker.TabIndex = 10;
            // 
            // SetValuesModalEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1114, 807);
            this.Controls.Add(this.policySelect);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.keyLabel);
            this.Controls.Add(this.useDefaultDataCheckbox);
            this.Controls.Add(this.classLabel);
            this.Controls.Add(this.testPicker);
            this.Controls.Add(this.removeButton);
            this.Controls.Add(this.setterEditorPanel);
            this.Controls.Add(this.addYieldButton);
            this.Controls.Add(this.actionCombobox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.entryList);
            this.Controls.Add(this.panel1);
            this.MinimumSize = new System.Drawing.Size(1109, 700);
            this.Name = "SetValuesModalEditor";
            this.Text = "Set values editor";
            this.Load += new System.EventHandler(this.SetValuesModalEditor_Load);
            this.panel1.ResumeLayout(false);
            this.entryListContextMeny.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button closeButton;
        private System.Windows.Forms.ListView entryList;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox actionCombobox;
        private System.Windows.Forms.Button addYieldButton;
        private System.Windows.Forms.Panel setterEditorPanel;
        private System.Windows.Forms.Button removeButton;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private TestPicker testPicker;
        private System.Windows.Forms.Label classLabel;
        private System.Windows.Forms.CheckBox useDefaultDataCheckbox;
        private System.Windows.Forms.ContextMenuStrip entryListContextMeny;
        private System.Windows.Forms.ToolStripMenuItem cutMenuItem;
        private System.Windows.Forms.ToolStripMenuItem copyMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pasteMenuItem;
        private System.Windows.Forms.Label keyLabel;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox policySelect;
    }
}