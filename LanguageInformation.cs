using System;
using System.Collections;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Drawing;
using System.Text;

namespace LanguageInformation
{
    public struct LanguageFile
    {
        public String CircleDockVersion;
        public String LanguageFileVersion;
        public String LanguageName;
    }

    public struct General
    {
        public String CircleDockName;
        public String GeneralWebsite;
        public String HelpWebsite;
        public String AuthorWord;
    }

    public struct MainContextMenu
    {
        public String WebsiteWord;
        public String SettingsWord;
        public String HideWord;
        public String QuitWord;
        public String RemoveWord;
        public String AddWord;
        public String DockFolder;
        public String ChangeIcon;
    }

    public struct SettingsPanel
    {
        public String Name;
        public String SettingsPanelWord;
    }
}
