using System.Drawing;

namespace CommonUtility
{
    public static class ImageUtility
    {
        public static Image Crop(Image bmp, Rectangle cropRect)
        {

            if (bmp != null)
            {
                Bitmap result = new Bitmap(cropRect.Width, cropRect.Height);
                Graphics g = Graphics.FromImage(result);
                g.DrawImage(bmp, 0, 0, cropRect, GraphicsUnit.Pixel);
                g.Dispose();
                return result;
            }
            return null;
        }


        public static Image Scale(Image image, float factor)
        {
            if (image != null)
            {
                Rectangle cropRect = new Rectangle(0, 0, image.Width, image.Height);
                Bitmap result = new Bitmap((int)(cropRect.Width * factor), (int)(cropRect.Height * factor));
                Graphics g = Graphics.FromImage(result);
                g.ScaleTransform(factor, factor);
                g.DrawImage(image, 0, 0, cropRect, GraphicsUnit.Pixel);
                g.Dispose();
                return result;
            }
            return null;
        }
    }

}
