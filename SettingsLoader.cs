using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using AMS.Profile;
using SettingsInformation;

namespace SettingsLoader
{
    public class SettingsLoader
    {
        #region Variables

        private Profile SettingsINI;
        public SettingsInformation.Background Background;
        public SettingsInformation.CentreImage CentreImage;
        public SettingsInformation.CircleParams CircleParams;
        public SettingsInformation.DockItemSize DockItemSize;
        public SettingsInformation.EllipseParams EllipseParams;
        public SettingsInformation.Language Language;
        public SettingsInformation.ObjectShape Shape;
        public SettingsInformation.Folders Folders;

        #endregion

        #region Constructor & Private Methods

        public SettingsLoader(String FilePath)
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
            SettingsINI = new Ini(FilePath);
            InitializeSettingsInfoStructs();
            SettingsLoaderLoadData();
        }

        public void SettingsLoaderLoadData()
        {
            LoadBackground();
            LoadCentreImage();
            LoadCircleParams();
            LoadDockItemSize();
            LoadEllipseParams();
            LoadLanguage();
            LoadShape();
            LoadFolders();
        }

        private void InitializeSettingsInfoStructs()
        {
            Background = new SettingsInformation.Background();
            CentreImage = new SettingsInformation.CentreImage();
            CircleParams = new SettingsInformation.CircleParams();
            DockItemSize = new SettingsInformation.DockItemSize();
            EllipseParams = new SettingsInformation.EllipseParams();
            Language = new SettingsInformation.Language();
            Shape = new SettingsInformation.ObjectShape();
            Folders = new SettingsInformation.Folders();
        }

        private String GetEntry(String Section, String EntryName)
        {
            if (SettingsINI.HasEntry(Section, EntryName))
            {
                return (String)SettingsINI.GetValue(Section, EntryName);
            }
            else
            {
                SettingsINI.SetValue(Section, EntryName, "1");
                return "1";
            }
        }

        #endregion

        #region Load Each Section for LanguageInformation

        private void LoadBackground()
        {
            Background.Path = GetEntry("Background", "Path");
        }

        private void LoadCentreImage()
        {
            CentreImage.Path = GetEntry("CentreImage", "Path");
            CentreImage.Width = int.Parse(GetEntry("CentreImage", "Width"));
            CentreImage.Height = int.Parse(GetEntry("CentreImage", "Height"));
        }

        private void LoadCircleParams()
        {
            CircleParams.CircleSeparation = int.Parse(GetEntry("CircleParams", "CircleSeparation"));
            CircleParams.MinRadius = int.Parse(GetEntry("CircleParams", "MinRadius"));
            CircleParams.Format = GetEntry("CircleParams", "Format");
            CircleParams.ConstNumItemsPerCircle = int.Parse(GetEntry("CircleParams", "ConstNumItemsPerCircle"));
        }

        private void LoadDockItemSize()
        {
            DockItemSize.DefaultHeight = int.Parse(GetEntry("DockItemSize", "DefaultHeight"));
            DockItemSize.DefaultWidth = int.Parse(GetEntry("DockItemSize", "DefaultWidth"));
            DockItemSize.MaxHeight = int.Parse(GetEntry("DockItemSize", "MaxHeight"));
            DockItemSize.MaxWidth = int.Parse(GetEntry("DockItemSize", "MaxWidth"));
            DockItemSize.MinHeight = int.Parse(GetEntry("DockItemSize", "MinHeight"));
            DockItemSize.MinWidth = int.Parse(GetEntry("DockItemSize", "MinWidth"));
        }

        private void LoadEllipseParams()
        {
            EllipseParams.MinHeight = int.Parse(GetEntry("EllipseParams", "MinHeight"));
            EllipseParams.AspectRatio = float.Parse(GetEntry("EllipseParams", "AspectRatio"));
        }

        private void LoadLanguage()
        {
            Language.path = GetEntry("Language", "Path");
        }

        private void LoadShape()
        {
            Shape.Shape = GetEntry("Shape", "Shape");
        }

        private void LoadFolders()
        {
            Folders.DockFolderImagePath = GetEntry("Folders", "DockFolderImagePath");
        }

        #endregion
    }
}
