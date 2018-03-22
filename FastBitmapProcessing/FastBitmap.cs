using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;

namespace FastBitmapProcessing
{
	public class FastBitmap
	{
		private Bitmap image;

		private BitmapData bitmapData;

		private int height;

		private int width;

		private int stride;

		private byte[] rgbValues;

		private bool locked = false;

		public int Height
		{
			get
			{
				return this.height;
			}
		}

		public int Width
		{
			get
			{
				return this.width;
			}
		}

		public FastBitmap(int x, int y)
		{
			this.width = x;
			this.height = y;
			this.image = new Bitmap(x, y);
		}

		public FastBitmap(Bitmap bitmap, bool createCopy)
		{
			this.width = bitmap.Width;
			this.height = bitmap.Height;
			if (createCopy)
			{
				this.image = new Bitmap(bitmap);
			}
			else
			{
				this.image = bitmap;
			}
		}

		public byte[] GetAllPixels()
		{
			return this.rgbValues;
		}

		public void SetAllPixels(byte[] pixels)
		{
			this.rgbValues = pixels;
		}

		public Color GetPixel(int x, int y)
		{
			int num = this.stride;
			int blue = (int)this.rgbValues[y * num + x * 4];
			int green = (int)this.rgbValues[y * num + x * 4 + 1];
			int red = (int)this.rgbValues[y * num + x * 4 + 2];
			int alpha = (int)this.rgbValues[y * num + x * 4 + 3];
			return Color.FromArgb(alpha, red, green, blue);
		}

		public byte[] GetPixelValues(int x, int y)
		{
			int num = this.width;
			int num2 = this.stride;
			byte[] array = new byte[]
			{
				0,
				0,
				0,
				this.rgbValues[y * num2 + x * 4]
			};
			array[2] = this.rgbValues[y * num2 + x * 4 + 1];
			array[1] = this.rgbValues[y * num2 + x * 4 + 2];
			array[0] = this.rgbValues[y * num2 + x * 4 + 3];
			return array;
		}

		public void SetPixel(int x, int y, Color cIn)
		{
			int num = this.stride;
			this.rgbValues[y * num + x * 4] = cIn.B;
			this.rgbValues[y * num + x * 4 + 1] = cIn.G;
			this.rgbValues[y * num + x * 4 + 2] = cIn.R;
			this.rgbValues[y * num + x * 4 + 3] = cIn.A;
		}

		public void SetPixel(int x, int y, byte a, byte r, byte g, byte b)
		{
			int num = this.width;
			int num2 = this.stride;
			this.rgbValues[y * num2 + x * 4] = b;
			this.rgbValues[y * num2 + x * 4 + 1] = g;
			this.rgbValues[y * num2 + x * 4 + 2] = r;
			this.rgbValues[y * num2 + x * 4 + 3] = a;
		}

		public static implicit operator Image(FastBitmap bmp)
		{
			return bmp.image;
		}

		public static implicit operator Bitmap(FastBitmap bmp)
		{
			return bmp.image;
		}

		public void LockBitmap()
		{
			this.LockBitmap(new Rectangle(0, 0, this.width, this.height));
		}

		private void LockBitmap(Rectangle area)
		{
			if (!this.locked)
			{
				this.locked = true;
				this.bitmapData = this.image.LockBits(area, ImageLockMode.ReadWrite, PixelFormat.Format32bppArgb);
				this.stride = this.bitmapData.Stride;
				IntPtr scan = this.bitmapData.Scan0;
				int num = this.bitmapData.Stride * this.height;
				this.rgbValues = new byte[num];
				Marshal.Copy(scan, this.rgbValues, 0, num);
			}
		}

		public void UnlockBitmap()
		{
			if (this.locked)
			{
				this.locked = false;
				Marshal.Copy(this.rgbValues, 0, this.bitmapData.Scan0, this.bitmapData.Stride * this.image.Height);
				this.image.UnlockBits(this.bitmapData);
			}
		}
	}
}
