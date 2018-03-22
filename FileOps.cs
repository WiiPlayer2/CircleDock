using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Drawing.Imaging;

using Orbit.Utilities;
using Win32.Shell32;
using CircleDock;

namespace FileOps
{
    /// <summary>
    /// Extracts the system representative thumbnail image or icon for a given file or folder path.
    /// Extracts the display name and description of the file/folder at the given path.
    /// Allows the execution/open of the given path.
    /// </summary>
    public class FileOps
    {
        /// <summary>
        /// Display name for the given path.
        /// </summary>
        public String Name;

        /// <summary>
        /// Description for the given path. Currently, this is the file extension of the path.
        /// </summary>
        public String Description;

        /// <summary>
        /// The system representative thumbnail or icon for the path.
        /// </summary>
        public Bitmap RepresentativeImage;

        /// <summary>
        /// Stores the file/folder path given in the constructor.
        /// </summary>
        public String _Path;

        /// <summary>
        /// Constant used to extract an image thumbnail from its metadata.
        /// </summary>
        private const int THUMBNAIL_DATA = 0x501B;

        /// <summary>
        /// Extracts the system representative thumbnail image or icon for a given file or folder path.
        /// Extracts the display name and description of the file/folder at the given path.
        /// Allows the execution/open of the given path.
        /// </summary>
        /// <param name="path">Path to the given file/directory.</param>
        public FileOps(String Path)
        {
            _Path = Path;
            GetFileInfo(Path);
        }

        /// <summary>
        /// Extracts the system representative thumbnail image or icon for a given file or folder path.
        /// Extracts the display name and description of the file/folder at the given path.
        /// Allows the execution/open of the given path.
        /// 
        /// Calling this constructor does not automatically set the path or retrieve the data for the path.
        /// This constructor just initializes the class and allows you to use the public functions.
        /// </summary>
        public FileOps()
        {
        }

        /// <summary>
        /// Gets the thumbnail from the image metadata. Returns null if no thumbnail
        /// is stored in the image metadata. Fast method.
        /// </summary>
        /// <param name="path">Path to the given file/directory.</param>
        /// <returns>Returns a thumbnail of the file at the given path if it exists. Otherwise, returns null.</returns>
        public Bitmap GetThumbnail(String path)
        {
            if (path == null || path == "" || !File.Exists(path))
                return null;

            string Extension = System.IO.Path.GetExtension(path).ToLower();
            if (!(Extension == ".png"
                || Extension == ".jpg"
                || Extension == ".gif"
                || Extension == ".bmp"
                || Extension == ".jpeg"
                || Extension == ".tiff"))
            {
                return null;
            }

            try
            {
                FileStream fs = File.OpenRead(path);
                // Last parameter tells GDI+ not the load the actual image data
                Image img = Image.FromStream(fs, false, false);


                // GDI+ throws an error if we try to read a property when the image
                // doesn't have that property. Check to make sure the thumbnail property
                // item exists.
                bool propertyFound = false;
                for (int i = 0; i < img.PropertyIdList.Length; i++)
                    if (img.PropertyIdList[i] == THUMBNAIL_DATA)
                    {
                        propertyFound = true;
                        break;
                    }

                if (!propertyFound)
                    return null;

                PropertyItem p = img.GetPropertyItem(THUMBNAIL_DATA);
                fs.Close();
                img.Dispose();


                // The image data is in the form of a byte array. Write all 
                // the bytes to a stream and create a new image from that stream
                byte[] imageBytes = p.Value;
                MemoryStream stream = new MemoryStream(imageBytes.Length);
                stream.Write(imageBytes, 0, imageBytes.Length);

                return (Bitmap)Image.FromStream(stream);
            }
            catch (Exception)
            {
                return null;
            }
        }

        /// <summary>
        /// Gets the file preview image. Slow method but works for all image files even with no metadata. 
        /// This method is not currently used because it is too slow.
        /// </summary>
        /// <param name="Path">Path to the given file/directory.</param>
        /// <returns>Returns a thumbnail of the file at the given path if it exists. Otherwise, returns null.</returns> 
        public Bitmap GetPreviewThumb(String Path)
        {
            if (Path != null && Path != "" && System.IO.File.Exists(Path))
            {
                string Extension = System.IO.Path.GetExtension(Path).ToLower();
                if (Extension == ".png"
                    || Extension == ".jpg"
                    || Extension == ".gif"
                    || Extension == ".bmp"
                    || Extension == ".jpeg"
                    || Extension == ".tiff")
                {
                    try
                    {
                        using (Bitmap IconPic = (Bitmap)Bitmap.FromFile(Path))
                        {
                            //Bitmap returnBitmap = new Bitmap(IconPic.GetThumbnailImage(100, 100, null, new IntPtr()));
                            Bitmap returnBitmap = new Bitmap(IconPic);
                            return returnBitmap;
                        }
                    }
                    catch (Exception)
                    {
                        return null;
                    }
                }
                else
                {
                    return null;
                }
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// Opens (runs) the file at the Path given. Will display an error message if it encounters an error.
        /// </summary>
        /// <param name="Path">Path to the given file/directory.</param>
        public void Open(String Path)
        {
            if ((File.Exists(Path) || Directory.Exists(Path)) == false)
            {
                MessageBox.Show("File/Path is invalid.", "Circle Dock");
                return;
            }

            // try running it with the default .Net class
            System.Diagnostics.ProcessStartInfo ProcInfo = new System.Diagnostics.ProcessStartInfo(Path);
            ProcInfo.UseShellExecute = true;
            ProcInfo.WorkingDirectory = null;
            ProcInfo.WorkingDirectory = System.IO.Path.GetDirectoryName(Path);

            try
            {
                // try starting
                System.Diagnostics.Process.Start(ProcInfo);
            }
            catch (Exception)
            {
                try
                {
                    // if failed, try using the Win32 API function
                    Win32.Shell32.ShellExecuteInfo ShExInfo = new Win32.Shell32.ShellExecuteInfo();
                    ShExInfo.fMask = 0x0000000c;
                    //ShExInfo.hwnd=(int)this.Handle;
                    ShExInfo.hwnd = (int)System.Diagnostics.Process.GetCurrentProcess().MainWindowHandle;
                    ShExInfo.lpFile = ProcInfo.FileName;
                    ShExInfo.lpDirectory = ProcInfo.WorkingDirectory;
                    ShExInfo.lpParameters = ProcInfo.Arguments;
                    ShExInfo.lpVerb = "open";
                    ShExInfo.nShow = 1;
                    ShExInfo.cbSize = System.Runtime.InteropServices.Marshal.SizeOf(ShExInfo);
                    Win32.Shell32.Shell32API.ShellExecuteEx(ShExInfo);
                }
                catch (Exception)
                {
                    ProcInfo = null;
                    MessageBox.Show("File/Path is invalid.", "Circle Dock");
                }
            }
            ProcInfo = null;
        }

        /// <summary>
        /// Gets the name, description, and the representative image for the file/folder at the given path.
        /// If it encounters and error, it will set the name and description to "Invalid/Missing" and the representative
        /// image will be the MissingIcon image.
        /// </summary>
        /// <param name="Path">Path to the given file/directory.</param>
        public void GetFileInfo(String Path)
        {
            if ((File.Exists(Path) || Directory.Exists(Path)) == false)
            {
                Name = "Invalid/Missing";
                Description = "Invalid/Missing";
                RepresentativeImage = CircleDock.ImageResources.MissingIcon;
                return;
            }

            try
            {
                // get extra information on this file that the System.IO.FileInfo doesn't give us
                Win32.Shell32.SHFileInfo FileInfo = new Win32.Shell32.SHFileInfo();
                Win32.Shell32.Shell32API.SHGetFileInfo(Path, 0, ref FileInfo, (uint)System.Runtime.InteropServices.Marshal.SizeOf(FileInfo), Win32.Shell32.ShellGetFileInfoFlags.DisplayName | Win32.Shell32.ShellGetFileInfoFlags.FileTypeName | Win32.Shell32.ShellGetFileInfoFlags.LargeIcon | Win32.Shell32.ShellGetFileInfoFlags.Icon);

                // set the item name to the file name
                Name = FileInfo.szDisplayName;
                // set the item description to the file type
                Description = FileInfo.szTypeName;

                //RepresentativeImage = GetPreviewThumb(Path);
                RepresentativeImage = GetThumbnail(Path);

                if (RepresentativeImage == null)
                {
                    try
                    {
                        // getting the handle to the icon from the SHFileInfo structure
                        using (Icon IconO = Icon.FromHandle(FileInfo.hIcon))
                        {
                            // create the biggest possible icon
                            using (Icon icon = new Icon(IconO, 256, 256))
                            {
                                // convert to bitmap
                                using (Bitmap IconPic = Orbit.Utilities.ImageHelper.GetBitmapFromIcon(icon))
                                {
                                    Bitmap returnBitmap = new Bitmap(IconPic);
                                    RepresentativeImage = returnBitmap;
                                }
                            }
                        }
                    }
                    catch (Exception)
                    {
                        RepresentativeImage = ImageResources.MissingIcon;
                    }
                }
                    
                // don't forget to destroy the handle to the other icon
                Win32.User32.User32API.DestroyIcon(FileInfo.hIcon);
            }
            catch (Exception)
            {
                Name = "Invalid/Missing";
                Description = "Invalid/Missing";
                RepresentativeImage = CircleDock.ImageResources.MissingIcon;
            }
        }
    }
}
