using System;

namespace vbAccelerator.Components.ImageList
{
	[Flags]
	public enum ImageListDrawStateConstants
	{
		ILS_NORMAL = 0,
		ILS_GLOW = 1,
		ILS_SHADOW = 2,
		ILS_SATURATE = 4,
		ILS_ALPHA = 8
	}
}
