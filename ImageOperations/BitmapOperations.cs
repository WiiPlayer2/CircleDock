using System;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace ImageOperations
{
	internal class BitmapOperations
	{
		public static Bitmap ScaleByFactors(ref Bitmap Bitmap, float ScaleFactorX, float ScaleFactorY)
		{
			Bitmap result;
			try
			{
				int width = (int)Math.Max((float)Bitmap.Width * ScaleFactorX, 1f);
				int height = (int)Math.Max((float)Bitmap.Height * ScaleFactorY, 1f);
				Bitmap bitmap = new Bitmap(width, height);
				using (Graphics graphics = Graphics.FromImage(bitmap))
				{
					graphics.SmoothingMode = SmoothingMode.HighSpeed;
					graphics.PixelOffsetMode = PixelOffsetMode.HighSpeed;
					graphics.CompositingQuality = CompositingQuality.HighSpeed;
					graphics.InterpolationMode = InterpolationMode.High;
					graphics.DrawImage(Bitmap, new Rectangle(0, 0, width, height), new Rectangle(0, 0, Bitmap.Width, Bitmap.Height), GraphicsUnit.Pixel);
				}
				result = bitmap;
			}
			catch (Exception)
			{
				result = null;
			}
			return result;
		}

		public static Bitmap ScaleBySize(ref Bitmap Bitmap, int NewWidth, int NewHeight)
		{
			Bitmap result;
			try
			{
				Bitmap bitmap = new Bitmap(NewWidth, NewHeight);
				using (Graphics graphics = Graphics.FromImage(bitmap))
				{
					graphics.SmoothingMode = SmoothingMode.HighSpeed;
					graphics.PixelOffsetMode = PixelOffsetMode.HighSpeed;
					graphics.CompositingQuality = CompositingQuality.HighSpeed;
					graphics.InterpolationMode = InterpolationMode.High;
					graphics.DrawImage(Bitmap, new Rectangle(0, 0, NewWidth, NewHeight), new Rectangle(0, 0, Bitmap.Width, Bitmap.Height), GraphicsUnit.Pixel);
				}
				result = bitmap;
			}
			catch (Exception)
			{
				result = null;
			}
			return result;
		}

		public static Bitmap ScaleBySize(Bitmap Bitmap, int NewWidth, int NewHeight)
		{
			Bitmap result;
			try
			{
				Bitmap bitmap = new Bitmap(NewWidth, NewHeight);
				using (Graphics graphics = Graphics.FromImage(bitmap))
				{
					graphics.SmoothingMode = SmoothingMode.HighSpeed;
					graphics.PixelOffsetMode = PixelOffsetMode.HighSpeed;
					graphics.CompositingQuality = CompositingQuality.HighSpeed;
					graphics.InterpolationMode = InterpolationMode.High;
					graphics.DrawImage(Bitmap, new Rectangle(0, 0, NewWidth, NewHeight), new Rectangle(0, 0, Bitmap.Width, Bitmap.Height), GraphicsUnit.Pixel);
				}
				result = bitmap;
			}
			catch (Exception)
			{
				result = null;
			}
			return result;
		}

		public static Bitmap ScaleBySizeBestFit(ref Bitmap Bitmap, int NewWidth, int NewHeight)
		{
			Bitmap result;
			try
			{
				Bitmap bitmap = new Bitmap(NewWidth, NewHeight);
				using (Graphics graphics = Graphics.FromImage(bitmap))
				{
					graphics.SmoothingMode = SmoothingMode.HighSpeed;
					graphics.PixelOffsetMode = PixelOffsetMode.HighSpeed;
					graphics.CompositingQuality = CompositingQuality.HighSpeed;
					graphics.InterpolationMode = InterpolationMode.High;
					double num = (double)bitmap.Width / (double)bitmap.Height;
					double num2 = (double)Bitmap.Width / (double)Bitmap.Height;
					int x;
					int width;
					int y;
					int height;
					if (num2 > num)
					{
						x = 0;
						width = bitmap.Width;
						int num3 = (int)((double)bitmap.Width / num2);
						y = (bitmap.Height - num3) / 2;
						height = num3;
					}
					else
					{
						y = 0;
						height = bitmap.Height;
						int num4 = (int)((double)bitmap.Height * num2);
						x = (bitmap.Width - num4) / 2;
						width = num4;
					}
					graphics.DrawImage(Bitmap, new Rectangle(x, y, width, height), new Rectangle(0, 0, Bitmap.Width, Bitmap.Height), GraphicsUnit.Pixel);
				}
				result = bitmap;
			}
			catch (Exception)
			{
				result = null;
			}
			return result;
		}
	}
}
