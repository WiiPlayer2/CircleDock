using AMS.Profile;
using SettingsInformation;
using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace SettingsLoader
{
	public class SettingsLoader
	{
		private Profile SettingsINI;

		private string DataVerifier;

		public Background Background;

		public CentreImage CentreImage;

		public CircleParams CircleParams;

		public DockItems DockItems;

		public EllipseParams EllipseParams;

		public Language Language;

		public ObjectShape Shape;

		public Folders Folders;

		public General General;

		public PoofAnimation PoofAnimation;

		public Toggling Toggling;

		public Labels Labels;

		public GeneralAnimation GeneralAnimation;

		public SettingsLoader(string FilePath)
		{
			if (!File.Exists(FilePath))
			{
				MessageBox.Show("Config.ini: " + FilePath + " is missing. Please replace the settings file. Circle Dock will now exit.", "Circle Dock");
				Application.Exit();
			}
			this.SettingsINI = new Ini(FilePath);
			this.InitializeSettingsInfoStructs();
			this.SettingsLoaderLoadData();
		}

		public void InitializeSettingsInfoStructs()
		{
			this.Background = default(Background);
			this.CentreImage = default(CentreImage);
			this.CircleParams = default(CircleParams);
			this.DockItems = default(DockItems);
			this.EllipseParams = default(EllipseParams);
			this.Language = default(Language);
			this.Shape = default(ObjectShape);
			this.Folders = default(Folders);
			this.General = default(General);
			this.PoofAnimation = default(PoofAnimation);
			this.Toggling = default(Toggling);
			this.Labels = default(Labels);
			this.GeneralAnimation = default(GeneralAnimation);
		}

		public void SettingsLoaderLoadData()
		{
			this.LoadBackground();
			this.LoadCentreImage();
			this.LoadCircleParams();
			this.LoadDockItems();
			this.LoadEllipseParams();
			this.LoadLanguage();
			this.LoadShape();
			this.LoadFolders();
			this.LoadGeneral();
			this.LoadPoofAnimation();
			this.LoadToggling();
			this.LoadLabels();
			this.LoadGeneralAnimation();
		}

		public string GetEntry(string Section, string EntryName)
		{
			return (string)this.SettingsINI.GetValue(Section, EntryName);
		}

		public string[] GetSectionNames()
		{
			return this.SettingsINI.GetSectionNames();
		}

		public string[] GetEntryNames(string Section)
		{
			return this.SettingsINI.GetEntryNames(Section);
		}

		public void SetEntry(string Section, string EntryName, string Value)
		{
			this.SettingsINI.SetValue(Section, EntryName, Value);
		}

		public void RemoveEntry(string Section, string EntryName)
		{
			this.SettingsINI.RemoveEntry(Section, EntryName);
		}

		public void RemoveSection(string Section)
		{
			this.SettingsINI.RemoveSection(Section);
		}

		private void LoadBackground()
		{
			this.DataVerifier = null;
			this.DataVerifier = this.GetEntry("Background", "Path");
			if (this.DataVerifier == null)
			{
				this.DataVerifier = "";
				this.SetEntry("Background", "Path", this.DataVerifier);
			}
			this.Background.Path = this.DataVerifier;
			this.DataVerifier = null;
			this.DataVerifier = this.GetEntry("Background", "DefaultOpacity");
			if (this.DataVerifier == null)
			{
				this.DataVerifier = "255";
				this.SetEntry("Background", "DefaultOpacity", this.DataVerifier);
			}
			try
			{
				this.Background.DefaultOpacity = int.Parse(this.DataVerifier);
			}
			catch (Exception)
			{
				this.Background.DefaultOpacity = 255;
				this.SetEntry("Background", "DefaultOpacity", "255");
			}
			if (this.Background.DefaultOpacity < 0)
			{
				this.Background.DefaultOpacity = 0;
				this.SetEntry("Background", "DefaultOpacity", "0");
			}
			else if (this.Background.DefaultOpacity > 255)
			{
				this.Background.DefaultOpacity = 255;
				this.SetEntry("Background", "DefaultOpacity", "255");
			}
			this.DataVerifier = null;
			this.DataVerifier = this.GetEntry("Background", "DefaultWidth");
			if (this.DataVerifier == null)
			{
				this.DataVerifier = "255";
				this.SetEntry("Background", "DefaultWidth", this.DataVerifier);
			}
			try
			{
				this.Background.DefaultWidth = int.Parse(this.DataVerifier);
			}
			catch (Exception)
			{
				this.Background.DefaultWidth = 255;
				this.SetEntry("Background", "DefaultWidth", "255");
			}
			if (this.Background.DefaultWidth <= 0)
			{
				this.Background.DefaultWidth = 255;
				this.SetEntry("Background", "DefaultWidth", "255");
			}
			this.DataVerifier = null;
			this.DataVerifier = this.GetEntry("Background", "DefaultHeight");
			if (this.DataVerifier == null)
			{
				this.DataVerifier = "255";
				this.SetEntry("Background", "DefaultHeight", this.DataVerifier);
			}
			try
			{
				this.Background.DefaultHeight = int.Parse(this.DataVerifier);
			}
			catch (Exception)
			{
				this.Background.DefaultHeight = 255;
				this.SetEntry("Background", "DefaultHeight", "255");
			}
			if (this.Background.DefaultHeight <= 0)
			{
				this.Background.DefaultHeight = 255;
				this.SetEntry("Background", "DefaultHeight", "255");
			}
		}

		private void LoadCentreImage()
		{
			this.DataVerifier = null;
			this.DataVerifier = this.GetEntry("CentreImage", "Path");
			if (this.DataVerifier == null)
			{
				this.DataVerifier = "";
				this.SetEntry("CentreImage", "Path", this.DataVerifier);
			}
			this.CentreImage.Path = this.DataVerifier;
			this.DataVerifier = null;
			this.DataVerifier = this.GetEntry("CentreImage", "DefaultOpacity");
			if (this.DataVerifier == null)
			{
				this.DataVerifier = "255";
				this.SetEntry("CentreImage", "DefaultOpacity", this.DataVerifier);
			}
			try
			{
				this.CentreImage.DefaultOpacity = int.Parse(this.DataVerifier);
			}
			catch (Exception)
			{
				this.CentreImage.DefaultOpacity = 255;
				this.SetEntry("CentreImage", "DefaultOpacity", "255");
			}
			if (this.CentreImage.DefaultOpacity < 0)
			{
				this.CentreImage.DefaultOpacity = 0;
				this.SetEntry("CentreImage", "DefaultOpacity", "0");
			}
			else if (this.CentreImage.DefaultOpacity > 255)
			{
				this.CentreImage.DefaultOpacity = 255;
				this.SetEntry("CentreImage", "DefaultOpacity", "255");
			}
			this.DataVerifier = null;
			this.DataVerifier = this.GetEntry("CentreImage", "DefaultWidth");
			if (this.DataVerifier == null)
			{
				this.DataVerifier = "255";
				this.SetEntry("CentreImage", "DefaultWidth", this.DataVerifier);
			}
			try
			{
				this.CentreImage.DefaultWidth = int.Parse(this.DataVerifier);
			}
			catch (Exception)
			{
				this.CentreImage.DefaultWidth = 255;
				this.SetEntry("CentreImage", "DefaultWidth", "255");
			}
			if (this.CentreImage.DefaultWidth <= 0)
			{
				this.CentreImage.DefaultWidth = 255;
				this.SetEntry("CentreImage", "DefaultWidth", "255");
			}
			this.DataVerifier = null;
			this.DataVerifier = this.GetEntry("CentreImage", "DefaultHeight");
			if (this.DataVerifier == null)
			{
				this.DataVerifier = "255";
				this.SetEntry("CentreImage", "DefaultHeight", this.DataVerifier);
			}
			try
			{
				this.CentreImage.DefaultHeight = int.Parse(this.DataVerifier);
			}
			catch (Exception)
			{
				this.CentreImage.DefaultHeight = 255;
				this.SetEntry("CentreImage", "DefaultHeight", "255");
			}
			if (this.CentreImage.DefaultHeight <= 0)
			{
				this.CentreImage.DefaultHeight = 255;
				this.SetEntry("CentreImage", "DefaultHeight", "255");
			}
			this.DataVerifier = null;
			this.DataVerifier = this.GetEntry("CentreImage", "ShowStartMenuWhenClicked");
			if (this.DataVerifier == null)
			{
				this.DataVerifier = false.ToString();
				this.SetEntry("CentreImage", "ShowStartMenuWhenClicked", this.DataVerifier);
			}
			try
			{
				this.CentreImage.ShowStartMenuWhenClicked = bool.Parse(this.DataVerifier);
			}
			catch (Exception)
			{
				this.CentreImage.ShowStartMenuWhenClicked = false;
				this.SetEntry("CentreImage", "ShowStartMenuWhenClicked", false.ToString());
			}
		}

		private void LoadCircleParams()
		{
			this.DataVerifier = null;
			this.DataVerifier = this.GetEntry("CircleParams", "CircleSeparation");
			if (this.DataVerifier == null)
			{
				this.DataVerifier = "155";
				this.SetEntry("CircleParams", "CircleSeparation", this.DataVerifier);
			}
			try
			{
				this.CircleParams.CircleSeparation = int.Parse(this.DataVerifier);
			}
			catch (Exception)
			{
				this.CircleParams.CircleSeparation = 155;
				this.SetEntry("CircleParams", "CircleSeparation", "155");
			}
			if (this.CircleParams.CircleSeparation < 0)
			{
				this.CircleParams.CircleSeparation = 155;
				this.SetEntry("CircleParams", "CircleSeparation", "155");
			}
			this.DataVerifier = null;
			this.DataVerifier = this.GetEntry("CircleParams", "MinRadius");
			if (this.DataVerifier == null)
			{
				this.DataVerifier = "255";
				this.SetEntry("CircleParams", "MinRadius", this.DataVerifier);
			}
			try
			{
				this.CircleParams.MinRadius = int.Parse(this.DataVerifier);
			}
			catch (Exception)
			{
				this.CircleParams.MinRadius = 255;
				this.SetEntry("CircleParams", "MinRadius", "255");
			}
			if (this.CircleParams.MinRadius < 0)
			{
				this.CircleParams.MinRadius = 255;
				this.SetEntry("CircleParams", "MinRadius", "255");
			}
			this.DataVerifier = null;
			this.DataVerifier = this.GetEntry("CircleParams", "Format");
			ArrayList arrayList = new ArrayList();
			arrayList.Add("Constant Number of Items Per Circle");
			arrayList.Add("Maximum Number of Items Per Circle");
			if (this.DataVerifier == null || !arrayList.Contains(this.DataVerifier))
			{
				this.DataVerifier = "Constant Number of Items Per Circle";
				this.SetEntry("CircleParams", "Format", this.DataVerifier);
			}
			this.CircleParams.Format = this.DataVerifier;
			this.DataVerifier = null;
			this.DataVerifier = this.GetEntry("CircleParams", "ConstNumItemsPerCircle");
			if (this.DataVerifier == null)
			{
				this.DataVerifier = "10";
				this.SetEntry("CircleParams", "ConstNumItemsPerCircle", this.DataVerifier);
			}
			try
			{
				this.CircleParams.ConstNumItemsPerCircle = int.Parse(this.DataVerifier);
			}
			catch (Exception)
			{
				this.CircleParams.ConstNumItemsPerCircle = 10;
				this.SetEntry("CircleParams", "ConstNumItemsPerCircle", "10");
			}
			if (this.CircleParams.ConstNumItemsPerCircle < 0)
			{
				this.CircleParams.ConstNumItemsPerCircle = 10;
				this.SetEntry("CircleParams", "ConstNumItemsPerCircle", "10");
			}
		}

		private void LoadDockItems()
		{
			this.DataVerifier = null;
			this.DataVerifier = this.GetEntry("DockItems", "DefaultHeight");
			if (this.DataVerifier == null)
			{
				this.DataVerifier = "60";
				this.SetEntry("DockItems", "DefaultHeight", this.DataVerifier);
			}
			try
			{
				this.DockItems.DefaultHeight = int.Parse(this.DataVerifier);
			}
			catch (Exception)
			{
				this.DockItems.DefaultHeight = 60;
				this.SetEntry("DockItems", "DefaultHeight", "60");
			}
			if (this.DockItems.DefaultHeight <= 0)
			{
				this.DockItems.DefaultHeight = 60;
				this.SetEntry("DockItems", "DefaultHeight", "60");
			}
			this.DataVerifier = null;
			this.DataVerifier = this.GetEntry("DockItems", "DefaultWidth");
			if (this.DataVerifier == null)
			{
				this.DataVerifier = "60";
				this.SetEntry("DockItems", "DefaultWidth", this.DataVerifier);
			}
			try
			{
				this.DockItems.DefaultWidth = int.Parse(this.DataVerifier);
			}
			catch (Exception)
			{
				this.DockItems.DefaultWidth = 60;
				this.SetEntry("DockItems", "DefaultWidth", "60");
			}
			if (this.DockItems.DefaultWidth <= 0)
			{
				this.DockItems.DefaultWidth = 60;
				this.SetEntry("DockItems", "DefaultWidth", "60");
			}
			this.DataVerifier = null;
			this.DataVerifier = this.GetEntry("DockItems", "MaxHeight");
			if (this.DataVerifier == null)
			{
				this.DataVerifier = "100";
				this.SetEntry("DockItems", "MaxHeight", this.DataVerifier);
			}
			try
			{
				this.DockItems.MaxHeight = int.Parse(this.DataVerifier);
			}
			catch (Exception)
			{
				this.DockItems.MaxHeight = 100;
				this.SetEntry("DockItems", "MaxHeight", "100");
			}
			if (this.DockItems.MaxHeight <= 0)
			{
				this.DockItems.MaxHeight = 100;
				this.SetEntry("DockItems", "MaxHeight", "100");
			}
			this.DataVerifier = null;
			this.DataVerifier = this.GetEntry("DockItems", "MaxWidth");
			if (this.DataVerifier == null)
			{
				this.DataVerifier = "100";
				this.SetEntry("DockItems", "MaxWidth", this.DataVerifier);
			}
			try
			{
				this.DockItems.MaxWidth = int.Parse(this.DataVerifier);
			}
			catch (Exception)
			{
				this.DockItems.MaxWidth = 100;
				this.SetEntry("DockItems", "MaxWidth", "100");
			}
			if (this.DockItems.MaxWidth <= 0)
			{
				this.DockItems.MaxWidth = 100;
				this.SetEntry("DockItems", "MaxWidth", "100");
			}
			this.DataVerifier = null;
			this.DataVerifier = this.GetEntry("DockItems", "MinHeight");
			if (this.DataVerifier == null)
			{
				this.DataVerifier = "40";
				this.SetEntry("DockItems", "MinHeight", this.DataVerifier);
			}
			try
			{
				this.DockItems.MinHeight = int.Parse(this.DataVerifier);
			}
			catch (Exception)
			{
				this.DockItems.MinHeight = 40;
				this.SetEntry("DockItems", "MinHeight", "40");
			}
			if (this.DockItems.MinHeight <= 0)
			{
				this.DockItems.MinHeight = 40;
				this.SetEntry("DockItems", "MinHeight", "40");
			}
			this.DataVerifier = null;
			this.DataVerifier = this.GetEntry("DockItems", "MinWidth");
			if (this.DataVerifier == null)
			{
				this.DataVerifier = "40";
				this.SetEntry("DockItems", "MinWidth", this.DataVerifier);
			}
			try
			{
				this.DockItems.MinWidth = int.Parse(this.DataVerifier);
			}
			catch (Exception)
			{
				this.DockItems.MinWidth = 40;
				this.SetEntry("DockItems", "MinWidth", "40");
			}
			if (this.DockItems.MinWidth <= 0)
			{
				this.DockItems.MinWidth = 40;
				this.SetEntry("DockItems", "MinWidth", "40");
			}
			this.DataVerifier = null;
			this.DataVerifier = this.GetEntry("DockItems", "ShowExplorerContextMenus");
			if (this.DataVerifier == null)
			{
				this.DataVerifier = false.ToString();
				this.SetEntry("DockItems", "ShowExplorerContextMenus", this.DataVerifier);
			}
			try
			{
				this.DockItems.ShowExplorerContextMenus = bool.Parse(this.DataVerifier);
			}
			catch (Exception)
			{
				this.DockItems.ShowExplorerContextMenus = false;
				this.SetEntry("DockItems", "ShowExplorerContextMenus", false.ToString());
			}
			this.DataVerifier = null;
			this.DataVerifier = this.GetEntry("DockItems", "HideDockAfterExecution");
			if (this.DataVerifier == null)
			{
				this.DataVerifier = false.ToString();
				this.SetEntry("DockItems", "HideDockAfterExecution", this.DataVerifier);
			}
			try
			{
				this.DockItems.HideDockAfterExecution = bool.Parse(this.DataVerifier);
			}
			catch (Exception)
			{
				this.DockItems.HideDockAfterExecution = false;
				this.SetEntry("DockItems", "HideDockAfterExecution", false.ToString());
			}
			this.DataVerifier = null;
			this.DataVerifier = this.GetEntry("DockItems", "DefaultOpacity");
			if (this.DataVerifier == null)
			{
				this.DataVerifier = "255";
				this.SetEntry("DockItems", "DefaultOpacity", this.DataVerifier);
			}
			try
			{
				this.DockItems.DefaultOpacity = int.Parse(this.DataVerifier);
			}
			catch (Exception)
			{
				this.DockItems.DefaultOpacity = 255;
				this.SetEntry("DockItems", "DefaultOpacity", "255");
			}
			if (this.DockItems.DefaultOpacity < 0)
			{
				this.DockItems.DefaultOpacity = 0;
				this.SetEntry("DockItems", "DefaultOpacity", "0");
			}
			else if (this.DockItems.DefaultOpacity > 255)
			{
				this.DockItems.DefaultOpacity = 255;
				this.SetEntry("DockItems", "DefaultOpacity", "255");
			}
		}

		private void LoadEllipseParams()
		{
			this.DataVerifier = null;
			this.DataVerifier = this.GetEntry("EllipseParams", "MinHeight");
			if (this.DataVerifier == null)
			{
				this.DataVerifier = "255";
				this.SetEntry("EllipseParams", "MinHeight", this.DataVerifier);
			}
			try
			{
				this.EllipseParams.MinHeight = int.Parse(this.DataVerifier);
			}
			catch (Exception)
			{
				this.EllipseParams.MinHeight = 255;
				this.SetEntry("EllipseParams", "MinHeight", "255");
			}
			if (this.EllipseParams.MinHeight <= 0)
			{
				this.EllipseParams.MinHeight = 255;
				this.SetEntry("EllipseParams", "MinHeight", "255");
			}
			this.DataVerifier = null;
			this.DataVerifier = this.GetEntry("EllipseParams", "AspectRatio");
			if (this.DataVerifier == null)
			{
				this.DataVerifier = "1";
				this.SetEntry("EllipseParams", "AspectRatio", this.DataVerifier);
			}
			try
			{
				this.EllipseParams.AspectRatio = double.Parse(this.DataVerifier);
			}
			catch (Exception)
			{
				this.EllipseParams.AspectRatio = 1.0;
				this.SetEntry("EllipseParams", "AspectRatio", "1");
			}
			if (this.EllipseParams.AspectRatio <= 0.0)
			{
				this.EllipseParams.AspectRatio = 1.0;
				this.SetEntry("EllipseParams", "AspectRatio", "1");
			}
		}

		private void LoadLanguage()
		{
			this.DataVerifier = null;
			this.DataVerifier = this.GetEntry("Language", "Path");
			if (this.DataVerifier == null)
			{
				this.DataVerifier = "";
				this.SetEntry("Language", "Path", this.DataVerifier);
			}
			this.Language.path = this.DataVerifier;
		}

		private void LoadShape()
		{
			this.DataVerifier = null;
			this.DataVerifier = this.GetEntry("Shape", "Shape");
			ArrayList arrayList = new ArrayList();
			arrayList.Add("Circle");
			if (this.DataVerifier == null || !arrayList.Contains(this.DataVerifier))
			{
				this.DataVerifier = "Circle";
				this.SetEntry("Shape", "Shape", this.DataVerifier);
			}
			this.Shape.Shape = this.DataVerifier;
		}

		private void LoadFolders()
		{
			this.DataVerifier = null;
			this.DataVerifier = this.GetEntry("Folders", "DockFolderImagePath");
			if (this.DataVerifier == null)
			{
				this.DataVerifier = "";
				this.SetEntry("Folders", "DockFolderImagePath", this.DataVerifier);
			}
			this.Folders.DockFolderImagePath = this.DataVerifier;
		}

		private void LoadGeneral()
		{
			this.DataVerifier = null;
			this.DataVerifier = this.GetEntry("General", "ShowLevelRealTimeCreation");
			if (this.DataVerifier == null)
			{
				this.DataVerifier = false.ToString();
				this.SetEntry("General", "ShowLevelRealTimeCreation", this.DataVerifier);
			}
			try
			{
				this.General.ShowLevelRealTimeCreation = bool.Parse(this.DataVerifier);
			}
			catch (Exception)
			{
				this.General.ShowLevelRealTimeCreation = false;
				this.SetEntry("General", "ShowLevelRealTimeCreation", false.ToString());
			}
			this.DataVerifier = null;
			this.DataVerifier = this.GetEntry("General", "CentreAroundCursor");
			if (this.DataVerifier == null)
			{
				this.DataVerifier = true.ToString();
				this.SetEntry("General", "CentreAroundCursor", this.DataVerifier);
			}
			try
			{
				this.General.CentreAroundCursor = bool.Parse(this.DataVerifier);
			}
			catch (Exception)
			{
				this.General.CentreAroundCursor = true;
				this.SetEntry("General", "CentreAroundCursor", true.ToString());
			}
			this.DataVerifier = null;
			this.DataVerifier = this.GetEntry("General", "EnableDockRotation");
			if (this.DataVerifier == null)
			{
				this.DataVerifier = true.ToString();
				this.SetEntry("General", "EnableDockRotation", this.DataVerifier);
			}
			try
			{
				this.General.EnableDockRotation = bool.Parse(this.DataVerifier);
			}
			catch (Exception)
			{
				this.General.EnableDockRotation = true;
				this.SetEntry("General", "EnableDockRotation", true.ToString());
			}
			this.DataVerifier = null;
			this.DataVerifier = this.GetEntry("General", "AnimationInterval");
			if (this.DataVerifier == null)
			{
				this.DataVerifier = "20";
				this.SetEntry("General", "AnimationInterval", this.DataVerifier);
			}
			try
			{
				this.General.AnimationInterval = int.Parse(this.DataVerifier);
			}
			catch (Exception)
			{
				this.General.AnimationInterval = 20;
				this.SetEntry("General", "AnimationInterval", "20");
			}
			if (this.General.AnimationInterval <= 0)
			{
				this.General.AnimationInterval = 20;
				this.SetEntry("General", "AnimationInterval", "20");
			}
			this.DataVerifier = null;
			this.DataVerifier = this.GetEntry("General", "ClickSensitivity");
			if (this.DataVerifier == null)
			{
				this.DataVerifier = "0";
				this.SetEntry("General", "ClickSensitivity", this.DataVerifier);
			}
			try
			{
				this.General.ClickSensitivity = int.Parse(this.DataVerifier);
			}
			catch (Exception)
			{
				this.General.ClickSensitivity = 0;
				this.SetEntry("General", "ClickSensitivity", "0");
			}
			if (this.General.ClickSensitivity < 0)
			{
				this.General.ClickSensitivity = 0;
				this.SetEntry("General", "ClickSensitivity", "0");
			}
			else if (this.General.ClickSensitivity > 100)
			{
				this.General.ClickSensitivity = 100;
				this.SetEntry("General", "ClickSensitivity", "100");
			}
			this.DataVerifier = null;
			this.DataVerifier = this.GetEntry("General", "EnablePortabilityMode");
			if (this.DataVerifier == null)
			{
				this.DataVerifier = false.ToString();
				this.SetEntry("General", "EnablePortabilityMode", this.DataVerifier);
			}
			try
			{
				this.General.EnablePortabilityMode = bool.Parse(this.DataVerifier);
			}
			catch (Exception)
			{
				this.General.EnablePortabilityMode = false;
				this.SetEntry("General", "EnablePortabilityMode", false.ToString());
			}
			this.DataVerifier = null;
			this.DataVerifier = this.GetEntry("General", "KeyPressesPerRevolution");
			if (this.DataVerifier == null)
			{
				this.DataVerifier = "15";
				this.SetEntry("General", "KeyPressesPerRevolution", this.DataVerifier);
			}
			try
			{
				this.General.KeyPressesPerRevolution = int.Parse(this.DataVerifier);
			}
			catch (Exception)
			{
				this.General.KeyPressesPerRevolution = 15;
				this.SetEntry("General", "KeyPressesPerRevolution", "15");
			}
			if (this.General.KeyPressesPerRevolution < 0)
			{
				this.General.KeyPressesPerRevolution = 15;
				this.SetEntry("General", "KeyPressesPerRevolution", "15");
			}
			else if (this.General.KeyPressesPerRevolution > 50)
			{
				this.General.KeyPressesPerRevolution = 15;
				this.SetEntry("General", "KeyPressesPerRevolution", "50");
			}
			this.DataVerifier = null;
			this.DataVerifier = this.GetEntry("General", "UseMemorySaver");
			if (this.DataVerifier == null)
			{
				this.DataVerifier = true.ToString();
				this.SetEntry("General", "UseMemorySaver", this.DataVerifier);
			}
			try
			{
				this.General.UseMemorySaver = bool.Parse(this.DataVerifier);
			}
			catch (Exception)
			{
				this.General.UseMemorySaver = true;
				this.SetEntry("General", "UseMemorySaver", true.ToString());
			}
			this.DataVerifier = null;
			this.DataVerifier = this.GetEntry("General", "IconReplacementMode");
			if (this.DataVerifier == null)
			{
				this.DataVerifier = false.ToString();
				this.SetEntry("General", "IconReplacementMode", this.DataVerifier);
			}
			try
			{
				this.General.IconReplacementMode = bool.Parse(this.DataVerifier);
			}
			catch (Exception)
			{
				this.General.IconReplacementMode = false;
				this.SetEntry("General", "IconReplacementMode", false.ToString());
			}
			this.DataVerifier = null;
			this.DataVerifier = this.GetEntry("General", "zLevel");
			if (this.DataVerifier == null || (this.DataVerifier != "Topmost" && this.DataVerifier != "Normal" && this.DataVerifier != "Always On Bottom"))
			{
				this.DataVerifier = "Topmost";
				this.SetEntry("General", "zLevel", this.DataVerifier);
			}
			this.General.zLevel = this.DataVerifier;
			this.DataVerifier = null;
			this.DataVerifier = this.GetEntry("General", "lockDockPosition");
			if (this.DataVerifier == null)
			{
				this.DataVerifier = false.ToString();
				this.SetEntry("General", "lockDockPosition", this.DataVerifier);
			}
			try
			{
				this.General.lockDockPosition = bool.Parse(this.DataVerifier);
			}
			catch (Exception)
			{
				this.General.lockDockPosition = false;
				this.SetEntry("General", "lockDockPosition", false.ToString());
			}
			TypeConverter converter = TypeDescriptor.GetConverter(typeof(Point));
			this.DataVerifier = null;
			this.DataVerifier = this.GetEntry("General", "lockedPosition");
			if (this.DataVerifier == null)
			{
				this.DataVerifier = converter.ConvertToString(new Point(0, 0));
				this.SetEntry("General", "lockedPosition", this.DataVerifier);
			}
			try
			{
				this.General.lockedPosition = (Point)converter.ConvertFromString(this.DataVerifier);
			}
			catch (Exception)
			{
				this.General.lockedPosition = new Point(0, 0);
				this.SetEntry("General", "lockedPosition", converter.ConvertToString(new Point(0, 0)));
			}
			this.DataVerifier = null;
			this.DataVerifier = this.GetEntry("General", "useSameRotationValues");
			if (this.DataVerifier == null)
			{
				this.DataVerifier = false.ToString();
				this.SetEntry("General", "useSameRotationValues", this.DataVerifier);
			}
			try
			{
				this.General.useSameRotationValues = bool.Parse(this.DataVerifier);
			}
			catch (Exception)
			{
				this.General.useSameRotationValues = false;
				this.SetEntry("General", "useSameRotationValues", false.ToString());
			}
		}

		private void LoadPoofAnimation()
		{
			this.DataVerifier = null;
			this.DataVerifier = this.GetEntry("PoofAnimation", "Path");
			if (this.DataVerifier == null)
			{
				this.DataVerifier = "";
				this.SetEntry("PoofAnimation", "Path", this.DataVerifier);
			}
			this.PoofAnimation.PoofAnimationPath = this.DataVerifier;
			this.DataVerifier = null;
			this.DataVerifier = this.GetEntry("PoofAnimation", "NumFrames");
			ArrayList arrayList = new ArrayList();
			arrayList.Add(6);
			if (this.DataVerifier == null || !arrayList.Contains(this.DataVerifier))
			{
				this.DataVerifier = "6";
				this.SetEntry("PoofAnimation", "NumFrames", this.DataVerifier);
			}
			try
			{
				this.PoofAnimation.NumFrames = 6;
			}
			catch (Exception)
			{
				this.PoofAnimation.NumFrames = 6;
			}
			this.DataVerifier = null;
			this.DataVerifier = this.GetEntry("PoofAnimation", "DelayBetweenFrames");
			if (this.DataVerifier == null)
			{
				this.DataVerifier = "50";
				this.SetEntry("PoofAnimation", "DelayBetweenFrames", this.DataVerifier);
			}
			try
			{
				this.PoofAnimation.DelayBetweenFrames = int.Parse(this.DataVerifier);
			}
			catch (Exception)
			{
				this.PoofAnimation.DelayBetweenFrames = 50;
				this.SetEntry("PoofAnimation", "DelayBetweenFrames", "50");
			}
			if (this.PoofAnimation.DelayBetweenFrames <= 0)
			{
				this.PoofAnimation.DelayBetweenFrames = 50;
				this.SetEntry("PoofAnimation", "DelayBetweenFrames", "50");
			}
			this.DataVerifier = null;
			this.DataVerifier = this.GetEntry("PoofAnimation", "UsePoof");
			if (this.DataVerifier == null)
			{
				this.DataVerifier = true.ToString();
				this.SetEntry("PoofAnimation", "UsePoof", this.DataVerifier);
			}
			try
			{
				this.PoofAnimation.UsePoof = bool.Parse(this.DataVerifier);
			}
			catch (Exception)
			{
				this.PoofAnimation.UsePoof = true;
				this.SetEntry("PoofAnimation", "UsePoof", true.ToString());
			}
		}

		private void LoadToggling()
		{
			KeysConverter keysConverter = new KeysConverter();
			this.DataVerifier = null;
			this.DataVerifier = this.GetEntry("Toggling", "VisibilityCtrl");
			if (this.DataVerifier == null)
			{
				this.DataVerifier = false.ToString();
				this.SetEntry("Toggling", "VisibilityCtrl", this.DataVerifier);
			}
			try
			{
				this.Toggling.VisibilityCtrl = bool.Parse(this.DataVerifier);
			}
			catch (Exception)
			{
				this.Toggling.VisibilityCtrl = false;
				this.SetEntry("Toggling", "VisibilityCtrl", false.ToString());
			}
			this.DataVerifier = null;
			this.DataVerifier = this.GetEntry("Toggling", "VisibilityAlt");
			if (this.DataVerifier == null)
			{
				this.DataVerifier = false.ToString();
				this.SetEntry("Toggling", "VisibilityAlt", this.DataVerifier);
			}
			try
			{
				this.Toggling.VisibilityAlt = bool.Parse(this.DataVerifier);
			}
			catch (Exception)
			{
				this.Toggling.VisibilityAlt = false;
				this.SetEntry("Toggling", "VisibilityAlt", false.ToString());
			}
			this.DataVerifier = null;
			this.DataVerifier = this.GetEntry("Toggling", "VisibilityShift");
			if (this.DataVerifier == null)
			{
				this.DataVerifier = false.ToString();
				this.SetEntry("Toggling", "VisibilityShift", this.DataVerifier);
			}
			try
			{
				this.Toggling.VisibilityShift = bool.Parse(this.DataVerifier);
			}
			catch (Exception)
			{
				this.Toggling.VisibilityShift = false;
				this.SetEntry("Toggling", "VisibilityShift", false.ToString());
			}
			this.DataVerifier = null;
			this.DataVerifier = this.GetEntry("Toggling", "VisibilityWin");
			if (this.DataVerifier == null)
			{
				this.DataVerifier = false.ToString();
				this.SetEntry("Toggling", "VisibilityWin", this.DataVerifier);
			}
			try
			{
				this.Toggling.VisibilityWin = bool.Parse(this.DataVerifier);
			}
			catch (Exception)
			{
				this.Toggling.VisibilityWin = false;
				this.SetEntry("Toggling", "VisibilityWin", false.ToString());
			}
			this.DataVerifier = null;
			this.DataVerifier = this.GetEntry("Toggling", "VisibilityKey1");
			if (this.DataVerifier == null)
			{
				this.DataVerifier = keysConverter.ConvertToString(Keys.F1);
				this.SetEntry("Toggling", "VisibilityKey1", this.DataVerifier);
			}
			try
			{
				this.Toggling.VisibilityKey1 = int.Parse(this.DataVerifier);
			}
			catch (Exception)
			{
				this.DataVerifier = keysConverter.ConvertToString(Keys.F1);
				this.SetEntry("Toggling", "VisibilityKey1", this.DataVerifier);
			}
			this.DataVerifier = null;
			this.DataVerifier = this.GetEntry("Toggling", "VisibilityKey2");
			if (this.DataVerifier == null)
			{
				this.DataVerifier = keysConverter.ConvertToString(Keys.None);
				this.SetEntry("Toggling", "VisibilityKey2", this.DataVerifier);
			}
			try
			{
				this.Toggling.VisibilityKey2 = int.Parse(this.DataVerifier);
			}
			catch (Exception)
			{
				this.DataVerifier = keysConverter.ConvertToString(Keys.None);
				this.SetEntry("Toggling", "VisibilityKey2", this.DataVerifier);
			}
			this.DataVerifier = null;
			this.DataVerifier = this.GetEntry("Toggling", "VisibilityMouseButton");
			ArrayList arrayList = new ArrayList();
			arrayList.Add(keysConverter.ConvertToString(Keys.None));
			arrayList.Add(keysConverter.ConvertToString(Keys.MButton));
			arrayList.Add(keysConverter.ConvertToString(Keys.XButton1));
			arrayList.Add(keysConverter.ConvertToString(Keys.XButton2));
			if (this.DataVerifier == null || !arrayList.Contains(this.DataVerifier))
			{
				this.DataVerifier = keysConverter.ConvertToString(Keys.MButton);
				this.SetEntry("Toggling", "VisibilityMouseButton", this.DataVerifier);
			}
			try
			{
				this.Toggling.VisibilityMouseButton = keysConverter.ConvertToString(this.DataVerifier);
			}
			catch (Exception)
			{
				this.DataVerifier = keysConverter.ConvertToString(Keys.MButton);
				this.SetEntry("Toggling", "VisibilityMouseButton", this.DataVerifier);
			}
			this.DataVerifier = null;
			this.DataVerifier = this.GetEntry("Toggling", "ScreenLeftEdgeShow");
			if (this.DataVerifier == null)
			{
				this.DataVerifier = false.ToString();
				this.SetEntry("Toggling", "ScreenLeftEdgeShow", this.DataVerifier);
			}
			try
			{
				this.Toggling.ScreenLeftEdgeShow = bool.Parse(this.DataVerifier);
			}
			catch (Exception)
			{
				this.Toggling.ScreenLeftEdgeShow = false;
				this.SetEntry("Toggling", "ScreenLeftEdgeShow", false.ToString());
			}
			this.DataVerifier = null;
			this.DataVerifier = this.GetEntry("Toggling", "ScreenRightEdgeShow");
			if (this.DataVerifier == null)
			{
				this.DataVerifier = false.ToString();
				this.SetEntry("Toggling", "ScreenRightEdgeShow", this.DataVerifier);
			}
			try
			{
				this.Toggling.ScreenRightEdgeShow = bool.Parse(this.DataVerifier);
			}
			catch (Exception)
			{
				this.Toggling.ScreenRightEdgeShow = false;
				this.SetEntry("Toggling", "ScreenRightEdgeShow", false.ToString());
			}
			this.DataVerifier = null;
			this.DataVerifier = this.GetEntry("Toggling", "ScreenTopEdgeShow");
			if (this.DataVerifier == null)
			{
				this.DataVerifier = false.ToString();
				this.SetEntry("Toggling", "ScreenTopEdgeShow", this.DataVerifier);
			}
			try
			{
				this.Toggling.ScreenTopEdgeShow = bool.Parse(this.DataVerifier);
			}
			catch (Exception)
			{
				this.Toggling.ScreenTopEdgeShow = false;
				this.SetEntry("Toggling", "ScreenTopEdgeShow", false.ToString());
			}
			this.DataVerifier = null;
			this.DataVerifier = this.GetEntry("Toggling", "ScreenBottomEdgeShow");
			if (this.DataVerifier == null)
			{
				this.DataVerifier = false.ToString();
				this.SetEntry("Toggling", "ScreenBottomEdgeShow", this.DataVerifier);
			}
			try
			{
				this.Toggling.ScreenBottomEdgeShow = bool.Parse(this.DataVerifier);
			}
			catch (Exception)
			{
				this.Toggling.ScreenBottomEdgeShow = false;
				this.SetEntry("Toggling", "ScreenBottomEdgeShow", false.ToString());
			}
			this.DataVerifier = null;
			this.DataVerifier = this.GetEntry("Toggling", "EdgeWidthHeight");
			if (this.DataVerifier == null)
			{
				this.DataVerifier = "1";
				this.SetEntry("Toggling", "EdgeWidthHeight", this.DataVerifier);
			}
			try
			{
				this.Toggling.EdgeWidthHeight = int.Parse(this.DataVerifier);
			}
			catch (Exception)
			{
				this.Toggling.EdgeWidthHeight = 1;
				this.SetEntry("Toggling", "EdgeWidthHeight", "1");
			}
			if (this.Toggling.EdgeWidthHeight < 1)
			{
				this.Toggling.EdgeWidthHeight = 1;
				this.SetEntry("Toggling", "EdgeWidthHeight", "1");
			}
			else if (this.Toggling.EdgeWidthHeight > 10)
			{
				this.Toggling.EdgeWidthHeight = 10;
				this.SetEntry("Toggling", "EdgeWidthHeight", "10");
			}
			this.DataVerifier = null;
			this.DataVerifier = this.GetEntry("Toggling", "dwellTime");
			if (this.DataVerifier == null)
			{
				this.DataVerifier = "200";
				this.SetEntry("Toggling", "dwellTime", this.DataVerifier);
			}
			try
			{
				this.Toggling.dwellTime = int.Parse(this.DataVerifier);
			}
			catch (Exception)
			{
				this.Toggling.dwellTime = 200;
				this.SetEntry("Toggling", "dwellTime", "200");
			}
			if (this.Toggling.dwellTime < 0)
			{
				this.Toggling.dwellTime = 0;
				this.SetEntry("Toggling", "dwellTime", "0");
			}
			else if (this.Toggling.dwellTime > 1000)
			{
				this.Toggling.dwellTime = 1000;
				this.SetEntry("Toggling", "dwellTime", "1000");
			}
		}

		private void LoadLabels()
		{
			TypeConverter converter = TypeDescriptor.GetConverter(typeof(Font));
			TypeConverter converter2 = TypeDescriptor.GetConverter(typeof(Color));
			try
			{
				this.Labels.FontName = (Font)converter.ConvertFromString(this.GetEntry("Labels", "FontName"));
				if (this.Labels.FontName == null)
				{
					this.Labels.FontName = new Font(FontFamily.GenericSansSerif, 16f, FontStyle.Bold);
					this.SetEntry("Labels", "FontName", converter.ConvertToString(this.Labels.FontName));
				}
			}
			catch (Exception)
			{
				this.Labels.FontName = new Font(FontFamily.GenericSansSerif, 16f, FontStyle.Bold);
				this.SetEntry("Labels", "FontName", converter.ConvertToString(this.Labels.FontName));
			}
			try
			{
				this.Labels.FontColor = Color.FromArgb(int.Parse(this.GetEntry("Labels", "FontColor")));
				bool flag = 0 == 0;
			}
			catch (Exception)
			{
				this.Labels.FontColor = Color.Black;
				this.SetEntry("Labels", "FontColor", this.Labels.FontColor.ToArgb().ToString());
			}
			try
			{
				this.Labels.ShadowColor = Color.FromArgb(int.Parse(this.GetEntry("Labels", "ShadowColor")));
				bool flag = 0 == 0;
			}
			catch (Exception)
			{
				this.Labels.ShadowColor = Color.White;
				this.SetEntry("Labels", "ShadowColor", this.Labels.ShadowColor.ToArgb().ToString());
			}
			this.DataVerifier = null;
			this.DataVerifier = this.GetEntry("Labels", "ShadowSize");
			if (this.DataVerifier == null)
			{
				this.DataVerifier = "6";
				this.SetEntry("Labels", "ShadowSize", this.DataVerifier);
			}
			try
			{
				this.Labels.ShadowSize = int.Parse(this.DataVerifier);
			}
			catch (Exception)
			{
				this.Labels.ShadowSize = 6;
				this.SetEntry("Labels", "ShadowSize", "6");
			}
			if (this.Labels.ShadowSize < 0)
			{
				this.Labels.ShadowSize = 0;
				this.SetEntry("Labels", "ShadowSize", "0");
			}
			else if (this.Labels.ShadowSize > 15)
			{
				this.Labels.ShadowSize = 15;
				this.SetEntry("Labels", "ShadowSize", "15");
			}
			this.DataVerifier = null;
			this.DataVerifier = this.GetEntry("Labels", "ShadowDarkness");
			if (this.DataVerifier == null)
			{
				this.DataVerifier = "10";
				this.SetEntry("Labels", "ShadowDarkness", this.DataVerifier);
			}
			try
			{
				this.Labels.ShadowDarkness = int.Parse(this.DataVerifier);
			}
			catch (Exception)
			{
				this.Labels.ShadowDarkness = 10;
				this.SetEntry("Labels", "ShadowDarkness", "10");
			}
			if (this.Labels.ShadowDarkness < 0)
			{
				this.Labels.ShadowDarkness = 0;
				this.SetEntry("Labels", "ShadowDarkness", "0");
			}
			else if (this.Labels.ShadowDarkness > 25)
			{
				this.Labels.ShadowDarkness = 25;
				this.SetEntry("Labels", "ShadowDarkness", "25");
			}
			this.DataVerifier = null;
			this.DataVerifier = this.GetEntry("Labels", "ShowLabels");
			if (this.DataVerifier == null)
			{
				this.DataVerifier = true.ToString();
				this.SetEntry("Labels", "ShowLabels", this.DataVerifier);
			}
			try
			{
				this.Labels.ShowLabels = bool.Parse(this.DataVerifier);
			}
			catch (Exception)
			{
				this.Labels.ShowLabels = true;
				this.SetEntry("Labels", "ShowLabels", true.ToString());
			}
			this.DataVerifier = null;
			this.DataVerifier = this.GetEntry("Labels", "ShowLabelsOnMouseOverOnly");
			if (this.DataVerifier == null)
			{
				this.DataVerifier = true.ToString();
				this.SetEntry("Labels", "ShowLabelsOnMouseOverOnly", this.DataVerifier);
			}
			try
			{
				this.Labels.ShowLabelsOnMouseOverOnly = bool.Parse(this.DataVerifier);
			}
			catch (Exception)
			{
				this.Labels.ShowLabelsOnMouseOverOnly = true;
				this.SetEntry("Labels", "ShowLabelsOnMouseOverOnly", true.ToString());
			}
			this.DataVerifier = null;
			this.DataVerifier = this.GetEntry("Labels", "DefaultOpacity");
			if (this.DataVerifier == null)
			{
				this.DataVerifier = "255";
				this.SetEntry("Labels", "DefaultOpacity", this.DataVerifier);
			}
			try
			{
				this.Labels.DefaultOpacity = int.Parse(this.DataVerifier);
			}
			catch (Exception)
			{
				this.Labels.DefaultOpacity = 255;
				this.SetEntry("Labels", "DefaultOpacity", "255");
			}
			if (this.Labels.DefaultOpacity < 0)
			{
				this.Labels.DefaultOpacity = 0;
				this.SetEntry("Labels", "DefaultOpacity", "0");
			}
			else if (this.Labels.DefaultOpacity > 255)
			{
				this.Labels.DefaultOpacity = 255;
				this.SetEntry("Labels", "DefaultOpacity", "255");
			}
		}

		private void LoadGeneralAnimation()
		{
			this.DataVerifier = null;
			this.DataVerifier = this.GetEntry("GeneralAnimation", "RotationAnimationDuration");
			if (this.DataVerifier == null)
			{
				this.DataVerifier = "255";
				this.SetEntry("GeneralAnimation", "RotationAnimationDuration", this.DataVerifier);
			}
			try
			{
				this.GeneralAnimation.RotationAnimationDuration = int.Parse(this.DataVerifier);
			}
			catch (Exception)
			{
				this.GeneralAnimation.RotationAnimationDuration = 255;
			}
			if (this.GeneralAnimation.RotationAnimationDuration <= 0)
			{
				this.GeneralAnimation.RotationAnimationDuration = 255;
			}
			this.DataVerifier = null;
			this.DataVerifier = this.GetEntry("GeneralAnimation", "FadeInFadeOutDuration");
			if (this.DataVerifier == null)
			{
				this.DataVerifier = "255";
				this.SetEntry("GeneralAnimation", "FadeInFadeOutDuration", this.DataVerifier);
			}
			try
			{
				this.GeneralAnimation.FadeInFadeOutDuration = int.Parse(this.DataVerifier);
			}
			catch (Exception)
			{
				this.GeneralAnimation.FadeInFadeOutDuration = 255;
			}
			if (this.GeneralAnimation.FadeInFadeOutDuration <= 0)
			{
				this.GeneralAnimation.FadeInFadeOutDuration = 255;
			}
		}
	}
}
