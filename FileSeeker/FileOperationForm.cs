using CommonProcess.Exceptions;

namespace FileSeeker
{
    public partial class FileOperationForm : Form
    {
        /// <summary>
        /// 処理クラスのインターフェイス
        /// </summary>
        private IProcessor Processor;

        /// <summary>
        /// 画像ファイルパスリスト
        /// </summary>
        private readonly IEnumerable<string> ImgPathList;

        public FileOperationForm(IProcessor processor, IEnumerable<string> imgPathList)
        {
            Processor = processor;
            ImgPathList = imgPathList;
            InitializeComponent();
        }

        /// <summary>
        /// 実行ボタン押下処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ExecuteButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (MoveRadioButton.Checked)
                {
                    Processor.MoveFiles(ImgPathList);
                }
                else if (CoppyRadioButton.Checked)
                {
                    Processor.CoppyFiles(ImgPathList);
                }
                else
                {
                    Processor.DeleteFiles(ImgPathList);
                }
            }
            catch (AppException ex)
            {
                ShowErrorMessageBox(ex.Message);
            }

            Close();
        }

        /// <summary>
        /// エラーメッセージボックスを表示する
        /// </summary>
        /// <param name="message">エラー内容</param>
        private void ShowErrorMessageBox(string message)
        {
            MessageBox.Show(message, "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        /// <summary>
        /// キャンセルボタン押下処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CancelButton_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
