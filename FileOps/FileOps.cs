using CircleDock;
using LanguageLoader;
using Pinvoke;
using SettingsLoader;
using System;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using Win32.Shell32;

namespace FileOps
{
	public class FileOps
	{
		private const int THUMBNAIL_DATA = 20507;

		private const string rootSeparator = ":\\";

		private const string relativeToAppStartUp = ".\\";

		public string Name = "";

		public string Description = "";

		public Bitmap RepresentativeImage;

		public string _Path;

		public LanguageLoader Language;

		public SettingsLoader DockSettings;

		private IntPtr ParentObjectHandle = IntPtr.Zero;

		public FileOps(IntPtr theParent, string Path, LanguageLoader LanguageData, SettingsLoader SettingsData)
		{
			this.ParentObjectHandle = theParent;
			this.Language = LanguageData;
			this.DockSettings = SettingsData;
			if (this.DockSettings.General.EnablePortabilityMode && !Path.StartsWith(".\\"))
			{
				try
				{
					int num = Application.StartupPath.IndexOf(":\\");
					int num2 = Path.IndexOf(":\\");
					if (num >= 0 && num2 >= 0)
					{
						this._Path = Application.StartupPath.Substring(0, num + ":\\".Length) + Path.Substring(num2 + ":\\".Length, Path.Length - (num2 + ":\\".Length));
					}
					else
					{
						this._Path = Path;
					}
				}
				catch (Exception)
				{
					this._Path = Path;
				}
			}
			else
			{
				this._Path = Path;
			}
			if (Path.StartsWith(".\\"))
			{
				this._Path = Application.StartupPath + "\\" + Path.Substring(".\\".Length);
			}
			this.GetFileInfo(this._Path);
		}

		public FileOps(IntPtr theParent, LanguageLoader LanguageData, SettingsLoader SettingsData)
		{
			this.ParentObjectHandle = theParent;
			this.Language = LanguageData;
			this.DockSettings = SettingsData;
		}

		public void Open(string Path, string argsParams, ProcessWindowStyle runAs, IntPtr parentHandle)
		{
			if (Path.Length <= 0)
			{
				MessageBox.Show(this.Language.ErrorMessages.FilePathMissingInvalid + ": " + Path, this.Language.General.CircleDockName);
			}
			else if (Path.StartsWith("::{"))
			{
				try
				{
					Win32.ShellExecute(IntPtr.Zero, "open", Path, "", "", Win32.ShowCommands.SW_SHOW);
				}
				catch (Exception var_0_79)
				{
					MessageBox.Show(this.Language.ErrorMessages.FilePathMissingInvalid + ": " + Path, this.Language.General.CircleDockName);
				}
			}
			else
			{
				try
				{
					Process.Start(new ProcessStartInfo(Path)
					{
						WindowStyle = runAs,
						Arguments = argsParams,
						CreateNoWindow = false,
						ErrorDialog = true,
						ErrorDialogParentHandle = parentHandle,
						UseShellExecute = true
					});
				}
				catch (Exception var_2_F7)
				{
				}
			}
		}

		public void GetFileInfo(string Path)
		{
			if (!File.Exists(Path) && !Directory.Exists(Path))
			{
				this.Name = this.Language.ErrorMessages.MissingInvalid + ": " + Path;
				this.Description = this.Language.ErrorMessages.MissingInvalid + ": " + Path;
				this.RepresentativeImage = ImageResources.MissingIcon;
			}
			else
			{
				try
				{
					SHFileInfo sHFileInfo = default(SHFileInfo);
					Shell32API.SHGetFileInfo(Path, 0u, ref sHFileInfo, (uint)Marshal.SizeOf(sHFileInfo), (ShellGetFileInfoFlags)1536);
					this.Name = sHFileInfo.szDisplayName;
					this.Description = sHFileInfo.szTypeName;
					this.RepresentativeImage = null;
					try
					{
						if (Environment.OSVersion.Version.Major < 6)
						{
							this.RepresentativeImage = this.GetThumbnail(Path);
						}
						if (this.RepresentativeImage == null)
						{
							this.RepresentativeImage = ThumbnailGenerator.GenerateThumbnail(Path);
						}
						if (this.RepresentativeImage == null)
						{
							this.RepresentativeImage = ImageListThumbnailGenerator.GetJumboLargeThumbnail(Path);
						}
						if (this.RepresentativeImage == null)
						{
							this.RepresentativeImage = ImageResources.MissingIcon;
						}
					}
					catch (Exception)
					{
						this.RepresentativeImage = ImageResources.MissingIcon;
					}
				}
				catch (Exception)
				{
					this.Name = this.Language.ErrorMessages.MissingInvalid + ": " + Path;
					this.Description = this.Language.ErrorMessages.MissingInvalid + ": " + Path;
					this.RepresentativeImage = ImageResources.MissingIcon;
				}
			}
		}

		public Bitmap GetThumbnail(string path)
		{
			Bitmap result;
			if (path == null || path == "" || !File.Exists(path))
			{
				result = null;
			}
			else
			{
				string a = Path.GetExtension(path).ToLower();
				if (!(a == ".png") && !(a == ".jpg") && !(a == ".gif") && !(a == ".bmp") && !(a == ".jpeg") && !(a == ".tiff") && !(a == ".ico"))
				{
					result = null;
				}
				else
				{
					try
					{
						FileStream fileStream = File.OpenRead(path);
						Image image = Image.FromStream(fileStream, false, false);
						bool flag = false;
						for (int i = 0; i < image.PropertyIdList.Length; i++)
						{
							if (image.PropertyIdList[i] == 20507)
							{
								flag = true;
								break;
							}
						}
						if (!flag)
						{
							result = null;
						}
						else
						{
							PropertyItem propertyItem = image.GetPropertyItem(20507);
							fileStream.Close();
							image.Dispose();
							byte[] value = propertyItem.Value;
							MemoryStream memoryStream = new MemoryStream(value.Length);
							memoryStream.Write(value, 0, value.Length);
							result = (Bitmap)Image.FromStream(memoryStream);
						}
					}
					catch (Exception)
					{
						result = null;
					}
				}
			}
			return result;
		}

		public Bitmap GetPreviewThumb(string Path)
		{
			Bitmap result;
			if (Path != null && Path != "" && File.Exists(Path))
			{
				string a = Path.GetExtension(Path).ToLower();
				if (a == ".png" || a == ".jpg" || a == ".gif" || a == ".bmp" || a == ".jpeg" || a == ".tiff")
				{
					try
					{
						using (Bitmap bitmap = (Bitmap)Image.FromFile(Path))
						{
							Bitmap bitmap2 = new Bitmap(bitmap);
							result = bitmap2;
							return result;
						}
					}
					catch (Exception)
					{
						result = null;
						return result;
					}
				}
				result = null;
			}
			else
			{
				result = null;
			}
			return result;
		}
	}
}
