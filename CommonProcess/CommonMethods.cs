using Microsoft.WindowsAPICodePack.Dialogs;

namespace CommonProcess
{
    /// <summary>
    /// インターフェイス
    /// </summary>
    public interface ICommonMethods
    {
        public string GetFolderPath(string s);
    }

    /// <summary>
    /// 共通処理
    /// </summary>
    public class CommonMethods : ICommonMethods
    {

        /// <summary>
        /// フォルダー選択ダイアログ表示
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public string GetFolderPath(string s)
        {
            var result = string.Empty;
            var dialogInitialPath = string.IsNullOrEmpty(s) ? Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) : s;

            using (var dialog = new CommonOpenFileDialog()
            {
                IsFolderPicker = true,
                Title = "フォルダーを選択してください",
                InitialDirectory = dialogInitialPath,

            })
            {
                return dialog.ShowDialog() == CommonFileDialogResult.Ok ? dialog.FileName : string.Empty;
            }
        }
    }
}
