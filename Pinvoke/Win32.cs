using System;
using System.Drawing;
using System.Runtime.InteropServices;

namespace Pinvoke
{
	public sealed class Win32
	{
		public struct WINDOWINFO
		{
			public uint cbSize;

			public Win32.RECT rcWindow;

			public Win32.RECT rcClient;

			public uint dwStyle;

			public uint dwExStyle;

			public uint dwWindowStatus;

			public uint cxWindowBorders;

			public uint cyWindowBorders;

			public ushort atomWindowType;

			public ushort wCreatorVersion;
		}

		public struct RECT
		{
			public int left;

			public int top;

			public int right;

			public int bottom;
		}

		public enum ShowWindowEnum
		{
			Hide,
			ShowNormal,
			ShowMinimized,
			ShowMaximized,
			Maximize = 3,
			ShowNormalNoActivate,
			Show,
			Minimize,
			ShowMinNoActivate,
			ShowNoActivate,
			Restore,
			ShowDefault,
			ForceMinimized
		}

		public enum ShowCommands
		{
			SW_HIDE,
			SW_SHOWNORMAL,
			SW_NORMAL = 1,
			SW_SHOWMINIMIZED,
			SW_SHOWMAXIMIZED,
			SW_MAXIMIZE = 3,
			SW_SHOWNOACTIVATE,
			SW_SHOW,
			SW_MINIMIZE,
			SW_SHOWMINNOACTIVE,
			SW_SHOWNA,
			SW_RESTORE,
			SW_SHOWDEFAULT,
			SW_FORCEMINIMIZE,
			SW_MAX = 11
		}

		public const int SW_SHOWNOACTIVATE = 4;

		public const int HWND_TOPMOST = -1;

		public const int HWND_BOTTOM = 1;

		public const int HWND_NOTOPMOST = -2;

		public const uint SWP_NOACTIVATE = 16u;

		public const uint SWP_NOSIZE = 1u;

		public const uint SWP_NOMOVE = 2u;

		public const uint SWP_NOZORDER = 4u;

		public const uint SWP_NOREDRAW = 8u;

		public const uint SWP_SHOWWINDOW = 64u;

		public const uint SWP_FRAMECHANGED = 32u;

		public const uint SWP_HIDEWINDOW = 128u;

		public const uint SWP_NOCOPYBITS = 256u;

		public const uint SWP_NOOWNERZORDER = 512u;

		public const uint SWP_NOSENDCHANGING = 1024u;

		public const int MONITOR_DEFAULTTOPRIMARY = 1;

		public const int MONITOR_DEFAULTTONULL = 0;

		public const int MONITOR_DEFAULTTONEAREST = 2;

		[DllImport("user32.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Auto)]
		public static extern IntPtr CreateWindowEx(uint dwExStyle, string lpClassName, string lpWindowName, uint dwStyle, int x, int y, int nWidth, int nHeight, IntPtr hWndParent, IntPtr hMenu, IntPtr hInstance, IntPtr lpParam);

		[DllImport("user32.dll")]
		public static extern bool SetForegroundWindow(int hwnd);

		[DllImport("User32.dll")]
		public static extern bool SetForegroundWindow(IntPtr hWnd);

		[DllImport("user32.dll")]
		public static extern int GetDesktopWindow();

		[DllImport("user32.dll")]
		public static extern int FindWindow(string className, string windowText);

		[DllImport("user32.dll", SetLastError = true)]
		public static extern IntPtr FindWindowEx(IntPtr parentHandle, IntPtr childAfter, string className, string windowTitle);

		[DllImport("user32")]
		public static extern int MoveWindow(int hwnd, int x, int y, int nWidth, int nHeight, int bRepaint);

		[DllImport("user32.dll")]
		public static extern bool GetWindowInfo(IntPtr hwnd, ref Win32.WINDOWINFO pwi);

		[DllImport("user32.dll")]
		public static extern uint SendMessage(IntPtr hWnd, uint msg, uint wParam, uint lParam);

		[DllImport("user32.dll")]
		public static extern IntPtr GetForegroundWindow();

		[DllImport("user32.dll", CallingConvention = CallingConvention.StdCall, SetLastError = true)]
		public static extern int SetWindowPos(IntPtr hWnd, IntPtr hWndInsertAfter, int X, int Y, int cx, int cy, uint uFlags);

		[DllImport("user32.dll")]
		public static extern bool SetWindowPos(int hWnd, int hWndInsertAfter, int X, int Y, int cx, int cy, uint uFlags);

		[DllImport("user32.dll")]
		public static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);

		[DllImport("user32.dll")]
		public static extern bool ShowWindowAsync(IntPtr hWnd, int nCmdShow);

		[DllImport("user32.dll", SetLastError = true)]
		public static extern IntPtr SetParent(IntPtr hWndChild, IntPtr hWndNewParent);

		[DllImport("user32.dll")]
		public static extern int SetWindowLong(IntPtr hWnd, int nIndex, int dwNewLong);

		[DllImport("user32.dll")]
		public static extern int SetWindowLong(IntPtr hWnd, int nIndex, long dwNewLong);

		[DllImport("user32.dll")]
		public static extern long GetWindowLong(IntPtr hWnd, int nIndex);

		[DllImport("user32.dll")]
		public static extern bool RegisterHotKey(IntPtr hWnd, int id, int fsModifiers, int vlc);

		[DllImport("user32.dll")]
		public static extern bool UnregisterHotKey(IntPtr hWnd, int id);

		[DllImport("kernel32.dll")]
		public static extern bool SetProcessWorkingSetSize(IntPtr proc, int min, int max);

		[DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
		public static extern bool SendNotifyMessage(IntPtr hWnd, uint Msg, UIntPtr wParam, IntPtr lParam);

		[DllImport("user32")]
		public static extern int SetLayeredWindowAttributes(IntPtr hWnd, byte crey, byte alpha, int flags);

		[DllImport("user32.dll", SetLastError = true)]
		[return: MarshalAs(UnmanagedType.Bool)]
		private static extern bool PostMessage(HandleRef hWnd, uint Msg, IntPtr wParam, IntPtr lParam);

		public static IntPtr GetClassLongPtr(IntPtr hWnd, int nIndex)
		{
			IntPtr result;
			if (IntPtr.Size > 4)
			{
				result = Win32.GetClassLongPtr64(hWnd, nIndex);
			}
			else
			{
				result = new IntPtr((long)((ulong)Win32.GetClassLongPtr32(hWnd, nIndex)));
			}
			return result;
		}

		[DllImport("user32.dll", EntryPoint = "GetClassLong")]
		public static extern uint GetClassLongPtr32(IntPtr hWnd, int nIndex);

		[DllImport("user32.dll", EntryPoint = "GetClassLongPtr")]
		public static extern IntPtr GetClassLongPtr64(IntPtr hWnd, int nIndex);

		public static IntPtr SetClassLong(IntPtr hWnd, int nIndex, IntPtr dwNewLong)
		{
			IntPtr result;
			if (IntPtr.Size > 4)
			{
				result = Win32.SetClassLongPtr64(hWnd, nIndex, dwNewLong);
			}
			else
			{
				result = new IntPtr((long)((ulong)Win32.SetClassLongPtr32(hWnd, nIndex, (uint)dwNewLong.ToInt32())));
			}
			return result;
		}

		[DllImport("user32.dll", EntryPoint = "SetClassLong")]
		public static extern uint SetClassLongPtr32(IntPtr hWnd, int nIndex, uint dwNewLong);

		[DllImport("user32.dll", EntryPoint = "SetClassLongPtr")]
		public static extern IntPtr SetClassLongPtr64(IntPtr hWnd, int nIndex, IntPtr dwNewLong);

		[DllImport("user32.dll")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool RedrawWindow(IntPtr hWnd, [In] ref Win32.RECT lprcUpdate, IntPtr hrgnUpdate, uint flags);

		[DllImport("user32.dll")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool RedrawWindow(IntPtr hWnd, IntPtr lprcUpdate, IntPtr hrgnUpdate, uint flags);

		[DllImport("shell32.dll")]
		public static extern IntPtr ShellExecute(IntPtr hwnd, string lpOperation, string lpFile, string lpParameters, string lpDirectory, Win32.ShowCommands nShowCmd);

		[DllImport("User32")]
		public static extern IntPtr MonitorFromWindow(IntPtr hWnd, int dwFlags);

		[DllImport("user32.dll")]
		public static extern IntPtr MonitorFromPoint(Point pt, uint dwFlags);
	}
}
