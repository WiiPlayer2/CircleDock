using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using AMS.Profile;
using DockItemsInformation;

namespace DockItemSettingsLoader
{
    public class DockItemSettingsLoader
    {
        #region Variables

        private Profile DockItemSettingsSettingsINI;

        #endregion

        #region Constructor & Private Methods

        public DockItemSettingsLoader(String FilePath)
        {
            if (!File.Exists(FilePath))
            {
                try
                {
                    File.Create(FilePath);
                }
                catch (Exception)
                {
                }
            }
            DockItemSettingsSettingsINI = new Ini(FilePath);
        }

        public String GetEntry(String Section, String EntryName)
        {
            if (DockItemSettingsSettingsINI.HasEntry(Section, EntryName))
            {
                return (String)DockItemSettingsSettingsINI.GetValue(Section, EntryName);
            }
            else
            {
                DockItemSettingsSettingsINI.SetValue(Section, EntryName, "1");
                return "1";
            }
        }

        public String[] GetSectionNames()
        {
            return DockItemSettingsSettingsINI.GetSectionNames();
        }

        public String[] GetEntryNames(String Section)
        {
            return DockItemSettingsSettingsINI.GetEntryNames(Section);
        }

        public void SetEntry(String Section, String EntryName, String Value)
        {
            DockItemSettingsSettingsINI.SetValue(Section, EntryName, Value);
        }

        public void RemoveEntry(String Section, String EntryName)
        {
            DockItemSettingsSettingsINI.RemoveEntry(Section, EntryName);
        }

        public void RemoveSection(String Section)
        {
            DockItemSettingsSettingsINI.RemoveSection(Section);
        }

        #endregion

    }
}
