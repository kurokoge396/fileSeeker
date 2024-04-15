namespace FileSeeker
{
    public partial class MainForm : Form
    {

        /// <summary>
        /// 処理クラスのインターフェイス
        /// </summary>
        private IProcessor processor;

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public MainForm()
        {
            processor = new Processor();
            InitializeComponent();
        }

        private void FileOperationButton_Click(object sender, EventArgs e)
        {
            // ファイル操作画面を表示

        }

        /// <summary>
        /// リストビューにファイルを表示する
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FileDisplayButton_Click(object sender, EventArgs e)
        {
            SetImgList(processor.GetImgPathList(FolderTextBox.Text));
        }

        /// <summary>
        /// フォルダー選択ボタン押下処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SelectFolderButton_Click(object sender, EventArgs e)
        {
            // フォルダー選択ダイアログ表示
            GetFolderPath();
        }

        /// <summary>
        /// フォルダーパス取得処理
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
        /// リストビューに画像を表示する
        /// </summary>
        /// <param name="imgPathList">画像ファイルパスリスト</param>
        private void SetImgList(IEnumerable<string> imgPathList)
        {
            var i = 0;
            foreach (string imgPath in imgPathList)
            {
                //画像を読み込み
                Image img = Image.FromFile(imgPath);
                //ImageList に画像を追加
                FileImageList.Images.Add(processor.SetImageDirection(img));
                //ListView に画像を追加
                ListView.Items.Add(imgPath, i);
                //画像を破棄
                img.Dispose();
                i++;
            }
        }

        /// <summary>
        /// 画面を閉じるときの処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            // フォルダパス保存
            SaveItems();
        }

        /// <summary>
        /// フォルダパス保存処理
        /// </summary>
        private void SaveItems()
        {
            Properties.Settings.Default.folderPath = FolderTextBox.Text;
            Properties.Settings.Default.Save();
        }

        /// <summary>
        /// フォルダテキストボックスの値が変化したときの処理
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
        /// 保存したフォルダパスを読み込む
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainForm_Load(object sender, EventArgs e)
        {
            FolderTextBox.Text = Properties.Settings.Default.folderPath;
        }
    }
}
