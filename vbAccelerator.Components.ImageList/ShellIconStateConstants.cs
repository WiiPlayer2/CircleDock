using System;

namespace vbAccelerator.Components.ImageList
{
	[Flags]
	public enum ShellIconStateConstants
	{
		ShellIconStateNormal = 0,
		ShellIconStateLinkOverlay = 32768,
		ShellIconStateSelected = 65536,
		ShellIconStateOpen = 2,
		ShellIconAddOverlays = 32
	}
}
