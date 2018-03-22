using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Threading;

using DockItemsInformation;
using AMS.Profile;
using BaseDockObjects;
using PerPixelAlphaForms;

using LanguageLoader;
using SettingsLoader;
using DockItemSettingsLoader;
using Pinvoke;

using Orbit.Utilities;
using Win32.Shell32;
using FileOps;


namespace CircleDock
{
    public partial class MainForm : PerPixelAlphaForms.InvisiblePerPixelAlphaForm 
    //public partial class MainForm : Form
    {
        #region Variables

        private BaseDockObjects.CentreObject CentreObject;
        //private DockItemsInformation.ObjectData CentreObjectData;

        private BaseDockObjects.BackgroundObject BackgroundObject;
        //private DockItemsInformation.ObjectData BackgroundObjectData;

        private static ArrayList MainDockObjects;

        public static LanguageLoader.LanguageLoader LanguageWords;
        public static SettingsLoader.SettingsLoader DockSettings;
        public static DockItemSettingsLoader.DockItemSettingsLoader DockItemSettings;

        private String CurrentLevelShown;
        private Point[] CalculatedPoints;
        private Size[] NewDockItemSizes;

        #endregion

        #region Constructor and Initialization

        public MainForm()
        {
            DockSettings = new SettingsLoader.SettingsLoader(Application.StartupPath + "\\System\\Settings\\Config.ini");
            LanguageWords = new LanguageLoader.LanguageLoader(Application.StartupPath + DockSettings.Language.path);
            DockItemSettings = new DockItemSettingsLoader.DockItemSettingsLoader(Application.StartupPath + "\\System\\Settings\\DockItemData.ini");

            InitializeComponent();
            MainDockObjects = new ArrayList();

            InitializeBackgroundObject();
            InitializeCentreObject();
            ShowLevel("0-");
        }

        public void InitializeBackgroundObject()
        {
            Size tempSize;

            if (DockSettings.Shape.Shape == "Ellipse")
            {
                tempSize = new Size((int)((float)DockSettings.EllipseParams.MinHeight * DockSettings.EllipseParams.AspectRatio), 
                    DockSettings.EllipseParams.MinHeight);
            }
            else //(DockSettings.Shape.Shape == "Circle")
            {
                tempSize = new Size(DockSettings.CircleParams.MinRadius*2, DockSettings.CircleParams.MinRadius*2);
            }
            BackgroundObject = new BaseDockObjects.BackgroundObject(this, LanguageWords, DockSettings, "Background", tempSize);

            // MainForm handles all the location and sizing of the objects
            BackgroundObject.Location = new Point(SystemInformation.VirtualScreen.Right / 2 - tempSize.Width / 2,
                SystemInformation.VirtualScreen.Bottom / 2 - tempSize.Height / 2);
            BackgroundObject.DrawBitmapManaged(tempSize.Width, tempSize.Height, false, 0, 0, false, 0, 0, 0, 0, false, 0);

            Bitmap DrawBackground = new Bitmap(tempSize.Width, tempSize.Height);
            using (Graphics gr = Graphics.FromImage(DrawBackground))
            {
                gr.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
                gr.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.HighQuality;
                gr.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighQuality;
                gr.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;

                //gr.DrawImage(Bitmap, new Rectangle(0, 0, scaleWidth, scaleHeight), new Rectangle(0, 0, Bitmap.Width, Bitmap.Height), GraphicsUnit.Pixel);
                Bitmap textureimage = new Bitmap(Application.StartupPath + @"\System\Background\Skins\Brushed\Brushed.png");
                Brush texturebrush = new TextureBrush(textureimage);
                Brush texturepenbrush = Brushes.LightGray;

                float penWidth = 5f;
                Pen texturepen = new Pen(texturepenbrush, penWidth);

                gr.DrawEllipse(texturepen, penWidth, penWidth, (float)tempSize.Width - penWidth*2, (float)tempSize.Height - penWidth*2);
                //gr.FillEllipse(texturebrush, 0, 0, tempSize.Width, tempSize.Height);
                BackgroundObject.SetBitmapManaged(ref DrawBackground);
            }
            BackgroundObject.DrawBitmapManaged(tempSize.Width, tempSize.Height, false, 0, 0, false, 0, 0, 0, 0, false, 0);

            BackgroundObject.Show();
            BackgroundObject.BringToFront();
        }

        public void InitializeCentreObject()
        {
            Size tempSize = new Size(DockSettings.CentreImage.Width, DockSettings.CentreImage.Height);

            CentreObject = new BaseDockObjects.CentreObject(this, LanguageWords, DockSettings, "CentreImage", tempSize);
            //CentreObject.TopLevel = false;
            //CentreObject.Parent = BackgroundObject;
            CentreObject.Owner = BackgroundObject;

            // MainForm handles all the location and sizing of the objects
            //Size tempBackgroundObjectSize = BackgroundObject.ObjectSize;
            //CentreObject.Location = new Point(BackgroundObject.Location.X + tempBackgroundObjectSize.Width / 2 - tempSize.Width / 2,
            //  BackgroundObject.Location.Y + tempBackgroundObjectSize.Height / 2 - tempSize.Height / 2);
            CentreObject.Location = new Point(SystemInformation.VirtualScreen.Right / 2 - tempSize.Width / 2,
              SystemInformation.VirtualScreen.Bottom / 2 - tempSize.Height / 2);
            CentreObject.DrawBitmapManaged(tempSize.Width, tempSize.Height, false, 0, 0, false, 0, 0, 0, 0, false, 0);

            CentreObject.Show();
            CentreObject.BringToFront();
        }

        public void CloseLevel(String Level)
        {
            for (int i = 0; i < MainDockObjects.Count; i++)
            {
                BaseDockObjects.DockItemObject tempDockItem = (BaseDockObjects.DockItemObject)MainDockObjects[i];
                if (tempDockItem.DockItemSectionName.StartsWith(Level))
                {
                    tempDockItem.Close();
                    MainDockObjects.RemoveAt(i);
                    i--;
                }
            }
        }

        public void ShowLevelUp()
        {
            if (CurrentLevelShown != null && CurrentLevelShown != "0-" && CurrentLevelShown.Length > 0)
            {
                int LastDash = -1;
                String NewLevel = CurrentLevelShown;
                for (int i = CurrentLevelShown.Length - 2; i >= 0; i--)
                {
                    if (CurrentLevelShown[i] == '-')
                    {
                        LastDash = i;
                        break;
                    }
                }

                if (LastDash > 0)
                {
                    NewLevel = CurrentLevelShown.Substring(0, LastDash + 1);
                }

                //Console.WriteLine(CurrentLevelShown + "   "+ NewLevel);
                ShowLevel(NewLevel);
            }
        }
        
        public void ShowLevel(String Level)
        {
            if (CurrentLevelShown != null)
            {
                CloseLevel(CurrentLevelShown);
            }
            CurrentLevelShown = Level;
            ChangeCentreImage(Level);

            String[] AllSectionNames = DockItemSettings.GetSectionNames();
            ArrayList NewDockItems = new ArrayList();

            for (int i = 0; i < AllSectionNames.Length; i++)
            {
                if (AllSectionNames[i].StartsWith(Level) && AllSectionNames[i].Substring(Level.Length, AllSectionNames[i].Length - Level.Length).Contains("-") == false)
                {
                    //Console.WriteLine("name: " + AllSectionNames[i]);
                    BaseDockObjects.DockItemObject NewDockItem = CreateDockItem(AllSectionNames[i], null);
                    NewDockItems.Add(NewDockItem);
                }
            }

            NewDockItemSizes = new Size[NewDockItems.Count];

            for (int i = 0; i < NewDockItems.Count; i++)
            {
                BaseDockObjects.DockItemObject tempDockItem = (BaseDockObjects.DockItemObject)NewDockItems[i];
                NewDockItemSizes[i] = tempDockItem.ObjectSize;
            }

            //Size tempBackgroundObjectSize = BackgroundObject.ObjectSize;
            //tempBackgroundObjectSize = new Size(NewDockItems.Count * DockSettings.DockItemSize.DefaultWidth / 2, NewDockItems.Count * DockSettings.DockItemSize.DefaultWidth / 2);
            //BackgroundObject.Hide();
            //BackgroundObject.SuspendLayout();
            //BackgroundObject.Location = new Point(SystemInformation.VirtualScreen.Right / 2 - tempBackgroundObjectSize.Width / 2,
            //    SystemInformation.VirtualScreen.Bottom / 2 - tempBackgroundObjectSize.Height / 2);
            //BackgroundObject.ResumeLayout();

            //BackgroundObject.DrawBitmapManaged(tempBackgroundObjectSize.Width, tempBackgroundObjectSize.Height, false, 0, 0, false, 0, 0, 0, 0);
            //BackgroundObject.Show();

            CalculatedPoints = CalculateDockItemPositions(NewDockItemSizes);

            for (int i = 0; i < NewDockItems.Count; i++)
            {
                BaseDockObjects.DockItemObject tempDockItem = (BaseDockObjects.DockItemObject)NewDockItems[i];
                tempDockItem.DrawBitmapManaged(NewDockItemSizes[i].Width, NewDockItemSizes[i].Height, true, CalculatedPoints[i].X, CalculatedPoints[i].Y, false, 0, 0, 0, 0, false, 0);
            }
        }

        public void ChangeCentreImage(String Level)
        {
            if (Level == null || Level.Length == 0)
                return;

            Bitmap NewBitmap;
            if (Level == "0-")
            {
                try
                {
                    NewBitmap = new Bitmap(Application.StartupPath + DockSettings.CentreImage.Path);
                }
                catch (Exception)
                {
                    NewBitmap = new Bitmap(ImageResources.CircleDockIconCentreImage);
                }
            }
            else
            {
                String ParsedLevel = Level.Substring(0, Level.Length - 1);
                FileOps.FileOps FileOperations;

                if (ParsedLevel != null && ParsedLevel != "")
                {
                    //Console.WriteLine(ParsedLevel + "  " + @DockItemSettings.GetEntry(ParsedLevel, "Args"));
                    String ImagePath = @DockItemSettings.GetEntry(ParsedLevel, "ImagePath");

                    try
                    {
                        if (ImagePath != null && ImagePath.Length > 0)
                        {
                            NewBitmap = new Bitmap(Application.StartupPath + @ImagePath);
                        }
                        else
                        {
                            FileOperations = new FileOps.FileOps(@DockItemSettings.GetEntry(ParsedLevel, "Args"));
                            NewBitmap = new Bitmap(FileOperations.RepresentativeImage);
                        }
                    }
                    catch (Exception)
                    {
                        NewBitmap = new Bitmap(ImageResources.CircleDockIconCentreImage);
                    }
                }
                else
                {
                    NewBitmap = new Bitmap(ImageResources.CircleDockIconCentreImage);
                }
            }
            CentreObject.SetBitmapManaged(ref NewBitmap);
            Size ObjectSize = CentreObject.ObjectSize; 
            CentreObject.DrawBitmapManaged(ObjectSize.Width, ObjectSize.Height, false, 0, 0, false, 0, 0, 0, 0, false, 0);
        }

        public void SetDockItemPositions(Point[] DesiredPositions)
        {
            if (DesiredPositions == null)
                return;

            for (int i = 0; i < DesiredPositions.Length; i++)
            {
                BaseDockObjects.DockItemObject tempDockItem = (BaseDockObjects.DockItemObject)MainDockObjects[i];
                tempDockItem.Location = new Point(DesiredPositions[i].X, DesiredPositions[i].Y);
            }  
        }

        public BaseDockObjects.DockItemObject CreateDockItem(String SectionName, String Path)
        {
            Size tempSize = new Size(DockSettings.DockItemSize.DefaultWidth, DockSettings.DockItemSize.DefaultHeight);
            BaseDockObjects.DockItemObject NewDockItem = new BaseDockObjects.DockItemObject(this, LanguageWords, DockSettings, DockItemSettings, SectionName, tempSize, Path);
            NewDockItem.Owner = CentreObject;
            
            //Size tempBackgroundObjectSize = BackgroundObject.ObjectSize;
            //NewDockItem.Location = new Point(BackgroundObject.Location.X + tempBackgroundObjectSize.Width / 2 - tempSize.Width / 2,
            //  BackgroundObject.Location.Y + tempBackgroundObjectSize.Height / 2 - tempSize.Height / 2);
            //NewDockItem.DrawBitmapManaged(tempSize.Width, tempSize.Height, false, 0, 0, 0, 0);
            
            MainDockObjects.Add(NewDockItem);
            return NewDockItem;
        }

        public BaseDockObjects.DockItemObject ShowDockItem(String SectionName, String Path)
        {
            Size tempSize = new Size(DockSettings.DockItemSize.DefaultWidth, DockSettings.DockItemSize.DefaultHeight);
            BaseDockObjects.DockItemObject NewDockItem = new BaseDockObjects.DockItemObject(this, LanguageWords, DockSettings, DockItemSettings, SectionName, tempSize, Path);
            NewDockItem.Owner = BackgroundObject;

            Size tempBackgroundObjectSize = BackgroundObject.ObjectSize;
            NewDockItem.Location = new Point(BackgroundObject.Location.X + tempBackgroundObjectSize.Width / 2 - tempSize.Width / 2,
              BackgroundObject.Location.Y + tempBackgroundObjectSize.Height / 2 - tempSize.Height / 2);
            NewDockItem.DrawBitmapManaged(tempSize.Width, tempSize.Height, false, 0, 0, false, 0, 0, 0, 0, false, 0);

            NewDockItem.Show();
            NewDockItem.BringToFront();
            MainDockObjects.Add(NewDockItem);

            return NewDockItem;
        }

        /// <summary> 
        /// Returns an array of positions at which the dock items should be drawn to fit on the background shape.
        /// </summary>
        /// <param name="DockItemSizes">Size of each of the dock items.</param>
        public Point[] CalculateDockItemPositions(Size[] DockItemSizes)
        {
            Point[] CalculatedPoints = new Point[DockItemSizes.Length];
            if (DockSettings.Shape.Shape == "Ellipse")
            {
                // Need to write
                return null;
            }
            else //(DockSettings.Shape.Shape == "Circle")
            {
                if (DockSettings.CircleParams.Format == "Constant Number of Items Per Circle")
                {
                    Size tempCentreObjectSize = CentreObject.ObjectSize;
                    double RadianDivisons;

                    if (DockItemSizes.Length < DockSettings.CircleParams.ConstNumItemsPerCircle)
                        RadianDivisons = 2.0 * Math.PI / DockItemSizes.Length;
                    else
                    {
                        RadianDivisons = 2.0 * Math.PI / DockSettings.CircleParams.ConstNumItemsPerCircle;
                    }
                    int CentreObjectRadius;

                    if (tempCentreObjectSize.Height > tempCentreObjectSize.Width)
                        CentreObjectRadius = tempCentreObjectSize.Height / 2;
                    else
                        CentreObjectRadius = tempCentreObjectSize.Width / 2;

                    int IncreaseRadius = 0;
                    int tempCounter = 0;
                    for (int i = 0; i < DockItemSizes.Length; i++)
                    {
                        CalculatedPoints[i] = new Point(CentreObject.Location.X + CentreObjectRadius + (int)((double)(DockSettings.CircleParams.MinRadius + IncreaseRadius - DockItemSizes[i].Width / 2) * Math.Cos(i * RadianDivisons + Math.PI)) - DockItemSizes[i].Width / 2,
                            CentreObject.Location.Y + CentreObjectRadius + (int)((double)(DockSettings.CircleParams.MinRadius + IncreaseRadius - DockItemSizes[i].Height / 2) * Math.Sin(i * RadianDivisons + Math.PI)) - DockItemSizes[i].Height / 2);
                        tempCounter++;
                        if (tempCounter >= DockSettings.CircleParams.ConstNumItemsPerCircle)
                        {
                            tempCounter = 0;
                            IncreaseRadius = IncreaseRadius + DockSettings.CircleParams.CircleSeparation;
                        }
                    }

                    return CalculatedPoints;
                }
                else //(DockSettings.CircleParams.Format == "Maximum Items Distributed") // Not coded yet, just copied from above.
                {
                    Size tempCentreObjectSize = CentreObject.ObjectSize;
                    double RadianDivisons;

                    if (DockItemSizes.Length < DockSettings.CircleParams.ConstNumItemsPerCircle)
                        RadianDivisons = 2.0 * Math.PI / DockItemSizes.Length;
                    else
                    {
                        RadianDivisons = 2.0 * Math.PI / DockSettings.CircleParams.ConstNumItemsPerCircle;
                    }
                    int CentreObjectRadius;

                    if (tempCentreObjectSize.Height > tempCentreObjectSize.Width)
                        CentreObjectRadius = tempCentreObjectSize.Height / 2;
                    else
                        CentreObjectRadius = tempCentreObjectSize.Width / 2;

                    int IncreaseRadius = 0;
                    int tempCounter = 0;
                    for (int i = 0; i < DockItemSizes.Length; i++)
                    {
                        CalculatedPoints[i] = new Point(CentreObject.Location.X + CentreObjectRadius + (int)((double)(DockSettings.CircleParams.MinRadius + IncreaseRadius - DockItemSizes[i].Width / 2) * Math.Cos(i * RadianDivisons + Math.PI)) - DockItemSizes[i].Width / 2,
                            CentreObject.Location.Y + CentreObjectRadius + (int)((double)(DockSettings.CircleParams.MinRadius + IncreaseRadius - DockItemSizes[i].Height / 2) * Math.Sin(i * RadianDivisons + Math.PI)) - DockItemSizes[i].Height / 2);
                        tempCounter++;
                        if (tempCounter >= DockSettings.CircleParams.ConstNumItemsPerCircle)
                        {
                            tempCounter = 0;
                            IncreaseRadius = IncreaseRadius + DockSettings.CircleParams.CircleSeparation;
                        }
                    }

                    return CalculatedPoints;
                }
            }
        }

        #endregion

        public void RemoveDockItem(BaseDockObjects.DockItemObject ItemToRemove)
        {
            String ItemToRemoveSectionHeader = @ItemToRemove.DockItemSectionName + @"-";
            CloseLevel(@ItemToRemoveSectionHeader);
            MainDockObjects.Remove(ItemToRemove);
            ItemToRemove.Close();

            String[] AllSectionNames = DockItemSettings.GetSectionNames();

            for (int i = 0; i < AllSectionNames.Length; i++)
            {
                if (AllSectionNames[i].StartsWith(ItemToRemoveSectionHeader) && 
                    AllSectionNames[i].Substring(ItemToRemoveSectionHeader.Length, AllSectionNames[i].Length - ItemToRemoveSectionHeader.Length).Contains("-") == false)
                {
                    DockItemSettings.RemoveSection(AllSectionNames[i]);
                }
            }

            DockItemSettings.RemoveSection(ItemToRemoveSectionHeader.Substring(0, ItemToRemoveSectionHeader.Length - 1));

            ShowLevel(CurrentLevelShown);
        }

        public void AddDockItem(String Action, String Args, String Description, String ImagePath, String Name)
        {
            String[] AllSectionHeaders = DockItemSettings.GetSectionNames();
            int UnusedNumber = 0;
            ArrayList UsedNumbers = new ArrayList();
            
            foreach (String tempHeader in AllSectionHeaders)
            {
                if (tempHeader.StartsWith(CurrentLevelShown))
                {
                    String tempHeaderSubString = tempHeader.Substring(CurrentLevelShown.Length, tempHeader.Length - CurrentLevelShown.Length);
                    int NextDashLocation = tempHeaderSubString.IndexOf('-');
                    if (NextDashLocation < 0)
                        NextDashLocation = tempHeaderSubString.Length;

                    //Console.WriteLine("current path: " + tempHeaderSubString);
                    //Console.WriteLine("next dash location: " + NextDashLocation);
                    int CurrentNumber = int.Parse(tempHeaderSubString.Substring(0, NextDashLocation));
                    UsedNumbers.Add(CurrentNumber);

                    //Console.WriteLine(tempHeaderSubString + "  currentnum: " + CurrentNumber);
                    //Console.WriteLine("");
                }
            }

            UsedNumbers.Sort();
            for (int i = 0; i < UsedNumbers.Count; i++)
            {
                if (UnusedNumber == (int)(UsedNumbers[i]))
                {
                    UnusedNumber++;
                    i = 0;
                }
            }

            String NewSectionHeader = CurrentLevelShown + UnusedNumber.ToString();
            //Console.WriteLine(NewSectionHeader);
            DockItemSettings.SetEntry(NewSectionHeader, "Action", Action);
            DockItemSettings.SetEntry(NewSectionHeader, "Args", Args);
            DockItemSettings.SetEntry(NewSectionHeader, "Description", Description);
            DockItemSettings.SetEntry(NewSectionHeader, "ImagePath", ImagePath);
            DockItemSettings.SetEntry(NewSectionHeader, "Name", Name);
            DockItemSettings.SetEntry(NewSectionHeader, "CircleRotation", "0");
            DockItemSettings.SetEntry(NewSectionHeader, "EllipseRotation", "0");
            DockItemSettings.SetEntry(NewSectionHeader, "SpiralRotation", "0");

            ShowLevel(CurrentLevelShown);
        }

        private void quitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary> 
        /// The child objects can request program actions to be taken.
        /// </summary>
        public void ChildRequestAction(String ActionCommand)
        {
            switch (ActionCommand)
            {
                case "QUIT":
                    this.Close();
                    break;
            }               
        }

        private void MainForm_Shown(object sender, EventArgs e)
        {
            this.Hide();
        }

        #region Movement Handlers

        public void ChildMoved(BaseDockObjects.DockItemObject ChildObject)
        {
            
        }

        public void ChildMoved(BaseDockObjects.BackgroundObject ChildObject)
        {

        }

        public void ChildMoved(BaseDockObjects.CentreObject ChildObject)
        {
            CalculatedPoints = CalculateDockItemPositions(NewDockItemSizes);
            SetDockItemPositions(CalculatedPoints);
            Application.DoEvents();

            Size BackgroundSize = BackgroundObject.ObjectSize;
            Size CentreObjectSize = CentreObject.ObjectSize;

            BackgroundObject.Location = new Point(CentreObject.Location.X - (BackgroundSize.Width/2 - CentreObjectSize.Width/2),
                CentreObject.Location.Y - (BackgroundSize.Height/2 - CentreObjectSize.Height/2));
        }

        #endregion
    }
}
