using System;
using System.Runtime.InteropServices;

namespace Hook
{
	public class Hooks
	{
		private enum SystemEvents : uint
		{
			EVENT_SYSTEM_CREATE = 3u,
			EVENT_SYSTEM_DESTROY = 32769u,
			EVENT_SYSTEM_MINIMIZESTART = 22u,
			EVENT_SYSTEM_MINIMIZEEND,
			EVENT_SYSTEM_FOREGROUND = 3u
		}

		private delegate void WinEventDelegate(IntPtr hWinEventHook, uint eventType, IntPtr hWnd, int idObject, int idChild, uint dwEventThread, uint dwmsEventTime);

		private delegate int HookProc(int nCode, int wParam, IntPtr lParam);

		private const uint WINEVENT_OUTOFCONTEXT = 0u;

		private Hooks.WinEventDelegate dEvent;

		private IntPtr pHook;

		private IntPtr qHook;

		private IntPtr rHook;

		private IntPtr sHook;

		private IntPtr tHook;

		public OnForegroundWindowChangedDelegate OnForegroundWindowChanged;

		public OnWindowMinimizeStartDelegate OnWindowMinimizeStart;

		public OnWindowMinimizeEndDelegate OnWindowMinimizeEnd;

		public OnWindowDestroyDelegate OnWindowDestroy;

		public OnWindowCreateDelegate OnWindowCreate;

		[DllImport("User32.dll", SetLastError = true)]
		private static extern IntPtr SetWinEventHook(uint eventMin, uint eventMax, IntPtr hmodWinEventProc, Hooks.WinEventDelegate lpfnWinEventProc, uint idProcess, uint idThread, uint dwFlags);

		[DllImport("user32.dll")]
		private static extern bool UnhookWinEvent(IntPtr hWinEventHook);

		public Hooks()
		{
			this.dEvent = new Hooks.WinEventDelegate(this.WinEvent);
			this.pHook = Hooks.SetWinEventHook(32769u, 32769u, IntPtr.Zero, this.dEvent, 0u, 0u, 0u);
			this.qHook = Hooks.SetWinEventHook(22u, 22u, IntPtr.Zero, this.dEvent, 0u, 0u, 0u);
			this.rHook = Hooks.SetWinEventHook(23u, 23u, IntPtr.Zero, this.dEvent, 0u, 0u, 0u);
			this.sHook = Hooks.SetWinEventHook(3u, 3u, IntPtr.Zero, this.dEvent, 0u, 0u, 0u);
			GC.KeepAlive(this.dEvent);
			GC.KeepAlive(this.qHook);
			GC.KeepAlive(this.pHook);
			GC.KeepAlive(this.rHook);
			GC.KeepAlive(this.sHook);
		}

		private void WinEvent(IntPtr hWinEventHook, uint eventType, IntPtr hWnd, int idObject, int idChild, uint dwEventThread, uint dwmsEventTime)
		{
			GC.KeepAlive(this.dEvent);
			GC.KeepAlive(this.qHook);
			GC.KeepAlive(this.pHook);
			GC.KeepAlive(this.rHook);
			GC.KeepAlive(this.sHook);
			if (eventType != 3u)
			{
				switch (eventType)
				{
				case 22u:
					if (this.OnWindowMinimizeStart != null)
					{
						this.OnWindowMinimizeStart(hWnd);
					}
					break;
				case 23u:
					if (this.OnWindowMinimizeEnd != null)
					{
						this.OnWindowMinimizeEnd(hWnd);
					}
					break;
				default:
					if (eventType == 32769u)
					{
						if (this.OnWindowDestroy != null)
						{
							this.OnWindowDestroy(hWnd);
						}
					}
					break;
				}
			}
			else if (this.OnForegroundWindowChanged != null)
			{
				this.OnForegroundWindowChanged(hWnd);
			}
		}

		~Hooks()
		{
			try
			{
				if (!IntPtr.Zero.Equals(this.qHook))
				{
					Hooks.UnhookWinEvent(this.qHook);
				}
				if (!IntPtr.Zero.Equals(this.pHook))
				{
					Hooks.UnhookWinEvent(this.pHook);
				}
				if (!IntPtr.Zero.Equals(this.rHook))
				{
					Hooks.UnhookWinEvent(this.rHook);
				}
				if (!IntPtr.Zero.Equals(this.sHook))
				{
					Hooks.UnhookWinEvent(this.sHook);
				}
				if (!IntPtr.Zero.Equals(this.sHook))
				{
					Hooks.UnhookWinEvent(this.tHook);
				}
			}
			catch (Exception)
			{
			}
			this.pHook = IntPtr.Zero;
			this.qHook = IntPtr.Zero;
			this.rHook = IntPtr.Zero;
			this.sHook = IntPtr.Zero;
			this.tHook = IntPtr.Zero;
			this.dEvent = null;
			this.OnWindowMinimizeStart = null;
			this.OnWindowDestroy = null;
			this.OnWindowMinimizeEnd = null;
			this.OnForegroundWindowChanged = null;
			this.OnWindowCreate = null;
		}
	}
}
