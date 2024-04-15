using CommonProcess;

namespace FileSeeker
{

    /// <summary>
    /// 処理クラスインターフェイス
    /// </summary>
    interface IProcessor
    {
        /// <summary>
        /// イメージファイルパスリスト取得
        /// </summary>
        /// <param name="path">フォルダパス</param>
        /// <returns>ファイルパスリスト</returns>
        public IEnumerable<string> GetImgPathList(string path);

        /// <summary>
        /// イメージファイルパスリスト取得
        /// </summary>
        /// <param name="path">フォルダパス</param>
        /// <returns>ファイルパスリスト</returns>
        public string GetFolderPath(string path);

        /// <summary>
        /// 画像の方向を修正する
        /// </summary>
        /// <param name="image">画像</param>
        /// <returns>方向を修正した画像</returns>
        public Image SetImageDirection(Image image);
    }

    /// <summary>
    /// 処理クラス
    /// </summary>
    public class Processor : IProcessor
    {
        /// <summary>
        /// 共通処理
        /// </summary>
        private ICommonMethods methods;

        /// <summary>
        /// 画像処理
        /// </summary>
        private IImageProcessor imageProcessor;

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public Processor()
        {
            // 共通処理のインスタンス作成
            methods = new CommonMethods();
            imageProcessor = new ImageProcessor();
        }

        /// <summary>
        /// イメージファイルパスリスト取得
        /// </summary>
        /// <param name="path">フォルダパス</param>
        /// <returns>ファイルパスリスト</returns>
        public IEnumerable<string> GetImgPathList(string path)
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

        /// <summary>
        /// フォルダー選択ダイアログ表示
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public string GetFolderPath(string path)
        {
            return methods.GetFolderPath(path);
        }

        /// <summary>
        /// 画像の方向を修正する
        /// </summary>
        /// <param name="image">画像</param>
        /// <returns>方向を修正した画像</returns>
        public Image SetImageDirection(Image image)
        {
            return imageProcessor.SetImageDirection(image);
        }
    }
}
