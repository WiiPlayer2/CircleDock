using AMS.Profile;
using System;
using System.IO;
using System.Windows.Forms;

namespace DockItemSettingsLoader
{
	public class DockItemSettingsLoader
	{
		private Profile DockItemSettingsSettingsINI;

		public DockItemSettingsLoader(string FilePath)
		{
			if (!File.Exists(FilePath))
			{
				MessageBox.Show(FilePath + " is missing. Please replace the file. Circle Dock will now exit.", "Circle Dock");
				Application.Exit();
			}
			this.DockItemSettingsSettingsINI = new Ini(FilePath);
		}

		public string GetEntry(string Section, string EntryName)
		{
			return (string)this.DockItemSettingsSettingsINI.GetValue(Section, EntryName);
		}

		public string[] GetSectionNames()
		{
			return this.DockItemSettingsSettingsINI.GetSectionNames();
		}

		public string[] GetEntryNames(string Section)
		{
			return this.DockItemSettingsSettingsINI.GetEntryNames(Section);
		}

		public void SetEntry(string Section, string EntryName, string Value)
		{
			this.DockItemSettingsSettingsINI.SetValue(Section, EntryName, Value);
		}

		public void RemoveEntry(string Section, string EntryName)
		{
			this.DockItemSettingsSettingsINI.RemoveEntry(Section, EntryName);
		}

		public void RemoveSection(string Section)
		{
			this.DockItemSettingsSettingsINI.RemoveSection(Section);
		}
	}
}
