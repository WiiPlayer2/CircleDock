using SingleInstance;
using System;
using System.Diagnostics;
using System.Threading;
using System.Windows.Forms;

namespace CircleDock
{
	internal static class Program
	{
		[STAThread]
		private static void Main()
		{
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			Application.ThreadException += new ThreadExceptionEventHandler(Program.Program_UIThreadException);
			Application.SetUnhandledExceptionMode(UnhandledExceptionMode.CatchException);
			AppDomain.CurrentDomain.UnhandledException += new UnhandledExceptionEventHandler(Program.CurrentDomain_UnhandledException);
			if (SingleApplication.Run(new MainForm()))
			{
			}
		}

		private static void Program_UIThreadException(object sender, ThreadExceptionEventArgs t)
		{
			DialogResult dialogResult = DialogResult.Cancel;
			try
			{
				dialogResult = Program.ShowThreadExceptionDialog("Circle Dock: Windows Forms Error", t.Exception);
			}
			catch
			{
				try
				{
					MessageBox.Show("Fatal Windows Forms Error", "Circle Dock", MessageBoxButtons.AbortRetryIgnore, MessageBoxIcon.Hand);
				}
				finally
				{
					Application.Exit();
				}
			}
			if (dialogResult == DialogResult.Abort)
			{
				Application.Exit();
			}
		}

		private static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
		{
			try
			{
				Exception ex = (Exception)e.ExceptionObject;
				string str = "An application error occurred. Please contact the adminstrator with the following information:\n\n";
				if (!EventLog.SourceExists("ThreadException"))
				{
					EventLog.CreateEventSource("ThreadException", "Application");
				}
				new EventLog
				{
					Source = "ThreadException"
				}.WriteEntry(str + ex.Message + "\n\nStack Trace:\n" + ex.StackTrace);
				MessageBox.Show("Current Domain Unhandled Exception", str + ex.Message + "\n\nStack Trace:\n" + ex.StackTrace, MessageBoxButtons.OK, MessageBoxIcon.Hand);
			}
			catch (Exception ex2)
			{
				try
				{
					MessageBox.Show("Fatal Non-UI Error. Could not write the error to the event log. Reason: " + ex2.Message, "Circle Dock: Current Domain", MessageBoxButtons.OK, MessageBoxIcon.Hand);
				}
				finally
				{
					Application.Exit();
				}
			}
		}

		private static DialogResult ShowThreadExceptionDialog(string title, Exception e)
		{
			string text = "An application error occurred. Please contact the adminstrator with the following information:\n\n";
			text = text + e.Message + "\n\nStack Trace:\n" + e.StackTrace;
			return MessageBox.Show(text, title, MessageBoxButtons.AbortRetryIgnore, MessageBoxIcon.Hand);
		}
	}
}
