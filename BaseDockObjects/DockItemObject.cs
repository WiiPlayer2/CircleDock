using CircleDock;
using DockItemSettingsLoader;
using FileOps;
using LanguageLoader;
using PerPixelAlphaForms;
using Pinvoke;
using SettingsLoader;
using ShellExtension;
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace BaseDockObjects
{
	public class DockItemObject : DockItemPerPixelAlphaForm
	{
		private ContextMenuStrip contextMenuStrip;

		private IContainer components;

		private ToolStripMenuItem removeToolStripMenuItem;

		private ToolStripMenuItem changeIconToolStripMenuItem;

		private ToolStripMenuItem itemSettingsToolStripMenuItem;

		private OpenFileDialog ChangeIconDialog;

		private DockItemSettingsLoader.DockItemSettingsLoader DockItemSettings;

		public string DockItemSectionName;

		public int PreviousOpacity;

		public FileOps.FileOps FileOperations;

		public int dockOrderNum;

		private Point previousMousePosition;

		private Point StoredMouseOffset;

		public LabelObject MyLabel;

		private int TargetOpacity;

		private double OpacityRateOfChange;

		private double tempNewObjectOpacity;

		private void InitializeComponent()
		{
			this.components = new Container();
			this.contextMenuStrip = new ContextMenuStrip(this.components);
			this.removeToolStripMenuItem = new ToolStripMenuItem();
			this.changeIconToolStripMenuItem = new ToolStripMenuItem();
			this.itemSettingsToolStripMenuItem = new ToolStripMenuItem();
			this.ChangeIconDialog = new OpenFileDialog();
			this.contextMenuStrip.SuspendLayout();
			base.SuspendLayout();
			this.contextMenuStrip.Items.AddRange(new ToolStripItem[]
			{
				this.changeIconToolStripMenuItem,
				this.removeToolStripMenuItem,
				this.itemSettingsToolStripMenuItem
			});
			this.contextMenuStrip.Name = "contextMenuStrip";
			this.contextMenuStrip.Size = new Size(153, 48);
			this.changeIconToolStripMenuItem.Name = "changeIconToolStripMenuItem";
			this.changeIconToolStripMenuItem.Size = new Size(152, 22);
			this.changeIconToolStripMenuItem.Text = this.Language.MainContextMenu.ChangeIcon;
			this.changeIconToolStripMenuItem.Click += new EventHandler(this.changeIconToolStripMenuItem_Click);
			this.removeToolStripMenuItem.Name = "removeToolStripMenuItem";
			this.removeToolStripMenuItem.Size = new Size(152, 22);
			this.removeToolStripMenuItem.Text = this.Language.MainContextMenu.RemoveWord;
			this.removeToolStripMenuItem.Click += new EventHandler(this.removeToolStripMenuItem_Click);
			this.itemSettingsToolStripMenuItem.Name = "itemSettingsToolStripMenuItem";
			this.itemSettingsToolStripMenuItem.Size = new Size(152, 22);
			this.itemSettingsToolStripMenuItem.Text = this.Language.MainContextMenu.ItemSettings;
			this.itemSettingsToolStripMenuItem.Click += new EventHandler(this.itemSettingsToolStripMenuItem_Click);
			this.ChangeIconDialog.InitialDirectory = Application.StartupPath + "\\System\\Icons";
			this.ChangeIconDialog.Filter = "PNG|*.png";
			this.ChangeIconDialog.Multiselect = false;
			this.ChangeIconDialog.Title = this.Language.MainContextMenu.ChangeIcon;
			this.ChangeIconDialog.FileOk += new CancelEventHandler(this.ChangeIconDialog_FileOk);
			base.ClientSize = new Size(1, 1);
			base.MouseEnter += new EventHandler(this.DockItem_MouseEnter);
			base.MouseDown += new MouseEventHandler(this.DockItem_MouseDown);
			base.MouseUp += new MouseEventHandler(this.DockItem_MouseUp);
			base.MouseMove += new MouseEventHandler(this.DockItem_MouseMove);
			base.MouseWheel += new MouseEventHandler(this.DockItem_MouseWheel);
			base.MouseHover += new EventHandler(this.DockItem_MouseHover);
			base.MouseLeave += new EventHandler(this.DockItemObject_MouseLeave);
			base.DragEnter += new DragEventHandler(this.DockItem_DragEnter);
			base.DragDrop += new DragEventHandler(this.DockItem_DragDrop);
			base.KeyDown += new KeyEventHandler(this.DockItem_KeyDown);
			base.Shown += new EventHandler(this.DockItemObject_Shown);
			base.Deactivate += new EventHandler(this.DockItemObject_Deactivate);
			base.Name = "TransparentObject";
			this.contextMenuStrip.ResumeLayout(false);
			base.ResumeLayout(false);
		}

		private void DockItemObject_Shown(object sender, EventArgs e)
		{
		}

		private void DockItemObject_Deactivate(object sender, EventArgs e)
		{
			if (!base.Disposing)
			{
				this.ParentObject.itemDeactivated();
			}
		}

		public DockItemObject(MainForm TheParent, LanguageLoader.LanguageLoader LanguageData, SettingsLoader.SettingsLoader SettingsData, DockItemSettingsLoader.DockItemSettingsLoader DockItemData, string SectionName, Size InitialSize, string Path)
		{
			this.Language = LanguageData;
			this.DockSettings = SettingsData;
			this.ParentObject = TheParent;
			this.DockItemSettings = DockItemData;
			this.DockItemSectionName = SectionName;
			this.ObjectSize = InitialSize;
			this.StoredMouseOffset = new Point(0, 0);
			this.dockOrderNum = 0;
			this.RetrieveDockItemOrder();
			this.InitializeFileOps();
			this.InitializeComponent();
			this.AnimationTimer.Tick += new EventHandler(this.AnimationTimer_Tick);
			this.AnimationTimer.Interval = this.DockSettings.General.AnimationInterval;
			this.SetZLevel();
			this.LeftMouseButtonDown = false;
			this.ThisObjectMovedWithLeftMouse = false;
			this.ObjectOpacity = this.DockSettings.DockItems.DefaultOpacity;
			this.PreviousOpacity = this.ObjectOpacity;
			this.SetBitmap();
			this.MyLabel = new LabelObject(this.ParentObject, SettingsData, this.ObjectSize);
			this.MyLabel.Owner = this;
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

		public void InitializeFileOps()
		{
			if (this.DockItemSectionName != null && this.DockItemSectionName != "")
			{
				if (this.DockItemSettings.GetEntry(this.DockItemSectionName, "Action") == "[link]")
				{
					this.FileOperations = new FileOps.FileOps(IntPtr.Zero, this.DockItemSettings.GetEntry(this.DockItemSectionName, "Args"), this.Language, this.DockSettings);
					string entry = this.DockItemSettings.GetEntry(this.DockItemSectionName, "Name");
					if (entry.Length > 0)
					{
						this.FileOperations.Name = entry;
					}
				}
				else if (this.DockItemSettings.GetEntry(this.DockItemSectionName, "Action") == "[dockfolder]")
				{
					this.FileOperations = new FileOps.FileOps(IntPtr.Zero, this.Language, this.DockSettings);
					string entry = this.DockItemSettings.GetEntry(this.DockItemSectionName, "Name");
					if (entry.Length > 0)
					{
						this.FileOperations.Name = entry;
					}
				}
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
			if (this.ObjectOpacity == 0 || this.ObjectOpacity == 255 || (this.OpacityRateOfChange < 0.0 && this.ObjectOpacity <= this.TargetOpacity) || (this.OpacityRateOfChange > 0.0 && this.ObjectOpacity >= this.TargetOpacity))
			{
				this.AnimationTimer.Stop();
				this.AnimationTimer.Enabled = false;
			}
		}

		public void UpdateAnimationTimerInterval(int NewInterval)
		{
			this.AnimationTimer.Interval = NewInterval;
			this.MyLabel.UpdateAnimationTimerInterval(NewInterval);
		}

		public void RetrieveDockItemOrder()
		{
			if (this.DockItemSectionName != null && this.DockItemSectionName != "")
			{
				try
				{
					this.dockOrderNum = int.Parse(this.DockItemSettings.GetEntry(this.DockItemSectionName, "Order"));
				}
				catch (Exception)
				{
					this.dockOrderNum = 0;
				}
			}
			else
			{
				this.dockOrderNum = 0;
			}
		}

		public void SetDockItemOrder(int NewOrderNum)
		{
			this.dockOrderNum = NewOrderNum;
			this.DockItemSettings.SetEntry(this.DockItemSectionName, "Order", NewOrderNum.ToString());
		}

		public void SetBitmap()
		{
			Bitmap bitmap;
			try
			{
				if (this.DockItemSectionName != null && this.DockItemSectionName.Length > 0)
				{
					string entry = this.DockItemSettings.GetEntry(this.DockItemSectionName, "ImagePath");
					if (entry.Length > 0)
					{
						if (entry.StartsWith(".\\"))
						{
							bitmap = new Bitmap(Application.StartupPath + entry.Substring(1, entry.Length - 1));
						}
						else
						{
							bitmap = new Bitmap(entry);
						}
					}
					else
					{
						bitmap = new Bitmap(this.FileOperations.RepresentativeImage);
					}
				}
				else
				{
					bitmap = new Bitmap(this.FileOperations.RepresentativeImage);
				}
			}
			catch (Exception)
			{
				bitmap = new Bitmap(ImageResources.MissingIcon);
			}
			base.SetBitmapManaged(ref bitmap);
		}

		public void SetLabel(string DisplayText)
		{
			Point displayAtCentrePoint = new Point(base.Location.X + this.ObjectSize.Width / 2, base.Location.Y + this.ObjectSize.Height);
			this.MyLabel.SetBitmap(DisplayText, displayAtCentrePoint);
		}

		protected override void OnMove(EventArgs e)
		{
			base.OnMove(e);
		}

		private void DockItem_MouseHover(object sender, EventArgs e)
		{
			base.Activate();
		}

		private void DockItem_KeyDown(object sender, KeyEventArgs e)
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
			else if (e.KeyCode == Keys.Delete)
			{
				this.ParentObject.RemoveDockItem(this);
			}
		}

		private void DockItem_DragDrop(object sender, DragEventArgs e)
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

		private void DockItem_DragEnter(object sender, DragEventArgs e)
		{
			e.Effect = DragDropEffects.Link;
		}

		private void DockItem_MouseWheel(object sender, MouseEventArgs e)
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

		private void DockItem_MouseMove(object sender, MouseEventArgs e)
		{
			if (this.LeftMouseButtonDown)
			{
				if (this.ThisObjectMovedWithLeftMouse || Math.Abs(Cursor.Position.X - this.previousMousePosition.X) > this.DockSettings.General.ClickSensitivity || Math.Abs(Cursor.Position.Y - this.previousMousePosition.Y) > this.DockSettings.General.ClickSensitivity)
				{
					this.ThisObjectMovedWithLeftMouse = true;
					base.Location = new Point(Cursor.Position.X - this.StoredMouseOffset.X, Cursor.Position.Y - this.StoredMouseOffset.Y);
					if (this.ParentObject != null)
					{
						this.ParentObject.ChildMoving(this);
					}
				}
			}
		}

		private void DockItem_MouseUp(object sender, MouseEventArgs e)
		{
			if (!this.ThisObjectMovedWithLeftMouse)
			{
				if (e.Button == MouseButtons.Left && this.LeftMouseButtonDown)
				{
					this.LeftMouseButtonDown = false;
					if (this.ParentObject.DockIsVisible || this.DockSettings.General.zLevel == "Always On Bottom")
					{
						base.DrawBitmapManaged(this.ObjectSize.Width, this.ObjectSize.Height, false, 0, 0, false, 0, 0, 0, 0, true, this.DockSettings.DockItems.DefaultOpacity);
						this.PreviousOpacity = this.ObjectOpacity;
						if (this.DockItemSectionName != null && this.DockItemSettings.GetEntry(this.DockItemSectionName, "Action") == "[link]")
						{
							if (this.DockSettings.DockItems.HideDockAfterExecution)
							{
								this.ParentObject.HideAll();
							}
							string entry = this.DockItemSettings.GetEntry(this.DockItemSectionName, "RunAs");
							ProcessWindowStyle runAs;
							if (entry == null || (entry != "Normal" && entry != "Minimized" && entry != "Maximized"))
							{
								this.DockItemSettings.SetEntry(this.DockItemSectionName, "RunAs", "Normal");
								runAs = ProcessWindowStyle.Normal;
							}
							else if (entry == "Maximized")
							{
								runAs = ProcessWindowStyle.Maximized;
							}
							else if (entry == "Minimized")
							{
								runAs = ProcessWindowStyle.Minimized;
							}
							else
							{
								runAs = ProcessWindowStyle.Normal;
							}
							this.FileOperations.Open(this.FileOperations._Path, this.DockItemSettings.GetEntry(this.DockItemSectionName, "ArgsParams"), runAs, base.Handle);
						}
						else if (this.DockItemSectionName != null && this.DockItemSettings.GetEntry(this.DockItemSectionName, "Action") == "[dockfolder]")
						{
							this.ParentObject.ShowLevel(this.DockItemSectionName + "-");
						}
					}
				}
				else if (e.Button == MouseButtons.Right)
				{
					if (this.DockSettings.DockItems.ShowExplorerContextMenus && this.DockItemSectionName != null && this.DockItemSettings.GetEntry(this.DockItemSectionName, "Action") == "[link]")
					{
						try
						{
							ShellContextMenu shellContextMenu = new ShellContextMenu();
							FileInfo[] files = new FileInfo[]
							{
								new FileInfo(this.DockItemSettings.GetEntry(this.DockItemSectionName, "Args"))
							};
							string[] addedItems = new string[]
							{
								this.Language.MainContextMenu.ChangeIcon,
								this.Language.MainContextMenu.RemoveWord,
								this.Language.MainContextMenu.ItemSettings
							};
							int num = shellContextMenu.ShowContextMenu(files, Cursor.Position, addedItems);
							if (num >= 0)
							{
								switch (num)
								{
								case 0:
									this.changeIconToolStripMenuItem_Click(this, null);
									break;
								case 1:
									this.removeToolStripMenuItem_Click(this, null);
									break;
								case 2:
									this.itemSettingsToolStripMenuItem_Click(this, null);
									break;
								}
							}
							else if (num == -2)
							{
								this.contextMenuStrip.Show();
								this.contextMenuStrip.Left = Control.MousePosition.X;
								this.contextMenuStrip.Top = Control.MousePosition.Y;
							}
						}
						catch (Exception)
						{
							this.contextMenuStrip.Show();
							this.contextMenuStrip.Left = Control.MousePosition.X;
							this.contextMenuStrip.Top = Control.MousePosition.Y;
						}
					}
					else
					{
						this.contextMenuStrip.Show();
						this.contextMenuStrip.Left = Control.MousePosition.X;
						this.contextMenuStrip.Top = Control.MousePosition.Y;
					}
				}
			}
			else
			{
				this.ThisObjectMovedWithLeftMouse = false;
				if (e.Button == MouseButtons.Left && this.LeftMouseButtonDown)
				{
					this.LeftMouseButtonDown = false;
					if (this.ParentObject.DockIsVisible || this.DockSettings.General.zLevel == "Always On Bottom")
					{
						base.DrawBitmapManaged(this.ObjectSize.Width, this.ObjectSize.Height, false, 0, 0, false, 0, 0, 0, 0, true, this.DockSettings.DockItems.DefaultOpacity);
						this.PreviousOpacity = this.ObjectOpacity;
					}
					this.ParentObject.ChildMoved(this);
				}
			}
		}

		private void DockItem_MouseDown(object sender, MouseEventArgs e)
		{
			base.Activate();
			base.BringToFront();
			if (e.Button == MouseButtons.Left)
			{
				this.LeftMouseButtonDown = true;
				this.ThisObjectMovedWithLeftMouse = false;
				this.PreviousOpacity = this.ObjectOpacity;
				base.DrawBitmapManaged(this.ObjectSize.Width, this.ObjectSize.Height, false, 0, 0, false, 0, 0, 0, 0, true, this.ObjectOpacity / 2);
				this.StoredMouseOffset = new Point(Cursor.Position.X - base.Location.X, Cursor.Position.Y - base.Location.Y);
				this.previousMousePosition = Cursor.Position;
			}
		}

		private void DockItem_MouseEnter(object sender, EventArgs e)
		{
			base.BringToFront();
			if (this.DockSettings.Labels.ShowLabels)
			{
				try
				{
					this.SetLabel(this.FileOperations.Name);
				}
				catch (Exception)
				{
					this.SetLabel("");
				}
			}
		}

		private void DockItemObject_MouseLeave(object sender, EventArgs e)
		{
			if (this.DockSettings.Labels.ShowLabels)
			{
				this.SetLabel("");
			}
		}

		private void quitToolStripMenuItem_Click(object sender, EventArgs e)
		{
			this.ParentObject.ChildRequestAction("QUIT");
		}

		private void removeToolStripMenuItem_Click(object sender, EventArgs e)
		{
			this.ParentObject.RemoveDockItem(this);
		}

		private void changeIconToolStripMenuItem_Click(object sender, EventArgs e)
		{
			this.ChangeIconDialog.InitialDirectory = Application.StartupPath + "\\System\\Icons";
			this.ChangeIconDialog.ShowDialog();
		}

		public void itemSettingsToolStripMenuItem_Click(object sender, EventArgs e)
		{
			DockItemProperties dockItemProperties = new DockItemProperties(this, this.Language, this.DockSettings, this.DockItemSettings, this.DockItemSectionName);
			dockItemProperties.ShowDialog();
		}

		private void ChangeIconDialog_FileOk(object sender, CancelEventArgs e)
		{
			string value;
			if (this.ChangeIconDialog.FileName.StartsWith(Application.StartupPath + "\\"))
			{
				value = "." + this.ChangeIconDialog.FileName.Substring(Application.StartupPath.Length, this.ChangeIconDialog.FileName.Length - Application.StartupPath.Length);
			}
			else
			{
				value = this.ChangeIconDialog.FileName;
			}
			if (this.DockItemSectionName != null && this.DockItemSectionName != "")
			{
				this.DockItemSettings.SetEntry(this.DockItemSectionName, "ImagePath", value);
			}
			this.SetBitmap();
			Size objectSize = this.ObjectSize;
			base.DrawBitmapManaged(objectSize.Width, objectSize.Height, false, 0, 0, false, 0, 0, 0, 0, false, 0);
		}

		public void SetBitmapRedraw()
		{
			this.SetBitmap();
			Size objectSize = this.ObjectSize;
			base.DrawBitmapManaged(objectSize.Width, objectSize.Height, false, 0, 0, false, 0, 0, 0, 0, false, 0);
		}
	}
}
