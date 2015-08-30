namespace cbox.modelling.editors
{
    partial class LogicNodeEditor
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.allSelect = new System.Windows.Forms.RadioButton();
            this.eitherSelect = new System.Windows.Forms.RadioButton();
            this.neitherSelect = new System.Windows.Forms.RadioButton();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.neitherSelect);
            this.groupBox1.Controls.Add(this.eitherSelect);
            this.groupBox1.Controls.Add(this.allSelect);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(4, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(788, 636);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Logic node";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Logic:";
            // 
            // allSelect
            // 
            this.allSelect.AutoSize = true;
            this.allSelect.Location = new System.Drawing.Point(58, 28);
            this.allSelect.Name = "allSelect";
            this.allSelect.Size = new System.Drawing.Size(68, 21);
            this.allSelect.TabIndex = 1;
            this.allSelect.TabStop = true;
            this.allSelect.Text = "All of..";
            this.allSelect.UseVisualStyleBackColor = true;
            // 
            // eitherSelect
            // 
            this.eitherSelect.AutoSize = true;
            this.eitherSelect.Location = new System.Drawing.Point(58, 55);
            this.eitherSelect.Name = "eitherSelect";
            this.eitherSelect.Size = new System.Drawing.Size(90, 21);
            this.eitherSelect.TabIndex = 2;
            this.eitherSelect.TabStop = true;
            this.eitherSelect.Text = "Either of..";
            this.eitherSelect.UseVisualStyleBackColor = true;
            // 
            // neitherSelect
            // 
            this.neitherSelect.AutoSize = true;
            this.neitherSelect.Location = new System.Drawing.Point(58, 82);
            this.neitherSelect.Name = "neitherSelect";
            this.neitherSelect.Size = new System.Drawing.Size(87, 21);
            this.neitherSelect.TabIndex = 3;
            this.neitherSelect.TabStop = true;
            this.neitherSelect.Text = "None of..";
            this.neitherSelect.UseVisualStyleBackColor = true;
            // 
            // LogicNodeEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox1);
            this.Name = "LogicNodeEditor";
            this.Size = new System.Drawing.Size(795, 643);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton neitherSelect;
        private System.Windows.Forms.RadioButton eitherSelect;
        private System.Windows.Forms.RadioButton allSelect;
        private System.Windows.Forms.Label label1;
    }
}
