// Portions of "private void SetBitmap" in "public class PerPixelAlphaForm" Copyright © 2002-2004 Rui Godinho Lopes <rui@ruilopes.com>
// All other code Copyright 2008 Eric Wong


using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using ImageOperations;
using CircleDock;

namespace PerPixelAlphaForms
{
    /// <summary>
    /// Creates an invisible form. Used for the main form of Circle Dock that is used to control everything else but is not displayed.
    /// </summary>
    public class InvisiblePerPixelAlphaForm : Form
    {
        public InvisiblePerPixelAlphaForm()
        {
            // This form should not have a border or else Windows will clip it.
            FormBorderStyle = FormBorderStyle.None;
            this.Hide();
        }

        /// <summary>
        /// Allows us to set the window styles at creation time to allow for widget type objects.
        /// </summary>
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ExStyle = Constants.WindowExStyles.WS_EX_LAYERED | Constants.WindowExStyles.WS_EX_NOACTIVATE;
                return cp;
            }
        }
    }

    /// <summary>
    /// Creates an alpha blended form for the background object.
    /// </summary>
    public class BackgroundPerPixelAlphaForm : PerPixelAlphaForm
    {
        public BackgroundPerPixelAlphaForm()
        {
        }

        /// <summary>
        /// Allows us to set the window styles at creation time to allow for widget type objects.
        /// </summary>
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;

                //Set the form to be a layered type to allow for alpha blended graphics and makes it a toolwindow type to 
                //remove it from the taskbar and Alt-Tab list.
                cp.ExStyle = Constants.WindowExStyles.WS_EX_LAYERED | Constants.WindowExStyles.WS_EX_TOOLWINDOW;

                //The following style sets the form to be a WS_CHILD type without getting error messages at creation.
                //Setting cp.Style to WS_CHILD the regular way does not work because of WS_EX_LAYERED.
                cp.Style = unchecked((int)0xD4000000);
                return cp;
            }
        }
    }

    /// <summary>
    /// Creates an alpha blended form for the dock items including the centre image.
    /// </summary>
    public class DockItemPerPixelAlphaForm : PerPixelAlphaForm
    {
        public DockItemPerPixelAlphaForm()
        {
        }

        /// <summary>
        /// Allows us to set the window styles at creation time to allow for widget type objects.
        /// </summary>
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;

                //Set the form to be a layered type to allow for alpha blended graphics and makes it a toolwindow type to 
                //remove it from the taskbar and Alt-Tab list.
                cp.ExStyle = Constants.WindowExStyles.WS_EX_LAYERED | Constants.WindowExStyles.WS_EX_TOOLWINDOW ;
                
                //The following style sets the form to be a WS_CHILD type without getting error messages at creation.
                //Setting cp.Style to WS_CHILD the regular way does not work because of WS_EX_LAYERED.
                cp.Style = unchecked((int)0xD4000000);
                return cp;
            }
        }
    }

    /// <summary>
    /// This is the basic class that other dock items/objects inherits. 
    /// Essentially, it contains methods that manage the setting of the image bitmaps to be displayed.
    /// </summary>
    public class PerPixelAlphaForm : Form
    {
        #region Variables

        /// <summary> 
        /// Bitmap image to be drawn on the object.
        /// </summary>
        public Bitmap ObjectBitmap;

        /// <summary> 
        /// Opacity of the object (0-255).
        /// </summary>
        public int ObjectOpacity;

        /// <summary> 
        /// Overlay to be drawn over top of ObjectBitmap.
        /// </summary>
        public Bitmap OverlayBitmap;

        /// <summary> 
        /// Our link to the form that created this object.
        /// </summary>
        public MainForm ParentObject;

        /// <summary> 
        /// Our working copy of the saved data for this object.
        /// </summary>
        public DockItemsInformation.ObjectData WorkingObjectData;

        /// <summary> 
        /// Variables to enable a workaround to detect the left mouse up with WndProc.
        /// </summary>
        public bool LeftMouseButtonDown;
        public bool ThisObjectMovedWithLeftMouse;

        /// <summary> 
        /// Access to the language words used.
        /// </summary>
        public LanguageLoader.LanguageLoader Language;

        /// <summary> 
        /// Access to the general dock settings with read and write capabilities. Not for individual dock item settings!
        /// </summary>
        public SettingsLoader.SettingsLoader DockSettings;

        /// <summary> 
        /// The size that the object should be drawn as.
        /// </summary>
        public Size ObjectSize;

        /// <summary> 
        /// The size that the overlay should be drawn as.
        /// </summary>
        public Size OverlaySize;

        #endregion

        #region Constructor

        #region Windows Form Designer generated code

        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        public System.Windows.Forms.Timer AnimationTimer;

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.AnimationTimer = new System.Windows.Forms.Timer(this.components);
        }

        #endregion

        

        /// <summary> 
        /// PerPixelAlpha is the basis of all the other form objects in Circle Dock. Everything else inherits this class.
        /// </summary>
        public PerPixelAlphaForm()
        {
            InitializeComponent();
            // This form should not have a border or else Windows will clip it.
            
            FormBorderStyle = FormBorderStyle.None;
            AllowDrop = true;
            
            EnableDoubleBuffering();
            StartPosition = FormStartPosition.Manual;
            ObjectOpacity = 255;
        }

        /// <summary>
        ///  Enable double-buffering
        /// </summary>
        public void EnableDoubleBuffering()
        {
            // Set the value of the double-buffering style bits to true.
            DoubleBuffered = true;
            this.SetStyle(ControlStyles.DoubleBuffer | ControlStyles.UserPaint |
                            ControlStyles.AllPaintingInWmPaint, true);
            this.UpdateStyles();
        }

        #endregion

        #region Alpha Blending

        /// <summary> 
        /// Changes the current bitmap shown in the form with a custom opacity level and alpha blending.  Here is where all happens!
        /// The size of the bitmap drawn is equal to the size of the given "bitmap".
        /// This is a private method. Use the other managed methods to perform the bitmap setting operations.
        /// </summary>
        /// <param name="bitmap">The bitmap must be 32ppp with alpha-channel.</param>
        /// <param name="opacity">0-255</param>
        private void SetBitmap(ref Bitmap bitmap, byte opacity, bool SetNewPos, int NewLeftPos, int NewTopPos)
        {
            if (bitmap.PixelFormat != PixelFormat.Format32bppArgb)
                throw new ApplicationException("The bitmap must be 32ppp with alpha-channel.");

            // The idea of this is very simple,
            // 1. Create a compatible DC with screen;
            // 2. Select the bitmap with 32bpp with alpha-channel in the compatible DC;
            // 3. Call the UpdateLayeredWindow.

            IntPtr screenDc = Win32.GetDC(IntPtr.Zero);
            IntPtr memDc = Win32.CreateCompatibleDC(screenDc);
            IntPtr hBitmap = IntPtr.Zero;
            IntPtr oldBitmap = IntPtr.Zero;

            try
            {
                hBitmap = bitmap.GetHbitmap(Color.FromArgb(0));  // grab a GDI handle from this GDI+ bitmap
                oldBitmap = Win32.SelectObject(memDc, hBitmap);

                Win32.Size size = new Win32.Size(bitmap.Width, bitmap.Height);
                Win32.Point pointSource = new Win32.Point(0, 0);
                Win32.Point topPos;
                if (SetNewPos == true)
                {
                    topPos = new Win32.Point( NewLeftPos, NewTopPos);

                    //Very important to update the Location because UpdateLayeredWindow doesn't do it correctly.
                    this.Location = new Point(NewLeftPos, NewTopPos);
                }
                else
                {
                    topPos = new Win32.Point(Left, Top);
                    this.Location = new Point(Left, Top);
                }

                Win32.BLENDFUNCTION blend = new Win32.BLENDFUNCTION();
                blend.BlendOp = Win32.AC_SRC_OVER;
                blend.BlendFlags = 0;
                blend.SourceConstantAlpha = opacity;
                blend.AlphaFormat = Win32.AC_SRC_ALPHA;

                Win32.UpdateLayeredWindow(Handle, screenDc, ref topPos, ref size, memDc, ref pointSource, 0, ref blend, Win32.ULW_ALPHA);
            }
            finally
            {
                Win32.ReleaseDC(IntPtr.Zero, screenDc);
                if (hBitmap != IntPtr.Zero)
                {
                    Win32.SelectObject(memDc, oldBitmap);
                    //Windows.DeleteObject(hBitmap); // The documentation says that we have to use the Windows.DeleteObject... but since there is no such method I use the normal DeleteObject from Win32 GDI and it's working fine without any resource leak.
                    Win32.DeleteObject(hBitmap);
                }
                Win32.DeleteDC(memDc);
            }
        }

        #endregion

        #region Set Object Bitmap and Opacity

        /// <summary> 
        /// Changes the stored bitmap with a new bitmap from a file.
        /// </summary>
        /// <param name="fileName">The file must contain an image with an alpha-channel and be 32ppp.</param>
        public void SetBitmapManaged(string fileName)
        {
            try
            {
                Bitmap newBitmap = Image.FromFile(fileName) as Bitmap;
                if (ObjectBitmap != null)
                    ObjectBitmap.Dispose();
                ObjectBitmap = newBitmap;
            }
            catch (ApplicationException e)
            {
                MessageBox.Show(this, e.Message, "Error with bitmap.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            catch (Exception e)
            {
                MessageBox.Show(this, e.Message, "Could not open image file.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        /// <summary> 
        /// Changes the stored bitmap with a new bitmap.
        /// </summary>
        /// <param name="newBitmap">The bitmap must be 32ppp with alpha-channel.</param>
        public void SetBitmapManaged(ref Bitmap newBitmap)
        {
            try
            {
                if (ObjectBitmap != null)
                    ObjectBitmap.Dispose();
                ObjectBitmap = newBitmap;
            }
            catch (ApplicationException e)
            {
                MessageBox.Show(this, e.Message, "Error with bitmap.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            catch (Exception e)
            {
                MessageBox.Show(this, e.Message, "Could not open image file.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        /// <summary> 
        /// Changes the stored overlay with a new bitmap from a file.
        /// </summary>
        /// <param name="fileName">The file must contain an image with an alpha-channel and be 32ppp.</param>
        public void SetOverlayManaged(string fileName)
        {
            try
            {
                Bitmap newBitmap = Image.FromFile(fileName) as Bitmap;
                if (OverlayBitmap != null)
                    OverlayBitmap.Dispose();
                OverlayBitmap = newBitmap;
            }
            catch (ApplicationException e)
            {
                MessageBox.Show(this, e.Message, "Error with bitmap.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            catch (Exception e)
            {
                MessageBox.Show(this, e.Message, "Could not open image file.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        /// <summary> 
        /// Changes the stored overlay with a new bitmap.
        /// </summary>
        /// <param name="newBitmap">The bitmap must be 32ppp with alpha-channel.</param>
        public void SetOverlayManaged(ref Bitmap newBitmap)
        {
            try
            {
                if (OverlayBitmap != null)
                    OverlayBitmap.Dispose();
                OverlayBitmap = newBitmap;
            }
            catch (ApplicationException e)
            {
                MessageBox.Show(this, e.Message, "Error with bitmap.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            catch (Exception e)
            {
                MessageBox.Show(this, e.Message, "Could not open image file.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        /// <summary> 
        /// Draws the ObjectBitmap and OverlayBitmap to the form.
        /// </summary>
        /// <param name="DesiredWidth">Width of the object.</param>
        /// <param name="DesiredHeight">Height of the object.</param>
        public void DrawBitmapManaged(int ObjectDesiredWidth, int ObjectDesiredHeight, bool ChangePosition, int NewLeft, int NewTop, bool ShowOverlay, int OverlayDesiredLeft,
            int OverlayDesiredTop, int OverlayDesiredWidth, int OverlayDesiredHeight, bool ChangeOpacity, int NewOpacity)
        {
            try
            {
                if (ObjectBitmap != null)
                {
                    Bitmap newBitmap = ImageOperations.BitmapOperations.ScaleBySize(ref ObjectBitmap, ObjectDesiredWidth, ObjectDesiredHeight);

                    if (ShowOverlay == true && OverlayBitmap != null)
                    {
                        // Scale the bitmap in high quality mode.
                        using (Graphics gr = Graphics.FromImage(newBitmap))
                        {
                            gr.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
                            gr.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.HighQuality;
                            gr.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighQuality;
                            gr.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;

                            gr.DrawImage(newBitmap, new Rectangle(OverlayDesiredLeft, OverlayDesiredTop, OverlayDesiredWidth, OverlayDesiredHeight), new Rectangle(0, 0, OverlayBitmap.Width, OverlayBitmap.Height), GraphicsUnit.Pixel);
                        }
                    }

                    if (ObjectSize.Width != ObjectDesiredWidth || ObjectSize.Height != ObjectDesiredHeight)
                    {
                        ObjectSize = new Size(ObjectDesiredWidth, ObjectDesiredHeight);
                    }

                    if (OverlaySize.Width != OverlayDesiredWidth || OverlaySize.Height != OverlayDesiredHeight)
                    {
                        OverlaySize = new Size(OverlayDesiredWidth, OverlayDesiredHeight);
                    }

                    if (ChangeOpacity)
                        ObjectOpacity = NewOpacity;

                    //Bitmap newBitmap = new Bitmap(ObjectBitmap, ObjectDesiredWidth, ObjectDesiredHeight);

                    this.SetBitmap(ref newBitmap, (byte)ObjectOpacity, ChangePosition, NewLeft, NewTop);
                }
            }
            catch (ApplicationException e)
            {
                MessageBox.Show(this, e.Message, "Error with bitmap.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            catch (Exception e)
            {
                MessageBox.Show(this, e.Message, "Could not open image file.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        #endregion


    }

    // class that exposes needed win32 gdi functions.
    class Win32
    {
        public enum Bool
        {
            False = 0,
            True
        };


        [StructLayout(LayoutKind.Sequential)]
        public struct Point
        {
            public Int32 x;
            public Int32 y;

            public Point(Int32 x, Int32 y) { this.x = x; this.y = y; }
        }


        [StructLayout(LayoutKind.Sequential)]
        public struct Size
        {
            public Int32 cx;
            public Int32 cy;

            public Size(Int32 cx, Int32 cy) { this.cx = cx; this.cy = cy; }
        }


        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        struct ARGB
        {
            public byte Blue;
            public byte Green;
            public byte Red;
            public byte Alpha;
        }


        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        public struct BLENDFUNCTION
        {
            public byte BlendOp;
            public byte BlendFlags;
            public byte SourceConstantAlpha;
            public byte AlphaFormat;
        }


        public const Int32 ULW_COLORKEY = 0x00000001;
        public const Int32 ULW_ALPHA = 0x00000002;
        public const Int32 ULW_OPAQUE = 0x00000004;

        public const byte AC_SRC_OVER = 0x00;
        public const byte AC_SRC_ALPHA = 0x01;


        [DllImport("user32.dll", ExactSpelling = true, SetLastError = true)]
        public static extern Bool UpdateLayeredWindow(IntPtr hwnd, IntPtr hdcDst, ref Point pptDst, ref Size psize, IntPtr hdcSrc, ref Point pprSrc, Int32 crKey, ref BLENDFUNCTION pblend, Int32 dwFlags);

        [DllImport("user32.dll", ExactSpelling = true, SetLastError = true)]
        public static extern IntPtr GetDC(IntPtr hWnd);

        [DllImport("user32.dll", ExactSpelling = true)]
        public static extern int ReleaseDC(IntPtr hWnd, IntPtr hDC);

        [DllImport("gdi32.dll", ExactSpelling = true, SetLastError = true)]
        public static extern IntPtr CreateCompatibleDC(IntPtr hDC);

        [DllImport("gdi32.dll", ExactSpelling = true, SetLastError = true)]
        public static extern Bool DeleteDC(IntPtr hdc);

        [DllImport("gdi32.dll", ExactSpelling = true)]
        public static extern IntPtr SelectObject(IntPtr hDC, IntPtr hObject);

        [DllImport("gdi32.dll", ExactSpelling = true, SetLastError = true)]
        public static extern Bool DeleteObject(IntPtr hObject);
    }
}
