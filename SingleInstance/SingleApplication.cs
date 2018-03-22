using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace SingleInstance
{
	public class SingleApplication
	{
		private const int SW_RESTORE = 9;

		[DllImport("user32.dll")]
		private static extern int ShowWindow(IntPtr hWnd, int nCmdShow);

		[DllImport("user32.dll")]
		private static extern int SetForegroundWindow(IntPtr hWnd);

		[DllImport("user32.dll")]
		private static extern int IsIconic(IntPtr hWnd);

		private static IntPtr GetCurrentInstanceWindowHandle()
		{
			IntPtr result = IntPtr.Zero;
			Process currentProcess = Process.GetCurrentProcess();
			Process[] processesByName = Process.GetProcessesByName(currentProcess.ProcessName);
			Process[] array = processesByName;
			for (int i = 0; i < array.Length; i++)
			{
				Process process = array[i];
				if (process.Id != currentProcess.Id && process.MainModule.FileName == currentProcess.MainModule.FileName && process.MainWindowHandle != IntPtr.Zero)
				{
					result = process.MainWindowHandle;
					break;
				}
			}
			return result;
		}

		private static void SwitchToCurrentInstance()
		{
			IntPtr currentInstanceWindowHandle = SingleApplication.GetCurrentInstanceWindowHandle();
			if (currentInstanceWindowHandle != IntPtr.Zero)
			{
			}
		}

		public static bool Run(Form frmMain)
		{
			bool result;
			if (SingleApplication.IsAlreadyRunning())
			{
				SingleApplication.SwitchToCurrentInstance();
				result = false;
			}
			else
			{
				Application.Run(frmMain);
				result = true;
			}
			return result;
		}

		public static bool Run()
		{
			return !SingleApplication.IsAlreadyRunning();
		}

		private static bool IsAlreadyRunning()
		{
			int num = 0;
			Process[] processes = Process.GetProcesses();
			Process[] array = processes;
			for (int i = 0; i < array.Length; i++)
			{
				Process process = array[i];
				try
				{
					if (process.MainModule.FileName.ToUpper() == Application.ExecutablePath.ToUpper())
					{
						num++;
					}
				}
				catch (Exception)
				{
				}
			}
			return num > 1;
		}
	}
}
