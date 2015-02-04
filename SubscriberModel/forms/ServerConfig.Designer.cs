namespace OntologyEditor
{
    partial class ServerConfig
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ServerConfig));
            this.applyButton = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.serverInfoText = new System.Windows.Forms.RichTextBox();
            this.serverRootPick = new System.Windows.Forms.Button();
            this.serverRootInput = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.autoLoadCheckbox = new System.Windows.Forms.CheckBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // applyButton
            // 
            this.applyButton.Location = new System.Drawing.Point(258, 248);
            this.applyButton.Name = "applyButton";
            this.applyButton.Size = new System.Drawing.Size(75, 23);
            this.applyButton.TabIndex = 0;
            this.applyButton.Text = "Apply";
            this.applyButton.UseVisualStyleBackColor = true;
            this.applyButton.Click += new System.EventHandler(this.applyButton_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.autoLoadCheckbox);
            this.groupBox1.Controls.Add(this.serverInfoText);
            this.groupBox1.Controls.Add(this.serverRootPick);
            this.groupBox1.Controls.Add(this.serverRootInput);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(13, 13);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(320, 229);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Files";
            // 
            // serverInfoText
            // 
            this.serverInfoText.BackColor = System.Drawing.Color.White;
            this.serverInfoText.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.serverInfoText.Location = new System.Drawing.Point(6, 99);
            this.serverInfoText.Name = "serverInfoText";
            this.serverInfoText.Size = new System.Drawing.Size(304, 124);
            this.serverInfoText.TabIndex = 10;
            this.serverInfoText.Text = resources.GetString("serverInfoText.Text");
            this.serverInfoText.LinkClicked += new System.Windows.Forms.LinkClickedEventHandler(this.serverInfoText_LinkClicked);
            // 
            // serverRootPick
            // 
            this.serverRootPick.Location = new System.Drawing.Point(251, 37);
            this.serverRootPick.Name = "serverRootPick";
            this.serverRootPick.Size = new System.Drawing.Size(60, 23);
            this.serverRootPick.TabIndex = 9;
            this.serverRootPick.Text = "Pick";
            this.serverRootPick.UseVisualStyleBackColor = true;
            this.serverRootPick.Click += new System.EventHandler(this.pickServerRoot);
            // 
            // serverRootInput
            // 
            this.serverRootInput.FormattingEnabled = true;
            this.serverRootInput.Location = new System.Drawing.Point(6, 39);
            this.serverRootInput.Name = "serverRootInput";
            this.serverRootInput.Size = new System.Drawing.Size(239, 21);
            this.serverRootInput.TabIndex = 7;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Server root:";
            // 
            // autoLoadCheckbox
            // 
            this.autoLoadCheckbox.AutoSize = true;
            this.autoLoadCheckbox.Location = new System.Drawing.Point(7, 67);
            this.autoLoadCheckbox.Name = "autoLoadCheckbox";
            this.autoLoadCheckbox.Size = new System.Drawing.Size(200, 17);
            this.autoLoadCheckbox.TabIndex = 11;
            this.autoLoadCheckbox.Text = "Automatically load when server starts";
            this.autoLoadCheckbox.UseVisualStyleBackColor = true;
            // 
            // ServerConfig
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(345, 283);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.applyButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "ServerConfig";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "Server configuration";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button applyButton;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RichTextBox serverInfoText;
        private System.Windows.Forms.Button serverRootPick;
        private System.Windows.Forms.ComboBox serverRootInput;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox autoLoadCheckbox;
    }
}