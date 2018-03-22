using System;

namespace ShellExtension
{
	public class ShellContextMenuException : Exception
	{
		public ShellContextMenuException()
		{
		}

		public ShellContextMenuException(string message) : base(message)
		{
		}
	}
}
