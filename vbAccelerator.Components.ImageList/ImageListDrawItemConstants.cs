using System;

namespace vbAccelerator.Components.ImageList
{
	[Flags]
	public enum ImageListDrawItemConstants
	{
		ILD_NORMAL = 0,
		ILD_TRANSPARENT = 1,
		ILD_BLEND25 = 2,
		ILD_SELECTED = 4,
		ILD_MASK = 16,
		ILD_IMAGE = 32,
		ILD_ROP = 64,
		ILD_PRESERVEALPHA = 4096,
		ILD_SCALE = 8192,
		ILD_DPISCALE = 16384
	}
}
