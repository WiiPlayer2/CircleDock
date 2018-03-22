using System;

namespace ShellExtension
{
	internal static class ShellHelper
	{
		public static uint HiWord(IntPtr ptr)
		{
			uint result;
			if (((int)ptr & -2147483648) == -2147483648)
			{
				result = (uint)((int)ptr) >> 16;
			}
			else
			{
				result = ((uint)((int)ptr) >> 16 & 65535u);
			}
			return result;
		}

		public static uint LoWord(IntPtr ptr)
		{
			return (uint)((int)ptr & 65535);
		}
	}
}
