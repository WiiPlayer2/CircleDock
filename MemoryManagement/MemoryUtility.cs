using Pinvoke;
using System;
using System.Diagnostics;

namespace MemoryManagement
{
	public static class MemoryUtility
	{
		private static volatile bool _enabled = true;

		public static void ClearUnusedMemory()
		{
			if (MemoryUtility._enabled)
			{
				try
				{
					if (Environment.OSVersion.Platform >= PlatformID.Win32NT)
					{
						Win32.SetProcessWorkingSetSize(Process.GetCurrentProcess().Handle, -1, -1);
					}
					else
					{
						MemoryUtility._enabled = false;
					}
				}
				catch
				{
					MemoryUtility._enabled = false;
				}
			}
		}
	}
}
