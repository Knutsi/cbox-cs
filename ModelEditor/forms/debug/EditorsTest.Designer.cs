namespace ModelEditor
{
    partial class EditorsTest
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
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.flowLayout = new System.Windows.Forms.FlowLayoutPanel();
            this.xmlSaveOutput = new System.Windows.Forms.TextBox();
            this.handlerDataXml = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.flowLayout);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.handlerDataXml);
            this.splitContainer1.Panel2.Controls.Add(this.xmlSaveOutput);
            this.splitContainer1.Size = new System.Drawing.Size(993, 741);
            this.splitContainer1.SplitterDistance = 742;
            this.splitContainer1.TabIndex = 0;
            // 
            // flowLayout
            // 
            this.flowLayout.AutoScroll = true;
            this.flowLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayout.Location = new System.Drawing.Point(0, 0);
            this.flowLayout.Name = "flowLayout";
            this.flowLayout.Size = new System.Drawing.Size(742, 741);
            this.flowLayout.TabIndex = 1;
            // 
            // xmlSaveOutput
            // 
            this.xmlSaveOutput.Location = new System.Drawing.Point(3, 0);
            this.xmlSaveOutput.Multiline = true;
            this.xmlSaveOutput.Name = "xmlSaveOutput";
            this.xmlSaveOutput.Size = new System.Drawing.Size(247, 223);
            this.xmlSaveOutput.TabIndex = 0;
            // 
            // handlerDataXml
            // 
            this.handlerDataXml.Location = new System.Drawing.Point(3, 229);
            this.handlerDataXml.Multiline = true;
            this.handlerDataXml.Name = "handlerDataXml";
            this.handlerDataXml.Size = new System.Drawing.Size(247, 509);
            this.handlerDataXml.TabIndex = 1;
            // 
            // EditorsTest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(993, 741);
            this.Controls.Add(this.splitContainer1);
            this.Name = "EditorsTest";
            this.Text = "EditorsTest";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.FlowLayoutPanel flowLayout;
        private System.Windows.Forms.TextBox xmlSaveOutput;
        private System.Windows.Forms.TextBox handlerDataXml;

    }
}