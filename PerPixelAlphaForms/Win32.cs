using System;
using System.Runtime.InteropServices;

namespace PerPixelAlphaForms
{
	internal class Win32
	{
		public enum Bool
		{
			False,
			True
		}

		public struct Point
		{
			public int x;

			public int y;

			public Point(int x, int y)
			{
				this.x = x;
				this.y = y;
			}
		}

		public struct Size
		{
			public int cx;

			public int cy;

			public Size(int cx, int cy)
			{
				this.cx = cx;
				this.cy = cy;
			}
		}

		[StructLayout(LayoutKind.Sequential, Pack = 1)]
		private struct ARGB
		{
			public byte Blue;

			public byte Green;

			public byte Red;

			public byte Alpha;
		}

		[StructLayout(LayoutKind.Sequential, Pack = 1)]
		public struct BLENDFUNCTION
		{
			public byte BlendOp;

			public byte BlendFlags;

			public byte SourceConstantAlpha;

			public byte AlphaFormat;
		}

		public const int ULW_COLORKEY = 1;

		public const int ULW_ALPHA = 2;

		public const int ULW_OPAQUE = 4;

		public const byte AC_SRC_OVER = 0;

		public const byte AC_SRC_ALPHA = 1;

		[DllImport("user32.dll", ExactSpelling = true, SetLastError = true)]
		public static extern Win32.Bool UpdateLayeredWindow(IntPtr hwnd, IntPtr hdcDst, ref Win32.Point pptDst, ref Win32.Size psize, IntPtr hdcSrc, ref Win32.Point pprSrc, int crKey, ref Win32.BLENDFUNCTION pblend, int dwFlags);

		[DllImport("user32.dll", ExactSpelling = true, SetLastError = true)]
		public static extern IntPtr GetDC(IntPtr hWnd);

		[DllImport("user32.dll", ExactSpelling = true)]
		public static extern int ReleaseDC(IntPtr hWnd, IntPtr hDC);

		[DllImport("gdi32.dll", ExactSpelling = true, SetLastError = true)]
		public static extern IntPtr CreateCompatibleDC(IntPtr hDC);

		[DllImport("gdi32.dll", ExactSpelling = true, SetLastError = true)]
		public static extern Win32.Bool DeleteDC(IntPtr hdc);

		[DllImport("gdi32.dll", ExactSpelling = true)]
		public static extern IntPtr SelectObject(IntPtr hDC, IntPtr hObject);

		[DllImport("gdi32.dll", ExactSpelling = true, SetLastError = true)]
		public static extern Win32.Bool DeleteObject(IntPtr hObject);
	}
}
