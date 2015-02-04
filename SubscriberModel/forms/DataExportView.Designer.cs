namespace OntologyEditor
{
    partial class DataExportView
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
            this.dataView = new System.Windows.Forms.TextBox();
            this.saveButton = new System.Windows.Forms.Button();
            this.pickFileButton = new System.Windows.Forms.Button();
            this.fileLocationInput = new System.Windows.Forms.ComboBox();
            this.commentLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // dataView
            // 
            this.dataView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataView.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(20)))), ((int)(((byte)(30)))));
            this.dataView.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dataView.ForeColor = System.Drawing.Color.White;
            this.dataView.Location = new System.Drawing.Point(13, 29);
            this.dataView.Multiline = true;
            this.dataView.Name = "dataView";
            this.dataView.Size = new System.Drawing.Size(481, 523);
            this.dataView.TabIndex = 0;
            // 
            // saveButton
            // 
            this.saveButton.Location = new System.Drawing.Point(419, 558);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(75, 23);
            this.saveButton.TabIndex = 2;
            this.saveButton.Text = "Save";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // pickFileButton
            // 
            this.pickFileButton.Location = new System.Drawing.Point(339, 558);
            this.pickFileButton.Name = "pickFileButton";
            this.pickFileButton.Size = new System.Drawing.Size(75, 23);
            this.pickFileButton.TabIndex = 2;
            this.pickFileButton.Text = "Pick";
            this.pickFileButton.UseVisualStyleBackColor = true;
            this.pickFileButton.Click += new System.EventHandler(this.pickFileButton_Click);
            // 
            // fileLocationInput
            // 
            this.fileLocationInput.FormattingEnabled = true;
            this.fileLocationInput.Location = new System.Drawing.Point(13, 558);
            this.fileLocationInput.Name = "fileLocationInput";
            this.fileLocationInput.Size = new System.Drawing.Size(320, 21);
            this.fileLocationInput.TabIndex = 3;
            // 
            // commentLabel
            // 
            this.commentLabel.AutoSize = true;
            this.commentLabel.Location = new System.Drawing.Point(13, 13);
            this.commentLabel.Name = "commentLabel";
            this.commentLabel.Size = new System.Drawing.Size(35, 13);
            this.commentLabel.TabIndex = 4;
            this.commentLabel.Text = "label1";
            // 
            // DataExportView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(506, 589);
            this.Controls.Add(this.commentLabel);
            this.Controls.Add(this.fileLocationInput);
            this.Controls.Add(this.pickFileButton);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.dataView);
            this.Name = "DataExportView";
            this.Text = "Export data preview";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox dataView;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.Button pickFileButton;
        private System.Windows.Forms.ComboBox fileLocationInput;
        private System.Windows.Forms.Label commentLabel;
    }
}