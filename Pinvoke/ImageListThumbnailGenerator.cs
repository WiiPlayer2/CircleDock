using System;
using System.Drawing;
using vbAccelerator.Components.ImageList;

namespace Pinvoke
{
	public static class ImageListThumbnailGenerator
	{
		public static Bitmap GetJumboLargeThumbnail(string fileName)
		{
			Bitmap result;
			if (Environment.OSVersion.Version.Major >= 6)
			{
				try
				{
					SysImageList sysImageList = new SysImageList(SysImageListSize.SHIL_JUMBO);
					Bitmap bitmap = sysImageList.Icon(sysImageList.IconIndex(fileName, true)).ToBitmap();
					if (bitmap.GetPixel((int)((double)bitmap.Width / 1.5), (int)((double)bitmap.Height / 1.5)).ToArgb() != 0 && bitmap.GetPixel(bitmap.Width / 2, bitmap.Height / 2).ToArgb() != 0 && bitmap.GetPixel(bitmap.Width / 3, bitmap.Height / 3).ToArgb() != 0 && bitmap.GetPixel(bitmap.Width / 4, bitmap.Height / 4).ToArgb() != 0)
					{
						result = bitmap;
						return result;
					}
					SysImageList sysImageList2 = new SysImageList(SysImageListSize.extraLargeIcons);
					Bitmap bitmap2 = sysImageList2.Icon(sysImageList2.IconIndex(fileName, true)).ToBitmap();
					result = bitmap2;
					return result;
				}
				catch (Exception)
				{
					result = null;
					return result;
				}
			}
			if (Environment.OSVersion.Version.Major >= 5)
			{
				try
				{
					SysImageList sysImageList2 = new SysImageList(SysImageListSize.extraLargeIcons);
					result = sysImageList2.Icon(sysImageList2.IconIndex(fileName, true)).ToBitmap();
					return result;
				}
				catch (Exception)
				{
					result = null;
					return result;
				}
			}
			result = null;
			return result;
		}
	}
}
