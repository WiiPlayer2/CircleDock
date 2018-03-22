using System;

namespace VistaToolbelt.Interop.Native
{
	[Flags]
	public enum SIIGBF
	{
		SIIGBF_RESIZETOFIT = 0,
		SIIGBF_BIGGERSIZEOK = 1,
		SIIGBF_MEMORYONLY = 2,
		SIIGBF_ICONONLY = 4,
		SIIGBF_THUMBNAILONLY = 8,
		SIIGBF_INCACHEONLY = 16
	}
}
