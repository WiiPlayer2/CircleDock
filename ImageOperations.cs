using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace ImageOperations
{
    /// <summary> 
    /// Collection of bitmap operation routines.
    /// </summary>
    class BitmapOperations
    {
        /// <summary> 
        /// Returns a bitmap scaled by a factor of ScaleFactorX and ScaleFactorY. Uses high quality scaling.
        /// Returns null if an error is encountered.
        /// </summary>
        /// <param name="Bitmap">Image to scale.</param>
        /// <param name="ScaleFactorX">Factor to scale the x-size by.</param>
        /// <param name="ScaleFactorY">Factor to scale the y-size by.</param>
        public static Bitmap ScaleByFactors(ref Bitmap Bitmap, float ScaleFactorX, float ScaleFactorY)
        {
            try
            {
                int scaleWidth = (int)Math.Max(Bitmap.Width * ScaleFactorX, 1.0f);
                int scaleHeight = (int)Math.Max(Bitmap.Height * ScaleFactorY, 1.0f);

                Bitmap scaledBitmap = new Bitmap(scaleWidth, scaleHeight);

                // Scale the bitmap in high quality mode.
                using (Graphics gr = Graphics.FromImage(scaledBitmap))
                {
                    gr.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
                    gr.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.HighQuality;
                    gr.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighQuality;
                    gr.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;

                    gr.DrawImage(Bitmap, new Rectangle(0, 0, scaleWidth, scaleHeight), new Rectangle(0, 0, Bitmap.Width, Bitmap.Height), GraphicsUnit.Pixel);
                }

                return scaledBitmap;
            }
            catch (Exception)
            {
                return null;
            }
        }


        /// <summary> 
        /// Returns a bitmap resized to NewWidth and NewHeight. Uses high quality scaling.
        /// Returns null if an error is encountered.
        /// </summary>
        /// <param name="Bitmap">Image to resize.</param>
        /// <param name="NewWidth">Width of the resized bitmap.</param>
        /// <param name="NewHeight">Height of the resized bitmap.</param>
        public static Bitmap ScaleBySize(ref Bitmap Bitmap, int NewWidth, int NewHeight)
        {
            try
            {
                Bitmap scaledBitmap = new Bitmap(NewWidth, NewHeight);

                // Scale the bitmap in high quality mode.
                using (Graphics gr = Graphics.FromImage(scaledBitmap))
                {
                    gr.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
                    gr.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.HighQuality;
                    gr.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighQuality;
                    gr.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;

                    gr.DrawImage(Bitmap, new Rectangle(0, 0, NewWidth, NewHeight), new Rectangle(0, 0, Bitmap.Width, Bitmap.Height), GraphicsUnit.Pixel);
                }

                return scaledBitmap;
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
