using System;
using System.Runtime.InteropServices;

namespace VistaToolbelt.Interop.Native
{
	[Guid("bcc18b79-ba16-442f-80c4-8a59c30c463b"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	[ComImport]
	public interface IShellItemImageFactory
	{
		void GetImage([MarshalAs(UnmanagedType.Struct)] [In] SIZE size, [In] SIIGBF flags, out IntPtr phbm);
	}
}
