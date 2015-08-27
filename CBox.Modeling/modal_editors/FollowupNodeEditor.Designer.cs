namespace cbox.modelling.editors
{
    partial class FollowupNodeEditor
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.answerDataGrid = new System.Windows.Forms.DataGridView();
            this.multipleChoiceSelect = new System.Windows.Forms.RadioButton();
            this.singleChoiceSelect = new System.Windows.Forms.RadioButton();
            this.questionInput = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.removeButton = new System.Windows.Forms.Button();
            this.newButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.applyButton = new System.Windows.Forms.Button();
            this.questionList = new System.Windows.Forms.ListBox();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.answerDataGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.questionList);
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.removeButton);
            this.panel1.Controls.Add(this.newButton);
            this.panel1.Location = new System.Drawing.Point(-3, -2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1081, 667);
            this.panel1.TabIndex = 5;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.answerDataGrid);
            this.groupBox1.Controls.Add(this.multipleChoiceSelect);
            this.groupBox1.Controls.Add(this.singleChoiceSelect);
            this.groupBox1.Controls.Add(this.questionInput);
            this.groupBox1.Location = new System.Drawing.Point(268, 23);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(796, 637);
            this.groupBox1.TabIndex = 14;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Question details";
            // 
            // answerDataGrid
            // 
            this.answerDataGrid.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.answerDataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.answerDataGrid.Location = new System.Drawing.Point(7, 164);
            this.answerDataGrid.Name = "answerDataGrid";
            this.answerDataGrid.RowTemplate.Height = 24;
            this.answerDataGrid.Size = new System.Drawing.Size(783, 467);
            this.answerDataGrid.TabIndex = 3;
            // 
            // multipleChoiceSelect
            // 
            this.multipleChoiceSelect.AutoSize = true;
            this.multipleChoiceSelect.Location = new System.Drawing.Point(126, 136);
            this.multipleChoiceSelect.Name = "multipleChoiceSelect";
            this.multipleChoiceSelect.Size = new System.Drawing.Size(122, 21);
            this.multipleChoiceSelect.TabIndex = 2;
            this.multipleChoiceSelect.TabStop = true;
            this.multipleChoiceSelect.Text = "Multiple choice";
            this.multipleChoiceSelect.UseVisualStyleBackColor = true;
            // 
            // singleChoiceSelect
            // 
            this.singleChoiceSelect.AutoSize = true;
            this.singleChoiceSelect.Location = new System.Drawing.Point(7, 136);
            this.singleChoiceSelect.Name = "singleChoiceSelect";
            this.singleChoiceSelect.Size = new System.Drawing.Size(113, 21);
            this.singleChoiceSelect.TabIndex = 1;
            this.singleChoiceSelect.TabStop = true;
            this.singleChoiceSelect.Text = "Single choice";
            this.singleChoiceSelect.UseVisualStyleBackColor = true;
            // 
            // questionInput
            // 
            this.questionInput.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.questionInput.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.questionInput.Location = new System.Drawing.Point(7, 22);
            this.questionInput.Multiline = true;
            this.questionInput.Name = "questionInput";
            this.questionInput.Size = new System.Drawing.Size(783, 107);
            this.questionInput.TabIndex = 0;
            this.questionInput.Text = "Question text";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(7, 10);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(79, 17);
            this.label5.TabIndex = 12;
            this.label5.Text = "Quiestions:";
            // 
            // removeButton
            // 
            this.removeButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.removeButton.Location = new System.Drawing.Point(44, 637);
            this.removeButton.Name = "removeButton";
            this.removeButton.Size = new System.Drawing.Size(28, 23);
            this.removeButton.TabIndex = 3;
            this.removeButton.Text = "-";
            this.removeButton.UseVisualStyleBackColor = true;
            this.removeButton.Click += new System.EventHandler(this.removeButton_Click);
            // 
            // newButton
            // 
            this.newButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.newButton.Location = new System.Drawing.Point(10, 637);
            this.newButton.Name = "newButton";
            this.newButton.Size = new System.Drawing.Size(28, 23);
            this.newButton.TabIndex = 1;
            this.newButton.Text = "+";
            this.newButton.UseVisualStyleBackColor = true;
            this.newButton.Click += new System.EventHandler(this.newButton_Click);
            // 
            // cancelButton
            // 
            this.cancelButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cancelButton.Location = new System.Drawing.Point(983, 671);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(80, 29);
            this.cancelButton.TabIndex = 4;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // applyButton
            // 
            this.applyButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.applyButton.Location = new System.Drawing.Point(893, 671);
            this.applyButton.Name = "applyButton";
            this.applyButton.Size = new System.Drawing.Size(84, 29);
            this.applyButton.TabIndex = 3;
            this.applyButton.Text = "Apply";
            this.applyButton.UseVisualStyleBackColor = true;
            this.applyButton.Click += new System.EventHandler(this.applyButton_Click);
            // 
            // questionList
            // 
            this.questionList.FormattingEnabled = true;
            this.questionList.ItemHeight = 16;
            this.questionList.Location = new System.Drawing.Point(10, 30);
            this.questionList.Name = "questionList";
            this.questionList.Size = new System.Drawing.Size(252, 596);
            this.questionList.TabIndex = 15;
            // 
            // FollowupNodeEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1075, 711);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.applyButton);
            this.Name = "FollowupNodeEditor";
            this.Text = "Followup node editor";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.answerDataGrid)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView answerDataGrid;
        private System.Windows.Forms.RadioButton multipleChoiceSelect;
        private System.Windows.Forms.RadioButton singleChoiceSelect;
        private System.Windows.Forms.TextBox questionInput;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button removeButton;
        private System.Windows.Forms.Button newButton;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Button applyButton;
        private System.Windows.Forms.ListBox questionList;
    }
}