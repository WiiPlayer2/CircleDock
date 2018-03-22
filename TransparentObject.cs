using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using System.Drawing;
using System.Text;
using CircleDock;
using Constants;
using DockItemsInformation;
using PerPixelAlphaForms;
using LanguageLoader;
using SettingsLoader;
using DockItemSettingsLoader;

using Orbit.Utilities;
using Win32.Shell32;
using FileOps;

namespace BaseDockObjects
{
    /// <para>Our test form for this sample application.  The bitmap will be displayed in this window.</para>
    //public partial class TransparentObject : Form
    public partial class BackgroundObject : PerPixelAlphaForms.BackgroundPerPixelAlphaForm 
    {
        #region Windows Form Designer

        private ContextMenuStrip contextMenuStrip;
        private System.ComponentModel.IContainer components;
        private ToolStripMenuItem quitToolStripMenuItem;
        private ToolStripMenuItem addToolStripMenuItem;
        private ToolStripMenuItem dockFolderToolStripMenuItem;

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.contextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.quitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dockFolderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // contextMenuStrip
            // 
            this.contextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addToolStripMenuItem, this.quitToolStripMenuItem});
            this.contextMenuStrip.Name = "contextMenuStrip";
            this.contextMenuStrip.Size = new System.Drawing.Size(153, 48);
            // 
            // quitToolStripMenuItem
            // 
            this.quitToolStripMenuItem.Name = "quitToolStripMenuItem";
            this.quitToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.quitToolStripMenuItem.Text = Language.MainContextMenu.QuitWord;
            this.quitToolStripMenuItem.Click += new System.EventHandler(this.quitToolStripMenuItem_Click);
            // 
            // addToolStripMenuItem
            // 
            this.addToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.dockFolderToolStripMenuItem});
            this.addToolStripMenuItem.Name = "addToolStripMenuItem";
            this.addToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.addToolStripMenuItem.Text = Language.MainContextMenu.AddWord;
            // 
            // dockFolderToolStripMenuItem
            // 
            this.dockFolderToolStripMenuItem.Name = "dockFolderToolStripMenuItem";
            this.dockFolderToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.dockFolderToolStripMenuItem.Text = Language.MainContextMenu.DockFolder;
            this.dockFolderToolStripMenuItem.Click += new System.EventHandler(this.dockFolderToolStripMenuItem_Click);
            // 
            // TransparentObject
            // 
            this.ClientSize = new System.Drawing.Size(284, 264);
            //this.MaximizeBox = false;
            //this.MinimizeBox = false;
            this.Name = "TransparentObject";
            this.contextMenuStrip.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        #endregion


        #region Variables

        public String SectionName;

        #endregion

        #region Constructor

        /// <summary> 
        /// Create an alpha blended form with a transparent background that is movable and responds to mouse and key inputs.
        /// </summary>
        public BackgroundObject(MainForm TheParent, LanguageLoader.LanguageLoader LanguageData, SettingsLoader.SettingsLoader SettingsData, String Section, Size InitialSize)
        {
            Language = LanguageData;
            DockSettings = SettingsData;
            ParentObject = TheParent;
            SectionName = Section;
            //WorkingObjectData = TheData;
            ObjectSize = InitialSize;
            
            InitializeComponent();

            DoubleBuffered = true;
            this.AnimationTimer.Tick += new System.EventHandler(this.AnimationTimer_Tick);
            AnimationTimer.Interval = 30;

            TopMost = true;
            ShowInTaskbar = false;
            AllowDrop = true;

            LeftMouseButtonDown = false;
            ThisObjectMovedWithLeftMouse = false;

            ObjectBitmap = new Bitmap(1, 1, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
            OverlayBitmap = new Bitmap(1, 1, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
            ObjectOpacity = 255;

            SetBitmap();
        }

        int OpacityChange = 1;
        int Change = -1;
        private void AnimationTimer_Tick(object sender, EventArgs e)
        {
            if (ObjectSize.Width > 500)
            {
                ObjectSize.Width = 500;
                ObjectSize.Height = 500;
                Change = Change * -1;
            }
            else if (ObjectSize.Width < 30)
            {
                ObjectSize.Width = 30;
                ObjectSize.Width = 30;
                Change = Change * -1;
            }

            //ObjectOpacity = ObjectOpacity + Change * 10;

            //if (ObjectOpacity > 255)
            //{
            //    ObjectOpacity = 255;
            //    OpacityChange = OpacityChange * -1;
            //}
            //else if (ObjectOpacity < 10)
            //{
            //    ObjectOpacity = 10;
            //    OpacityChange = OpacityChange * -1;
            //}

            DrawBitmapManaged(ObjectSize.Width + Change * 5, ObjectSize.Height + Change * 5, false, this.Location.X -Change * 0, this.Location.Y -Change * 0, false, 0, 0, 0, 0, false, 0);

            //Console.WriteLine(this.Location);    
        }

        public void SetBitmap()
        {
            Bitmap tempBitmap;
            try
            {
                tempBitmap = new Bitmap(Application.StartupPath + @DockSettings.Background.Path);
            }
            catch (Exception)
            {
                tempBitmap = new Bitmap(ImageResources.sapphire_ring);
            }

            SetBitmapManaged(ref tempBitmap);
        }

        #endregion

        #region Object Events

        /// <summary> 
        /// Capture the Window messages for the form to take the appropriate actions.
        /// Normal events don't fire because of our of the PerPixelAlpaForm inheritance.
        /// </summary>
        protected override void WndProc(ref Message m)
        {
            //if (m.Msg == Constants.WindowMessageConstants.WM_NCRBUTTONDOWN)
            //{
            //    // Do nothing
            //}
            //else if (m.Msg == Constants.WindowMessageConstants.WM_NCRBUTTONUP)
            //{
            //    contextMenuStrip.Show();
            //    contextMenuStrip.Left = MousePosition.X;
            //    contextMenuStrip.Top = MousePosition.Y;
            //    return;
            //}
            //else if (m.Msg == Constants.WindowMessageConstants.WM_NCLBUTTONDBLCLK)
            //{
            //    //return;
            //}
            //else if (m.Msg == Constants.WindowMessageConstants.WM_NCLBUTTONDOWN)
            //{
            //    LeftMouseButtonDown = true;
            //}
            ////else if (m.Msg == Constants.WindowMessageConstants.WM_NCLBUTTONUP)
            ////{
            ////    // This doesn't work
            ////    Console.WriteLine("Moved");
            ////    return;
            ////}
            //else if (m.Msg == Constants.WindowMessageConstants.WM_CAPTURECHANGED)
            //{
            //    if (LeftMouseButtonDown && !(MouseButtons == MouseButtons.Left))
            //    {
            //        if (ThisObjectMovedWithLeftMouse)
            //        {
            //            Console.WriteLine("Object Moved with Mouse");
            //        }
            //        else
            //        {
            //            Console.WriteLine("Background Mouse Left Click");

            //            //if (AnimationTimer.Enabled)
            //            //    AnimationTimer.Stop();
            //            //else
            //            //    AnimationTimer.Start();

            //            //AnimationTimer.Enabled = true;
            //            //AnimationTimer.Start();
            //        }
            //        LeftMouseButtonDown = false;
            //        ThisObjectMovedWithLeftMouse = false;
            //    }
            //}
            //else if (m.Msg == 0x0084 /*WM_NCHITTEST*/)
            //{
            //    m.Result = (IntPtr)2;	// HTCLIENT 
            //    return;
            //}
            base.WndProc(ref m);
        }

        /// <summary> 
        /// Notify the parent form when this is moved.
        /// </summary>
        protected override void OnMove(EventArgs e)
        {
            if (ParentObject != null && ThisObjectMovedWithLeftMouse)
                ParentObject.ChildMoved(this);
            if (LeftMouseButtonDown)
                ThisObjectMovedWithLeftMouse = true;
            base.OnMove(e);
        }

        /// <summary> 
        /// Change the cursor when using Drag and Drop
        /// </summary>
        protected override void OnDragEnter(DragEventArgs e)
        {
            //if (e.Data.GetDataPresent(DataFormats.FileDrop))
            e.Effect = DragDropEffects.Copy;
            base.OnDragEnter(e);
        }

        /// <summary> 
        /// Add files to the dock using Drag and Drop
        /// </summary>
        protected override void OnDragDrop(DragEventArgs e)
        {
            string[] files = e.Data.GetData(DataFormats.FileDrop) as string[];
            if (files != null)
            {
                for (int i = 0; i < files.Length; i++)
                {
                    ParentObject.AddDockItem("[link]", files[i], "Link", "", "File Link");
                }
            }
            base.OnDragDrop(e);
        }

        #endregion

        #region Context Menu

        private void quitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ParentObject.ChildRequestAction("QUIT");
        }

        private void dockFolderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ParentObject.AddDockItem("[dockfolder]", "", "Dock Folder", DockSettings.Folders.DockFolderImagePath, "Dock Folder");
        }

        #endregion
    }

    public partial class DockItemObject : PerPixelAlphaForms.DockItemPerPixelAlphaForm
    {
        #region Windows Form Designer

        private ContextMenuStrip contextMenuStrip;
        private System.ComponentModel.IContainer components;
        private ToolStripMenuItem quitToolStripMenuItem;
        private ToolStripMenuItem removeToolStripMenuItem;
        private ToolStripMenuItem addToolStripMenuItem;
        private ToolStripMenuItem dockFolderToolStripMenuItem;
        private ToolStripMenuItem changeIconToolStripMenuItem;
        private OpenFileDialog ChangeIconDialog;

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.contextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.quitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.removeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dockFolderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.changeIconToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ChangeIconDialog = new System.Windows.Forms.OpenFileDialog();
            this.contextMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // contextMenuStrip
            // 
            this.contextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addToolStripMenuItem, this.changeIconToolStripMenuItem, this.removeToolStripMenuItem, this.quitToolStripMenuItem});
            this.contextMenuStrip.Name = "contextMenuStrip";
            this.contextMenuStrip.Size = new System.Drawing.Size(153, 48);
            // 
            // quitToolStripMenuItem
            // 
            this.quitToolStripMenuItem.Name = "quitToolStripMenuItem";
            this.quitToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.quitToolStripMenuItem.Text = Language.MainContextMenu.QuitWord;
            this.quitToolStripMenuItem.Click += new System.EventHandler(this.quitToolStripMenuItem_Click);
            // 
            // changeIconStripMenuItem
            // 
            this.changeIconToolStripMenuItem.Name = "changeIconToolStripMenuItem";
            this.changeIconToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.changeIconToolStripMenuItem.Text = Language.MainContextMenu.ChangeIcon;
            this.changeIconToolStripMenuItem.Click += new System.EventHandler(this.changeIconToolStripMenuItem_Click);
            // 
            // removeToolStripMenuItem
            // 
            this.removeToolStripMenuItem.Name = "removeToolStripMenuItem";
            this.removeToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.removeToolStripMenuItem.Text = Language.MainContextMenu.RemoveWord;
            this.removeToolStripMenuItem.Click += new System.EventHandler(this.removeToolStripMenuItem_Click);
            // 
            // addToolStripMenuItem
            // 
            this.addToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.dockFolderToolStripMenuItem});
            this.addToolStripMenuItem.Name = "addToolStripMenuItem";
            this.addToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.addToolStripMenuItem.Text = Language.MainContextMenu.AddWord;
            // 
            // dockFolderToolStripMenuItem
            // 
            this.dockFolderToolStripMenuItem.Name = "dockFolderToolStripMenuItem";
            this.dockFolderToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.dockFolderToolStripMenuItem.Text = Language.MainContextMenu.DockFolder;
            this.dockFolderToolStripMenuItem.Click += new System.EventHandler(this.dockFolderToolStripMenuItem_Click);
            // 
            // OpenDataPointsDialog
            // 
            this.ChangeIconDialog.FileName = "Change Icon";
            this.ChangeIconDialog.Filter = "PNG|*.png";
            this.ChangeIconDialog.FileOk += new System.ComponentModel.CancelEventHandler(this.ChangeIconDialog_FileOk);
            // 
            // TransparentObject
            // 
            this.ClientSize = new System.Drawing.Size(284, 264);
            this.Name = "TransparentObject";
            this.contextMenuStrip.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        #endregion

        #region Variables

        DockItemSettingsLoader.DockItemSettingsLoader DockItemSettings;
        public String DockItemSectionName;
        public int PreviousOpacity;
        FileOps.FileOps FileOperations;

        #endregion

        #region Constructor

        /// <summary> 
        /// Create an alpha blended form with a transparent background that is movable and responds to mouse and key inputs.
        /// </summary>
        public DockItemObject(MainForm TheParent, LanguageLoader.LanguageLoader LanguageData, SettingsLoader.SettingsLoader SettingsData,
            DockItemSettingsLoader.DockItemSettingsLoader DockItemData, String SectionName, Size InitialSize, String Path)
        {
            Language = LanguageData;
            DockSettings = SettingsData;
            ParentObject = TheParent;
            DockItemSettings = DockItemData;
            DockItemSectionName = SectionName;
            ObjectSize = InitialSize;

            if (DockItemSectionName != null && DockItemSectionName != "")
            {
                FileOperations = new FileOps.FileOps(@DockItemSettings.GetEntry(DockItemSectionName, "Args"));
            }
            else
            {
                FileOperations = new FileOps.FileOps(@Path);
            }

            InitializeComponent();

            TopMost = true;
            ShowInTaskbar = false;
            AllowDrop = true;

            LeftMouseButtonDown = false;
            ThisObjectMovedWithLeftMouse = false;

            ObjectBitmap = new Bitmap(1, 1, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
            OverlayBitmap = new Bitmap(1, 1, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
            ObjectOpacity = 255;
            PreviousOpacity = ObjectOpacity;

            SetBitmap();
        }

        #endregion

        public void SetBitmap()
        {
            Bitmap tempBitmap;
            try
            {
                if (DockItemSectionName != null && DockItemSectionName != "" && DockItemSettings.GetEntry(DockItemSectionName, "ImagePath") != "")
                {
                    tempBitmap = new Bitmap(Application.StartupPath + @DockItemSettings.GetEntry(DockItemSectionName, "ImagePath"));
                }
                else
                {
                    tempBitmap = new Bitmap(FileOperations.RepresentativeImage);
                }
            }
            catch (Exception)
            {
                tempBitmap = new Bitmap(ImageResources.MissingIcon);
            }

            SetBitmapManaged(ref tempBitmap);
        }

        #region Object Events

        /// <summary> 
        /// Capture the Window messages for the form to take the appropriate actions.
        /// Normal events don't fire because of our of the PerPixelAlpaForm inheritance.
        /// </summary>
        protected override void WndProc(ref Message m)
        {
            if (m.Msg == Constants.WindowMessageConstants.WM_NCRBUTTONDOWN)
            {
                // Do nothing
            }
            else if (m.Msg == Constants.WindowMessageConstants.WM_NCRBUTTONUP)
            {
                contextMenuStrip.Show();
                contextMenuStrip.Left = MousePosition.X;
                contextMenuStrip.Top = MousePosition.Y;
                return;
            }
            else if (m.Msg == Constants.WindowMessageConstants.WM_NCLBUTTONDBLCLK)
            {
                //return;
            }
            else if (m.Msg == Constants.WindowMessageConstants.WM_NCLBUTTONDOWN)
            {
                LeftMouseButtonDown = true;
                PreviousOpacity = ObjectOpacity;
                DrawBitmapManaged(ObjectSize.Width, ObjectSize.Height, false, 0, 0, false, 0, 0, 0, 0, true, ObjectOpacity / 2);
            }
            //else if (m.Msg == Constants.WindowMessageConstants.WM_NCLBUTTONUP)
            //{
            //    // This doesn't work
            //    Console.WriteLine("Moved");
            //    return;
            //}
            else if (m.Msg == Constants.WindowMessageConstants.WM_CAPTURECHANGED)
            {
                if (LeftMouseButtonDown && !(MouseButtons == MouseButtons.Left))
                {
                    DrawBitmapManaged(ObjectSize.Width, ObjectSize.Height, false, 0, 0, false, 0, 0, 0, 0, true, PreviousOpacity);
                    PreviousOpacity = ObjectOpacity;

                    if (ThisObjectMovedWithLeftMouse)
                    {
                        Console.WriteLine("Dock Item: Object Moved with Mouse");

                        if (ParentObject != null)
                            ParentObject.ChildMoved(this);
                    }
                    else
                    {
                        Console.WriteLine("Dock Item Mouse Left Click");

                        if (DockItemSectionName != null && DockItemSettings.GetEntry(DockItemSectionName, @"Action") == @"[link]")
                        {
                            FileOperations.Open(DockItemSettings.GetEntry(DockItemSectionName, @"Args"));
                        }
                        else if (DockItemSectionName != null && DockItemSettings.GetEntry(DockItemSectionName, @"Action") == @"[dockfolder]")
                        {
                            ParentObject.ShowLevel(DockItemSectionName + @"-");
                        }
                        else if (FileOperations._Path != null)
                        {
                            FileOperations.Open(@FileOperations._Path);
                        }
                    }

                    LeftMouseButtonDown = false;
                    ThisObjectMovedWithLeftMouse = false;
                }
            }
            else if (m.Msg == 0x0084 /*WM_NCHITTEST*/)
            {
                m.Result = (IntPtr)2;	// HTCLIENT 
                return;
            }
            base.WndProc(ref m);
        }

        /// <summary> 
        /// Notify the parent form when this is moved.
        /// </summary>
        protected override void OnMove(EventArgs e)
        {
            //if (ParentObject != null && ThisObjectMovedWithLeftMouse)
            //    ParentObject.ChildMoved(this);
            if (LeftMouseButtonDown)
                ThisObjectMovedWithLeftMouse = true;
            base.OnMove(e);
        }

        /// <summary> 
        /// Change the cursor when using Drag and Drop
        /// </summary>
        protected override void OnDragEnter(DragEventArgs e)
        {
            //if (e.Data.GetDataPresent(DataFormats.FileDrop))
            e.Effect = DragDropEffects.Copy;
            base.OnDragEnter(e);
        }

        /// <summary> 
        /// Add files to the dock using Drag and Drop
        /// </summary>
        protected override void OnDragDrop(DragEventArgs e)
        {
            string[] files = e.Data.GetData(DataFormats.FileDrop) as string[];
            if (files != null)
            {
                for (int i = 0; i < files.Length; i++)
                {
                    ParentObject.AddDockItem("[link]", files[i], "Link", "", "File Link");
                }
            }
            base.OnDragDrop(e);
        }

        #endregion

        #region Context Menu

        private void quitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ParentObject.ChildRequestAction("QUIT");
        }

        private void removeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ParentObject.RemoveDockItem(this);
        }

        private void changeIconToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ChangeIconDialog.Multiselect = false;
            ChangeIconDialog.InitialDirectory = Application.StartupPath + @"\System\Icons\";
            ChangeIconDialog.ShowDialog();
        }

        private void ChangeIconDialog_FileOk(object sender, CancelEventArgs e)
        {
            String NewImagePath;
            if (ChangeIconDialog.FileName.StartsWith(Application.StartupPath))
            {
                NewImagePath = ChangeIconDialog.FileName.Substring(Application.StartupPath.Length, ChangeIconDialog.FileName.Length - Application.StartupPath.Length);
            }
            else
            {
                NewImagePath = ChangeIconDialog.FileName;
            }

            //Console.WriteLine(NewImagePath);

            if (DockItemSectionName != null && DockItemSectionName != "")
            {
                DockItemSettings.SetEntry(DockItemSectionName, "ImagePath", NewImagePath);
                FileOperations = new FileOps.FileOps(@DockItemSettings.GetEntry(DockItemSectionName, "Args"));
            }
            //else
            //{
            //    FileOperations = new FileOps.FileOps(@Path);
            //}

            SetBitmap();
            Size ObjectSize = this.ObjectSize;
            DrawBitmapManaged(ObjectSize.Width, ObjectSize.Height, false, 0, 0, false, 0, 0, 0, 0, false, 0);       
        }

        private void dockFolderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ParentObject.AddDockItem("[dockfolder]", "", "Dock Folder", DockSettings.Folders.DockFolderImagePath, "Dock Folder");
        }

        #endregion
    }

    public partial class CentreObject : PerPixelAlphaForms.DockItemPerPixelAlphaForm
    {
        #region Windows Form Designer

        private ContextMenuStrip contextMenuStrip;
        private System.ComponentModel.IContainer components;
        private ToolStripMenuItem quitToolStripMenuItem;
        private ToolStripMenuItem addToolStripMenuItem;
        private ToolStripMenuItem dockFolderToolStripMenuItem;

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.contextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.quitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dockFolderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // contextMenuStrip
            // 
            this.contextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addToolStripMenuItem, this.quitToolStripMenuItem});
            this.contextMenuStrip.Name = "contextMenuStrip";
            this.contextMenuStrip.Size = new System.Drawing.Size(153, 48);
            // 
            // quitToolStripMenuItem
            // 
            this.quitToolStripMenuItem.Name = "quitToolStripMenuItem";
            this.quitToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.quitToolStripMenuItem.Text = Language.MainContextMenu.QuitWord;
            this.quitToolStripMenuItem.Click += new System.EventHandler(this.quitToolStripMenuItem_Click);
            // 
            // addToolStripMenuItem
            // 
            this.addToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.dockFolderToolStripMenuItem});
            this.addToolStripMenuItem.Name = "addToolStripMenuItem";
            this.addToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.addToolStripMenuItem.Text = Language.MainContextMenu.AddWord;
            // 
            // dockFolderToolStripMenuItem
            // 
            this.dockFolderToolStripMenuItem.Name = "dockFolderToolStripMenuItem";
            this.dockFolderToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.dockFolderToolStripMenuItem.Text = Language.MainContextMenu.DockFolder;
            this.dockFolderToolStripMenuItem.Click += new System.EventHandler(this.dockFolderToolStripMenuItem_Click);
            // 
            // TransparentObject
            // 
            this.ClientSize = new System.Drawing.Size(284, 264);
            this.Name = "TransparentObject";
            this.contextMenuStrip.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        #endregion

        #region Variables

        public String SectionName;
        public int PreviousOpacity;

        #endregion

        #region Constructor

        /// <summary> 
        /// Create an alpha blended form with a transparent background that is movable and responds to mouse and key inputs.
        /// </summary>
        public CentreObject(MainForm TheParent, LanguageLoader.LanguageLoader LanguageData, SettingsLoader.SettingsLoader SettingsData, String Section, Size InitialSize)
        {
            Language = LanguageData;
            DockSettings = SettingsData;
            ParentObject = TheParent;
            ObjectSize = InitialSize;
            SectionName = Section;

            InitializeComponent();
            TopMost = true;
            ShowInTaskbar = false;
            AllowDrop = true;

            LeftMouseButtonDown = false;
            ThisObjectMovedWithLeftMouse = false;

            ObjectBitmap = new Bitmap(1, 1, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
            OverlayBitmap = new Bitmap(1, 1, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
            ObjectOpacity = 255;
            PreviousOpacity = ObjectOpacity;

            SetBitmap();
        }

        #endregion

        public void SetBitmap()
        {
            Bitmap tempBitmap;
            try
            {
                tempBitmap = new Bitmap(Application.StartupPath + @DockSettings.CentreImage.Path);
            }
            catch (Exception)
            {
                tempBitmap = new Bitmap(ImageResources.CircleDockIconCentreImage);
            }

            SetBitmapManaged(ref tempBitmap);
        }

        #region Object Events

        /// <summary> 
        /// Capture the Window messages for the form to take the appropriate actions.
        /// Normal events don't fire because of our of the PerPixelAlpaForm inheritance.
        /// </summary>
        protected override void WndProc(ref Message m)
        {
            if (m.Msg == Constants.WindowMessageConstants.WM_NCRBUTTONDOWN)
            {
                // Do nothing
            }
            else if (m.Msg == Constants.WindowMessageConstants.WM_NCRBUTTONUP)
            {
                contextMenuStrip.Show();
                contextMenuStrip.Left = MousePosition.X;
                contextMenuStrip.Top = MousePosition.Y;
                return;
            }
            else if (m.Msg == Constants.WindowMessageConstants.WM_NCLBUTTONDBLCLK)
            {
                //return;
            }
            else if (m.Msg == Constants.WindowMessageConstants.WM_NCLBUTTONDOWN)
            {
                LeftMouseButtonDown = true;
                PreviousOpacity = ObjectOpacity;
                DrawBitmapManaged(ObjectSize.Width, ObjectSize.Height, false, 0, 0, false, 0, 0, 0, 0, true, ObjectOpacity / 2);
            }
            //else if (m.Msg == Constants.WindowMessageConstants.WM_NCLBUTTONUP)
            //{
            //    // This doesn't work
            //    Console.WriteLine("Moved");
            //    return;
            //}
            //else if (m.Msg == Constants.WindowMessageConstants.WM_PAINT)
            //{
            //    // This doesn't work
            //    Console.WriteLine("paint");
            //    return;
            //}
            else if (m.Msg == Constants.WindowMessageConstants.WM_CAPTURECHANGED)
            {
                if (LeftMouseButtonDown && !(MouseButtons == MouseButtons.Left))
                {
                    DrawBitmapManaged(ObjectSize.Width, ObjectSize.Height, false, 0, 0, false, 0, 0, 0, 0, true, PreviousOpacity);
                    PreviousOpacity = ObjectOpacity;

                    if (ThisObjectMovedWithLeftMouse)
                    {
                        Console.WriteLine("Object Moved with Mouse");
                    }
                    else
                    {
                        Console.WriteLine("Mouse Left Click");
                        ParentObject.ShowLevelUp();
                    }
                    LeftMouseButtonDown = false;
                    ThisObjectMovedWithLeftMouse = false;
                }
            }
            else if (m.Msg == 0x0084 /*WM_NCHITTEST*/)
            {
                m.Result = (IntPtr)2;	// HTCLIENT 
                return;
            }
            base.WndProc(ref m);
        }

        /// <summary> 
        /// Notify the parent form when this is moved.
        /// </summary>
        protected override void OnMove(EventArgs e)
        {
            if (ParentObject != null && ThisObjectMovedWithLeftMouse)
                ParentObject.ChildMoved(this);
            if (LeftMouseButtonDown)
                ThisObjectMovedWithLeftMouse = true;
            base.OnMove(e);
        }

        /// <summary> 
        /// Change the cursor when using Drag and Drop
        /// </summary>
        protected override void OnDragEnter(DragEventArgs e)
        {
            //if (e.Data.GetDataPresent(DataFormats.FileDrop))
            e.Effect = DragDropEffects.Copy;
            base.OnDragEnter(e);
        }

        /// <summary> 
        /// Add files to the dock using Drag and Drop
        /// </summary>
        protected override void OnDragDrop(DragEventArgs e)
        {
            string[] files = e.Data.GetData(DataFormats.FileDrop) as string[];
            if (files != null)
            {
                for (int i = 0; i < files.Length; i++)
                {
                    ParentObject.AddDockItem("[link]", files[i], "Link", "", "File Link");
                }
            }
            base.OnDragDrop(e);
        }

        #endregion

        #region Context Menu

        private void quitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ParentObject.ChildRequestAction("QUIT");
        }

        private void dockFolderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ParentObject.AddDockItem("[dockfolder]", "", "Dock Folder", DockSettings.Folders.DockFolderImagePath, "Dock Folder");
        }

        #endregion
    }
}
