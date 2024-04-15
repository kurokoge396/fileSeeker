using CommonProcess;
using CommonProcess.Exceptions;

namespace FileSeeker
{

    /// <summary>
    /// 処理クラスインターフェイス
    /// </summary>
    public interface IProcessor
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

        /// <summary>
        /// ファイルを移動する
        /// </summary>
        /// <param name="filePathList">ファイルパスリスト</param>
        public void MoveFiles(IEnumerable<string> filePathList);

        /// <summary>
        /// ファイルをコピーする
        /// </summary>
        /// <param name="filePathList">ファイルパスリスト</param>
        public void CoppyFiles(IEnumerable<string> filePathList);

        /// <summary>
        /// ファイルを削除する
        /// </summary>
        /// <param name="filePathList">ファイルパスリスト</param>
        public void DeleteFiles(IEnumerable<string> filePathList);
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
            return Directory.GetFiles(path, "*", SearchOption.TopDirectoryOnly).Where(t => t.EndsWith(".png") || t.EndsWith(".jpg") || t.EndsWith(".jpeg"));
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

        /// <summary>
        /// ファイルを移動する
        /// </summary>
        /// <param name="filePathList">ファイルパスリスト</param>
        /// <exception cref="NotFileExitsException">ファイルエラー</exception>
        public void MoveFiles(IEnumerable<string> filePathList)
        {
            var errorList = new List<string>();

            // 移動先フォルダを選択させる
            var moveAtFolder = GetFolderPath(string.Empty);

            if (string.IsNullOrEmpty(moveAtFolder))
            {
                return;
            }

            foreach (var filePath in filePathList)
            {
                if (File.Exists(filePath))
                {
                    try
                    {
                        File.Move(filePath, Path.Combine(moveAtFolder, Path.GetFileName(filePath)));
                    }
                    catch (Exception)
                    {
                        errorList.Add(filePath);
                    }
                }
                else
                {
                    errorList.Add(filePath);
                }
            }

            if (errorList.Any())
            {
                // ファイル移動できていない
                throw new NotFileExitsException(errorList);
            }
            else
            {
                MessageBox.Show("ファイルを移動しました。");
            }
        }

        /// <summary>
        /// ファイルをコピーする
        /// </summary>
        /// <param name="filePathList">ファイルパスリスト</param>
        /// <exception cref="NotFileExitsException">ファイルエラー</exception>
        public void CoppyFiles(IEnumerable<string> filePathList)
        {
            var errorList = new List<string>();

            // コピー先フォルダを選択させる
            var coppyAtFolder = GetFolderPath(string.Empty);

            if (string.IsNullOrEmpty(coppyAtFolder))
            {
                return;
            }

            foreach (var filePath in filePathList)
            {
                if (File.Exists(filePath))
                {
                    try
                    {
                        File.Copy(filePath, Path.Combine(coppyAtFolder, Path.GetFileName(filePath)));
                    }
                    catch (Exception)
                    {
                        errorList.Add(filePath);
                    }
                }
                else
                {
                    errorList.Add(filePath);
                }
            }

            if (errorList.Any())
            {
                // ファイルコピーできていない
                throw new NotFileExitsException(errorList);
            }
            else
            {
                MessageBox.Show("ファイルをコピーしました。");
            }
        }

        /// <summary>
        /// ファイルを削除するする
        /// </summary>
        /// <param name="filePathList">ファイルパスリスト</param>
        /// <exception cref="NotFileExitsException">ファイルエラー</exception>
        public void DeleteFiles(IEnumerable<string> filePathList)
        {
            var errorList = new List<string>();

            foreach (var filePath in filePathList)
            {
                if (File.Exists(filePath))
                {
                    try
                    {
                        File.Delete(filePath);
                    }
                    catch (Exception)
                    {
                        errorList.Add(filePath);
                    }
                }
                else
                {
                    errorList.Add(filePath);
                }
            }

            if (errorList.Any())
            {
                // ファイルが削除できていない
                throw new NotFileExitsException(errorList);
            }
            else
            {
                MessageBox.Show("ファイルを削除しました。");
            }
        }
    }
}
