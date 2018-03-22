using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;

namespace ImageOperations
{
	public class FancyText
	{
		public static Image ImageFromText(string strText, Font fnt, Color clrFore, Color clrBack, int blurAmount, int blurAlpha)
		{
			if (blurAlpha > 255)
			{
				blurAlpha = 255;
			}
			else if (blurAlpha < 0)
			{
				blurAlpha = 0;
			}
			Bitmap bitmap = null;
			using (Graphics graphics = Graphics.FromHwnd(IntPtr.Zero))
			{
				SizeF sizeF = graphics.MeasureString(strText, fnt);
				using (Bitmap bitmap2 = new Bitmap((int)sizeF.Width, (int)sizeF.Height))
				{
					using (Graphics graphics2 = Graphics.FromImage(bitmap2))
					{
						using (SolidBrush solidBrush = new SolidBrush(Color.FromArgb(blurAlpha, (int)clrBack.R, (int)clrBack.G, (int)clrBack.B)))
						{
							using (SolidBrush solidBrush2 = new SolidBrush(clrFore))
							{
								graphics2.SmoothingMode = SmoothingMode.HighSpeed;
								graphics2.InterpolationMode = InterpolationMode.HighQualityBilinear;
								graphics2.TextRenderingHint = TextRenderingHint.AntiAliasGridFit;
								graphics2.DrawString(strText, fnt, solidBrush, 0f, 0f);
								bitmap = new Bitmap(bitmap2.Width + blurAmount, bitmap2.Height + blurAmount);
								using (Graphics graphics3 = Graphics.FromImage(bitmap))
								{
									graphics3.SmoothingMode = SmoothingMode.HighSpeed;
									graphics3.InterpolationMode = InterpolationMode.HighQualityBilinear;
									graphics3.TextRenderingHint = TextRenderingHint.AntiAliasGridFit;
									for (int i = 0; i <= blurAmount; i++)
									{
										for (int j = 0; j <= blurAmount; j++)
										{
											graphics3.DrawImageUnscaled(bitmap2, i, j);
										}
									}
									graphics3.DrawString(strText, fnt, solidBrush2, (float)(blurAmount / 2), (float)(blurAmount / 2));
								}
							}
						}
					}
				}
			}
			return bitmap;
		}
	}
}
