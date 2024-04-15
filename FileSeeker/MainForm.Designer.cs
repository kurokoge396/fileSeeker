namespace FileSeeker
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            label1 = new Label();
            FolderTextBox = new TextBox();
            button1 = new Button();
            button2 = new Button();
            FileOperationButton = new Button();
            FileImageList = new ImageList(components);
            FileDisplayButton = new Button();
            ListView = new ListView();
            SelectFolderButton = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(28, 9);
            label1.Name = "label1";
            label1.Size = new Size(68, 15);
            label1.TabIndex = 0;
            label1.Text = "ファイルサーチ";
            // 
            // FolderTextBox
            // 
            FolderTextBox.Location = new Point(28, 33);
            FolderTextBox.Name = "FolderTextBox";
            FolderTextBox.Size = new Size(489, 23);
            FolderTextBox.TabIndex = 1;
            FolderTextBox.TextChanged += FolderTextBox_TextChanged;
            // 
            // button1
            // 
            button1.Location = new Point(532, 64);
            button1.Name = "button1";
            button1.Size = new Size(100, 30);
            button1.TabIndex = 2;
            button1.Text = "フォルダパス追加";
            button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            button2.Location = new Point(638, 64);
            button2.Name = "button2";
            button2.Size = new Size(100, 30);
            button2.TabIndex = 3;
            button2.Text = "フォルダパス削除";
            button2.UseVisualStyleBackColor = true;
            // 
            // FileOperationButton
            // 
            FileOperationButton.Location = new Point(744, 64);
            FileOperationButton.Name = "FileOperationButton";
            FileOperationButton.Size = new Size(100, 30);
            FileOperationButton.TabIndex = 4;
            FileOperationButton.Text = "ファイル操作";
            FileOperationButton.UseVisualStyleBackColor = true;
            FileOperationButton.Click += FileOperationButton_Click;
            // 
            // FileImageList
            // 
            FileImageList.ColorDepth = ColorDepth.Depth32Bit;
            FileImageList.ImageSize = new Size(160, 90);
            FileImageList.TransparentColor = Color.Transparent;
            // 
            // FileDisplayButton
            // 
            FileDisplayButton.Enabled = false;
            FileDisplayButton.Location = new Point(532, 28);
            FileDisplayButton.Name = "FileDisplayButton";
            FileDisplayButton.Size = new Size(100, 30);
            FileDisplayButton.TabIndex = 5;
            FileDisplayButton.Text = "ファイル表示";
            FileDisplayButton.UseVisualStyleBackColor = true;
            FileDisplayButton.Click += FileDisplayButton_Click;
            // 
            // ListView
            // 
            ListView.LargeImageList = FileImageList;
            ListView.Location = new Point(28, 97);
            ListView.Name = "ListView";
            ListView.Size = new Size(886, 388);
            ListView.TabIndex = 6;
            ListView.UseCompatibleStateImageBehavior = false;
            // 
            // SelectFolderButton
            // 
            SelectFolderButton.Location = new Point(28, 61);
            SelectFolderButton.Name = "SelectFolderButton";
            SelectFolderButton.Size = new Size(100, 30);
            SelectFolderButton.TabIndex = 7;
            SelectFolderButton.Text = "フォルダ選択";
            SelectFolderButton.UseVisualStyleBackColor = true;
            SelectFolderButton.Click += SelectFolderButton_Click;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(947, 497);
            Controls.Add(SelectFolderButton);
            Controls.Add(ListView);
            Controls.Add(FileDisplayButton);
            Controls.Add(FileOperationButton);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(FolderTextBox);
            Controls.Add(label1);
            Name = "MainForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Form1";
            FormClosed += MainForm_FormClosed;
            Load += MainForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label label1;
        private TextBox FolderTextBox;
        private Button button1;
        private Button button2;
        private Button FileOperationButton;
        private ListView listView1;
        private ImageList FileImageList;
        private Button FileButton;
        private Button FileDisplayButton;
        private ListView ListView;
        private Button SelectFolderButton;
    }
}
