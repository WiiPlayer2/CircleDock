using System;

namespace ShellExtension
{
	public class HookEventArgs : EventArgs
	{
		public int HookCode;

		public IntPtr wParam;

		public IntPtr lParam;
	}
}
