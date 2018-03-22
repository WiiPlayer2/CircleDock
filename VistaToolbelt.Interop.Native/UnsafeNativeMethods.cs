using System;
using System.Runtime.InteropServices;
using System.Security;

namespace VistaToolbelt.Interop.Native
{
	[SuppressUnmanagedCodeSecurity]
	public static class UnsafeNativeMethods
	{
		[DllImport("shell32.dll", CharSet = CharSet.Unicode, PreserveSig = false)]
		public static extern void SHCreateItemFromParsingName([MarshalAs(UnmanagedType.LPWStr)] [In] string pszPath, [In] IntPtr pbc, [MarshalAs(UnmanagedType.LPStruct)] [In] Guid riid, [MarshalAs(UnmanagedType.Interface)] out IShellItem ppv);
	}
}
