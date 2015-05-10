namespace OntologyEditor
{
    partial class TestSpreadsheetImportTool
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
            this.pasteButton = new System.Windows.Forms.Button();
            this.writeButton = new System.Windows.Forms.Button();
            this.gridPanel = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // pasteButton
            // 
            this.pasteButton.Location = new System.Drawing.Point(24, 23);
            this.pasteButton.Margin = new System.Windows.Forms.Padding(6);
            this.pasteButton.Name = "pasteButton";
            this.pasteButton.Size = new System.Drawing.Size(236, 44);
            this.pasteButton.TabIndex = 1;
            this.pasteButton.Text = "Import from clipboard";
            this.pasteButton.UseVisualStyleBackColor = true;
            this.pasteButton.Click += new System.EventHandler(this.pasteButton_Click);
            // 
            // writeButton
            // 
            this.writeButton.Enabled = false;
            this.writeButton.Location = new System.Drawing.Point(269, 23);
            this.writeButton.Name = "writeButton";
            this.writeButton.Size = new System.Drawing.Size(177, 44);
            this.writeButton.TabIndex = 2;
            this.writeButton.Text = "Write ontology";
            this.writeButton.UseVisualStyleBackColor = true;
            this.writeButton.Click += new System.EventHandler(this.writeButton_Click);
            // 
            // gridPanel
            // 
            this.gridPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gridPanel.Location = new System.Drawing.Point(1, 90);
            this.gridPanel.Name = "gridPanel";
            this.gridPanel.Size = new System.Drawing.Size(2151, 1004);
            this.gridPanel.TabIndex = 3;
            // 
            // TestSpreadsheetImportTool
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(2152, 1094);
            this.Controls.Add(this.gridPanel);
            this.Controls.Add(this.writeButton);
            this.Controls.Add(this.pasteButton);
            this.Margin = new System.Windows.Forms.Padding(6);
            this.Name = "TestSpreadsheetImportTool";
            this.Text = "Test import tool";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button pasteButton;
        private System.Windows.Forms.Button writeButton;
        private System.Windows.Forms.Panel gridPanel;
    }
}