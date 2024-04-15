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
            // フォルダ内の画像を取得
            var imgList = GetImgPathList(@"F:\test");

            // 画像を表示する
            SetImgList(imgList);

            // 完了メッセージを表示する
            MessageBox.Show("読み込み完了");

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
                //画像を読み込み
                Image img = Image.FromFile(imgPath);
                //ImageList に画像を追加
                ImageList.Images.Add(img);
                //ListView に画像を追加
                ImgListView.Items.Add(imgPath, i);
                //画像を破棄
                img.Dispose();
                i++;
            }
        }

        private void ImgListView_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            // sender がダブルクリックされた項目
            var selectItem = ImgListView.SelectedItems[0];


            // データバインディングを使っているなら、
            // DataContext からデータを取得できる
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
        /// ファイルパスを指定して画像ファイルを開く
        /// </summary>
        /// <param name="fileName">画像ファイルのファイルパスを指定します。</param>
        /// <returns>生成したBitmapクラスオブジェクト</returns>
        private Bitmap ImageFileOpen(string fileName)
        {
            // 指定したファイルが存在するか？確認
            if (System.IO.File.Exists(fileName) == false) return null;

            // 拡張子の確認
            var ext = System.IO.Path.GetExtension(fileName).ToLower();

            // ファイルの拡張子が対応しているファイルかどうか調べる
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

            // ファイルストリームでファイルを開く
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
