namespace TemplateBuilder
{
    partial class TemplateBuilder
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TemplateBuilder));
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.xmlInput = new System.Windows.Forms.TextBox();
            this.xsltInput = new System.Windows.Forms.TextBox();
            this.renderOutput = new System.Windows.Forms.WebBrowser();
            this.loadButton = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
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
            this.splitContainer1.Panel1.Controls.Add(this.xsltInput);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer2);
            this.splitContainer1.Size = new System.Drawing.Size(1052, 621);
            this.splitContainer1.SplitterDistance = 512;
            this.splitContainer1.TabIndex = 0;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.textBox1);
            this.splitContainer2.Panel1.Controls.Add(this.loadButton);
            this.splitContainer2.Panel1.Controls.Add(this.xmlInput);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.renderOutput);
            this.splitContainer2.Size = new System.Drawing.Size(536, 621);
            this.splitContainer2.SplitterDistance = 231;
            this.splitContainer2.TabIndex = 0;
            // 
            // xmlInput
            // 
            this.xmlInput.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.xmlInput.Location = new System.Drawing.Point(0, 0);
            this.xmlInput.Multiline = true;
            this.xmlInput.Name = "xmlInput";
            this.xmlInput.Size = new System.Drawing.Size(533, 200);
            this.xmlInput.TabIndex = 0;
            this.xmlInput.Text = resources.GetString("xmlInput.Text");
            // 
            // xsltInput
            // 
            this.xsltInput.BackColor = System.Drawing.Color.Black;
            this.xsltInput.Dock = System.Windows.Forms.DockStyle.Fill;
            this.xsltInput.Font = new System.Drawing.Font("Lucida Console", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xsltInput.ForeColor = System.Drawing.SystemColors.InactiveCaption;
            this.xsltInput.Location = new System.Drawing.Point(0, 0);
            this.xsltInput.Multiline = true;
            this.xsltInput.Name = "xsltInput";
            this.xsltInput.Size = new System.Drawing.Size(512, 621);
            this.xsltInput.TabIndex = 1;
            this.xsltInput.Text = resources.GetString("xsltInput.Text");
            // 
            // renderOutput
            // 
            this.renderOutput.Dock = System.Windows.Forms.DockStyle.Fill;
            this.renderOutput.Location = new System.Drawing.Point(0, 0);
            this.renderOutput.MinimumSize = new System.Drawing.Size(20, 20);
            this.renderOutput.Name = "renderOutput";
            this.renderOutput.Size = new System.Drawing.Size(536, 386);
            this.renderOutput.TabIndex = 0;
            // 
            // loadButton
            // 
            this.loadButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.loadButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.loadButton.Location = new System.Drawing.Point(3, 205);
            this.loadButton.Name = "loadButton";
            this.loadButton.Size = new System.Drawing.Size(89, 20);
            this.loadButton.TabIndex = 1;
            this.loadButton.Text = "Load from server";
            this.loadButton.UseVisualStyleBackColor = true;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(98, 205);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(434, 20);
            this.textBox1.TabIndex = 2;
            this.textBox1.Text = "http://localhost:8008/service/xml/case/random";
            // 
            // TemplateBuilder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1052, 621);
            this.Controls.Add(this.splitContainer1);
            this.Name = "TemplateBuilder";
            this.Text = "Form1";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel1.PerformLayout();
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TextBox xsltInput;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.Button loadButton;
        private System.Windows.Forms.TextBox xmlInput;
        private System.Windows.Forms.WebBrowser renderOutput;
        private System.Windows.Forms.TextBox textBox1;
    }
}

