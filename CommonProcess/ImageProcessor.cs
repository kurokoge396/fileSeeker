using System.Drawing;

namespace CommonProcess
{
    /// <summary>
    /// 画像処理クラスインターフェイス
    /// </summary>
    public interface IImageProcessor
    {
        public Image SetImageDirection(Image image);
    }

    /// <summary>
    /// 画像処理クラス
    /// </summary>
    public class ImageProcessor : IImageProcessor
    {
        /// <summary>
        /// コンストラクタ
        /// </summary>
        public ImageProcessor()
        {
        }

        /// <summary>
        /// 画像の方向を修正する
        /// </summary>
        /// <param name="image">画像</param>
        /// <returns>方向が修正された画像</returns>
        public Image SetImageDirection(Image image)
        {
            var bitmap = image;

            // 0x0112 = Orientation を保持するタグ ID
            var property = bitmap.PropertyItems.FirstOrDefault(p => p.Id == 0x0112);

            if (property != null)
            {
                var rotation = RotateFlipType.RotateNoneFlipNone;

                var orientation = (ExifOrientation)BitConverter.ToUInt16(property.Value, 0);

                // Exif 情報に従って画像を回転させる
                switch (orientation)
                {
                    case ExifOrientation.TopLeft:
                        break;
                    case ExifOrientation.TopRight:
                        rotation = RotateFlipType.RotateNoneFlipX;
                        break;
                    case ExifOrientation.BottomRight:
                        rotation = RotateFlipType.Rotate180FlipNone;
                        break;
                    case ExifOrientation.BottomLeft:
                        rotation = RotateFlipType.RotateNoneFlipY;
                        break;
                    case ExifOrientation.LeftTop:
                        rotation = RotateFlipType.Rotate270FlipY;
                        break;
                    case ExifOrientation.RightTop:
                        rotation = RotateFlipType.Rotate90FlipNone;
                        break;
                    case ExifOrientation.RightBottom:
                        rotation = RotateFlipType.Rotate90FlipY;
                        break;
                    case ExifOrientation.LeftBottom:
                        rotation = RotateFlipType.Rotate270FlipNone;
                        break;
                }

                bitmap.RotateFlip(rotation);

                property.Value = BitConverter.GetBytes((ushort)ExifOrientation.TopLeft);
                bitmap.SetPropertyItem(property);
            }

            return bitmap;
        }

        private enum ExifOrientation : ushort
        {
            TopLeft = 1,
            TopRight = 2,
            BottomRight = 3,
            BottomLeft = 4,
            LeftTop = 5,
            RightTop = 6,
            RightBottom = 7,
            LeftBottom = 8
        }
    }
}
