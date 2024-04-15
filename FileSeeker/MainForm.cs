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

        /// <summary>
        /// �t�H�[���ǂݍ��ݎ�����
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainForm_Load(object sender, EventArgs e)
        {
            FolderTextBox.Text = Properties.Settings.Default.folderPath;
            if (!string.IsNullOrEmpty(FolderTextBox.Text))
            {
                SetImgList(processor.GetImgPathList(FolderTextBox.Text));
            }
        }

        /// <summary>
        /// �t�@�C������{�^����������
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FileOperationButton_Click(object sender, EventArgs e)
        {
            var fileList = GetSelectedItems();
            if (!fileList.Any())
            {
                MessageBox.Show("�摜��I�����Ă���t�@�C������{�^�����������Ă��������B", "�x��", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // �t�@�C�������ʂ�\��
            var fileOperationFrom = new FileOperationForm(processor, fileList);
            fileOperationFrom.ShowDialog();

            // ���X�g�r���[�ēǂݍ���
            ReloadListView();
        }

        /// <summary>
        /// ���X�g�r���[�Ƀt�@�C����\������
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FileDisplayButton_Click(object sender, EventArgs e)
        {
            ReloadListView();
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
            foreach (var imgPath in imgPathList)
            {
                //�摜��ǂݍ���
                Image img = Image.FromFile(imgPath);
                //ImageList �ɉ摜��ǉ�
                FileImageList.Images.Add(processor.SetImageDirection(img));
                //ListView �ɉ摜��ǉ�
                ListView.Items.Add(Path.GetFileName(imgPath), i);
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
        /// �I���������X�g�r���[�̉摜�t�@�C���̃p�X���X�g���擾����B
        /// </summary>
        /// <returns>�摜�t�@�C���̃p�X���X�g</returns>
        private IEnumerable<string> GetSelectedItems()
        {
            List<string> items = new List<string>();
            foreach (ListViewItem item in ListView.SelectedItems)
            {
                items.Add(Path.Combine(FolderTextBox.Text, item.Text));
            }

            return items;
        }

        /// <summary>
        /// ���X�g�r���[���ēǂݍ��݂���
        /// </summary>
        private void ReloadListView()
        {
            FileImageList.Images.Clear();
            ListView.Items.Clear();
            var filePaths = processor.GetImgPathList(FolderTextBox.Text);
            if (filePaths.Any())
            {
                SetImgList(filePaths);
            }
        }
    }
}
