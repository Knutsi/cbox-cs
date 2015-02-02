namespace OntologyEditor
{
    partial class FormsEditor
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormsEditor));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.addFormButton = new System.Windows.Forms.ToolStripButton();
            this.removeFormButton = new System.Windows.Forms.ToolStripButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.headlineTitleInput = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.actionSelect = new System.Windows.Forms.ComboBox();
            this.removeActionButton = new System.Windows.Forms.Button();
            this.addActionButton = new System.Windows.Forms.Button();
            this.actionsList = new System.Windows.Forms.ListBox();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.colorInput = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.headlinesList = new System.Windows.Forms.ListBox();
            this.removeHeadlineButton = new System.Windows.Forms.Button();
            this.addHeadlineButton = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.titleInput = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.formsList = new System.Windows.Forms.ListBox();
            this.toolStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addFormButton,
            this.removeFormButton});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(874, 25);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // addFormButton
            // 
            this.addFormButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.addFormButton.Image = ((System.Drawing.Image)(resources.GetObject("addFormButton.Image")));
            this.addFormButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.addFormButton.Name = "addFormButton";
            this.addFormButton.Size = new System.Drawing.Size(23, 22);
            this.addFormButton.Text = "toolStripButton1";
            this.addFormButton.Click += new System.EventHandler(this.addFormButton_Click);
            // 
            // removeFormButton
            // 
            this.removeFormButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.removeFormButton.Image = ((System.Drawing.Image)(resources.GetObject("removeFormButton.Image")));
            this.removeFormButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.removeFormButton.Name = "removeFormButton";
            this.removeFormButton.Size = new System.Drawing.Size(23, 22);
            this.removeFormButton.Text = "toolStripButton2";
            this.removeFormButton.Click += new System.EventHandler(this.removeFormButton_Click);
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.groupBox2);
            this.panel1.Controls.Add(this.colorInput);
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.titleInput);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(264, 23);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(599, 506);
            this.panel1.TabIndex = 11;
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.headlineTitleInput);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.actionSelect);
            this.groupBox2.Controls.Add(this.removeActionButton);
            this.groupBox2.Controls.Add(this.addActionButton);
            this.groupBox2.Controls.Add(this.actionsList);
            this.groupBox2.Controls.Add(this.button3);
            this.groupBox2.Controls.Add(this.button4);
            this.groupBox2.Location = new System.Drawing.Point(275, 7);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(309, 493);
            this.groupBox2.TabIndex = 17;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Actions in selected headline";
            // 
            // headlineTitleInput
            // 
            this.headlineTitleInput.Location = new System.Drawing.Point(56, 25);
            this.headlineTitleInput.Name = "headlineTitleInput";
            this.headlineTitleInput.Size = new System.Drawing.Size(180, 20);
            this.headlineTitleInput.TabIndex = 15;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(4, 28);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(52, 13);
            this.label3.TabIndex = 14;
            this.label3.Text = "Headline:";
            // 
            // actionSelect
            // 
            this.actionSelect.FormattingEnabled = true;
            this.actionSelect.Location = new System.Drawing.Point(7, 466);
            this.actionSelect.Name = "actionSelect";
            this.actionSelect.Size = new System.Drawing.Size(154, 21);
            this.actionSelect.TabIndex = 5;
            // 
            // removeActionButton
            // 
            this.removeActionButton.Location = new System.Drawing.Point(247, 464);
            this.removeActionButton.Name = "removeActionButton";
            this.removeActionButton.Size = new System.Drawing.Size(60, 23);
            this.removeActionButton.TabIndex = 4;
            this.removeActionButton.Text = "Remove";
            this.removeActionButton.UseVisualStyleBackColor = true;
            // 
            // addActionButton
            // 
            this.addActionButton.Location = new System.Drawing.Point(167, 464);
            this.addActionButton.Name = "addActionButton";
            this.addActionButton.Size = new System.Drawing.Size(74, 23);
            this.addActionButton.TabIndex = 3;
            this.addActionButton.Text = "Add action";
            this.addActionButton.UseVisualStyleBackColor = true;
            // 
            // actionsList
            // 
            this.actionsList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.actionsList.FormattingEnabled = true;
            this.actionsList.Location = new System.Drawing.Point(6, 62);
            this.actionsList.Name = "actionsList";
            this.actionsList.Size = new System.Drawing.Size(297, 394);
            this.actionsList.TabIndex = 2;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(56, 411);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(60, 23);
            this.button3.TabIndex = 1;
            this.button3.Text = "Remove";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(6, 411);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(44, 23);
            this.button4.TabIndex = 0;
            this.button4.Text = "Add";
            this.button4.UseVisualStyleBackColor = true;
            // 
            // colorInput
            // 
            this.colorInput.Location = new System.Drawing.Point(79, 32);
            this.colorInput.Name = "colorInput";
            this.colorInput.Size = new System.Drawing.Size(180, 20);
            this.colorInput.TabIndex = 16;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.headlinesList);
            this.groupBox1.Controls.Add(this.removeHeadlineButton);
            this.groupBox1.Controls.Add(this.addHeadlineButton);
            this.groupBox1.Location = new System.Drawing.Point(6, 64);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(259, 436);
            this.groupBox1.TabIndex = 15;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Headlines";
            // 
            // headlinesList
            // 
            this.headlinesList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.headlinesList.DisplayMember = "Title";
            this.headlinesList.FormattingEnabled = true;
            this.headlinesList.Location = new System.Drawing.Point(6, 23);
            this.headlinesList.Name = "headlinesList";
            this.headlinesList.Size = new System.Drawing.Size(247, 381);
            this.headlinesList.Sorted = true;
            this.headlinesList.TabIndex = 2;
            this.headlinesList.ValueMember = "Title";
            this.headlinesList.SelectedValueChanged += new System.EventHandler(this.headlinesList_SelectedValueChanged);
            // 
            // removeHeadlineButton
            // 
            this.removeHeadlineButton.Location = new System.Drawing.Point(95, 407);
            this.removeHeadlineButton.Name = "removeHeadlineButton";
            this.removeHeadlineButton.Size = new System.Drawing.Size(60, 23);
            this.removeHeadlineButton.TabIndex = 1;
            this.removeHeadlineButton.Text = "Remove";
            this.removeHeadlineButton.UseVisualStyleBackColor = true;
            this.removeHeadlineButton.Click += new System.EventHandler(this.removeHeadlineButton_Click);
            // 
            // addHeadlineButton
            // 
            this.addHeadlineButton.Location = new System.Drawing.Point(5, 407);
            this.addHeadlineButton.Name = "addHeadlineButton";
            this.addHeadlineButton.Size = new System.Drawing.Size(84, 23);
            this.addHeadlineButton.TabIndex = 0;
            this.addHeadlineButton.Text = "Add headline";
            this.addHeadlineButton.UseVisualStyleBackColor = true;
            this.addHeadlineButton.Click += new System.EventHandler(this.addHeadlineButton_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 35);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 13);
            this.label2.TabIndex = 14;
            this.label2.Text = "Header color:";
            // 
            // titleInput
            // 
            this.titleInput.Location = new System.Drawing.Point(79, 7);
            this.titleInput.Name = "titleInput";
            this.titleInput.Size = new System.Drawing.Size(180, 20);
            this.titleInput.TabIndex = 13;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 13);
            this.label1.TabIndex = 12;
            this.label1.Text = "Form title:";
            // 
            // formsList
            // 
            this.formsList.DisplayMember = "Title";
            this.formsList.FormattingEnabled = true;
            this.formsList.Location = new System.Drawing.Point(0, 23);
            this.formsList.Name = "formsList";
            this.formsList.Size = new System.Drawing.Size(258, 511);
            this.formsList.TabIndex = 12;
            this.formsList.ValueMember = "Title";
            this.formsList.SelectedValueChanged += new System.EventHandler(this.formsList_SelectedValueChanged);
            // 
            // FormsEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(874, 538);
            this.Controls.Add(this.formsList);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.toolStrip1);
            this.Name = "FormsEditor";
            this.Text = "Forms Editor";
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton addFormButton;
        private System.Windows.Forms.ToolStripButton removeFormButton;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ComboBox actionSelect;
        private System.Windows.Forms.Button removeActionButton;
        private System.Windows.Forms.Button addActionButton;
        private System.Windows.Forms.ListBox actionsList;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.TextBox colorInput;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ListBox headlinesList;
        private System.Windows.Forms.Button removeHeadlineButton;
        private System.Windows.Forms.Button addHeadlineButton;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox titleInput;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox formsList;
        private System.Windows.Forms.TextBox headlineTitleInput;
        private System.Windows.Forms.Label label3;
    }
}