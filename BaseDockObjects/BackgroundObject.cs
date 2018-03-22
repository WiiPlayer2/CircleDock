using CircleDock;
using FileOps;
using LanguageLoader;
using PerPixelAlphaForms;
using Pinvoke;
using SettingsLoader;
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.Windows.Forms;

namespace BaseDockObjects
{
	public class BackgroundObject : BackgroundPerPixelAlphaForm
	{
		private ContextMenuStrip contextMenuStrip;

		private IContainer components;

		private ToolStripMenuItem quitToolStripMenuItem;

		private ToolStripMenuItem addToolStripMenuItem;

		private ToolStripMenuItem hideToolStripMenuItem;

		private ToolStripMenuItem settingsToolStripMenuItem;

		private ToolStripMenuItem dockFolderToolStripMenuItem;

		private ToolStripMenuItem changeIconToolStripMenuItem;

		private ToolStripMenuItem iconReplacementModeToolStripMenuItem;

		private ToolStripMenuItem pauseMouseHotkeysToolStripMenuItem;

		private ToolStripMenuItem blankIconToolStripMenuItem;

		private OpenFileDialog ChangeIconDialog;

		public string SectionName;

		private Point previousMousePosition;

		private Point StoredMouseOffset;

		private int TargetOpacity;

		private double OpacityRateOfChange;

		private double tempNewObjectOpacity;

		private void InitializeComponent()
		{
			this.components = new Container();
			this.contextMenuStrip = new ContextMenuStrip(this.components);
			this.quitToolStripMenuItem = new ToolStripMenuItem();
			this.addToolStripMenuItem = new ToolStripMenuItem();
			this.hideToolStripMenuItem = new ToolStripMenuItem();
			this.dockFolderToolStripMenuItem = new ToolStripMenuItem();
			this.blankIconToolStripMenuItem = new ToolStripMenuItem();
			this.settingsToolStripMenuItem = new ToolStripMenuItem();
			this.changeIconToolStripMenuItem = new ToolStripMenuItem();
			this.iconReplacementModeToolStripMenuItem = new ToolStripMenuItem();
			this.pauseMouseHotkeysToolStripMenuItem = new ToolStripMenuItem();
			this.ChangeIconDialog = new OpenFileDialog();
			this.contextMenuStrip.SuspendLayout();
			base.SuspendLayout();
			this.contextMenuStrip.Items.AddRange(new ToolStripItem[]
			{
				this.hideToolStripMenuItem,
				this.addToolStripMenuItem,
				this.changeIconToolStripMenuItem,
				this.iconReplacementModeToolStripMenuItem,
				this.pauseMouseHotkeysToolStripMenuItem,
				this.settingsToolStripMenuItem,
				this.quitToolStripMenuItem
			});
			this.contextMenuStrip.Name = "contextMenuStrip";
			this.contextMenuStrip.Size = new Size(153, 48);
			this.contextMenuStrip.Opening += new CancelEventHandler(this.contextMenuStrip_Opening);
			this.quitToolStripMenuItem.Name = "quitToolStripMenuItem";
			this.quitToolStripMenuItem.Size = new Size(152, 22);
			this.quitToolStripMenuItem.Text = this.Language.MainContextMenu.QuitWord;
			this.quitToolStripMenuItem.Click += new EventHandler(this.quitToolStripMenuItem_Click);
			this.addToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[]
			{
				this.dockFolderToolStripMenuItem,
				this.blankIconToolStripMenuItem
			});
			this.addToolStripMenuItem.Name = "addToolStripMenuItem";
			this.addToolStripMenuItem.Size = new Size(152, 22);
			this.addToolStripMenuItem.Text = this.Language.MainContextMenu.AddWord;
			this.hideToolStripMenuItem.Name = "hideToolStripMenuItem";
			this.hideToolStripMenuItem.Size = new Size(152, 22);
			this.hideToolStripMenuItem.Text = this.Language.MainContextMenu.HideWord;
			this.hideToolStripMenuItem.Click += new EventHandler(this.hideToolStripMenuItem_Click);
			this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
			this.settingsToolStripMenuItem.Size = new Size(152, 22);
			this.settingsToolStripMenuItem.Text = this.Language.MainContextMenu.SettingsWord;
			this.settingsToolStripMenuItem.Click += new EventHandler(this.settingsToolStripMenuItem_Click);
			this.iconReplacementModeToolStripMenuItem.Name = "iconReplacementModeToolStripMenuItem";
			this.iconReplacementModeToolStripMenuItem.Size = new Size(152, 22);
			this.iconReplacementModeToolStripMenuItem.Text = this.Language.General.IconReplacementMode;
			this.iconReplacementModeToolStripMenuItem.CheckOnClick = true;
			this.iconReplacementModeToolStripMenuItem.Checked = this.DockSettings.General.IconReplacementMode;
			this.iconReplacementModeToolStripMenuItem.Click += new EventHandler(this.iconReplacementModeToolStripMenuItem_Click);
			this.pauseMouseHotkeysToolStripMenuItem.Name = "pauseMouseHotkeysToolStripMenuItem";
			this.pauseMouseHotkeysToolStripMenuItem.Size = new Size(152, 22);
			this.pauseMouseHotkeysToolStripMenuItem.Text = this.Language.MainContextMenu.PauseMouseToggling;
			this.pauseMouseHotkeysToolStripMenuItem.CheckOnClick = true;
			this.pauseMouseHotkeysToolStripMenuItem.Click += new EventHandler(this.pauseMouseHotkeysToolStripMenuItem_Click);
			this.ChangeIconDialog.InitialDirectory = Application.StartupPath + "\\System\\Icons";
			this.ChangeIconDialog.Filter = "PNG|*.png";
			this.ChangeIconDialog.Multiselect = false;
			this.ChangeIconDialog.Title = this.Language.MainContextMenu.ChangeIcon;
			this.ChangeIconDialog.FileOk += new CancelEventHandler(this.ChangeIconDialog_FileOk);
			this.changeIconToolStripMenuItem.Name = "changeIconToolStripMenuItem";
			this.changeIconToolStripMenuItem.Size = new Size(152, 22);
			this.changeIconToolStripMenuItem.Text = this.Language.MainContextMenu.ChangeIcon;
			this.changeIconToolStripMenuItem.Click += new EventHandler(this.changeIconToolStripMenuItem_Click);
			this.dockFolderToolStripMenuItem.Name = "dockFolderToolStripMenuItem";
			this.dockFolderToolStripMenuItem.Size = new Size(152, 22);
			this.dockFolderToolStripMenuItem.Text = this.Language.MainContextMenu.DockFolder;
			this.dockFolderToolStripMenuItem.Click += new EventHandler(this.dockFolderToolStripMenuItem_Click);
			this.blankIconToolStripMenuItem.Name = "blankIconToolStripMenuItem";
			this.blankIconToolStripMenuItem.Size = new Size(152, 22);
			this.blankIconToolStripMenuItem.Text = this.Language.MainContextMenu.blankIcon;
			this.blankIconToolStripMenuItem.Click += new EventHandler(this.blankIconToolStripMenuItem_Click);
			base.ClientSize = new Size(1, 1);
			base.MouseEnter += new EventHandler(this.BackgroundObject_MouseEnter);
			base.MouseDown += new MouseEventHandler(this.BackgroundObject_MouseDown);
			base.MouseUp += new MouseEventHandler(this.BackgroundObject_MouseUp);
			base.MouseMove += new MouseEventHandler(this.BackgroundObject_MouseMove);
			base.MouseWheel += new MouseEventHandler(this.BackgroundObject_MouseWheel);
			base.MouseHover += new EventHandler(this.BackgroundObject_MouseHover);
			base.DragEnter += new DragEventHandler(this.BackgroundObject_DragEnter);
			base.DragDrop += new DragEventHandler(this.BackgroundObject_DragDrop);
			base.KeyDown += new KeyEventHandler(this.BackgroundObject_KeyDown);
			base.Deactivate += new EventHandler(this.BackgroundObject_Deactivate);
			this.ContextMenuStrip = this.contextMenuStrip;
			base.Name = "TransparentObject";
			this.contextMenuStrip.ResumeLayout(false);
			base.ResumeLayout(false);
		}

		private void BackgroundObject_Deactivate(object sender, EventArgs e)
		{
			this.ParentObject.itemDeactivated();
		}

		protected override void WndProc(ref Message m)
		{
			base.WndProc(ref m);
		}

		public BackgroundObject(MainForm TheParent, LanguageLoader LanguageData, SettingsLoader SettingsData, string Section, Size InitialSize)
		{
			this.Language = LanguageData;
			this.DockSettings = SettingsData;
			this.ParentObject = TheParent;
			this.SectionName = Section;
			this.ObjectSize = InitialSize;
			this.InitializeComponent();
			this.DoubleBuffered = true;
			this.AnimationTimer.Tick += new EventHandler(this.AnimationTimer_Tick);
			this.AnimationTimer.Interval = this.DockSettings.General.AnimationInterval;
			base.ShowInTaskbar = false;
			this.AllowDrop = true;
			this.LeftMouseButtonDown = false;
			this.ThisObjectMovedWithLeftMouse = false;
			this.ObjectBitmap = new Bitmap(1, 1, PixelFormat.Format32bppArgb);
			this.OverlayBitmap = new Bitmap(1, 1, PixelFormat.Format32bppArgb);
			this.ObjectOpacity = this.DockSettings.Background.DefaultOpacity;
			this.SetZLevel();
			this.SetBitmap();
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

		public void SetBitmap()
		{
			Bitmap bitmap;
			try
			{
				if (this.DockSettings.Background.Path.StartsWith(".\\"))
				{
					bitmap = new Bitmap(Application.StartupPath + this.DockSettings.Background.Path.Substring(1, this.DockSettings.Background.Path.Length - 1));
				}
				else
				{
					bitmap = new Bitmap(this.DockSettings.Background.Path);
				}
			}
			catch (Exception)
			{
				bitmap = new Bitmap(ImageResources.sapphire_ring);
			}
			base.SetBitmapManaged(ref bitmap);
		}

		protected override void OnMove(EventArgs e)
		{
			base.OnMove(e);
		}

		private void BackgroundObject_MouseHover(object sender, EventArgs e)
		{
			base.Activate();
		}

		private void BackgroundObject_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Left)
			{
				this.ParentObject.RotateDock(-1.0);
			}
			else if (e.KeyCode == Keys.Right)
			{
				this.ParentObject.RotateDock(1.0);
			}
			else if (e.KeyCode == Keys.Down)
			{
				this.ParentObject.RotateDock(-1.0);
			}
			else if (e.KeyCode == Keys.Up)
			{
				this.ParentObject.RotateDock(1.0);
			}
		}

		private void BackgroundObject_DragEnter(object sender, DragEventArgs e)
		{
			e.Effect = DragDropEffects.Link;
		}

		private void BackgroundObject_DragDrop(object sender, DragEventArgs e)
		{
			string[] array = e.Data.GetData(DataFormats.FileDrop) as string[];
			if (this.DockSettings.General.IconReplacementMode && array != null && array.Length == 1 && array[0].ToUpper().EndsWith(".PNG"))
			{
				this.ChangeIconDialog.FileName = array[0];
				this.ChangeIconDialog_FileOk(this, null);
			}
			else if (array != null)
			{
				this.ParentObject.CentreObject.Activate();
				for (int i = 0; i < array.Length; i++)
				{
					this.ParentObject.AddDockItem("[link]", array[i], "Link", "", "");
				}
				this.ParentObject.PositionCurrentLevel();
			}
		}

		private void BackgroundObject_MouseWheel(object sender, MouseEventArgs e)
		{
			if (e.Delta < 0)
			{
				this.ParentObject.RotateDock(1.0);
			}
			else
			{
				this.ParentObject.RotateDock(-1.0);
			}
		}

		private void BackgroundObject_MouseMove(object sender, MouseEventArgs e)
		{
			if (!this.DockSettings.General.lockDockPosition && this.LeftMouseButtonDown)
			{
				if (this.ThisObjectMovedWithLeftMouse || Math.Abs(Cursor.Position.X - this.previousMousePosition.X) > this.DockSettings.General.ClickSensitivity || Math.Abs(Cursor.Position.Y - this.previousMousePosition.Y) > this.DockSettings.General.ClickSensitivity)
				{
					this.ThisObjectMovedWithLeftMouse = true;
					base.Location = new Point(Cursor.Position.X - this.StoredMouseOffset.X, Cursor.Position.Y - this.StoredMouseOffset.Y);
					if (this.ParentObject != null)
					{
						this.ParentObject.ChildMoved(this);
					}
				}
			}
		}

		private void BackgroundObject_MouseUp(object sender, MouseEventArgs e)
		{
			if (!this.ThisObjectMovedWithLeftMouse)
			{
				if (e.Button == MouseButtons.Left && this.LeftMouseButtonDown)
				{
					this.LeftMouseButtonDown = false;
				}
			}
			else
			{
				this.ThisObjectMovedWithLeftMouse = false;
				if (e.Button == MouseButtons.Left && this.LeftMouseButtonDown)
				{
					this.LeftMouseButtonDown = false;
				}
			}
		}

		private void BackgroundObject_MouseDown(object sender, MouseEventArgs e)
		{
			base.Activate();
			base.BringToFront();
			if (e.Button == MouseButtons.Left)
			{
				this.LeftMouseButtonDown = true;
				this.ThisObjectMovedWithLeftMouse = false;
				this.StoredMouseOffset = new Point(Cursor.Position.X - base.Location.X, Cursor.Position.Y - base.Location.Y);
				this.previousMousePosition = Cursor.Position;
			}
		}

		private void BackgroundObject_MouseEnter(object sender, EventArgs e)
		{
			base.BringToFront();
		}

		private void quitToolStripMenuItem_Click(object sender, EventArgs e)
		{
			this.ParentObject.ChildRequestAction("QUIT");
		}

		private void dockFolderToolStripMenuItem_Click(object sender, EventArgs e)
		{
			this.ParentObject.CentreObject.Activate();
			this.ParentObject.AddDockItem("[dockfolder]", "", this.Language.MainContextMenu.DockFolder, this.DockSettings.Folders.DockFolderImagePath, this.Language.MainContextMenu.DockFolder);
			this.ParentObject.PositionCurrentLevel();
		}

		private void blankIconToolStripMenuItem_Click(object sender, EventArgs e)
		{
			this.ParentObject.CentreObject.Activate();
			this.ParentObject.AddDockItem("[blanklink]", "", "Link", "", "");
			this.ParentObject.PositionCurrentLevel();
		}

		private void hideToolStripMenuItem_Click(object sender, EventArgs e)
		{
			this.ParentObject.HideAll();
		}

		private void settingsToolStripMenuItem_Click(object sender, EventArgs e)
		{
			this.ParentObject.ShowSettingsPanel();
		}

		private void pauseMouseHotkeysToolStripMenuItem_Click(object sender, EventArgs e)
		{
			this.ParentObject.pauseMouseHotkeysToolStripMenuItem.Checked = this.pauseMouseHotkeysToolStripMenuItem.Checked;
			this.ParentObject.SetMouseKeys();
		}

		private void changeIconToolStripMenuItem_Click(object sender, EventArgs e)
		{
			this.ChangeIconDialog.InitialDirectory = Application.StartupPath + "\\System\\Icons";
			this.ChangeIconDialog.ShowDialog();
		}

		private void iconReplacementModeToolStripMenuItem_Click(object sender, EventArgs e)
		{
			this.DockSettings.General.IconReplacementMode = this.iconReplacementModeToolStripMenuItem.Checked;
			this.DockSettings.SetEntry("General", "IconReplacementMode", this.iconReplacementModeToolStripMenuItem.Checked.ToString());
			if (this.DockSettings.General.IconReplacementMode)
			{
				FileOps fileOps = new FileOps(IntPtr.Zero, this.Language, this.DockSettings);
				fileOps.Open(Application.StartupPath + "\\System\\Icons", "", ProcessWindowStyle.Normal, base.Handle);
			}
		}

		private void contextMenuStrip_Opening(object sender, CancelEventArgs e)
		{
			this.iconReplacementModeToolStripMenuItem.Checked = this.DockSettings.General.IconReplacementMode;
			this.pauseMouseHotkeysToolStripMenuItem.Checked = this.ParentObject.pauseMouseHotkeysToolStripMenuItem.Checked;
		}

		private void ChangeIconDialog_FileOk(object sender, CancelEventArgs e)
		{
			string text;
			if (this.ChangeIconDialog.FileName.StartsWith(Application.StartupPath + "\\"))
			{
				text = "." + this.ChangeIconDialog.FileName.Substring(Application.StartupPath.Length, this.ChangeIconDialog.FileName.Length - Application.StartupPath.Length);
			}
			else
			{
				text = this.ChangeIconDialog.FileName;
			}
			this.DockSettings.SetEntry("Background", "Path", text);
			this.DockSettings.Background.Path = text;
			this.SetBitmap();
			Size objectSize = this.ObjectSize;
			base.DrawBitmapManaged(objectSize.Width, objectSize.Height, false, 0, 0, false, 0, 0, 0, 0, false, 0);
		}
	}
}
