using System;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.InteropServices;

namespace vbAccelerator.Components.ImageList
{
	public class SysImageList : IDisposable
	{
		[Flags]
		private enum SHGetFileInfoConstants
		{
			SHGFI_ICON = 256,
			SHGFI_DISPLAYNAME = 512,
			SHGFI_TYPENAME = 1024,
			SHGFI_ATTRIBUTES = 2048,
			SHGFI_ICONLOCATION = 4096,
			SHGFI_EXETYPE = 8192,
			SHGFI_SYSICONINDEX = 16384,
			SHGFI_LINKOVERLAY = 32768,
			SHGFI_SELECTED = 65536,
			SHGFI_ATTR_SPECIFIED = 131072,
			SHGFI_LARGEICON = 0,
			SHGFI_SMALLICON = 1,
			SHGFI_OPENICON = 2,
			SHGFI_SHELLICONSIZE = 4,
			SHGFI_USEFILEATTRIBUTES = 16,
			SHGFI_ADDOVERLAYS = 32,
			SHGFI_OVERLAYINDEX = 64
		}

		private struct RECT
		{
			private int left;

			private int top;

			private int right;

			private int bottom;
		}

		private struct POINT
		{
			private int x;

			private int y;
		}

		private struct IMAGELISTDRAWPARAMS
		{
			public int cbSize;

			public IntPtr himl;

			public int i;

			public IntPtr hdcDst;

			public int x;

			public int y;

			public int cx;

			public int cy;

			public int xBitmap;

			public int yBitmap;

			public int rgbBk;

			public int rgbFg;

			public int fStyle;

			public int dwRop;

			public int fState;

			public int Frame;

			public int crEffect;
		}

		private struct IMAGEINFO
		{
			public IntPtr hbmImage;

			public IntPtr hbmMask;

			public int Unused1;

			public int Unused2;

			public SysImageList.RECT rcImage;
		}

		private struct SHFILEINFO
		{
			public IntPtr hIcon;

			public int iIcon;

			public int dwAttributes;

			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 260)]
			public string szDisplayName;

			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 80)]
			public string szTypeName;
		}

		[Guid("46EB5926-582E-4017-9FDF-E8998DAA0950"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
		[ComImport]
		private interface IImageList
		{
			[PreserveSig]
			int Add(IntPtr hbmImage, IntPtr hbmMask, ref int pi);

			[PreserveSig]
			int ReplaceIcon(int i, IntPtr hicon, ref int pi);

			[PreserveSig]
			int SetOverlayImage(int iImage, int iOverlay);

			[PreserveSig]
			int Replace(int i, IntPtr hbmImage, IntPtr hbmMask);

			[PreserveSig]
			int AddMasked(IntPtr hbmImage, int crMask, ref int pi);

			[PreserveSig]
			int Draw(ref SysImageList.IMAGELISTDRAWPARAMS pimldp);

			[PreserveSig]
			int Remove(int i);

			[PreserveSig]
			int GetIcon(int i, int flags, ref IntPtr picon);

			[PreserveSig]
			int GetImageInfo(int i, ref SysImageList.IMAGEINFO pImageInfo);

			[PreserveSig]
			int Copy(int iDst, SysImageList.IImageList punkSrc, int iSrc, int uFlags);

			[PreserveSig]
			int Merge(int i1, SysImageList.IImageList punk2, int i2, int dx, int dy, ref Guid riid, ref IntPtr ppv);

			[PreserveSig]
			int Clone(ref Guid riid, ref IntPtr ppv);

			[PreserveSig]
			int GetImageRect(int i, ref SysImageList.RECT prc);

			[PreserveSig]
			int GetIconSize(ref int cx, ref int cy);

			[PreserveSig]
			int SetIconSize(int cx, int cy);

			[PreserveSig]
			int GetImageCount(ref int pi);

			[PreserveSig]
			int SetImageCount(int uNewCount);

			[PreserveSig]
			int SetBkColor(int clrBk, ref int pclr);

			[PreserveSig]
			int GetBkColor(ref int pclr);

			[PreserveSig]
			int BeginDrag(int iTrack, int dxHotspot, int dyHotspot);

			[PreserveSig]
			int EndDrag();

			[PreserveSig]
			int DragEnter(IntPtr hwndLock, int x, int y);

			[PreserveSig]
			int DragLeave(IntPtr hwndLock);

			[PreserveSig]
			int DragMove(int x, int y);

			[PreserveSig]
			int SetDragCursorImage(ref SysImageList.IImageList punk, int iDrag, int dxHotspot, int dyHotspot);

			[PreserveSig]
			int DragShowNolock(int fShow);

			[PreserveSig]
			int GetDragImage(ref SysImageList.POINT ppt, ref SysImageList.POINT pptHotspot, ref Guid riid, ref IntPtr ppv);

			[PreserveSig]
			int GetItemFlags(int i, ref int dwFlags);

			[PreserveSig]
			int GetOverlayImage(int iOverlay, ref int piIndex);
		}

		private const int MAX_PATH = 260;

		private const int FILE_ATTRIBUTE_NORMAL = 128;

		private const int FILE_ATTRIBUTE_DIRECTORY = 16;

		private const int FORMAT_MESSAGE_ALLOCATE_BUFFER = 256;

		private const int FORMAT_MESSAGE_ARGUMENT_ARRAY = 8192;

		private const int FORMAT_MESSAGE_FROM_HMODULE = 2048;

		private const int FORMAT_MESSAGE_FROM_STRING = 1024;

		private const int FORMAT_MESSAGE_FROM_SYSTEM = 4096;

		private const int FORMAT_MESSAGE_IGNORE_INSERTS = 512;

		private const int FORMAT_MESSAGE_MAX_WIDTH_MASK = 255;

		private IntPtr hIml = IntPtr.Zero;

		private SysImageList.IImageList iImageList = null;

		private SysImageListSize size = SysImageListSize.smallIcons;

		private bool disposed = false;

		public IntPtr Handle
		{
			get
			{
				return this.hIml;
			}
		}

		public SysImageListSize ImageListSize
		{
			get
			{
				return this.size;
			}
			set
			{
				this.size = value;
				this.create();
			}
		}

		public Size Size
		{
			get
			{
				int width = 0;
				int height = 0;
				if (this.iImageList == null)
				{
					SysImageList.ImageList_GetIconSize(this.hIml, ref width, ref height);
				}
				else
				{
					this.iImageList.GetIconSize(ref width, ref height);
				}
				Size result = new Size(width, height);
				return result;
			}
		}

		[DllImport("shell32")]
		private static extern IntPtr SHGetFileInfo(string pszPath, int dwFileAttributes, ref SysImageList.SHFILEINFO psfi, uint cbFileInfo, uint uFlags);

		[DllImport("user32.dll")]
		private static extern int DestroyIcon(IntPtr hIcon);

		[DllImport("kernel32")]
		private static extern int FormatMessage(int dwFlags, IntPtr lpSource, int dwMessageId, int dwLanguageId, string lpBuffer, uint nSize, int argumentsLong);

		[DllImport("kernel32")]
		private static extern int GetLastError();

		[DllImport("comctl32")]
		private static extern int ImageList_Draw(IntPtr hIml, int i, IntPtr hdcDst, int x, int y, int fStyle);

		[DllImport("comctl32")]
		private static extern int ImageList_DrawIndirect(ref SysImageList.IMAGELISTDRAWPARAMS pimldp);

		[DllImport("comctl32")]
		private static extern int ImageList_GetIconSize(IntPtr himl, ref int cx, ref int cy);

		[DllImport("comctl32")]
		private static extern IntPtr ImageList_GetIcon(IntPtr himl, int i, int flags);

		[DllImport("shell32.dll", EntryPoint = "#727")]
		private static extern int SHGetImageList(int iImageList, ref Guid riid, ref SysImageList.IImageList ppv);

		[DllImport("shell32.dll", EntryPoint = "#727")]
		private static extern int SHGetImageListHandle(int iImageList, ref Guid riid, ref IntPtr handle);

		public Icon Icon(int index)
		{
			Icon result = null;
			IntPtr intPtr = IntPtr.Zero;
			if (this.iImageList == null)
			{
				intPtr = SysImageList.ImageList_GetIcon(this.hIml, index, 1);
			}
			else
			{
				this.iImageList.GetIcon(index, 1, ref intPtr);
			}
			if (intPtr != IntPtr.Zero)
			{
				result = System.Drawing.Icon.FromHandle(intPtr);
			}
			return result;
		}

		public int IconIndex(string fileName)
		{
			return this.IconIndex(fileName, false);
		}

		public int IconIndex(string fileName, bool forceLoadFromDisk)
		{
			return this.IconIndex(fileName, forceLoadFromDisk, ShellIconStateConstants.ShellIconStateNormal);
		}

		public int IconIndex(string fileName, bool forceLoadFromDisk, ShellIconStateConstants iconState)
		{
			SysImageList.SHGetFileInfoConstants sHGetFileInfoConstants = SysImageList.SHGetFileInfoConstants.SHGFI_SYSICONINDEX;
			if (this.size == SysImageListSize.smallIcons)
			{
				sHGetFileInfoConstants |= SysImageList.SHGetFileInfoConstants.SHGFI_SMALLICON;
			}
			int dwFileAttributes;
			if (!forceLoadFromDisk)
			{
				sHGetFileInfoConstants |= SysImageList.SHGetFileInfoConstants.SHGFI_USEFILEATTRIBUTES;
				dwFileAttributes = 128;
			}
			else
			{
				dwFileAttributes = 0;
			}
			SysImageList.SHFILEINFO sHFILEINFO = default(SysImageList.SHFILEINFO);
			uint cbFileInfo = (uint)Marshal.SizeOf(sHFILEINFO.GetType());
			IntPtr intPtr = SysImageList.SHGetFileInfo(fileName, dwFileAttributes, ref sHFILEINFO, cbFileInfo, (uint)(sHGetFileInfoConstants | (SysImageList.SHGetFileInfoConstants)iconState));
			int result;
			if (intPtr.Equals(IntPtr.Zero))
			{
				Debug.Assert(!intPtr.Equals(IntPtr.Zero), "Failed to get icon index");
				result = 0;
			}
			else
			{
				result = sHFILEINFO.iIcon;
			}
			return result;
		}

		public void DrawImage(IntPtr hdc, int index, int x, int y)
		{
			this.DrawImage(hdc, index, x, y, ImageListDrawItemConstants.ILD_TRANSPARENT);
		}

		public void DrawImage(IntPtr hdc, int index, int x, int y, ImageListDrawItemConstants flags)
		{
			if (this.iImageList == null)
			{
				int num = SysImageList.ImageList_Draw(this.hIml, index, hdc, x, y, (int)flags);
			}
			else
			{
				SysImageList.IMAGELISTDRAWPARAMS iMAGELISTDRAWPARAMS = default(SysImageList.IMAGELISTDRAWPARAMS);
				iMAGELISTDRAWPARAMS.hdcDst = hdc;
				iMAGELISTDRAWPARAMS.cbSize = Marshal.SizeOf(iMAGELISTDRAWPARAMS.GetType());
				iMAGELISTDRAWPARAMS.i = index;
				iMAGELISTDRAWPARAMS.x = x;
				iMAGELISTDRAWPARAMS.y = y;
				iMAGELISTDRAWPARAMS.rgbFg = -1;
				iMAGELISTDRAWPARAMS.fStyle = (int)flags;
				this.iImageList.Draw(ref iMAGELISTDRAWPARAMS);
			}
		}

		public void DrawImage(IntPtr hdc, int index, int x, int y, ImageListDrawItemConstants flags, int cx, int cy)
		{
			SysImageList.IMAGELISTDRAWPARAMS iMAGELISTDRAWPARAMS = default(SysImageList.IMAGELISTDRAWPARAMS);
			iMAGELISTDRAWPARAMS.hdcDst = hdc;
			iMAGELISTDRAWPARAMS.cbSize = Marshal.SizeOf(iMAGELISTDRAWPARAMS.GetType());
			iMAGELISTDRAWPARAMS.i = index;
			iMAGELISTDRAWPARAMS.x = x;
			iMAGELISTDRAWPARAMS.y = y;
			iMAGELISTDRAWPARAMS.cx = cx;
			iMAGELISTDRAWPARAMS.cy = cy;
			iMAGELISTDRAWPARAMS.fStyle = (int)flags;
			if (this.iImageList == null)
			{
				iMAGELISTDRAWPARAMS.himl = this.hIml;
				int num = SysImageList.ImageList_DrawIndirect(ref iMAGELISTDRAWPARAMS);
			}
			else
			{
				this.iImageList.Draw(ref iMAGELISTDRAWPARAMS);
			}
		}

		public void DrawImage(IntPtr hdc, int index, int x, int y, ImageListDrawItemConstants flags, int cx, int cy, Color foreColor, ImageListDrawStateConstants stateFlags, Color saturateColorOrAlpha, Color glowOrShadowColor)
		{
			SysImageList.IMAGELISTDRAWPARAMS iMAGELISTDRAWPARAMS = default(SysImageList.IMAGELISTDRAWPARAMS);
			iMAGELISTDRAWPARAMS.hdcDst = hdc;
			iMAGELISTDRAWPARAMS.cbSize = Marshal.SizeOf(iMAGELISTDRAWPARAMS.GetType());
			iMAGELISTDRAWPARAMS.i = index;
			iMAGELISTDRAWPARAMS.x = x;
			iMAGELISTDRAWPARAMS.y = y;
			iMAGELISTDRAWPARAMS.cx = cx;
			iMAGELISTDRAWPARAMS.cy = cy;
			iMAGELISTDRAWPARAMS.rgbFg = Color.FromArgb(0, (int)foreColor.R, (int)foreColor.G, (int)foreColor.B).ToArgb();
			Console.WriteLine("{0}", iMAGELISTDRAWPARAMS.rgbFg);
			iMAGELISTDRAWPARAMS.fStyle = (int)flags;
			iMAGELISTDRAWPARAMS.fState = (int)stateFlags;
			if ((stateFlags & ImageListDrawStateConstants.ILS_ALPHA) == ImageListDrawStateConstants.ILS_ALPHA)
			{
				iMAGELISTDRAWPARAMS.Frame = (int)saturateColorOrAlpha.A;
			}
			else if ((stateFlags & ImageListDrawStateConstants.ILS_SATURATE) == ImageListDrawStateConstants.ILS_SATURATE)
			{
				saturateColorOrAlpha = Color.FromArgb(0, (int)saturateColorOrAlpha.R, (int)saturateColorOrAlpha.G, (int)saturateColorOrAlpha.B);
				iMAGELISTDRAWPARAMS.Frame = saturateColorOrAlpha.ToArgb();
			}
			glowOrShadowColor = Color.FromArgb(0, (int)glowOrShadowColor.R, (int)glowOrShadowColor.G, (int)glowOrShadowColor.B);
			iMAGELISTDRAWPARAMS.crEffect = glowOrShadowColor.ToArgb();
			if (this.iImageList == null)
			{
				iMAGELISTDRAWPARAMS.himl = this.hIml;
				int num = SysImageList.ImageList_DrawIndirect(ref iMAGELISTDRAWPARAMS);
			}
			else
			{
				this.iImageList.Draw(ref iMAGELISTDRAWPARAMS);
			}
		}

		private bool isXpOrAbove()
		{
			bool result = false;
			if (Environment.OSVersion.Version.Major > 5)
			{
				result = true;
			}
			else if (Environment.OSVersion.Version.Major == 5 && Environment.OSVersion.Version.Minor >= 1)
			{
				result = true;
			}
			return result;
		}

		private void create()
		{
			this.hIml = IntPtr.Zero;
			if (this.isXpOrAbove())
			{
				Guid guid = new Guid("46EB5926-582E-4017-9FDF-E8998DAA0950");
				int num = SysImageList.SHGetImageList((int)this.size, ref guid, ref this.iImageList);
				SysImageList.SHGetImageListHandle((int)this.size, ref guid, ref this.hIml);
			}
			else
			{
				SysImageList.SHGetFileInfoConstants sHGetFileInfoConstants = SysImageList.SHGetFileInfoConstants.SHGFI_SYSICONINDEX | SysImageList.SHGetFileInfoConstants.SHGFI_USEFILEATTRIBUTES;
				if (this.size == SysImageListSize.smallIcons)
				{
					sHGetFileInfoConstants |= SysImageList.SHGetFileInfoConstants.SHGFI_SMALLICON;
				}
				SysImageList.SHFILEINFO sHFILEINFO = default(SysImageList.SHFILEINFO);
				uint cbFileInfo = (uint)Marshal.SizeOf(sHFILEINFO.GetType());
				this.hIml = SysImageList.SHGetFileInfo(".txt", 128, ref sHFILEINFO, cbFileInfo, (uint)sHGetFileInfoConstants);
				Debug.Assert(this.hIml != IntPtr.Zero, "Failed to create Image List");
			}
		}

		public SysImageList()
		{
			this.create();
		}

		public SysImageList(SysImageListSize size)
		{
			this.size = size;
			this.create();
		}

		public void Dispose()
		{
			this.Dispose(true);
			GC.SuppressFinalize(this);
		}

		public virtual void Dispose(bool disposing)
		{
			if (!this.disposed)
			{
				if (disposing)
				{
					if (this.iImageList != null)
					{
						Marshal.ReleaseComObject(this.iImageList);
					}
					this.iImageList = null;
				}
			}
			this.disposed = true;
		}

		~SysImageList()
		{
			this.Dispose(false);
		}
	}
}
