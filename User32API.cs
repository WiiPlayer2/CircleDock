using System;
using System.Runtime.InteropServices;

namespace Pinvoke
{
	/// <summary>
	/// Provides declarations for the User32 API Calls
	/// </summary>
	public sealed class Win32
	{
        //Import for CreateWindowEx.
        //Use this function to create a new window with specified styles.
        /// <summary>
        /// CreateWindowEx allows you to specify regular Window styles and extend Window styles.
        /// </summary>
        /// <param name="dwExStyle">Extend Window Style</param>
        [DllImport("user32.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]
        public static extern IntPtr CreateWindowEx(
           uint dwExStyle,
           string lpClassName,
           string lpWindowName,
           uint dwStyle,
           int x,
           int y,
           int nWidth,
           int nHeight,
           IntPtr hWndParent,
           IntPtr hMenu,
           IntPtr hInstance,
           IntPtr lpParam);

	}
}