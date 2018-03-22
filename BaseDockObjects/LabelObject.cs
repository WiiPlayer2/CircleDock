using CircleDock;
using ImageOperations;
using PerPixelAlphaForms;
using Pinvoke;
using SettingsLoader;
using System;
using System.ComponentModel;
using System.Drawing;

namespace BaseDockObjects
{
	public class LabelObject : LabelPerPixelAlphaForm
	{
		private IContainer components;

		private string LabelText;

		private Size LabelSize;

		private Point CentrePoint;

		private new MainForm ParentObject;

		private int TargetOpacity;

		private double OpacityRateOfChange;

		private double tempNewObjectOpacity;

		private void InitializeComponent()
		{
			this.components = new Container();
			base.SuspendLayout();
			base.Deactivate += new EventHandler(this.LabelObject_Deactivate);
			base.ClientSize = new Size(1, 1);
			base.Name = "TransparentObject";
			base.ResumeLayout(false);
		}

		private void LabelObject_Deactivate(object sender, EventArgs e)
		{
			this.ParentObject.itemDeactivated();
		}

		public LabelObject(MainForm theParent, SettingsLoader.SettingsLoader SettingsData, Size DisplaySize)
		{
			this.ParentObject = theParent;
			this.DockSettings = SettingsData;
			this.LabelSize = DisplaySize;
			this.InitializeComponent();
			this.DoubleBuffered = true;
			this.AnimationTimer.Tick += new EventHandler(this.AnimationTimer_Tick);
			this.AnimationTimer.Interval = this.DockSettings.General.AnimationInterval;
			this.SetZLevel();
			base.ShowInTaskbar = false;
			this.AllowDrop = false;
			this.ObjectOpacity = this.DockSettings.Labels.DefaultOpacity;
		}

		public void SetZLevel()
		{
			if (this.DockSettings.General.zLevel == "Always On Bottom")
			{
				Pinvoke.Win32.SetWindowPos(base.Handle, (IntPtr)1, 0, 0, 0, 0, 1563u);
			}
			else if (this.DockSettings.General.zLevel == "Normal")
			{
				Pinvoke.Win32.SetWindowPos(base.Handle, (IntPtr)(-2), 0, 0, 0, 0, 1563u);
			}
			else
			{
				Pinvoke.Win32.SetWindowPos(base.Handle, (IntPtr)(-1), 0, 0, 0, 0, 1563u);
			}
		}

		public void AnimateOpacity(int NewOpacity, int Duration)
		{
			if (Duration > 0)
			{
				this.TargetOpacity = NewOpacity;
				this.OpacityRateOfChange = ((double)NewOpacity - (double)this.ObjectOpacity) / ((double)Duration / (double)this.AnimationTimer.Interval);
				this.tempNewObjectOpacity = (double)this.ObjectOpacity;
				this.AnimationTimer.Start();
			}
		}

		private void AnimationTimer_Tick(object sender, EventArgs e)
		{
			this.tempNewObjectOpacity += this.OpacityRateOfChange;
			if ((this.OpacityRateOfChange > 0.0 && this.tempNewObjectOpacity > (double)this.TargetOpacity) || (this.OpacityRateOfChange < 0.0 && this.tempNewObjectOpacity < (double)this.TargetOpacity))
			{
				this.tempNewObjectOpacity = (double)this.TargetOpacity;
			}
			base.UpdateOpacity((int)this.tempNewObjectOpacity);
			if ((this.OpacityRateOfChange < 0.0 && this.ObjectOpacity <= this.TargetOpacity) || (this.OpacityRateOfChange > 0.0 && this.ObjectOpacity >= this.TargetOpacity))
			{
				this.AnimationTimer.Stop();
				this.AnimationTimer.Enabled = false;
			}
		}

		public void UpdateAnimationTimerInterval(int NewInterval)
		{
			this.AnimationTimer.Interval = NewInterval;
		}

		public void RedrawBitmap()
		{
			this.SetBitmap(this.LabelText, this.CentrePoint);
		}

		public void SetBitmap(string DisplayText, Point DisplayAtCentrePoint)
		{
			bool flag = 0 == 0;
			this.CentrePoint = DisplayAtCentrePoint;
			try
			{
				this.LabelText = DisplayText;
				Bitmap bitmap;
				if (DisplayText != null && DisplayText.Length > 0)
				{
					Font fontName = this.DockSettings.Labels.FontName;
					Color fontColor = this.DockSettings.Labels.FontColor;
					Color shadowColor = this.DockSettings.Labels.ShadowColor;
					bitmap = (Bitmap)FancyText.ImageFromText(DisplayText, fontName, fontColor, shadowColor, this.DockSettings.Labels.ShadowSize, this.DockSettings.Labels.ShadowDarkness);
				}
				else
				{
					bitmap = new Bitmap(1, 1);
				}
				base.SetBitmapManaged(ref bitmap);
				base.DrawBitmapManaged(bitmap.Width, bitmap.Height, true, DisplayAtCentrePoint.X - bitmap.Width / 2, DisplayAtCentrePoint.Y, false, 0, 0, 0, 0, false, 0);
				bitmap.Dispose();
			}
			catch (Exception)
			{
			}
		}
	}
}
