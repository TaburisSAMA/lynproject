using System.Drawing;
using System.Drawing.Imaging;
using System.Windows.Forms;

namespace CommonUtility.Screenshot
{
    public static class ScreenShot
    {
        public static void CaptureImage(Point SourcePoint, Point DestinationPoint, Rectangle SelectionRectangle, string FilePath)
        {
            using (Bitmap bitmap = new Bitmap(SelectionRectangle.Width, SelectionRectangle.Height))
            {
                using (Graphics g = Graphics.FromImage(bitmap))
                {
                    g.CopyFromScreen(SourcePoint, DestinationPoint, SelectionRectangle.Size);
                }
                bitmap.Save(FilePath, ImageFormat.Bmp);
            }
        }

        public static void CaptureImageToClipboard(Point SourcePoint, Point DestinationPoint, Rectangle SelectionRectangle)
        {
            using (Bitmap bitmap = new Bitmap(SelectionRectangle.Width, SelectionRectangle.Height))
            {
                using (Graphics g = Graphics.FromImage(bitmap))
                {
                    g.CopyFromScreen(SourcePoint, DestinationPoint, SelectionRectangle.Size);
                }
                Clipboard.SetImage(bitmap);
            }
        }
    }
}
