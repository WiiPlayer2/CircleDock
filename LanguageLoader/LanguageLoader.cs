using AMS.Profile;
using LanguageInformation;
using System;
using System.IO;
using System.Windows.Forms;

namespace LanguageLoader
{
	public class LanguageLoader
	{
		private Profile LanguageINI;

		public General General;

		public LanguageFile LanguageFile;

		public MainContextMenu MainContextMenu;

		public LanguageInformation.SettingsPanel SettingsPanel;

		public ErrorMessages ErrorMessages;

		public DockItemProperties DockItemProperties;

		public LanguageLoader(string FilePath)
		{
			if (!File.Exists(FilePath))
			{
				MessageBox.Show("Language file: " + FilePath + " is missing.\rPlease replace the language file.", "Circle Dock");
			}
			this.LanguageINI = new Ini(FilePath);
			this.InitializeLanguageInfoStructs();
			this.LoadLanguageData();
		}

		public void InitializeLanguageInfoStructs()
		{
			this.General = default(General);
			this.LanguageFile = default(LanguageFile);
			this.MainContextMenu = default(MainContextMenu);
			this.SettingsPanel = default(LanguageInformation.SettingsPanel);
			this.ErrorMessages = default(ErrorMessages);
		}

		public void LoadLanguageData()
		{
			this.LoadGeneral();
			this.LoadLanguageFile();
			this.LoadMainContextMenu();
			this.LoadSettingsPanel();
			this.LoadErrorMessages();
			this.LoadDockItemProperties();
		}

		public void LoadLanguageDataFromNewFile(string FilePath)
		{
			this.LanguageINI = new Ini(FilePath);
			this.LoadLanguageData();
		}

		private string GetEntry(string Section, string EntryName)
		{
			string text = null;
			try
			{
				text = (string)this.LanguageINI.GetValue(Section, EntryName);
			}
			catch (Exception)
			{
			}
			string result;
			if (text != null)
			{
				result = text;
			}
			else
			{
				try
				{
					this.LanguageINI.SetValue(Section, EntryName, "?????");
				}
				catch (Exception)
				{
				}
				result = "?????";
			}
			return result;
		}

		private void LoadGeneral()
		{
			this.General.AuthorWord = this.GetEntry("General", "AuthorWord");
			this.General.CircleDockName = this.GetEntry("General", "CircleDockName");
			this.General.GeneralWebsite = this.GetEntry("General", "GeneralWebsite");
			this.General.HelpWebsite = this.GetEntry("General", "HelpWebsite");
			this.General.CircleDockWebsiteWord = this.GetEntry("General", "CircleDockWebsiteWord");
			this.General.SupportForumWord = this.GetEntry("General", "SupportForumWord");
			this.General.SupportForumWebsite = this.GetEntry("General", "SupportForumWebsite");
			this.General.RotationSensitivity = this.GetEntry("General", "RotationSensitivity");
			this.General.IconReplacementMode = this.GetEntry("General", "IconReplacementMode");
			this.General.normal = this.GetEntry("General", "normal");
			this.General.topmost = this.GetEntry("General", "topmost");
			this.General.alwaysOnBottom = this.GetEntry("General", "alwaysOnBottom");
			this.General.zLevel = this.GetEntry("General", "zLevel");
		}

		private void LoadLanguageFile()
		{
			this.LanguageFile.CircleDockVersion = this.GetEntry("LanguageFile", "CircleDockVersion");
			this.LanguageFile.LanguageName = this.GetEntry("LanguageFile", "LanguageName");
			this.LanguageFile.LanguageFileVersion = this.GetEntry("LanguageFile", "LanguageFileVersion");
			this.LanguageFile.FileAuthor = this.GetEntry("LanguageFile", "FileAuthor");
		}

		private void LoadMainContextMenu()
		{
			this.MainContextMenu.HideWord = this.GetEntry("MainContextMenu", "HideWord");
			this.MainContextMenu.ShowWord = this.GetEntry("MainContextMenu", "ShowWord");
			this.MainContextMenu.QuitWord = this.GetEntry("MainContextMenu", "QuitWord");
			this.MainContextMenu.SettingsWord = this.GetEntry("MainContextMenu", "SettingsWord");
			this.MainContextMenu.WebsiteWord = this.GetEntry("MainContextMenu", "WebsiteWord");
			this.MainContextMenu.RemoveWord = this.GetEntry("MainContextMenu", "RemoveWord");
			this.MainContextMenu.AddWord = this.GetEntry("MainContextMenu", "AddWord");
			this.MainContextMenu.DockFolder = this.GetEntry("MainContextMenu", "DockFolder");
			this.MainContextMenu.ChangeIcon = this.GetEntry("MainContextMenu", "ChangeIcon");
			this.MainContextMenu.ItemSettings = this.GetEntry("MainContextMenu", "ItemSettings");
			this.MainContextMenu.PauseMouseToggling = this.GetEntry("MainContextMenu", "PauseMouseToggling");
			this.MainContextMenu.blankIcon = this.GetEntry("MainContextMenu", "blankIcon");
		}

		private void LoadSettingsPanel()
		{
			this.SettingsPanel.Name = this.GetEntry("SettingsPanel", "Name");
			this.SettingsPanel.SettingsPanelWord = this.GetEntry("SettingsPanel", "SettingsPanelWord");
			this.SettingsPanel.General = this.GetEntry("SettingsPanel", "GeneralWord");
			this.SettingsPanel.DockShape = this.GetEntry("SettingsPanel", "DockShape");
			this.SettingsPanel.Labels = this.GetEntry("SettingsPanel", "Labels");
			this.SettingsPanel.Animation = this.GetEntry("SettingsPanel", "Animation");
			this.SettingsPanel.LocationWord = this.GetEntry("SettingsPanel", "LocationWord");
			this.SettingsPanel.TogglingWord = this.GetEntry("SettingsPanel", "TogglingWord");
			this.SettingsPanel.FileDockIconAssociations = this.GetEntry("SettingsPanel", "FileDockIconAssociations");
			this.SettingsPanel.LanguageWord = this.GetEntry("SettingsPanel", "LanguageWord");
			this.SettingsPanel.HelpWord = this.GetEntry("SettingsPanel", "HelpWord");
			this.SettingsPanel.CircleDockVersionWord = this.GetEntry("SettingsPanel", "CircleDockVersionWord");
			this.SettingsPanel.EnableDockRotation = this.GetEntry("SettingsPanel", "EnableDockRotation");
			this.SettingsPanel.HotKeySelectorToggleDock = this.GetEntry("SettingsPanel", "HotKeySelectorToggleDock");
			this.SettingsPanel.CtrlWordAbbreviation = this.GetEntry("SettingsPanel", "CtrlWordAbbreviation");
			this.SettingsPanel.AltWordAbbreviation = this.GetEntry("SettingsPanel", "AltWordAbbreviation");
			this.SettingsPanel.ShiftWordAbbreviation = this.GetEntry("SettingsPanel", "ShiftWordAbbreviation");
			this.SettingsPanel.WindowsKeyWordAbbreviation = this.GetEntry("SettingsPanel", "WindowsKeyWordAbbreviation");
			this.SettingsPanel.ValidHotkeyCombination = this.GetEntry("SettingsPanel", "ValidHotkeyCombination");
			this.SettingsPanel.InvalidHotKeyCombination = this.GetEntry("SettingsPanel", "InvalidHotKeyCombination");
			this.SettingsPanel.lockDockAtCurrentPosition = this.GetEntry("SettingsPanel", "lockDockAtCurrentPosition");
			this.SettingsPanel.CentreAroundCursorWhenShown = this.GetEntry("SettingsPanel", "CentreAroundCursorWhenShown");
			this.SettingsPanel.ConfigurationDescriptionLabel = this.GetEntry("SettingsPanel", "ConfigurationDescriptionLabel");
			this.SettingsPanel.KeepDockAboveAllOtherWindows = this.GetEntry("SettingsPanel", "KeepDockAboveAllOtherWindows");
			this.SettingsPanel.ClickSensitivity = this.GetEntry("SettingsPanel", "ClickSensitivity");
			this.SettingsPanel.Sensitive = this.GetEntry("SettingsPanel", "Sensitive");
			this.SettingsPanel.NotSensitive = this.GetEntry("SettingsPanel", "NotSensitive");
			this.SettingsPanel.EnablePortabilityMode = this.GetEntry("SettingsPanel", "EnablePortabilityMode");
			this.SettingsPanel.UseMemorySaver = this.GetEntry("SettingsPanel", "UseMemorySaver");
			this.SettingsPanel.useSameRotationValueAllLevels = this.GetEntry("SettingsPanel", "useSameRotationValueAllLevels");
			this.SettingsPanel.currentRotationValue = this.GetEntry("SettingsPanel", "currentRotationValue");
			this.SettingsPanel.Background = this.GetEntry("SettingsPanel", "Background");
			this.SettingsPanel.BackgroundImage = this.GetEntry("SettingsPanel", "BackgroundImage");
			this.SettingsPanel.NormalOpacity = this.GetEntry("SettingsPanel", "NormalOpacity");
			this.SettingsPanel.NormalSize = this.GetEntry("SettingsPanel", "NormalSize");
			this.SettingsPanel.ConstantNumberOfItemsPerCircle = this.GetEntry("SettingsPanel", "ConstantNumberOfItemsPerCircle");
			this.SettingsPanel.maximumNumberOfItemsPerCircle = this.GetEntry("SettingsPanel", "maximumNumberOfItemsPerCircle");
			this.SettingsPanel.NumberOfIconsPerCircle = this.GetEntry("SettingsPanel", "NumberOfIconsPerCircle");
			this.SettingsPanel.MinimumRadius = this.GetEntry("SettingsPanel", "MinimumRadius");
			this.SettingsPanel.SeparationBetweenCircles = this.GetEntry("SettingsPanel", "SeparationBetweenCircles");
			this.SettingsPanel.FormatWord = this.GetEntry("SettingsPanel", "FormatWord");
			this.SettingsPanel.CircleWord = this.GetEntry("SettingsPanel", "CircleWord");
			this.SettingsPanel.lineWord = this.GetEntry("SettingsPanel", "lineWord");
			this.SettingsPanel.spiralWord = this.GetEntry("SettingsPanel", "spiralWord");
			this.SettingsPanel.rateOfIncrease = this.GetEntry("SettingsPanel", "rateOfIncrease");
			this.SettingsPanel.defaultWord = this.GetEntry("SettingsPanel", "defaultWord");
			this.SettingsPanel.separationWord = this.GetEntry("SettingsPanel", "separationWord");
			this.SettingsPanel.CentreButton = this.GetEntry("SettingsPanel", "CentreButton");
			this.SettingsPanel.DefaultCentreButton = this.GetEntry("SettingsPanel", "DefaultCentreButton");
			this.SettingsPanel.OtherSettings = this.GetEntry("SettingsPanel", "OtherSettings");
			this.SettingsPanel.ShowStartMenuWhenClicked = this.GetEntry("SettingsPanel", "ShowStartMenuWhenClicked");
			this.SettingsPanel.StartMenuResidueWarning = this.GetEntry("SettingsPanel", "StartMenuResidueWarning");
			this.SettingsPanel.DockItems = this.GetEntry("SettingsPanel", "DockItems");
			this.SettingsPanel.RightClickMenu = this.GetEntry("SettingsPanel", "RightClickMenu");
			this.SettingsPanel.ShowWindowsFileFolderMenus = this.GetEntry("SettingsPanel", "ShowWindowsFileFolderMenus");
			this.SettingsPanel.HideDock = this.GetEntry("SettingsPanel", "HideDock");
			this.SettingsPanel.HideDockAfterFileExecution = this.GetEntry("SettingsPanel", "HideDockAfterFileExecution");
			this.SettingsPanel.FontWord = this.GetEntry("SettingsPanel", "FontWord");
			this.SettingsPanel.ChangeFont = this.GetEntry("SettingsPanel", "ChangeFont");
			this.SettingsPanel.ChangeColor = this.GetEntry("SettingsPanel", "ChangeColor");
			this.SettingsPanel.ShadowWord = this.GetEntry("SettingsPanel", "ShadowWord");
			this.SettingsPanel.ShadowSize = this.GetEntry("SettingsPanel", "ShadowSize");
			this.SettingsPanel.ShadowDarknessFactor = this.GetEntry("SettingsPanel", "ShadowDarknessFactor");
			this.SettingsPanel.ShowLabels = this.GetEntry("SettingsPanel", "ShowLabels");
			this.SettingsPanel.ShowLabelsOnMouseoverOnly = this.GetEntry("SettingsPanel", "ShowLabelsOnMouseoverOnly");
			this.SettingsPanel.AnimationWord = this.GetEntry("SettingsPanel", "AnimationWord");
			this.SettingsPanel.GeneralFrameRate = this.GetEntry("SettingsPanel", "GeneralFrameRate");
			this.SettingsPanel.RotationAnimationDuration = this.GetEntry("SettingsPanel", "RotationAnimationDuration");
			this.SettingsPanel.FadeInFadeOutDuration = this.GetEntry("SettingsPanel", "FadeInFadeOutDuration");
			this.SettingsPanel.UsePoofAnimationWhenDeleting = this.GetEntry("SettingsPanel", "UsePoofAnimationWhenDeleting");
			this.SettingsPanel.AboutWord = this.GetEntry("SettingsPanel", "AboutWord");
			this.SettingsPanel.ThePremiereCircularDockForWindows = this.GetEntry("SettingsPanel", "ThePremiereCircularDockForWindows");
			this.SettingsPanel.WebsiteWord = this.GetEntry("SettingsPanel", "WebsiteWord");
			this.SettingsPanel.VersionInformation = this.GetEntry("SettingsPanel", "VersionInformation");
			this.SettingsPanel.OfficialHomepage = this.GetEntry("SettingsPanel", "OfficialHomepage");
			this.SettingsPanel.SupportWord = this.GetEntry("SettingsPanel", "SupportWord");
			this.SettingsPanel.OfficalWebForum = this.GetEntry("SettingsPanel", "OfficialWebForum");
			this.SettingsPanel.OfficialWebHelpFAQ = this.GetEntry("SettingsPanel", "OfficialWebHelpFAQ");
			this.SettingsPanel.LanguageFileLocation = this.GetEntry("SettingsPanel", "LanguageFileLocation");
			this.SettingsPanel.LanguageName = this.GetEntry("SettingsPanel", "LanguageName");
			this.SettingsPanel.LanguageFileAuthor = this.GetEntry("SettingsPanel", "LanguageFileAuthor");
			this.SettingsPanel.LanguageFileVersion = this.GetEntry("SettingsPanel", "LanguageFileVersion");
			this.SettingsPanel.LanguageFileOriginallyIntendedFor = this.GetEntry("SettingsPanel", "LanguageFileOriginallyIntendedFor");
			this.SettingsPanel.LanguageFileProgramRestartRequired = this.GetEntry("SettingsPanel", "LanguageFileProgramRestartRequired");
			this.SettingsPanel.LanguageFileValidCurrent = this.GetEntry("SettingsPanel", "LanguageFileValidCurrent");
			this.SettingsPanel.LanguageFileInvalidOutofDate = this.GetEntry("SettingsPanel", "LanguageFileInvalidOutofDate");
			this.SettingsPanel.FileIconAssocationsDescription = this.GetEntry("SettingsPanel", "FileIconAssocationsDescription");
			this.SettingsPanel.FileNameIconAssociations = this.GetEntry("SettingsPanel", "FileNameIconAssociations");
			this.SettingsPanel.FolderNameIconAssociations = this.GetEntry("SettingsPanel", "FolderNameIconAssociations");
			this.SettingsPanel.FileExtensionIconAssociations = this.GetEntry("SettingsPanel", "FileExtensionIconAssociations");
			this.SettingsPanel.DockFolderIconAssociation = this.GetEntry("SettingsPanel", "DockFolderIconAssociation");
			this.SettingsPanel.fileName = this.GetEntry("SettingsPanel", "fileName");
			this.SettingsPanel.folderName = this.GetEntry("SettingsPanel", "folderName");
			this.SettingsPanel.extensionName = this.GetEntry("SettingsPanel", "extensionName");
			this.SettingsPanel.associatedDockIcon = this.GetEntry("SettingsPanel", "associatedDockIcon");
			this.SettingsPanel.browse = this.GetEntry("SettingsPanel", "browse");
			this.SettingsPanel.startsWith = this.GetEntry("SettingsPanel", "startsWith");
			this.SettingsPanel.endsWith = this.GetEntry("SettingsPanel", "endsWith");
			this.SettingsPanel.exactMatch = this.GetEntry("SettingsPanel", "exactMatch");
			this.SettingsPanel.contains = this.GetEntry("SettingsPanel", "contains");
			this.SettingsPanel.sample = this.GetEntry("SettingsPanel", "sample");
			this.SettingsPanel.ToggleVisibilityHotKey = this.GetEntry("SettingsPanel", "ToggleVisibilityHotKey");
			this.SettingsPanel.ToggleVisibilityMouseButton = this.GetEntry("SettingsPanel", "ToggleVisibilityMouseButton");
			this.SettingsPanel.ShowDockWhenIMoveMyMouseTo = this.GetEntry("SettingsPanel", "ShowDockWhenIMoveMyMouseTo");
			this.SettingsPanel.ScreenLeftEdge = this.GetEntry("SettingsPanel", "ScreenLeftEdge");
			this.SettingsPanel.ScreenRightEdge = this.GetEntry("SettingsPanel", "ScreenRightEdge");
			this.SettingsPanel.ScreenTopEdge = this.GetEntry("SettingsPanel", "ScreenTopEdge");
			this.SettingsPanel.ScreenBottomEdge = this.GetEntry("SettingsPanel", "ScreenBottomEdge");
			this.SettingsPanel.EdgeWidthHeight = this.GetEntry("SettingsPanel", "EdgeWidthHeight");
			this.SettingsPanel.dwellTime = this.GetEntry("SettingsPanel", "dwellTime");
		}

		private void LoadErrorMessages()
		{
			this.ErrorMessages.MissingInvalid = this.GetEntry("ErrorMessages", "MissingInvalid");
			this.ErrorMessages.FilePathMissingInvalid = this.GetEntry("ErrorMessages", "FilePathMissingInvalid");
		}

		private void LoadDockItemProperties()
		{
			this.DockItemProperties.Arguments = this.GetEntry("DockItemProperties", "Arguments");
			this.DockItemProperties.ItemSettings = this.GetEntry("DockItemProperties", "ItemSettings");
			this.DockItemProperties.File = this.GetEntry("DockItemProperties", "File");
			this.DockItemProperties.Folder = this.GetEntry("DockItemProperties", "Folder");
			this.DockItemProperties.IconImage = this.GetEntry("DockItemProperties", "IconImage");
			this.DockItemProperties.Maximized = this.GetEntry("DockItemProperties", "Maximized");
			this.DockItemProperties.Minimized = this.GetEntry("DockItemProperties", "Minimized");
			this.DockItemProperties.Name = this.GetEntry("DockItemProperties", "Name");
			this.DockItemProperties.Normal = this.GetEntry("DockItemProperties", "Normal");
			this.DockItemProperties.Run = this.GetEntry("DockItemProperties", "Run");
			this.DockItemProperties.StartIn = this.GetEntry("DockItemProperties", "StartIn");
			this.DockItemProperties.Target = this.GetEntry("DockItemProperties", "Target");
			this.DockItemProperties.Close = this.GetEntry("DockItemProperties", "Close");
		}
	}
}
