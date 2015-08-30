namespace cbox.modelling.editors
{
    partial class ConsequenceNodeEditor
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
            this.sumOfSelect = new System.Windows.Forms.RadioButton();
            this.unmatchedCommentInput = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.matchedCommentInput = new System.Windows.Forms.TextBox();
            this.commentSelect = new System.Windows.Forms.RadioButton();
            this.failSelect = new System.Windows.Forms.RadioButton();
            this.highestOfSelect = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.groupInput = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.groupInput);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.sumOfSelect);
            this.groupBox1.Controls.Add(this.unmatchedCommentInput);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.matchedCommentInput);
            this.groupBox1.Controls.Add(this.commentSelect);
            this.groupBox1.Controls.Add(this.failSelect);
            this.groupBox1.Controls.Add(this.highestOfSelect);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(4, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(630, 487);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Consequence node";
            // 
            // sumOfSelect
            // 
            this.sumOfSelect.AutoSize = true;
            this.sumOfSelect.Location = new System.Drawing.Point(243, 26);
            this.sumOfSelect.Name = "sumOfSelect";
            this.sumOfSelect.Size = new System.Drawing.Size(106, 21);
            this.sumOfSelect.TabIndex = 20;
            this.sumOfSelect.TabStop = true;
            this.sumOfSelect.Text = "Get sum of..";
            this.sumOfSelect.UseVisualStyleBackColor = true;
            // 
            // unmatchedCommentInput
            // 
            this.unmatchedCommentInput.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.unmatchedCommentInput.Location = new System.Drawing.Point(9, 312);
            this.unmatchedCommentInput.Multiline = true;
            this.unmatchedCommentInput.Name = "unmatchedCommentInput";
            this.unmatchedCommentInput.Size = new System.Drawing.Size(615, 169);
            this.unmatchedCommentInput.TabIndex = 19;
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 292);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(164, 17);
            this.label4.TabIndex = 18;
            this.label4.Text = "Comment if not matched:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 88);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(140, 17);
            this.label3.TabIndex = 17;
            this.label3.Text = "Comment if matched:";
            // 
            // matchedCommentInput
            // 
            this.matchedCommentInput.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.matchedCommentInput.Location = new System.Drawing.Point(9, 108);
            this.matchedCommentInput.Multiline = true;
            this.matchedCommentInput.Name = "matchedCommentInput";
            this.matchedCommentInput.Size = new System.Drawing.Size(615, 181);
            this.matchedCommentInput.TabIndex = 16;
            // 
            // commentSelect
            // 
            this.commentSelect.AutoSize = true;
            this.commentSelect.Location = new System.Drawing.Point(444, 26);
            this.commentSelect.Name = "commentSelect";
            this.commentSelect.Size = new System.Drawing.Size(116, 21);
            this.commentSelect.TabIndex = 13;
            this.commentSelect.TabStop = true;
            this.commentSelect.Text = "Comment on..";
            this.commentSelect.UseVisualStyleBackColor = true;
            // 
            // failSelect
            // 
            this.failSelect.AutoSize = true;
            this.failSelect.Location = new System.Drawing.Point(359, 26);
            this.failSelect.Name = "failSelect";
            this.failSelect.Size = new System.Drawing.Size(79, 21);
            this.failSelect.TabIndex = 12;
            this.failSelect.TabStop = true;
            this.failSelect.Text = "Fail on..";
            this.failSelect.UseVisualStyleBackColor = true;
            // 
            // highestOfSelect
            // 
            this.highestOfSelect.AutoSize = true;
            this.highestOfSelect.Location = new System.Drawing.Point(111, 26);
            this.highestOfSelect.Name = "highestOfSelect";
            this.highestOfSelect.Size = new System.Drawing.Size(126, 21);
            this.highestOfSelect.TabIndex = 11;
            this.highestOfSelect.TabStop = true;
            this.highestOfSelect.Text = "Get highest of..";
            this.highestOfSelect.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(99, 17);
            this.label1.TabIndex = 10;
            this.label1.Text = "Consequence:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 56);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 17);
            this.label2.TabIndex = 21;
            this.label2.Text = "Group:";
            // 
            // groupInput
            // 
            this.groupInput.Location = new System.Drawing.Point(64, 53);
            this.groupInput.Name = "groupInput";
            this.groupInput.Size = new System.Drawing.Size(155, 22);
            this.groupInput.TabIndex = 22;
            // 
            // ConsequenceNodeEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox1);
            this.Name = "ConsequenceNodeEditor";
            this.Size = new System.Drawing.Size(637, 494);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox unmatchedCommentInput;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox matchedCommentInput;
        private System.Windows.Forms.RadioButton commentSelect;
        private System.Windows.Forms.RadioButton failSelect;
        private System.Windows.Forms.RadioButton highestOfSelect;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RadioButton sumOfSelect;
        private System.Windows.Forms.TextBox groupInput;
        private System.Windows.Forms.Label label2;
    }
}
