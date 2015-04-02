namespace ModelEditor.forms
{
    partial class OntologySettings
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
            this.ontologyPathInput = new System.Windows.Forms.TextBox();
            this.findButton = new System.Windows.Forms.Button();
            this.loadButton = new System.Windows.Forms.Button();
            this.loadInfo = new System.Windows.Forms.TextBox();
            this.useForNoneSystemCheckbox = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // ontologyPathInput
            // 
            this.ontologyPathInput.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ontologyPathInput.Location = new System.Drawing.Point(12, 10);
            this.ontologyPathInput.Name = "ontologyPathInput";
            this.ontologyPathInput.Size = new System.Drawing.Size(194, 20);
            this.ontologyPathInput.TabIndex = 1;
            this.ontologyPathInput.TextChanged += new System.EventHandler(this.ontologyPathInput_TextChanged);
            // 
            // findButton
            // 
            this.findButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.findButton.Location = new System.Drawing.Point(212, 8);
            this.findButton.Name = "findButton";
            this.findButton.Size = new System.Drawing.Size(36, 23);
            this.findButton.TabIndex = 2;
            this.findButton.Text = "Find";
            this.findButton.UseVisualStyleBackColor = true;
            this.findButton.Click += new System.EventHandler(this.findButton_Click);
            // 
            // loadButton
            // 
            this.loadButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.loadButton.Location = new System.Drawing.Point(254, 8);
            this.loadButton.Name = "loadButton";
            this.loadButton.Size = new System.Drawing.Size(75, 23);
            this.loadButton.TabIndex = 3;
            this.loadButton.Text = "Load";
            this.loadButton.UseVisualStyleBackColor = true;
            this.loadButton.Click += new System.EventHandler(this.loadButton_Click);
            // 
            // loadInfo
            // 
            this.loadInfo.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.loadInfo.Location = new System.Drawing.Point(12, 60);
            this.loadInfo.Multiline = true;
            this.loadInfo.Name = "loadInfo";
            this.loadInfo.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.loadInfo.Size = new System.Drawing.Size(317, 250);
            this.loadInfo.TabIndex = 4;
            // 
            // useForNoneSystemCheckbox
            // 
            this.useForNoneSystemCheckbox.AutoSize = true;
            this.useForNoneSystemCheckbox.Location = new System.Drawing.Point(13, 37);
            this.useForNoneSystemCheckbox.Name = "useForNoneSystemCheckbox";
            this.useForNoneSystemCheckbox.Size = new System.Drawing.Size(152, 17);
            this.useForNoneSystemCheckbox.TabIndex = 5;
            this.useForNoneSystemCheckbox.Text = "Use for non-system models";
            this.useForNoneSystemCheckbox.UseVisualStyleBackColor = true;
            this.useForNoneSystemCheckbox.CheckedChanged += new System.EventHandler(this.useForNoneSystemCheckbox_CheckedChanged);
            // 
            // OntologySettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(341, 322);
            this.Controls.Add(this.useForNoneSystemCheckbox);
            this.Controls.Add(this.loadInfo);
            this.Controls.Add(this.loadButton);
            this.Controls.Add(this.findButton);
            this.Controls.Add(this.ontologyPathInput);
            this.Name = "OntologySettings";
            this.Text = "Ontology";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox ontologyPathInput;
        private System.Windows.Forms.Button findButton;
        private System.Windows.Forms.Button loadButton;
        private System.Windows.Forms.TextBox loadInfo;
        private System.Windows.Forms.CheckBox useForNoneSystemCheckbox;
    }
}