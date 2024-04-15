namespace FileSeeker
{
    public partial class MainForm : Form
    {

        /// <summary>
        /// �����N���X�̃C���^�[�t�F�C�X
        /// </summary>
        private IProcessor processor;

        /// <summary>
        /// �R���X�g���N�^
        /// </summary>
        public MainForm()
        {
            processor = new Processor();
            InitializeComponent();
        }

        private void FileOperationButton_Click(object sender, EventArgs e)
        {
            // �t�@�C�������ʂ�\��

        }

        /// <summary>
        /// ���X�g�r���[�Ƀt�@�C����\������
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FileDisplayButton_Click(object sender, EventArgs e)
        {
            SetImgList(processor.GetImgPathList(FolderTextBox.Text));
        }

        /// <summary>
        /// �t�H���_�[�I���{�^����������
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SelectFolderButton_Click(object sender, EventArgs e)
        {
            // �t�H���_�[�I���_�C�A���O�\��
            GetFolderPath();
        }

        /// <summary>
        /// �t�H���_�[�p�X�擾����
        /// </summary>
        private void GetFolderPath()
        {
            var path = processor.GetFolderPath(FolderTextBox.Text);
            if (!string.IsNullOrEmpty(path))
            {
                FolderTextBox.Text = path;
            }
        }

        /// <summary>
        /// ���X�g�r���[�ɉ摜��\������
        /// </summary>
        /// <param name="imgPathList">�摜�t�@�C���p�X���X�g</param>
        private void SetImgList(IEnumerable<string> imgPathList)
        {
            var i = 0;
            foreach (string imgPath in imgPathList)
            {
                //�摜��ǂݍ���
                Image img = Image.FromFile(imgPath);
                //ImageList �ɉ摜��ǉ�
                FileImageList.Images.Add(processor.SetImageDirection(img));
                //ListView �ɉ摜��ǉ�
                ListView.Items.Add(imgPath, i);
                //�摜��j��
                img.Dispose();
                i++;
            }
        }

        /// <summary>
        /// ��ʂ����Ƃ��̏���
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            // �t�H���_�p�X�ۑ�
            SaveItems();
        }

        /// <summary>
        /// �t�H���_�p�X�ۑ�����
        /// </summary>
        private void SaveItems()
        {
            Properties.Settings.Default.folderPath = FolderTextBox.Text;
            Properties.Settings.Default.Save();
        }

        /// <summary>
        /// �t�H���_�e�L�X�g�{�b�N�X�̒l���ω������Ƃ��̏���
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FolderTextBox_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(FolderTextBox.Text))
            {
                FileDisplayButton.Enabled = false;
            }
            else
            {
                FileDisplayButton.Enabled = true;
            }
        }

        /// <summary>
        /// �ۑ������t�H���_�p�X��ǂݍ���
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainForm_Load(object sender, EventArgs e)
        {
            FolderTextBox.Text = Properties.Settings.Default.folderPath;
        }
    }
}
