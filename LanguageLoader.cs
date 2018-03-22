using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using AMS.Profile;
using LanguageInformation;

namespace LanguageLoader
{
    public class LanguageLoader
    {
        #region Variables

        private Profile LanguageINI;
        public LanguageInformation.General General;
        public LanguageInformation.LanguageFile LanguageFile;
        public LanguageInformation.MainContextMenu MainContextMenu;
        public LanguageInformation.SettingsPanel SettingsPanel;

        #endregion

        #region Constructor & Private Methods

        public LanguageLoader(String FilePath)
        {           
            LanguageINI = new Ini(FilePath);
            InitializeLanguageInfoStructs();

            LoadGeneral();
            LoadLanguageFile();
            LoadMainContextMenu();
            LoadSettingsPanel();
        }

        private void InitializeLanguageInfoStructs()
        {
            General = new LanguageInformation.General();
            LanguageFile = new LanguageInformation.LanguageFile();
            MainContextMenu = new LanguageInformation.MainContextMenu();
            SettingsPanel = new LanguageInformation.SettingsPanel();
        }

        private String GetEntry(String Section, String EntryName)
        {
            if (LanguageINI.HasEntry(Section, EntryName))
            {
                return (String)LanguageINI.GetValue(Section, EntryName);
            }
            else
            {
                return "*****";
            }
        }

        #endregion

        #region Load Each Section for LanguageInformation

        private void LoadGeneral()
        {
            General.AuthorWord = GetEntry("General", "AuthorWord");
            General.CircleDockName = GetEntry("General", "CircleDockName");
            General.GeneralWebsite = GetEntry("General", "GeneralWebsite");
            General.HelpWebsite = GetEntry("General", "HelpWebsite");
        }

        private void LoadLanguageFile()
        {
            LanguageFile.CircleDockVersion = GetEntry("LanguageFile", "CircleDockVersion");
            LanguageFile.LanguageName = GetEntry("LanguageFile", "LanguageName");
            LanguageFile.LanguageFileVersion = GetEntry("LanguageFile", "LanguageFileVersion");
        }

        private void LoadMainContextMenu()
        {
            MainContextMenu.HideWord = GetEntry("MainContextMenu", "HideWord");
            MainContextMenu.QuitWord = GetEntry("MainContextMenu", "QuitWord");
            MainContextMenu.SettingsWord = GetEntry("MainContextMenu", "SettingsWord");
            MainContextMenu.WebsiteWord = GetEntry("MainContextMenu", "WebsiteWord");
            MainContextMenu.RemoveWord = GetEntry("MainContextMenu", "RemoveWord");
            MainContextMenu.AddWord = GetEntry("MainContextMenu", "AddWord");
            MainContextMenu.DockFolder = GetEntry("MainContextMenu", "DockFolder");
            MainContextMenu.ChangeIcon = GetEntry("MainContextMenu", "ChangeIcon");
        }

        private void LoadSettingsPanel()
        {
            SettingsPanel.Name = GetEntry("SettingsPanel", "Name");
            SettingsPanel.SettingsPanelWord = GetEntry("SettingsPanel", "SettingsPanelWord");
        }

        #endregion
    }
}
