namespace FileSeeker
{
    public partial class TestForm : Form
    {
        public TestForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // フォルダ内の画像を取得
            var imgList = GetImgPathList(@"F:\test");

            // 画像を表示する

            // 完了メッセージを表示する
            MessageBox.Show("読み込み完了");

        }

        private string[] GetImgPathList(string path)
        {
            var list = Directory.GetFiles(path, "*.jpg | *.png | *.jpeg", SearchOption.AllDirectories);

            if (!list.Any())
            {
                return null;
            }
            else
            {
                return list;
            }
        }
    }
}
