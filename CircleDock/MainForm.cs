using BaseDockObjects;
using DockItemSettingsLoader;
using FileOps;
using GlobalMouseKeyboardHook;
using IconsAndShortcuts;
using ImageOperations;
using LanguageLoader;
using MemoryManagement;
using PerPixelAlphaForms;
using Pinvoke;
using SettingsLoader;
using SettingsPanel;
using Shell32;
using System;
using System.Collections;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;
using Win32.Shell32;

namespace CircleDock
{
	public class MainForm : InvisiblePerPixelAlphaForm
	{
		public enum SortDirection
		{
			Ascending,
			Descending
		}

		public class DockItemOrderComparer : IComparer
		{
			private MainForm.SortDirection m_direction = MainForm.SortDirection.Ascending;

			public DockItemOrderComparer()
			{
			}

			public DockItemOrderComparer(MainForm.SortDirection direction)
			{
				this.m_direction = direction;
			}

			int IComparer.Compare(object x, object y)
			{
				DockItemObject dockItemObject = (DockItemObject)x;
				DockItemObject dockItemObject2 = (DockItemObject)y;
				int result;
				if (dockItemObject == null && dockItemObject2 == null)
				{
					result = 0;
				}
				else if (dockItemObject == null && dockItemObject2 != null)
				{
					result = ((this.m_direction == MainForm.SortDirection.Ascending) ? -1 : 1);
				}
				else if (dockItemObject != null && dockItemObject2 == null)
				{
					result = ((this.m_direction == MainForm.SortDirection.Ascending) ? 1 : -1);
				}
				else
				{
					int dockOrderNum = dockItemObject.dockOrderNum;
					int dockOrderNum2 = dockItemObject2.dockOrderNum;
					result = ((this.m_direction == MainForm.SortDirection.Ascending) ? dockOrderNum.CompareTo(dockItemObject2.dockOrderNum) : dockOrderNum2.CompareTo(dockItemObject.dockOrderNum));
				}
				return result;
			}
		}

		private const int ToggleDockHotKeyHandle = 0;

		private const int ModAlt = 1;

		private const int ModControl = 2;

		private const int ModShift = 4;

		private const int ModWin = 8;

		private const int WM_GLOBALMOUSECLICK = 6024;

		private const int WM_GLOBALHOTKEY = 786;

		private IContainer components = null;

		private ContextMenuStrip MainFormContextMenuStrip;

		private ToolStripMenuItem quitToolStripMenuItem;

		private ToolStripMenuItem showToolStripMenuItem;

		private ToolStripMenuItem hideToolStripMenuItem;

		private ToolStripMenuItem settingsToolStripMenuItem;

		private ToolStripMenuItem iconReplacementModeToolStripMenuItem;

		public ToolStripMenuItem pauseMouseHotkeysToolStripMenuItem;

		private NotifyIcon MainFormTrayIcon;

		private System.Windows.Forms.Timer MemoryManagementTimer;

		private System.Windows.Forms.Timer mouseTogglingDwellTimer;

		public readonly string CircleDockVersion = "0.9.2 Alpha 8";

		public CentreObject CentreObject;

		public BackgroundObject BackgroundObject;

		public static ArrayList MainDockObjects;

		public new LanguageLoader Language;

		public new SettingsLoader DockSettings;

		public static DockItemSettingsLoader DockItemSettings;

		public static string CurrentLevelShown;

		private static Point[] CalculatedPoints;

		private static Size[] NewDockItemSizes;

		public double RotationValue;

		private DockSetup ConfigureSettings;

		public bool ToggleDockHotKeyStatus;

		public bool DockIsVisible;

		public Cursor DeleteCursor;

		private static UserActivityHook actHook;

		public int dwellTime = 0;

		public bool loaded = false;

		public bool showingLevel = false;

		public bool RotateClockwise;

		public double TargetRotationValue;

		public int RotationDuration;

		public bool InScreenEdgeToggleZone = false;

		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		private void InitializeComponent()
		{
			this.components = new Container();
			ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(MainForm));
			this.MainFormContextMenuStrip = new ContextMenuStrip(this.components);
			this.quitToolStripMenuItem = new ToolStripMenuItem();
			this.showToolStripMenuItem = new ToolStripMenuItem();
			this.hideToolStripMenuItem = new ToolStripMenuItem();
			this.pauseMouseHotkeysToolStripMenuItem = new ToolStripMenuItem();
			this.iconReplacementModeToolStripMenuItem = new ToolStripMenuItem();
			this.settingsToolStripMenuItem = new ToolStripMenuItem();
			this.MainFormTrayIcon = new NotifyIcon(this.components);
			this.MemoryManagementTimer = new System.Windows.Forms.Timer(this.components);
			this.mouseTogglingDwellTimer = new System.Windows.Forms.Timer(this.components);
			this.MainFormContextMenuStrip.SuspendLayout();
			base.SuspendLayout();
			this.MainFormContextMenuStrip.Items.AddRange(new ToolStripItem[]
			{
				this.showToolStripMenuItem,
				this.hideToolStripMenuItem,
				this.iconReplacementModeToolStripMenuItem,
				this.pauseMouseHotkeysToolStripMenuItem,
				this.settingsToolStripMenuItem,
				this.quitToolStripMenuItem
			});
			this.MainFormContextMenuStrip.Name = this.Language.General.CircleDockName;
			this.MainFormContextMenuStrip.Size = new Size(98, 26);
			this.MainFormContextMenuStrip.Text = this.Language.General.CircleDockName;
			this.MainFormContextMenuStrip.Opening += new CancelEventHandler(this.MainFormContextMenuStrip_Opening);
			this.quitToolStripMenuItem.Name = "quitToolStripMenuItem";
			this.quitToolStripMenuItem.Size = new Size(152, 22);
			this.quitToolStripMenuItem.Text = this.Language.MainContextMenu.QuitWord;
			this.quitToolStripMenuItem.Click += new EventHandler(this.quitToolStripMenuItem_Click);
			this.showToolStripMenuItem.Name = "showToolStripMenuItem";
			this.showToolStripMenuItem.Size = new Size(152, 22);
			this.showToolStripMenuItem.Text = this.Language.MainContextMenu.ShowWord;
			this.showToolStripMenuItem.Click += new EventHandler(this.showToolStripMenuItem_Click);
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
			this.MainFormTrayIcon.ContextMenuStrip = this.MainFormContextMenuStrip;
			this.MainFormTrayIcon.Icon = (Icon)componentResourceManager.GetObject("MainFormTrayIcon.Icon");
			this.MainFormTrayIcon.Text = this.Language.General.CircleDockName;
			this.MainFormTrayIcon.MouseClick += new MouseEventHandler(this.MainFormTrayIcon_MouseClick);
			this.MainFormTrayIcon.Visible = true;
			base.AutoScaleDimensions = new SizeF(6f, 13f);
			base.AutoScaleMode = AutoScaleMode.Font;
			base.ClientSize = new Size(1, 1);
			base.Name = "MainForm";
			this.Text = this.Language.General.CircleDockName;
			base.Shown += new EventHandler(this.MainForm_Shown);
			base.FormClosing += new FormClosingEventHandler(this.MainForm_FormClosing);
			this.MainFormContextMenuStrip.ResumeLayout(false);
			base.ResumeLayout(false);
		}

		public MainForm()
		{
			this.DockSettings = new SettingsLoader(Application.StartupPath + "\\System\\Settings\\Config.ini");
			this.LoadLanguage();
			MainForm.DockItemSettings = new DockItemSettingsLoader(Application.StartupPath + "\\System\\Settings\\DockItemData.ini");
			this.InitializeComponent();
			this.DoubleBuffered = true;
			this.AnimationTimer.Tick += new EventHandler(this.AnimationTimer_Tick);
			this.AnimationTimer.Interval = this.DockSettings.General.AnimationInterval;
			this.MemoryManagementTimer.Tick += new EventHandler(this.MemoryManagementTimer_Tick);
			this.MemoryManagementTimer.Interval = 30000;
			this.ToggleMemorySaver(this.DockSettings.General.UseMemorySaver);
			this.CreateDeleteCursor();
			this.mouseTogglingDwellTimer.Tick += new EventHandler(this.mouseTogglingDwellTimer_Tick);
			this.mouseTogglingDwellTimer.Interval = 10;
			MainForm.MainDockObjects = new ArrayList();
			this.InitializeBackgroundObject();
			this.InitializeCentreObject();
			this.DrawBackground();
			this.ShowLevel("0-");
			this.DockIsVisible = true;
			this.SetMouseKeys();
			MainForm.actHook = new UserActivityHook(false, 0, false);
			this.SetMouseScreenToggles();
			MainForm.actHook.OnMouseActivity += new MouseEventHandler(this.MouseMoved);
			this.ToggleDockHotKeyStatus = false;
			this.RegisterHotKeyToggleDock();
			this.loaded = true;
		}

		private void MainForm_Shown(object sender, EventArgs e)
		{
			base.Hide();
		}

		public void ToggleMemorySaver(bool StartMemorySaver)
		{
			if (StartMemorySaver)
			{
				this.MemoryManagementTimer.Start();
			}
			else
			{
				this.MemoryManagementTimer.Stop();
			}
		}

		public void SetMouseKeys()
		{
			if (!this.pauseMouseHotkeysToolStripMenuItem.Checked)
			{
				KeysConverter keysConverter = new KeysConverter();
				Keys keys = (Keys)keysConverter.ConvertFromString(this.DockSettings.Toggling.VisibilityMouseButton);
				if (keys != Keys.None)
				{
					MainForm.StartHook(base.Handle);
					MainForm.SetShortcutKey(keys);
				}
				else
				{
					MainForm.StopHook(base.Handle);
				}
			}
			else
			{
				MainForm.StopHook(base.Handle);
			}
		}

		public void PauseMouseKeys()
		{
			MainForm.StopHook(base.Handle);
		}

		public void SetMouseScreenToggles()
		{
			if (this.DockSettings.Toggling.ScreenLeftEdgeShow || this.DockSettings.Toggling.ScreenTopEdgeShow || this.DockSettings.Toggling.ScreenRightEdgeShow || this.DockSettings.Toggling.ScreenBottomEdgeShow)
			{
				MainForm.actHook.Start(true, 0, false);
			}
			else
			{
				MainForm.actHook.Stop(true, true, false);
			}
		}

		public void LoadLanguage()
		{
			if (this.Language == null)
			{
				if (this.DockSettings.Language.path.StartsWith(".\\"))
				{
					this.Language = new LanguageLoader(Application.StartupPath + this.DockSettings.Language.path.Substring(1, this.DockSettings.Language.path.Length - 1));
				}
				else
				{
					this.Language = new LanguageLoader(this.DockSettings.Language.path);
				}
			}
			else
			{
				this.Language.LoadLanguageData();
			}
		}

		public void InitializeBackgroundObject()
		{
			Size initialSize;
			if (this.DockSettings.Shape.Shape == "Ellipse")
			{
				initialSize = new Size((int)((double)((float)this.DockSettings.EllipseParams.MinHeight) * this.DockSettings.EllipseParams.AspectRatio), this.DockSettings.EllipseParams.MinHeight);
			}
			else
			{
				initialSize = new Size(this.DockSettings.Background.DefaultWidth, this.DockSettings.Background.DefaultHeight);
			}
			this.BackgroundObject = new BackgroundObject(this, this.Language, this.DockSettings, "Background", initialSize);
			if (this.DockSettings.General.lockDockPosition)
			{
				this.BackgroundObject.Location = this.DockSettings.General.lockedPosition;
			}
			else
			{
				this.BackgroundObject.Location = new Point((int)((double)SystemInformation.PrimaryMonitorSize.Width / 2.0 - (double)initialSize.Width / 2.0), (int)((double)SystemInformation.PrimaryMonitorSize.Height / 2.0 - (double)initialSize.Height / 2.0));
			}
		}

		public void DrawBackground()
		{
			Size objectSize = this.BackgroundObject.ObjectSize;
			this.BackgroundObject.DrawBitmapManaged(objectSize.Width, objectSize.Height, false, 0, 0, false, 0, 0, 0, 0, true, this.DockSettings.Background.DefaultOpacity);
			this.BackgroundObject.Show();
			this.BackgroundObject.BringToFront();
			this.BackgroundObject.Activate();
		}

		public void ResizeBackground(int NewWidth, int NewHeight)
		{
			Size objectSize = this.CentreObject.ObjectSize;
			this.BackgroundObject.DrawBitmapManaged(NewWidth, NewHeight, true, this.CentreObject.Location.X - (NewWidth / 2 - objectSize.Width / 2), this.CentreObject.Location.Y - (NewHeight / 2 - objectSize.Height / 2), false, 0, 0, 0, 0, false, 0);
		}

		public void ResizeCentreObject(int NewWidth, int NewHeight)
		{
			Size objectSize = this.BackgroundObject.ObjectSize;
			this.CentreObject.DrawBitmapManaged(NewWidth, NewHeight, true, this.BackgroundObject.Location.X + (int)((double)objectSize.Width / 2.0 - (double)NewWidth / 2.0), this.BackgroundObject.Location.Y + (int)((double)objectSize.Height / 2.0 - (double)NewHeight / 2.0), false, 0, 0, 0, 0, false, 0);
		}

		public void ResizeDockItems(int NewWidth, int NewHeight)
		{
			for (int i = 0; i < MainForm.MainDockObjects.Count; i++)
			{
				DockItemObject dockItemObject = (DockItemObject)MainForm.MainDockObjects[i];
				dockItemObject.ObjectSize = new Size(NewWidth, NewHeight);
			}
			this.PositionCurrentLevel();
		}

		public void UpdateDockItemOpacity(int NewOpacity)
		{
			for (int i = 0; i < MainForm.MainDockObjects.Count; i++)
			{
				DockItemObject dockItemObject = (DockItemObject)MainForm.MainDockObjects[i];
				Size objectSize = dockItemObject.ObjectSize;
				dockItemObject.DrawBitmapManaged(objectSize.Width, objectSize.Height, false, 0, 0, false, 0, 0, 0, 0, true, NewOpacity);
			}
		}

		public void RefreshPortabilityMode()
		{
			for (int i = 0; i < MainForm.MainDockObjects.Count; i++)
			{
				DockItemObject dockItemObject = (DockItemObject)MainForm.MainDockObjects[i];
				dockItemObject.InitializeFileOps();
				dockItemObject.SetBitmapRedraw();
			}
		}

		public void RedrawDockItemLabels()
		{
			for (int i = 0; i < MainForm.MainDockObjects.Count; i++)
			{
				DockItemObject dockItemObject = (DockItemObject)MainForm.MainDockObjects[i];
				dockItemObject.MyLabel.RedrawBitmap();
			}
		}

		public void InitializeCentreObject()
		{
			Size initialSize = new Size(this.DockSettings.CentreImage.DefaultWidth, this.DockSettings.CentreImage.DefaultHeight);
			this.CentreObject = new CentreObject(this, this.Language, this.DockSettings, "CentreImage", initialSize);
			this.CentreObject.Owner = this.BackgroundObject;
			Size objectSize = this.BackgroundObject.ObjectSize;
			this.CentreObject.Location = new Point(this.BackgroundObject.Location.X + (int)((double)objectSize.Width / 2.0 - (double)initialSize.Width / 2.0), this.BackgroundObject.Location.Y + (int)((double)objectSize.Height / 2.0 - (double)initialSize.Height / 2.0));
		}

		public void DrawCentreObject()
		{
			Size objectSize = this.CentreObject.ObjectSize;
			this.CentreObject.DrawBitmapManaged(objectSize.Width, objectSize.Height, false, 0, 0, false, 0, 0, 0, 0, true, this.DockSettings.CentreImage.DefaultOpacity);
			this.CentreObject.Show();
			this.CentreObject.BringToFront();
			this.CentreObject.Activate();
		}

		public void CloseLevel(string Level)
		{
			for (int i = 0; i < MainForm.MainDockObjects.Count; i++)
			{
				DockItemObject dockItemObject = (DockItemObject)MainForm.MainDockObjects[i];
				if (dockItemObject.DockItemSectionName.StartsWith(Level))
				{
					dockItemObject.AnimationTimer.Stop();
					dockItemObject.MyLabel.AnimationTimer.Stop();
					dockItemObject.MyLabel.Close();
					dockItemObject.Close();
					MainForm.MainDockObjects.RemoveAt(i);
					i--;
				}
			}
		}

		public void CloseLevel()
		{
			this.HideDockItems();
			foreach (DockItemObject dockItemObject in MainForm.MainDockObjects)
			{
				dockItemObject.AnimationTimer.Stop();
				dockItemObject.MyLabel.AnimationTimer.Stop();
				dockItemObject.MyLabel.Close();
				dockItemObject.Close();
			}
			MainForm.MainDockObjects = new ArrayList();
		}

		public void ShowLevelUp()
		{
			if (!this.showingLevel)
			{
				if (MainForm.CurrentLevelShown != null && MainForm.CurrentLevelShown != "0-" && MainForm.CurrentLevelShown.Length > 0)
				{
					int num = -1;
					string level = MainForm.CurrentLevelShown;
					for (int i = MainForm.CurrentLevelShown.Length - 2; i >= 0; i--)
					{
						if (MainForm.CurrentLevelShown[i] == '-')
						{
							num = i;
							break;
						}
					}
					if (num > 0)
					{
						level = MainForm.CurrentLevelShown.Substring(0, num + 1);
					}
					this.ShowLevel(level);
				}
			}
		}

		public void ShowLevel(string Level)
		{
			this.showingLevel = true;
			this.CloseLevel(MainForm.CurrentLevelShown);
			MainForm.MainDockObjects = new ArrayList();
			MainForm.CurrentLevelShown = Level;
			this.ChangeCentreImage(Level);
			string[] sectionNames = MainForm.DockItemSettings.GetSectionNames();
			this.loadRotationValue();
			int num = 0;
			while (sectionNames != null && num < sectionNames.Length)
			{
				if (sectionNames[num].StartsWith(Level) && !sectionNames[num].Substring(Level.Length, sectionNames[num].Length - Level.Length).Contains("-"))
				{
					DockItemObject dockItemObject = this.CreateDockItem(sectionNames[num], null);
					if (this.DockSettings.General.ShowLevelRealTimeCreation)
					{
						this.PositionCurrentLevel();
					}
					Application.DoEvents();
				}
				num++;
			}
			this.BackgroundObject.Activate();
			this.BackgroundObject.BringToFront();
			if (!this.DockSettings.General.ShowLevelRealTimeCreation)
			{
				this.PositionCurrentLevel();
			}
			this.showingLevel = false;
			MemoryUtility.ClearUnusedMemory();
		}

		public void loadRotationValue()
		{
			if (this.DockSettings.General.useSameRotationValues)
			{
				try
				{
					this.RotationValue = double.Parse(MainForm.DockItemSettings.GetEntry("0", "CircleRotation"));
					if (double.IsNaN(this.RotationValue))
					{
						this.RotationValue = 0.0;
						MainForm.DockItemSettings.SetEntry("0", "CircleRotation", this.RotationValue.ToString());
					}
				}
				catch (Exception)
				{
					this.RotationValue = 0.0;
					MainForm.DockItemSettings.SetEntry("0", "CircleRotation", this.RotationValue.ToString());
				}
			}
			else
			{
				try
				{
					this.RotationValue = double.Parse(MainForm.DockItemSettings.GetEntry(MainForm.CurrentLevelShown.Substring(0, MainForm.CurrentLevelShown.Length - 1), "CircleRotation"));
					if (double.IsNaN(this.RotationValue))
					{
						this.RotationValue = 0.0;
						MainForm.DockItemSettings.SetEntry(MainForm.CurrentLevelShown.Substring(0, MainForm.CurrentLevelShown.Length - 1), "CircleRotation", this.RotationValue.ToString());
					}
				}
				catch (Exception)
				{
					this.RotationValue = 0.0;
					MainForm.DockItemSettings.SetEntry(MainForm.CurrentLevelShown.Substring(0, MainForm.CurrentLevelShown.Length - 1), "CircleRotation", this.RotationValue.ToString());
				}
			}
			this.TargetRotationValue = this.RotationValue;
		}

		public void saveRotationValue()
		{
			if (this.DockSettings.General.useSameRotationValues)
			{
				MainForm.DockItemSettings.SetEntry("0", "CircleRotation", this.RotationValue.ToString());
			}
			else
			{
				MainForm.DockItemSettings.SetEntry(MainForm.CurrentLevelShown.Substring(0, MainForm.CurrentLevelShown.Length - 1), "CircleRotation", this.RotationValue.ToString());
			}
		}

		public void resetDockLabels()
		{
			for (int i = 0; i < MainForm.MainDockObjects.Count; i++)
			{
				DockItemObject dockItemObject = (DockItemObject)MainForm.MainDockObjects[i];
				dockItemObject.SetLabel("");
			}
		}

		public void PositionCurrentLevel()
		{
			MainForm.NewDockItemSizes = new Size[MainForm.MainDockObjects.Count];
			MainForm.MainDockObjects.Sort(new MainForm.DockItemOrderComparer(MainForm.SortDirection.Ascending));
			for (int i = 0; i < MainForm.MainDockObjects.Count; i++)
			{
				DockItemObject dockItemObject = (DockItemObject)MainForm.MainDockObjects[i];
				dockItemObject.SetDockItemOrder(i);
				MainForm.NewDockItemSizes[i] = dockItemObject.ObjectSize;
			}
			MainForm.CalculatedPoints = this.CalculateDockItemPositions(MainForm.NewDockItemSizes);
			for (int i = 0; i < MainForm.MainDockObjects.Count; i++)
			{
				DockItemObject dockItemObject = (DockItemObject)MainForm.MainDockObjects[i];
				dockItemObject.DrawBitmapManaged(MainForm.NewDockItemSizes[i].Width, MainForm.NewDockItemSizes[i].Height, true, MainForm.CalculatedPoints[i].X, MainForm.CalculatedPoints[i].Y, false, 0, 0, 0, 0, false, 0);
			}
		}

		public void PositionCurrentLevelFast()
		{
			MainForm.CalculatedPoints = this.CalculateDockItemPositions(MainForm.NewDockItemSizes);
			for (int i = 0; i < MainForm.MainDockObjects.Count; i++)
			{
				DockItemObject dockItemObject = (DockItemObject)MainForm.MainDockObjects[i];
				dockItemObject.DrawBitmapManaged(MainForm.NewDockItemSizes[i].Width, MainForm.NewDockItemSizes[i].Height, true, MainForm.CalculatedPoints[i].X, MainForm.CalculatedPoints[i].Y, false, 0, 0, 0, 0, false, 0);
			}
		}

		public void ChangeCentreImage(string Level)
		{
			if (Level != null && Level.Length != 0)
			{
				Bitmap bitmap;
				if (Level == "0-")
				{
					try
					{
						if (this.DockSettings.CentreImage.Path.StartsWith(".\\"))
						{
							bitmap = new Bitmap(Application.StartupPath + this.DockSettings.CentreImage.Path.Substring(1, this.DockSettings.CentreImage.Path.Length - 1));
						}
						else
						{
							bitmap = new Bitmap(this.DockSettings.CentreImage.Path);
						}
					}
					catch (Exception)
					{
						bitmap = new Bitmap(ImageResources.CircleDockIconCentreImage);
					}
				}
				else
				{
					string text = Level.Substring(0, Level.Length - 1);
					if (text != null && text != "")
					{
						string entry = MainForm.DockItemSettings.GetEntry(text, "ImagePath");
						try
						{
							if (entry != null && entry.Length > 0)
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
								FileOps fileOps = new FileOps(IntPtr.Zero, MainForm.DockItemSettings.GetEntry(text, "Args"), this.Language, this.DockSettings);
								bitmap = new Bitmap(fileOps.RepresentativeImage);
							}
						}
						catch (Exception)
						{
							bitmap = new Bitmap(ImageResources.CircleDockIconCentreImage);
						}
					}
					else
					{
						bitmap = new Bitmap(ImageResources.CircleDockIconCentreImage);
					}
				}
				this.CentreObject.SetBitmapManaged(ref bitmap);
				Size objectSize = this.CentreObject.ObjectSize;
				this.CentreObject.DrawBitmapManaged(objectSize.Width, objectSize.Height, false, 0, 0, false, 0, 0, 0, 0, false, 0);
			}
		}

		public void SetDockItemPositions(Point[] DesiredPositions)
		{
			if (DesiredPositions != null)
			{
				int num = 0;
				while (num < DesiredPositions.Length && num < MainForm.MainDockObjects.Count)
				{
					DockItemObject dockItemObject = (DockItemObject)MainForm.MainDockObjects[num];
					dockItemObject.Location = new Point(DesiredPositions[num].X, DesiredPositions[num].Y);
					num++;
				}
			}
		}

		public DockItemObject CreateDockItem(string SectionName, string Path)
		{
			Size initialSize = new Size(this.DockSettings.DockItems.DefaultWidth, this.DockSettings.DockItems.DefaultHeight);
			DockItemObject dockItemObject = new DockItemObject(this, this.Language, this.DockSettings, MainForm.DockItemSettings, SectionName, initialSize, Path);
			dockItemObject.Owner = this.CentreObject;
			try
			{
				int num = int.Parse(MainForm.DockItemSettings.GetEntry(SectionName, "Order"));
			}
			catch (Exception)
			{
			}
			MainForm.MainDockObjects.Add(dockItemObject);
			return dockItemObject;
		}

		public Point[] CalculateDockItemPositions(Size[] DockItemSizes)
		{
			Point[] result;
			if (DockItemSizes == null)
			{
				result = new Point[0];
			}
			else
			{
				Point[] array = new Point[DockItemSizes.Length];
				if (this.DockSettings.Shape.Shape == "Ellipse")
				{
					result = null;
				}
				else if (this.DockSettings.CircleParams.Format == "Constant Number of Items Per Circle")
				{
					Size objectSize = this.CentreObject.ObjectSize;
					double num;
					if (DockItemSizes.Length < this.DockSettings.CircleParams.ConstNumItemsPerCircle)
					{
						num = 6.2831853071795862 / (double)DockItemSizes.Length;
					}
					else
					{
						num = 6.2831853071795862 / (double)this.DockSettings.CircleParams.ConstNumItemsPerCircle;
					}
					int num2;
					if (objectSize.Height > objectSize.Width)
					{
						num2 = objectSize.Height / 2;
					}
					else
					{
						num2 = objectSize.Width / 2;
					}
					int num3 = 0;
					int num4 = 0;
					for (int i = 0; i < DockItemSizes.Length; i++)
					{
						array[i] = new Point(this.CentreObject.Location.X + num2 + (int)((double)(this.DockSettings.CircleParams.MinRadius + num3 - DockItemSizes[i].Width / 2) * Math.Cos((double)i * num + this.RotationValue)) - DockItemSizes[i].Width / 2, this.CentreObject.Location.Y + num2 + (int)((double)(this.DockSettings.CircleParams.MinRadius + num3 - DockItemSizes[i].Height / 2) * Math.Sin((double)i * num + this.RotationValue)) - DockItemSizes[i].Height / 2);
						num4++;
						if (num4 >= this.DockSettings.CircleParams.ConstNumItemsPerCircle)
						{
							num4 = 0;
							num3 += this.DockSettings.CircleParams.CircleSeparation;
						}
					}
					result = array;
				}
				else
				{
					Size objectSize = this.CentreObject.ObjectSize;
					int num2;
					if (objectSize.Height > objectSize.Width)
					{
						num2 = objectSize.Height / 2;
					}
					else
					{
						num2 = objectSize.Width / 2;
					}
					int num3 = 0;
					int num5 = (int)Math.Floor(6.2831853071795862 * (double)(this.DockSettings.CircleParams.MinRadius + num3 - this.DockSettings.DockItems.DefaultWidth / 2) / Math.Sqrt(Math.Pow((double)this.DockSettings.DockItems.DefaultWidth, 2.0) + Math.Pow((double)this.DockSettings.DockItems.DefaultHeight, 2.0)));
					if (num5 > MainForm.MainDockObjects.Count)
					{
						num5 = MainForm.MainDockObjects.Count;
					}
					if (num5 <= 0)
					{
						num5 = 1;
					}
					double num = 6.2831853071795862 / (double)num5;
					int num4 = 0;
					for (int i = 0; i < DockItemSizes.Length; i++)
					{
						array[i] = new Point(this.CentreObject.Location.X + num2 + (int)((double)(this.DockSettings.CircleParams.MinRadius + num3 - DockItemSizes[i].Width / 2) * Math.Cos((double)i * num + this.RotationValue)) - DockItemSizes[i].Width / 2, this.CentreObject.Location.Y + num2 + (int)((double)(this.DockSettings.CircleParams.MinRadius + num3 - DockItemSizes[i].Height / 2) * Math.Sin((double)i * num + this.RotationValue)) - DockItemSizes[i].Height / 2);
						num4++;
						if (num4 >= num5)
						{
							num4 = 0;
							num3 += this.DockSettings.CircleParams.CircleSeparation;
							num5 = (int)Math.Floor(6.2831853071795862 * (double)(this.DockSettings.CircleParams.MinRadius + num3 - this.DockSettings.DockItems.DefaultWidth / 2) / Math.Sqrt(Math.Pow((double)this.DockSettings.DockItems.DefaultWidth, 2.0) + Math.Pow((double)this.DockSettings.DockItems.DefaultHeight, 2.0)));
							if (num5 <= 0)
							{
								num5 = 1;
							}
							num = 6.2831853071795862 / (double)num5;
						}
					}
					result = array;
				}
			}
			return result;
		}

		public void RemoveDockItem(DockItemObject ItemToRemove)
		{
			string text = ItemToRemove.DockItemSectionName + "-";
			this.CloseLevel(text);
			MainForm.MainDockObjects.Remove(ItemToRemove);
			ItemToRemove.Close();
			string[] sectionNames = MainForm.DockItemSettings.GetSectionNames();
			for (int i = 0; i < sectionNames.Length; i++)
			{
				if (sectionNames[i].StartsWith(text) && !sectionNames[i].Substring(text.Length, sectionNames[i].Length - text.Length).Contains("-"))
				{
					MainForm.DockItemSettings.RemoveSection(sectionNames[i]);
				}
			}
			MainForm.DockItemSettings.RemoveSection(text.Substring(0, text.Length - 1));
			this.PositionCurrentLevel();
		}

		public void AddDockItem(string Action, string Args, string Description, string ImagePath, string Name)
		{
			string a = Action;
			if (Action == "[blanklink]")
			{
				Action = "[link]";
			}
			string[] sectionNames = MainForm.DockItemSettings.GetSectionNames();
			int num = 0;
			ArrayList arrayList = new ArrayList();
			string[] array = sectionNames;
			for (int i = 0; i < array.Length; i++)
			{
				string text = array[i];
				if (text.StartsWith(MainForm.CurrentLevelShown))
				{
					string text2 = text.Substring(MainForm.CurrentLevelShown.Length, text.Length - MainForm.CurrentLevelShown.Length);
					int num2 = text2.IndexOf('-');
					if (num2 < 0)
					{
						num2 = text2.Length;
					}
					int num3 = int.Parse(text2.Substring(0, num2));
					arrayList.Add(num3);
				}
			}
			arrayList.Sort();
			for (int j = 0; j < arrayList.Count; j++)
			{
				if (num == (int)arrayList[j])
				{
					num++;
					j = 0;
				}
			}
			string text3 = MainForm.CurrentLevelShown + num.ToString();
			string value = "";
			string value2 = "Normal";
			if (Action == "[link]" && Args.ToUpper().EndsWith(".LNK") && File.Exists(Args))
			{
				try
				{
					SHFileInfo sHFileInfo = default(SHFileInfo);
					Shell32API.SHGetFileInfo(Args, 0u, ref sHFileInfo, (uint)Marshal.SizeOf(sHFileInfo), (ShellGetFileInfoFlags)1536);
					string directoryName = Path.GetDirectoryName(Args);
					string fileName = Path.GetFileName(Args);
					Shell shell = new ShellClass();
					Folder folder = shell.NameSpace(directoryName);
					FolderItem folderItem = folder.ParseName(fileName);
					if (folderItem != null)
					{
						ShellLinkObject shellLinkObject = (ShellLinkObject)folderItem.GetLink;
						string text4 = MsiShortcutParser.ParseShortcut(Args);
						if (text4 != null)
						{
							Args = text4;
						}
						else if (shellLinkObject.Path.Length > 0)
						{
							Args = shellLinkObject.Path;
						}
						value = shellLinkObject.Arguments;
						if (shellLinkObject.ShowCommand == 3)
						{
							value2 = "Maximized";
						}
						else if (shellLinkObject.ShowCommand == 7)
						{
							value2 = "Minimized";
						}
						else
						{
							value2 = "Normal";
						}
					}
					if (Name == "")
					{
						Name = sHFileInfo.szDisplayName;
					}
					if (Description == "")
					{
						Description = sHFileInfo.szTypeName;
					}
				}
				catch (Exception)
				{
				}
			}
			if (Action == "[link]" && Args.StartsWith(Application.StartupPath + "\\"))
			{
				Args = "." + Args.Substring(Application.StartupPath.Length);
			}
			MainForm.DockItemSettings.SetEntry(text3, "Action", Action);
			MainForm.DockItemSettings.SetEntry(text3, "Args", Args);
			MainForm.DockItemSettings.SetEntry(text3, "Description", Description);
			MainForm.DockItemSettings.SetEntry(text3, "ImagePath", ImagePath);
			MainForm.DockItemSettings.SetEntry(text3, "Name", Name);
			MainForm.DockItemSettings.SetEntry(text3, "Order", MainForm.MainDockObjects.Count.ToString());
			MainForm.DockItemSettings.SetEntry(text3, "CircleRotation", "0");
			MainForm.DockItemSettings.SetEntry(text3, "EllipseRotation", "0");
			MainForm.DockItemSettings.SetEntry(text3, "SpiralRotation", "0");
			MainForm.DockItemSettings.SetEntry(text3, "ArgsParams", value);
			MainForm.DockItemSettings.SetEntry(text3, "RunAs", value2);
			DockItemObject dockItemObject = this.CreateDockItem(text3, null);
			if (a == "[blanklink]")
			{
				dockItemObject.itemSettingsToolStripMenuItem_Click(this, null);
			}
		}

		public bool AtRootLevel()
		{
			return MainForm.CurrentLevelShown == "0-";
		}

		public void ChildMoved(DockItemObject ChildObject)
		{
			Size objectSize = this.CentreObject.ObjectSize;
			if (Cursor.Position.X >= this.CentreObject.Location.X && Cursor.Position.Y >= this.CentreObject.Location.Y && Cursor.Position.X <= this.CentreObject.Location.X + objectSize.Width && Cursor.Position.Y <= this.CentreObject.Location.Y + objectSize.Height)
			{
				Cursor.Current = Cursors.Default;
				if (this.DockSettings.PoofAnimation.UsePoof)
				{
					ChildObject.MyLabel.Hide();
					Bitmap bitmap;
					try
					{
						if (this.DockSettings.PoofAnimation.PoofAnimationPath.StartsWith(".\\"))
						{
							bitmap = new Bitmap(Application.StartupPath + this.DockSettings.PoofAnimation.PoofAnimationPath.Substring(1, this.DockSettings.PoofAnimation.PoofAnimationPath.Length - 1));
						}
						else
						{
							bitmap = new Bitmap(this.DockSettings.PoofAnimation.PoofAnimationPath);
						}
					}
					catch (Exception)
					{
						bitmap = new Bitmap(ImageResources.Poof);
					}
					Size size = new Size(bitmap.Width / this.DockSettings.PoofAnimation.NumFrames, bitmap.Height);
					Bitmap bitmap2 = new Bitmap(size.Width, size.Height);
					Graphics graphics = Graphics.FromImage(bitmap2);
					graphics.SmoothingMode = SmoothingMode.HighQuality;
					graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;
					graphics.CompositingQuality = CompositingQuality.HighQuality;
					graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
					for (int i = 0; i < this.DockSettings.PoofAnimation.NumFrames; i++)
					{
						graphics.Clear(Color.Transparent);
						graphics.DrawImage(bitmap, new Rectangle(0, 0, bitmap2.Width, bitmap2.Height), new Rectangle(i * size.Width, 0, i * size.Width + size.Width, bitmap.Height), GraphicsUnit.Pixel);
						Bitmap bitmap3 = new Bitmap(bitmap2);
						ChildObject.SetBitmapManaged(ref bitmap3);
						ChildObject.DrawBitmapManaged(size.Width, size.Height, false, 0, 0, false, 0, 0, 0, 0, false, 0);
						Thread.Sleep(this.DockSettings.PoofAnimation.DelayBetweenFrames);
					}
				}
				this.RemoveDockItem(ChildObject);
			}
			else
			{
				for (int i = 0; i < MainForm.MainDockObjects.Count; i++)
				{
					DockItemObject dockItemObject = (DockItemObject)MainForm.MainDockObjects[i];
					Size objectSize2 = dockItemObject.ObjectSize;
					if (Cursor.Position.X >= dockItemObject.Location.X && Cursor.Position.Y >= dockItemObject.Location.Y && Cursor.Position.X <= dockItemObject.Location.X + objectSize2.Width && Cursor.Position.Y <= dockItemObject.Location.Y + objectSize2.Height && ChildObject != dockItemObject)
					{
						ChildObject.SetDockItemOrder(dockItemObject.dockOrderNum);
						break;
					}
				}
				this.PositionCurrentLevel();
			}
		}

		public void CreateDeleteCursor()
		{
			Bitmap bitmap = BitmapOperations.ScaleBySize(ImageResources.Garbage_Can, 32, 32);
			this.DeleteCursor = new Cursor(bitmap.GetHicon());
		}

		public void ChildMoving(DockItemObject ChildObject)
		{
			Size objectSize = this.CentreObject.ObjectSize;
			if (Cursor.Position.X >= this.CentreObject.Location.X && Cursor.Position.Y >= this.CentreObject.Location.Y && Cursor.Position.X <= this.CentreObject.Location.X + objectSize.Width && Cursor.Position.Y <= this.CentreObject.Location.Y + objectSize.Height)
			{
				ChildObject.Cursor = this.DeleteCursor;
			}
			else
			{
				ChildObject.Cursor = Cursors.Default;
			}
		}

		public void ChildMouseEnter(DockItemObject ChildObject)
		{
		}

		public void ChildMouseLeave(DockItemObject ChildObject)
		{
		}

		public void ChildMoved(BackgroundObject ChildObject)
		{
			Size objectSize = this.BackgroundObject.ObjectSize;
			Size objectSize2 = this.CentreObject.ObjectSize;
			this.CentreObject.Location = new Point(this.BackgroundObject.Location.X + (int)((double)objectSize.Width / 2.0 - (double)objectSize2.Width / 2.0), this.BackgroundObject.Location.Y + (int)((double)objectSize.Height / 2.0 - (double)objectSize2.Height / 2.0));
			MainForm.CalculatedPoints = this.CalculateDockItemPositions(MainForm.NewDockItemSizes);
			this.SetDockItemPositions(MainForm.CalculatedPoints);
		}

		public void ChildMoved(CentreObject ChildObject)
		{
			Size objectSize = this.BackgroundObject.ObjectSize;
			Size objectSize2 = ChildObject.ObjectSize;
			this.BackgroundObject.Location = new Point(ChildObject.Location.X - (objectSize.Width / 2 - objectSize2.Width / 2), ChildObject.Location.Y - (objectSize.Height / 2 - objectSize2.Height / 2));
			MainForm.CalculatedPoints = this.CalculateDockItemPositions(MainForm.NewDockItemSizes);
			this.SetDockItemPositions(MainForm.CalculatedPoints);
		}

		public void RotateDock(double increment)
		{
			if (this.DockSettings.General.EnableDockRotation)
			{
				if (!(this.DockSettings.Shape.Shape == "Ellipse"))
				{
					if (increment < 0.0)
					{
						this.RotateClockwise = true;
						if (this.TargetRotationValue > -1.7976931348623157E+308)
						{
							this.TargetRotationValue -= 6.2831853071795862 / (double)this.DockSettings.General.KeyPressesPerRevolution;
						}
					}
					else
					{
						this.RotateClockwise = false;
						if (this.TargetRotationValue < 1.7976931348623157E+308)
						{
							this.TargetRotationValue += 6.2831853071795862 / (double)this.DockSettings.General.KeyPressesPerRevolution;
						}
					}
					this.AnimationTimer.Start();
					this.saveRotationValue();
				}
			}
		}

		private void AnimationTimer_Tick(object sender, EventArgs e)
		{
			if (!this.DockSettings.General.EnableDockRotation)
			{
				this.AnimationTimer.Stop();
			}
			else if (this.DockSettings.Shape.Shape == "Ellipse")
			{
				this.AnimationTimer.Stop();
			}
			else
			{
				if (this.RotateClockwise)
				{
					this.RotationValue -= 6.2831853071795862 / ((double)this.DockSettings.GeneralAnimation.RotationAnimationDuration / (double)this.DockSettings.General.AnimationInterval);
					if (this.RotationValue < this.TargetRotationValue)
					{
						this.RotationValue = this.TargetRotationValue;
					}
				}
				else
				{
					this.RotationValue += 6.2831853071795862 / ((double)this.DockSettings.GeneralAnimation.RotationAnimationDuration / (double)this.DockSettings.General.AnimationInterval);
					if (this.RotationValue > this.TargetRotationValue)
					{
						this.RotationValue = this.TargetRotationValue;
					}
				}
				MainForm.CalculatedPoints = this.CalculateDockItemPositions(MainForm.NewDockItemSizes);
				for (int i = 0; i < MainForm.MainDockObjects.Count; i++)
				{
					DockItemObject dockItemObject = (DockItemObject)MainForm.MainDockObjects[i];
					dockItemObject.Location = new Point(MainForm.CalculatedPoints[i].X, MainForm.CalculatedPoints[i].Y);
				}
				if ((this.RotateClockwise && this.RotationValue <= this.TargetRotationValue) || (!this.RotateClockwise && this.RotationValue >= this.TargetRotationValue))
				{
					this.AnimationTimer.Stop();
					int num = 0;
					if (this.RotationValue >= 6.2831853071795862)
					{
						num = (int)(this.RotationValue / 6.2831853071795862);
					}
					if (this.RotationValue <= -6.2831853071795862)
					{
						num = (int)(this.RotationValue / 6.2831853071795862);
					}
					this.RotationValue -= (double)num * 6.2831853071795862;
					this.TargetRotationValue = this.RotationValue;
				}
			}
		}

		public void UpdateAnimationIntervals(int NewInterval)
		{
			this.AnimationTimer.Interval = NewInterval;
			this.BackgroundObject.UpdateAnimationTimerInterval(NewInterval);
			this.CentreObject.UpdateAnimationTimerInterval(NewInterval);
			for (int i = 0; i < MainForm.MainDockObjects.Count; i++)
			{
				DockItemObject dockItemObject = (DockItemObject)MainForm.MainDockObjects[i];
				dockItemObject.UpdateAnimationTimerInterval(NewInterval);
			}
		}

		private void MemoryManagementTimer_Tick(object sender, EventArgs e)
		{
			MemoryUtility.ClearUnusedMemory();
		}

		private void quitToolStripMenuItem_Click(object sender, EventArgs e)
		{
			base.Close();
		}

		private void showToolStripMenuItem_Click(object sender, EventArgs e)
		{
			this.ShowAll();
		}

		private void hideToolStripMenuItem_Click(object sender, EventArgs e)
		{
			this.HideAll();
		}

		private void settingsToolStripMenuItem_Click(object sender, EventArgs e)
		{
			this.ShowSettingsPanel();
		}

		private void iconReplacementModeToolStripMenuItem_Click(object sender, EventArgs e)
		{
			this.DockSettings.General.IconReplacementMode = this.iconReplacementModeToolStripMenuItem.Checked;
			this.DockSettings.SetEntry("General", "IconReplacementMode", this.iconReplacementModeToolStripMenuItem.Checked.ToString());
			if (this.DockSettings.General.IconReplacementMode)
			{
				FileOps fileOps = new FileOps(IntPtr.Zero, this.Language, this.DockSettings);
				fileOps.Open(Application.StartupPath + "\\System\\Icons", "", ProcessWindowStyle.Normal, IntPtr.Zero);
			}
		}

		private void pauseMouseHotkeysToolStripMenuItem_Click(object sender, EventArgs e)
		{
			this.SetMouseKeys();
		}

		private void MainFormContextMenuStrip_Opening(object sender, CancelEventArgs e)
		{
			this.iconReplacementModeToolStripMenuItem.Checked = this.DockSettings.General.IconReplacementMode;
		}

		private void MainFormTrayIcon_MouseClick(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left)
			{
				this.ToggleVisiblity();
			}
		}

		public void ChildRequestAction(string ActionCommand)
		{
			if (ActionCommand != null)
			{
				if (!(ActionCommand == "QUIT"))
				{
					if (ActionCommand == "TAKE_FOCUS")
					{
						this.CentreObject.Focus();
					}
				}
				else
				{
					base.Close();
				}
			}
		}

		private void MainForm_FormClosing(object sender, EventArgs e)
		{
			MainForm.StopHook(base.Handle);
			MainForm.actHook.Stop(true, true, false);
			this.UnRegisterHotKeyToggleDock();
		}

		public void ShowSettingsPanel()
		{
			if (this.ConfigureSettings == null || this.ConfigureSettings.IsDisposed)
			{
				this.ConfigureSettings = new DockSetup(this, this.Language, this.DockSettings, MainForm.DockItemSettings);
				this.ConfigureSettings.Show();
				this.ConfigureSettings.BringToFront();
			}
			else
			{
				this.ConfigureSettings.Show();
				this.ConfigureSettings.BringToFront();
			}
		}

		public bool LanguageFileIsValid()
		{
			string[] array = new string[]
			{
				this.CircleDockVersion
			};
			string b = this.Language.LanguageFile.CircleDockVersion.Trim().ToUpper();
			string[] array2 = array;
			bool result;
			for (int i = 0; i < array2.Length; i++)
			{
				string text = array2[i];
				if (text.Trim().ToUpper() == b)
				{
					result = true;
					return result;
				}
			}
			result = false;
			return result;
		}

		public void ShowAll()
		{
			this.DockIsVisible = true;
			if (this.DockSettings.General.zLevel == "Always On Bottom")
			{
				this.BackgroundObject.Activate();
				this.BackgroundObject.BringToFront();
			}
			else
			{
				this.BackgroundObject.AnimateOpacity(this.DockSettings.Background.DefaultOpacity, this.DockSettings.GeneralAnimation.FadeInFadeOutDuration);
				this.CentreObject.AnimateOpacity(this.DockSettings.CentreImage.DefaultOpacity, this.DockSettings.GeneralAnimation.FadeInFadeOutDuration);
				foreach (DockItemObject dockItemObject in MainForm.MainDockObjects)
				{
					dockItemObject.AnimateOpacity(this.DockSettings.DockItems.DefaultOpacity, this.DockSettings.GeneralAnimation.FadeInFadeOutDuration);
					dockItemObject.MyLabel.AnimateOpacity(this.DockSettings.DockItems.DefaultOpacity, this.DockSettings.GeneralAnimation.FadeInFadeOutDuration);
				}
				this.BackgroundObject.Activate();
				this.BackgroundObject.BringToFront();
				this.CentreObject.Activate();
				this.CentreObject.BringToFront();
			}
		}

		public void HideAll()
		{
			this.DockIsVisible = false;
			if (this.DockSettings.General.zLevel == "Always On Bottom")
			{
				foreach (DockItemObject dockItemObject in MainForm.MainDockObjects)
				{
					Pinvoke.Win32.SetWindowPos(dockItemObject.Handle, (IntPtr)1, 0, 0, 0, 0, 1563u);
					Pinvoke.Win32.SetWindowPos(dockItemObject.MyLabel.Handle, (IntPtr)1, 0, 0, 0, 0, 1563u);
				}
				Pinvoke.Win32.SetWindowPos(this.CentreObject.Handle, (IntPtr)1, 0, 0, 0, 0, 1563u);
				Pinvoke.Win32.SetWindowPos(this.BackgroundObject.Handle, (IntPtr)1, 0, 0, 0, 0, 1563u);
			}
			else
			{
				foreach (DockItemObject dockItemObject in MainForm.MainDockObjects)
				{
					dockItemObject.AnimateOpacity(0, this.DockSettings.GeneralAnimation.FadeInFadeOutDuration);
					dockItemObject.MyLabel.AnimateOpacity(0, this.DockSettings.GeneralAnimation.FadeInFadeOutDuration);
				}
				this.BackgroundObject.AnimateOpacity(0, this.DockSettings.GeneralAnimation.FadeInFadeOutDuration);
				this.CentreObject.AnimateOpacity(0, this.DockSettings.GeneralAnimation.FadeInFadeOutDuration);
			}
		}

		public void HideDockItems()
		{
			foreach (DockItemObject dockItemObject in MainForm.MainDockObjects)
			{
				dockItemObject.AnimateOpacity(0, this.DockSettings.GeneralAnimation.FadeInFadeOutDuration);
				dockItemObject.MyLabel.AnimateOpacity(0, this.DockSettings.GeneralAnimation.FadeInFadeOutDuration);
			}
		}

		public void ToggleVisiblity()
		{
			if (this.DockIsVisible)
			{
				this.HideAll();
			}
			else
			{
				if (!this.DockSettings.General.lockDockPosition && this.DockSettings.General.CentreAroundCursor)
				{
					Size objectSize = this.BackgroundObject.ObjectSize;
					Size objectSize2 = this.CentreObject.ObjectSize;
					this.CentreObject.Location = new Point(Cursor.Position.X - objectSize2.Width / 2, Cursor.Position.Y - objectSize2.Height / 2);
					MainForm.CalculatedPoints = this.CalculateDockItemPositions(MainForm.NewDockItemSizes);
					this.SetDockItemPositions(MainForm.CalculatedPoints);
					this.BackgroundObject.Location = new Point(this.CentreObject.Location.X - (objectSize.Width / 2 - objectSize2.Width / 2), this.CentreObject.Location.Y - (objectSize.Height / 2 - objectSize2.Height / 2));
				}
				this.ShowAll();
			}
		}

		public void itemDeactivated()
		{
			if (this.loaded && !this.showingLevel && !(this.DockSettings.General.zLevel != "Always On Bottom"))
			{
				IntPtr foregroundWindow = Pinvoke.Win32.GetForegroundWindow();
				try
				{
					if (this.BackgroundObject.Handle != foregroundWindow && this.CentreObject.Handle != foregroundWindow)
					{
						bool flag = false;
						foreach (DockItemObject dockItemObject in MainForm.MainDockObjects)
						{
							if (dockItemObject.Handle == foregroundWindow || dockItemObject.MyLabel.Handle == foregroundWindow)
							{
								flag = true;
								break;
							}
						}
						if (!flag)
						{
							this.HideAll();
						}
					}
				}
				catch (Exception)
				{
				}
			}
		}

		public void setZLevels()
		{
			this.BackgroundObject.SetZLevel();
			this.CentreObject.SetZLevel();
			foreach (DockItemObject dockItemObject in MainForm.MainDockObjects)
			{
				dockItemObject.SetZLevel();
				dockItemObject.MyLabel.SetZLevel();
			}
		}

		public void UnRegisterHotKeyToggleDock()
		{
			if (this.ToggleDockHotKeyStatus)
			{
				Pinvoke.Win32.UnregisterHotKey(base.Handle, 0);
			}
		}

		public void RegisterHotKeyToggleDock()
		{
			this.UnRegisterHotKeyToggleDock();
			int num = 0;
			if (this.DockSettings.Toggling.VisibilityCtrl)
			{
				num |= 2;
			}
			if (this.DockSettings.Toggling.VisibilityAlt)
			{
				num |= 1;
			}
			if (this.DockSettings.Toggling.VisibilityShift)
			{
				num |= 4;
			}
			if (this.DockSettings.Toggling.VisibilityWin)
			{
				num |= 8;
			}
			int num2 = 0;
			try
			{
				num2 = (num2 | this.DockSettings.Toggling.VisibilityKey1 | this.DockSettings.Toggling.VisibilityKey2);
			}
			catch (Exception)
			{
				num2 = 0;
			}
			this.ToggleDockHotKeyStatus = Pinvoke.Win32.RegisterHotKey(base.Handle, 0, num, num2);
		}

		[DllImport("Orbit.Hook.dll")]
		public static extern bool StartHook(IntPtr hWnd);

		[DllImport("Orbit.Hook.dll")]
		public static extern bool StopHook(IntPtr hWnd);

		[DllImport("Orbit.Hook.dll")]
		public static extern void SetShortcutKey(Keys vKey);

		protected override void WndProc(ref Message m)
		{
			int msg = m.Msg;
			if (msg != 786)
			{
				if (msg == 6024)
				{
					this.ToggleVisiblity();
					this.BackgroundObject.Activate();
					this.CentreObject.Activate();
				}
			}
			else
			{
				this.ToggleVisiblity();
			}
			base.WndProc(ref m);
		}

		public void MyKeyDown(object sender, KeyEventArgs e)
		{
		}

		public void MyKeyPress(object sender, KeyPressEventArgs e)
		{
		}

		public void MyKeyUp(object sender, KeyEventArgs e)
		{
		}

		public void MouseMoved(object sender, MouseEventArgs e)
		{
			if ((this.DockSettings.Toggling.ScreenLeftEdgeShow && e.Location.X <= SystemInformation.VirtualScreen.Left + this.DockSettings.Toggling.EdgeWidthHeight) || (this.DockSettings.Toggling.ScreenTopEdgeShow && e.Location.Y <= SystemInformation.VirtualScreen.Top + this.DockSettings.Toggling.EdgeWidthHeight) || (this.DockSettings.Toggling.ScreenRightEdgeShow && e.Location.X >= SystemInformation.VirtualScreen.Right - this.DockSettings.Toggling.EdgeWidthHeight) || (this.DockSettings.Toggling.ScreenBottomEdgeShow && e.Location.Y >= SystemInformation.VirtualScreen.Bottom - this.DockSettings.Toggling.EdgeWidthHeight))
			{
				if (!this.InScreenEdgeToggleZone && Control.MouseButtons == MouseButtons.None)
				{
					this.InScreenEdgeToggleZone = true;
					this.dwellTime = 0;
					this.mouseTogglingDwellTimer.Start();
				}
			}
			else
			{
				this.InScreenEdgeToggleZone = false;
				this.mouseTogglingDwellTimer.Stop();
				this.dwellTime = 0;
			}
		}

		private void mouseTogglingDwellTimer_Tick(object sender, EventArgs e)
		{
			this.dwellTime += this.mouseTogglingDwellTimer.Interval;
			if (this.dwellTime >= this.DockSettings.Toggling.dwellTime)
			{
				this.ToggleVisiblity();
				this.dwellTime = 0;
				this.mouseTogglingDwellTimer.Stop();
			}
		}
	}
}
