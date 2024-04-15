namespace TestFrom
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // �t�H���_���̉摜���擾
            var imgList = GetImgPathList(@"F:\test");

            // �摜��\������
            SetImgList(imgList);

            // �������b�Z�[�W��\������
            MessageBox.Show("�ǂݍ��݊���");

        }

        private IEnumerable<string> GetImgPathList(string path)
        {
            var list = Directory.GetFiles(path, "*", SearchOption.AllDirectories).Where(t => t.EndsWith(".png") || t.EndsWith(".jpg") || t.EndsWith(".jpeg"));

            if (!list.Any())
            {
                return null;
            }
            else
            {
                return list;
            }
        }

        private void SetImgList(IEnumerable<string> imgPathList)
        {
            var i = 0;
            foreach (string imgPath in imgPathList)
            {
                //�摜��ǂݍ���
                Image img = Image.FromFile(imgPath);
                //ImageList �ɉ摜��ǉ�
                ImageList.Images.Add(img);
                //ListView �ɉ摜��ǉ�
                ImgListView.Items.Add(imgPath, i);
                //�摜��j��
                img.Dispose();
                i++;
            }
        }

        private void ImgListView_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            // sender ���_�u���N���b�N���ꂽ����
            var selectItem = ImgListView.SelectedItems[0];


            // �f�[�^�o�C���f�B���O���g���Ă���Ȃ�A
            // DataContext ����f�[�^���擾�ł���
            //var p = targetItem.Text;
            var aaa = 1;
        }

        private void ImgListView_ItemActivate(object sender, EventArgs e)
        {
            var selectItem = ImgListView.SelectedItems[0];
            var selectItems = ImgListView.SelectedItems;
            var aaaaaaaaa = ImgListView.Items;

            foreach (var item in selectItems)
            {
            }

            ImageFileOpen(selectItem.Text);

            var aaa = 1;
        }

        /// <summary>
        /// �t�@�C���p�X���w�肵�ĉ摜�t�@�C�����J��
        /// </summary>
        /// <param name="fileName">�摜�t�@�C���̃t�@�C���p�X���w�肵�܂��B</param>
        /// <returns>��������Bitmap�N���X�I�u�W�F�N�g</returns>
        private Bitmap ImageFileOpen(string fileName)
        {
            // �w�肵���t�@�C�������݂��邩�H�m�F
            if (System.IO.File.Exists(fileName) == false) return null;

            // �g���q�̊m�F
            var ext = System.IO.Path.GetExtension(fileName).ToLower();

            // �t�@�C���̊g���q���Ή����Ă���t�@�C�����ǂ������ׂ�
            if (
                (ext != ".bmp") &&
                (ext != ".jpg") &&
                (ext != ".png") &&
                (ext != ".tif")
                )
            {
                return null;
            }

            Bitmap bmp;

            // �t�@�C���X�g���[���Ńt�@�C�����J��
            using (var fs = new System.IO.FileStream(
                fileName,
                System.IO.FileMode.Open,
                System.IO.FileAccess.Read))
            {
                bmp = new Bitmap(fs);
            }
            return bmp;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var selectItem = ImgListView.SelectedItems[0];
            var selectItems = ImgListView.SelectedItems;
            var aaaaaaaaa = ImgListView.Items;

            foreach (ListViewItem item in selectItems)
            {

            }

            ImageFileOpen(selectItem.Text);

            var aaa = 1;
        }
    }
}
