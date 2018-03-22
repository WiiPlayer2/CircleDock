using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace ShellExtension
{
	public class LocalWindowsHook
	{
		public delegate int HookProc(int code, IntPtr wParam, IntPtr lParam);

		public delegate void HookEventHandler(object sender, HookEventArgs e);

		protected IntPtr m_hhook = IntPtr.Zero;

		protected LocalWindowsHook.HookProc m_filterFunc = null;

		protected HookType m_hookType;

		public event LocalWindowsHook.HookEventHandler HookInvoked
		{
			[MethodImpl(MethodImplOptions.Synchronized)]
			add
			{
				this.HookInvoked = (LocalWindowsHook.HookEventHandler)Delegate.Combine(this.HookInvoked, value);
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			remove
			{
				this.HookInvoked = (LocalWindowsHook.HookEventHandler)Delegate.Remove(this.HookInvoked, value);
			}
		}

		protected void OnHookInvoked(HookEventArgs e)
		{
			if (this.HookInvoked != null)
			{
				this.HookInvoked(this, e);
			}
		}

		public LocalWindowsHook(HookType hook)
		{
			this.m_hookType = hook;
			this.m_filterFunc = new LocalWindowsHook.HookProc(this.CoreHookProc);
		}

		public LocalWindowsHook(HookType hook, LocalWindowsHook.HookProc func)
		{
			this.m_hookType = hook;
			this.m_filterFunc = func;
		}

		protected int CoreHookProc(int code, IntPtr wParam, IntPtr lParam)
		{
			int result;
			if (code < 0)
			{
				result = LocalWindowsHook.CallNextHookEx(this.m_hhook, code, wParam, lParam);
			}
			else
			{
				this.OnHookInvoked(new HookEventArgs
				{
					HookCode = code,
					wParam = wParam,
					lParam = lParam
				});
				result = LocalWindowsHook.CallNextHookEx(this.m_hhook, code, wParam, lParam);
			}
			return result;
		}

		public void Install()
		{
			this.m_hhook = LocalWindowsHook.SetWindowsHookEx(this.m_hookType, this.m_filterFunc, IntPtr.Zero, AppDomain.GetCurrentThreadId());
		}

		public void Uninstall()
		{
			LocalWindowsHook.UnhookWindowsHookEx(this.m_hhook);
		}

		[DllImport("user32.dll")]
		protected static extern IntPtr SetWindowsHookEx(HookType code, LocalWindowsHook.HookProc func, IntPtr hInstance, int threadID);

		[DllImport("user32.dll")]
		protected static extern int UnhookWindowsHookEx(IntPtr hhook);

		[DllImport("user32.dll")]
		protected static extern int CallNextHookEx(IntPtr hhook, int code, IntPtr wParam, IntPtr lParam);
	}
}
