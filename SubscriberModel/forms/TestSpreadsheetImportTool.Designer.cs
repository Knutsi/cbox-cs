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
            this.importLog = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // pasteButton
            // 
            this.pasteButton.Location = new System.Drawing.Point(12, 12);
            this.pasteButton.Name = "pasteButton";
            this.pasteButton.Size = new System.Drawing.Size(118, 23);
            this.pasteButton.TabIndex = 1;
            this.pasteButton.Text = "Import from clipboard";
            this.pasteButton.UseVisualStyleBackColor = true;
            this.pasteButton.Click += new System.EventHandler(this.pasteButton_Click);
            // 
            // writeButton
            // 
            this.writeButton.Enabled = false;
            this.writeButton.Location = new System.Drawing.Point(134, 12);
            this.writeButton.Margin = new System.Windows.Forms.Padding(2);
            this.writeButton.Name = "writeButton";
            this.writeButton.Size = new System.Drawing.Size(88, 23);
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
            this.gridPanel.Location = new System.Drawing.Point(0, 47);
            this.gridPanel.Margin = new System.Windows.Forms.Padding(2);
            this.gridPanel.Name = "gridPanel";
            this.gridPanel.Size = new System.Drawing.Size(729, 555);
            this.gridPanel.TabIndex = 3;
            // 
            // importLog
            // 
            this.importLog.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.importLog.BackColor = System.Drawing.Color.Navy;
            this.importLog.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.importLog.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.importLog.ForeColor = System.Drawing.Color.White;
            this.importLog.Location = new System.Drawing.Point(734, 47);
            this.importLog.Multiline = true;
            this.importLog.Name = "importLog";
            this.importLog.Size = new System.Drawing.Size(211, 555);
            this.importLog.TabIndex = 4;
            this.importLog.Text = "<Unset>";
            // 
            // TestSpreadsheetImportTool
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(946, 603);
            this.Controls.Add(this.importLog);
            this.Controls.Add(this.gridPanel);
            this.Controls.Add(this.writeButton);
            this.Controls.Add(this.pasteButton);
            this.Name = "TestSpreadsheetImportTool";
            this.Text = "Test import tool";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button pasteButton;
        private System.Windows.Forms.Button writeButton;
        private System.Windows.Forms.Panel gridPanel;
        private System.Windows.Forms.TextBox importLog;
    }
}