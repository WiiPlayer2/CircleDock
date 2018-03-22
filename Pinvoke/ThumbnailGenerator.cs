using FastBitmapProcessing;
using System;
using System.Drawing;
using System.Runtime.InteropServices;
using VistaToolbelt.Interop.Native;

namespace Pinvoke
{
	public static class ThumbnailGenerator
	{
		public struct BLENDFUNCTION
		{
			public byte BlendOp;

			public byte BlendFlags;

			public byte SourceConstantAlpha;

			public byte AlphaFormat;

			public BLENDFUNCTION(byte op, byte flags, byte alpha, byte format)
			{
				this.BlendOp = op;
				this.BlendFlags = flags;
				this.SourceConstantAlpha = alpha;
				this.AlphaFormat = format;
			}
		}

		public struct RGBQUAD
		{
			public byte rgbBlue;

			public byte rgbGreen;

			public byte rgbRed;

			public byte rgbReserved;
		}

		public struct BITMAP
		{
			public int bmType;

			public int bmWidth;

			public int bmHeight;

			public int bmWidthBytes;

			public short bmPlanes;

			public short bmBitsPixel;

			public IntPtr bmBits;
		}

		public struct BITMAPINFOHEADER
		{
			public int biSize;

			public int biWidth;

			public int biHeight;

			public short biPlanes;

			public short biBitCount;

			public int biCompression;

			public int biSizeImage;

			public int biXPelsPerMeter;

			public int biYPelsPerMeter;

			public int biClrUsed;

			public int bitClrImportant;
		}

		public struct DIBSECTION
		{
			public ThumbnailGenerator.BITMAP dsBm;

			public ThumbnailGenerator.BITMAPINFOHEADER dsBmih;

			public int dsBitField1;

			public int dsBitField2;

			public int dsBitField3;

			public IntPtr dshSection;

			public int dsOffset;
		}

		public const byte AC_SRC_OVER = 0;

		public const byte AC_SRC_ALPHA = 1;

		public static Bitmap GenerateThumbnail(string filename)
		{
			Bitmap result;
			if (Environment.OSVersion.Version.Major < 6)
			{
				result = null;
			}
			else
			{
				IShellItem shellItem = null;
				IntPtr zero = IntPtr.Zero;
				Guid riid = new Guid("43826d1e-e718-42ee-bc55-a1e261c37bfe");
				Bitmap bitmap = null;
				UnsafeNativeMethods.SHCreateItemFromParsingName(filename, IntPtr.Zero, riid, out shellItem);
				try
				{
					((IShellItemImageFactory)shellItem).GetImage(new SIZE(256, 256), SIIGBF.SIIGBF_THUMBNAILONLY, out zero);
					bitmap = ThumbnailGenerator.ConvertPixelByPixel(zero);
				}
				catch (Exception)
				{
					try
					{
						if (shellItem != null)
						{
							Marshal.ReleaseComObject(shellItem);
						}
						if (zero != IntPtr.Zero)
						{
							Marshal.Release(zero);
						}
					}
					catch (Exception)
					{
					}
					result = null;
					return result;
				}
				Marshal.ReleaseComObject(shellItem);
				Marshal.Release(zero);
				result = bitmap;
			}
			return result;
		}

		public unsafe static Bitmap ConvertPixelByPixel(IntPtr ipd)
		{
			ThumbnailGenerator.DIBSECTION dIBSECTION = default(ThumbnailGenerator.DIBSECTION);
			ThumbnailGenerator.GetObjectDIBSection(ipd, Marshal.SizeOf(dIBSECTION), ref dIBSECTION);
			int bmWidth = dIBSECTION.dsBm.bmWidth;
			int bmHeight = dIBSECTION.dsBm.bmHeight;
			Bitmap result;
			if (bmWidth <= 0 || bmHeight <= 0)
			{
				result = null;
			}
			else
			{
				FastBitmap fastBitmap = new FastBitmap(bmWidth, bmHeight);
				fastBitmap.LockBitmap();
				ThumbnailGenerator.RGBQUAD* ptr = (ThumbnailGenerator.RGBQUAD*)((void*)dIBSECTION.dsBm.bmBits);
				for (int i = 0; i < dIBSECTION.dsBmih.biWidth; i++)
				{
					for (int j = 0; j < dIBSECTION.dsBmih.biHeight; j++)
					{
						int num = j * dIBSECTION.dsBmih.biWidth + i;
						if (ptr[num].rgbReserved != 0)
						{
							fastBitmap.SetPixel(i, j, ptr[num].rgbReserved, ptr[num].rgbRed, ptr[num].rgbGreen, ptr[num].rgbBlue);
						}
					}
				}
				fastBitmap.UnlockBitmap();
				result = fastBitmap;
			}
			return result;
		}

		[DllImport("gdi32.dll", EntryPoint = "GdiAlphaBlend")]
		public static extern bool AlphaBlend(IntPtr hdcDest, int nXOriginDest, int nYOriginDest, int nWidthDest, int nHeightDest, IntPtr hdcSrc, int nXOriginSrc, int nYOriginSrc, int nWidthSrc, int nHeightSrc, ThumbnailGenerator.BLENDFUNCTION blendFunction);

		[DllImport("gdi32.dll", ExactSpelling = true, SetLastError = true)]
		public static extern IntPtr CreateCompatibleDC(IntPtr hdc);

		[DllImport("gdi32.dll", ExactSpelling = true, SetLastError = true)]
		public static extern bool DeleteDC(IntPtr hdc);

		[DllImport("gdi32.dll", ExactSpelling = true, SetLastError = true)]
		public static extern IntPtr SelectObject(IntPtr hdc, IntPtr hgdiobj);

		[DllImport("gdi32.dll", ExactSpelling = true, SetLastError = true)]
		public static extern bool DeleteObject(IntPtr hObject);

		[DllImport("gdiplus.dll", CharSet = CharSet.Unicode, ExactSpelling = true)]
		public static extern int GdipCreateBitmapFromHBITMAP(IntPtr hbitmap, IntPtr hpalette, out IntPtr bitmap);

		[DllImport("gdi32.dll", EntryPoint = "GetObject")]
		public static extern int GetObjectDIBSection(IntPtr hObject, int nCount, ref ThumbnailGenerator.DIBSECTION lpObject);
	}
}
