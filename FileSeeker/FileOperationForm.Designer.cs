namespace FileSeeker
{
    partial class FileOperationForm
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
            ExecuteButton = new Button();
            CancelButton = new Button();
            MoveRadioButton = new RadioButton();
            CoppyRadioButton = new RadioButton();
            DeleteRadioButton = new RadioButton();
            RadioGroupBox = new GroupBox();
            RadioGroupBox.SuspendLayout();
            SuspendLayout();
            // 
            // ExecuteButton
            // 
            ExecuteButton.Location = new Point(59, 141);
            ExecuteButton.Name = "ExecuteButton";
            ExecuteButton.Size = new Size(75, 23);
            ExecuteButton.TabIndex = 0;
            ExecuteButton.Text = "実行";
            ExecuteButton.UseVisualStyleBackColor = true;
            ExecuteButton.Click += ExecuteButton_Click;
            // 
            // CancelButton
            // 
            CancelButton.Location = new Point(140, 141);
            CancelButton.Name = "CancelButton";
            CancelButton.Size = new Size(75, 23);
            CancelButton.TabIndex = 1;
            CancelButton.Text = "キャンセル";
            CancelButton.UseVisualStyleBackColor = true;
            CancelButton.Click += CancelButton_Click;
            // 
            // MoveRadioButton
            // 
            MoveRadioButton.AutoSize = true;
            MoveRadioButton.Checked = true;
            MoveRadioButton.Location = new Point(16, 22);
            MoveRadioButton.Name = "MoveRadioButton";
            MoveRadioButton.Size = new Size(49, 19);
            MoveRadioButton.TabIndex = 2;
            MoveRadioButton.TabStop = true;
            MoveRadioButton.Text = "移動";
            MoveRadioButton.UseVisualStyleBackColor = true;
            // 
            // CoppyRadioButton
            // 
            CoppyRadioButton.AutoSize = true;
            CoppyRadioButton.Location = new Point(16, 47);
            CoppyRadioButton.Name = "CoppyRadioButton";
            CoppyRadioButton.Size = new Size(50, 19);
            CoppyRadioButton.TabIndex = 3;
            CoppyRadioButton.TabStop = true;
            CoppyRadioButton.Text = "コピー";
            CoppyRadioButton.UseVisualStyleBackColor = true;
            // 
            // DeleteRadioButton
            // 
            DeleteRadioButton.AutoSize = true;
            DeleteRadioButton.Location = new Point(16, 72);
            DeleteRadioButton.Name = "DeleteRadioButton";
            DeleteRadioButton.Size = new Size(49, 19);
            DeleteRadioButton.TabIndex = 4;
            DeleteRadioButton.TabStop = true;
            DeleteRadioButton.Text = "削除";
            DeleteRadioButton.UseVisualStyleBackColor = true;
            // 
            // RadioGroupBox
            // 
            RadioGroupBox.Controls.Add(MoveRadioButton);
            RadioGroupBox.Controls.Add(DeleteRadioButton);
            RadioGroupBox.Controls.Add(CoppyRadioButton);
            RadioGroupBox.Location = new Point(25, 22);
            RadioGroupBox.Name = "RadioGroupBox";
            RadioGroupBox.Size = new Size(183, 113);
            RadioGroupBox.TabIndex = 5;
            RadioGroupBox.TabStop = false;
            RadioGroupBox.Text = "ファイル操作選択";
            // 
            // FileOperationForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(227, 178);
            Controls.Add(RadioGroupBox);
            Controls.Add(CancelButton);
            Controls.Add(ExecuteButton);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "FileOperationForm";
            Text = "ファイル操作";
            RadioGroupBox.ResumeLayout(false);
            RadioGroupBox.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Button ExecuteButton;
        private Button CancelButton;
        private RadioButton MoveRadioButton;
        private RadioButton CoppyRadioButton;
        private RadioButton DeleteRadioButton;
        private GroupBox RadioGroupBox;
    }
}