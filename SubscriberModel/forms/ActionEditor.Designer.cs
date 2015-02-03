namespace OntologyEditor
{
    partial class ActionEditor
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
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.formPlacementSelect = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.costInput = new System.Windows.Forms.NumericUpDown();
            this.waittimeInput = new System.Windows.Forms.NumericUpDown();
            this.painInput = new System.Windows.Forms.NumericUpDown();
            this.occtimeInput = new System.Windows.Forms.NumericUpDown();
            this.riskInput = new System.Windows.Forms.NumericUpDown();
            this.titleInput = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.removeYieldButton = new System.Windows.Forms.Button();
            this.addYieldButton = new System.Windows.Forms.Button();
            this.yieldsSearch = new System.Windows.Forms.ComboBox();
            this.yieldsSelect = new System.Windows.Forms.ListBox();
            this.addActionButton = new System.Windows.Forms.Button();
            this.removeActionButton = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.classSelect = new System.Windows.Forms.CheckedListBox();
            this.actionList = new System.Windows.Forms.ListBox();
            this.createMissingButton = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.costInput)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.waittimeInput)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.painInput)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.occtimeInput)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.riskInput)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // statusStrip1
            // 
            this.statusStrip1.Location = new System.Drawing.Point(0, 542);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(795, 22);
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.formPlacementSelect);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.costInput);
            this.groupBox1.Controls.Add(this.waittimeInput);
            this.groupBox1.Controls.Add(this.painInput);
            this.groupBox1.Controls.Add(this.occtimeInput);
            this.groupBox1.Controls.Add(this.riskInput);
            this.groupBox1.Controls.Add(this.titleInput);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(203, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(580, 171);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Action information";
            // 
            // formPlacementSelect
            // 
            this.formPlacementSelect.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.formPlacementSelect.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.formPlacementSelect.FormattingEnabled = true;
            this.formPlacementSelect.Location = new System.Drawing.Point(97, 141);
            this.formPlacementSelect.Name = "formPlacementSelect";
            this.formPlacementSelect.Size = new System.Drawing.Size(477, 21);
            this.formPlacementSelect.TabIndex = 4;
            this.formPlacementSelect.SelectedIndexChanged += new System.EventHandler(this.formPlacementSelect_SelectedIndexChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 144);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(85, 13);
            this.label7.TabIndex = 3;
            this.label7.Text = "Form placement:";
            // 
            // costInput
            // 
            this.costInput.DecimalPlaces = 2;
            this.costInput.Location = new System.Drawing.Point(43, 101);
            this.costInput.Name = "costInput";
            this.costInput.Size = new System.Drawing.Size(74, 20);
            this.costInput.TabIndex = 2;
            // 
            // waittimeInput
            // 
            this.waittimeInput.Location = new System.Drawing.Point(231, 101);
            this.waittimeInput.Name = "waittimeInput";
            this.waittimeInput.Size = new System.Drawing.Size(74, 20);
            this.waittimeInput.TabIndex = 2;
            // 
            // painInput
            // 
            this.painInput.DecimalPlaces = 2;
            this.painInput.Location = new System.Drawing.Point(43, 77);
            this.painInput.Name = "painInput";
            this.painInput.Size = new System.Drawing.Size(74, 20);
            this.painInput.TabIndex = 2;
            // 
            // occtimeInput
            // 
            this.occtimeInput.Location = new System.Drawing.Point(230, 77);
            this.occtimeInput.Name = "occtimeInput";
            this.occtimeInput.Size = new System.Drawing.Size(74, 20);
            this.occtimeInput.TabIndex = 2;
            // 
            // riskInput
            // 
            this.riskInput.DecimalPlaces = 2;
            this.riskInput.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.riskInput.Location = new System.Drawing.Point(42, 53);
            this.riskInput.Name = "riskInput";
            this.riskInput.Size = new System.Drawing.Size(74, 20);
            this.riskInput.TabIndex = 2;
            // 
            // titleInput
            // 
            this.titleInput.Location = new System.Drawing.Point(42, 26);
            this.titleInput.Name = "titleInput";
            this.titleInput.Size = new System.Drawing.Size(262, 20);
            this.titleInput.TabIndex = 1;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(144, 103);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(52, 13);
            this.label6.TabIndex = 0;
            this.label6.Text = "Time wait";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 103);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(31, 13);
            this.label4.TabIndex = 0;
            this.label4.Text = "Cost:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(144, 79);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(80, 13);
            this.label5.TabIndex = 0;
            this.label5.Text = "Time occupied:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 79);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(31, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "Pain:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 55);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(31, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Risk:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(30, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Title:";
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBox2.Controls.Add(this.removeYieldButton);
            this.groupBox2.Controls.Add(this.addYieldButton);
            this.groupBox2.Controls.Add(this.yieldsSearch);
            this.groupBox2.Controls.Add(this.yieldsSelect);
            this.groupBox2.Location = new System.Drawing.Point(204, 190);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(360, 349);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Yields";
            // 
            // removeYieldButton
            // 
            this.removeYieldButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.removeYieldButton.Location = new System.Drawing.Point(279, 318);
            this.removeYieldButton.Name = "removeYieldButton";
            this.removeYieldButton.Size = new System.Drawing.Size(75, 23);
            this.removeYieldButton.TabIndex = 5;
            this.removeYieldButton.Text = "Remove";
            this.removeYieldButton.UseVisualStyleBackColor = true;
            this.removeYieldButton.Click += new System.EventHandler(this.removeYieldButton_Click);
            // 
            // addYieldButton
            // 
            this.addYieldButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.addYieldButton.Location = new System.Drawing.Point(198, 318);
            this.addYieldButton.Name = "addYieldButton";
            this.addYieldButton.Size = new System.Drawing.Size(75, 23);
            this.addYieldButton.TabIndex = 5;
            this.addYieldButton.Text = "Add value";
            this.addYieldButton.UseVisualStyleBackColor = true;
            this.addYieldButton.Click += new System.EventHandler(this.addYieldButton_Click);
            // 
            // yieldsSearch
            // 
            this.yieldsSearch.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.yieldsSearch.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.yieldsSearch.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.yieldsSearch.DisplayMember = "Key";
            this.yieldsSearch.FormattingEnabled = true;
            this.yieldsSearch.Location = new System.Drawing.Point(8, 318);
            this.yieldsSearch.Name = "yieldsSearch";
            this.yieldsSearch.Size = new System.Drawing.Size(179, 21);
            this.yieldsSearch.TabIndex = 4;
            // 
            // yieldsSelect
            // 
            this.yieldsSelect.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.yieldsSelect.DisplayMember = "ToString";
            this.yieldsSelect.FormattingEnabled = true;
            this.yieldsSelect.Location = new System.Drawing.Point(8, 20);
            this.yieldsSelect.Name = "yieldsSelect";
            this.yieldsSelect.Size = new System.Drawing.Size(346, 290);
            this.yieldsSelect.TabIndex = 0;
            // 
            // addActionButton
            // 
            this.addActionButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.addActionButton.Location = new System.Drawing.Point(12, 479);
            this.addActionButton.Name = "addActionButton";
            this.addActionButton.Size = new System.Drawing.Size(104, 23);
            this.addActionButton.TabIndex = 5;
            this.addActionButton.Text = "Add action";
            this.addActionButton.UseVisualStyleBackColor = true;
            this.addActionButton.Click += new System.EventHandler(this.addActionButton_Click);
            // 
            // removeActionButton
            // 
            this.removeActionButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.removeActionButton.Location = new System.Drawing.Point(122, 479);
            this.removeActionButton.Name = "removeActionButton";
            this.removeActionButton.Size = new System.Drawing.Size(75, 23);
            this.removeActionButton.TabIndex = 5;
            this.removeActionButton.Text = "Remove";
            this.removeActionButton.UseVisualStyleBackColor = true;
            this.removeActionButton.Click += new System.EventHandler(this.removeActionButton_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox3.Controls.Add(this.classSelect);
            this.groupBox3.Location = new System.Drawing.Point(570, 190);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(213, 349);
            this.groupBox3.TabIndex = 3;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Applies to problem class";
            // 
            // classSelect
            // 
            this.classSelect.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.classSelect.CheckOnClick = true;
            this.classSelect.FormattingEnabled = true;
            this.classSelect.Location = new System.Drawing.Point(7, 20);
            this.classSelect.Name = "classSelect";
            this.classSelect.Size = new System.Drawing.Size(200, 319);
            this.classSelect.TabIndex = 6;
            this.classSelect.SelectedValueChanged += new System.EventHandler(this.classSelect_Click);
            // 
            // actionList
            // 
            this.actionList.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.actionList.FormattingEnabled = true;
            this.actionList.Location = new System.Drawing.Point(12, 12);
            this.actionList.Name = "actionList";
            this.actionList.Size = new System.Drawing.Size(185, 459);
            this.actionList.TabIndex = 6;
            this.actionList.SelectedValueChanged += new System.EventHandler(this.actionList_SelectedValueChanged);
            // 
            // createMissingButton
            // 
            this.createMissingButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.createMissingButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.createMissingButton.Location = new System.Drawing.Point(13, 506);
            this.createMissingButton.Name = "createMissingButton";
            this.createMissingButton.Size = new System.Drawing.Size(184, 23);
            this.createMissingButton.TabIndex = 7;
            this.createMissingButton.Text = "Create missing";
            this.createMissingButton.UseVisualStyleBackColor = true;
            // 
            // ActionEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(795, 564);
            this.Controls.Add(this.createMissingButton);
            this.Controls.Add(this.actionList);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.removeActionButton);
            this.Controls.Add(this.addActionButton);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.statusStrip1);
            this.Name = "ActionEditor";
            this.Text = "Actions Editor";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.costInput)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.waittimeInput)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.painInput)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.occtimeInput)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.riskInput)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown costInput;
        private System.Windows.Forms.NumericUpDown painInput;
        private System.Windows.Forms.NumericUpDown riskInput;
        private System.Windows.Forms.TextBox titleInput;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox formPlacementSelect;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.NumericUpDown waittimeInput;
        private System.Windows.Forms.NumericUpDown occtimeInput;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button removeYieldButton;
        private System.Windows.Forms.Button addYieldButton;
        private System.Windows.Forms.ComboBox yieldsSearch;
        private System.Windows.Forms.ListBox yieldsSelect;
        private System.Windows.Forms.Button addActionButton;
        private System.Windows.Forms.Button removeActionButton;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.CheckedListBox classSelect;
        private System.Windows.Forms.ListBox actionList;
        private System.Windows.Forms.Button createMissingButton;
    }
}