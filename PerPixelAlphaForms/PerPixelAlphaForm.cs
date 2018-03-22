using CircleDock;
using DockItemsInformation;
using ImageOperations;
using LanguageLoader;
using SettingsLoader;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace PerPixelAlphaForms
{
	public class PerPixelAlphaForm : Form
	{
		public Bitmap ObjectBitmap;

		public int ObjectOpacity;

		public Bitmap OverlayBitmap;

		public MainForm ParentObject;

		public ObjectData WorkingObjectData;

		public bool LeftMouseButtonDown;

		public bool ThisObjectMovedWithLeftMouse;

		public LanguageLoader Language;

		public SettingsLoader DockSettings;

		public Size ObjectSize;

		public Size OverlaySize;

		private IContainer components = null;

		public Timer AnimationTimer;

		private Bitmap CurrentObjectBitmap;

		private void InitializeComponent()
		{
			this.components = new Container();
			this.AnimationTimer = new Timer(this.components);
		}

		public PerPixelAlphaForm()
		{
			this.InitializeComponent();
			base.FormBorderStyle = FormBorderStyle.None;
			base.ShowInTaskbar = false;
			this.AllowDrop = true;
			this.EnableDoubleBuffering();
			base.StartPosition = FormStartPosition.Manual;
			this.ObjectOpacity = 255;
		}

		public void EnableDoubleBuffering()
		{
			this.DoubleBuffered = true;
			base.SetStyle(ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint | ControlStyles.DoubleBuffer, true);
			base.UpdateStyles();
		}

		private void SetBitmap(ref Bitmap bitmap, byte opacity, bool SetNewPos, int NewLeftPos, int NewTopPos)
		{
			IntPtr dC = Win32.GetDC(IntPtr.Zero);
			IntPtr intPtr = Win32.CreateCompatibleDC(dC);
			IntPtr intPtr2 = IntPtr.Zero;
			IntPtr hObject = IntPtr.Zero;
			try
			{
				intPtr2 = bitmap.GetHbitmap(Color.FromArgb(0));
				hObject = Win32.SelectObject(intPtr, intPtr2);
				Win32.Size size = new Win32.Size(bitmap.Width, bitmap.Height);
				Win32.Point point = new Win32.Point(0, 0);
				Win32.Point point2;
				if (SetNewPos)
				{
					point2 = new Win32.Point(NewLeftPos, NewTopPos);
					base.Location = new Point(NewLeftPos, NewTopPos);
				}
				else
				{
					point2 = new Win32.Point(base.Left, base.Top);
					base.Location = new Point(base.Left, base.Top);
				}
				Win32.BLENDFUNCTION bLENDFUNCTION = default(Win32.BLENDFUNCTION);
				bLENDFUNCTION.BlendOp = 0;
				bLENDFUNCTION.BlendFlags = 0;
				bLENDFUNCTION.SourceConstantAlpha = opacity;
				bLENDFUNCTION.AlphaFormat = 1;
				Win32.UpdateLayeredWindow(base.Handle, dC, ref point2, ref size, intPtr, ref point, 0, ref bLENDFUNCTION, 2);
			}
			catch (Exception)
			{
			}
			finally
			{
				Win32.ReleaseDC(IntPtr.Zero, dC);
				if (intPtr2 != IntPtr.Zero)
				{
					Win32.SelectObject(intPtr, hObject);
					Win32.DeleteObject(intPtr2);
				}
				Win32.DeleteDC(intPtr);
			}
		}

		public void SetBitmapManaged(string fileName)
		{
			try
			{
				Bitmap objectBitmap = Image.FromFile(fileName) as Bitmap;
				if (this.ObjectBitmap != null)
				{
					this.ObjectBitmap.Dispose();
				}
				this.ObjectBitmap = objectBitmap;
			}
			catch (Exception)
			{
			}
		}

		public void SetBitmapManaged(ref Bitmap newBitmap)
		{
			try
			{
				if (this.ObjectBitmap != null)
				{
					this.ObjectBitmap.Dispose();
				}
				this.ObjectBitmap = newBitmap;
			}
			catch (Exception)
			{
			}
		}

		public void SetOverlayManaged(string fileName)
		{
			try
			{
				Bitmap overlayBitmap = Image.FromFile(fileName) as Bitmap;
				if (this.OverlayBitmap != null)
				{
					this.OverlayBitmap.Dispose();
				}
				this.OverlayBitmap = overlayBitmap;
			}
			catch (Exception)
			{
			}
		}

		public void SetOverlayManaged(ref Bitmap newBitmap)
		{
			try
			{
				if (this.OverlayBitmap != null)
				{
					this.OverlayBitmap.Dispose();
				}
				this.OverlayBitmap = newBitmap;
			}
			catch (Exception)
			{
			}
		}

		public void DrawBitmapManaged(int ObjectDesiredWidth, int ObjectDesiredHeight, bool ChangePosition, int NewLeft, int NewTop, bool ShowOverlay, int OverlayDesiredLeft, int OverlayDesiredTop, int OverlayDesiredWidth, int OverlayDesiredHeight, bool ChangeOpacity, int NewOpacity)
		{
			try
			{
				if (this.ObjectBitmap != null)
				{
					this.CurrentObjectBitmap = BitmapOperations.ScaleBySizeBestFit(ref this.ObjectBitmap, ObjectDesiredWidth, ObjectDesiredHeight);
					if (ShowOverlay && this.OverlayBitmap != null)
					{
						using (Graphics graphics = Graphics.FromImage(this.CurrentObjectBitmap))
						{
							graphics.SmoothingMode = SmoothingMode.HighSpeed;
							graphics.PixelOffsetMode = PixelOffsetMode.HighSpeed;
							graphics.CompositingQuality = CompositingQuality.HighSpeed;
							graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
							graphics.DrawImage(this.CurrentObjectBitmap, new Rectangle(OverlayDesiredLeft, OverlayDesiredTop, OverlayDesiredWidth, OverlayDesiredHeight), new Rectangle(0, 0, this.OverlayBitmap.Width, this.OverlayBitmap.Height), GraphicsUnit.Pixel);
						}
					}
					if (this.ObjectSize.Width != ObjectDesiredWidth || this.ObjectSize.Height != ObjectDesiredHeight)
					{
						this.ObjectSize = new Size(ObjectDesiredWidth, ObjectDesiredHeight);
					}
					if (this.OverlaySize.Width != OverlayDesiredWidth || this.OverlaySize.Height != OverlayDesiredHeight)
					{
						this.OverlaySize = new Size(OverlayDesiredWidth, OverlayDesiredHeight);
					}
					if (ChangeOpacity)
					{
						if (NewOpacity < 0)
						{
							this.ObjectOpacity = 0;
						}
						else if (NewOpacity > 255)
						{
							this.ObjectOpacity = 255;
						}
						else
						{
							this.ObjectOpacity = NewOpacity;
						}
					}
					this.SetBitmap(ref this.CurrentObjectBitmap, (byte)this.ObjectOpacity, ChangePosition, NewLeft, NewTop);
				}
			}
			catch (Exception)
			{
			}
		}

		public void UpdateOpacity(int NewOpacity)
		{
			if (this.CurrentObjectBitmap != null)
			{
				if (NewOpacity < 0)
				{
					this.ObjectOpacity = 0;
				}
				else if (NewOpacity > 255)
				{
					this.ObjectOpacity = 255;
				}
				else
				{
					this.ObjectOpacity = NewOpacity;
				}
				this.SetBitmap(ref this.CurrentObjectBitmap, (byte)this.ObjectOpacity, false, 0, 0);
			}
		}
	}
}
