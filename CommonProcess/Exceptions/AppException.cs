namespace CommonProcess.Exceptions
{
    public class AppException : Exception
    {
        public AppException(string message) : base(message)
        {
        }

    }

    /// <summary>
    /// ファイルエラー
    /// </summary>
    public class NotFileExitsException : AppException
    {
        public NotFileExitsException(IEnumerable<string> files) : base($"下記ファイルが存在していない。またはアクセス権限がありませんでした\r\n {string.Join("\r\n", files)}")
        {

        }

    }

}
