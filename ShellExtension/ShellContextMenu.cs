using ShellDll;
using System;
using System.Drawing;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

namespace ShellExtension
{
	public class ShellContextMenu : NativeWindow
	{
		private struct CWPSTRUCT
		{
			public IntPtr lparam;

			public IntPtr wparam;

			public int message;

			public IntPtr hwnd;
		}

		[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
		private struct CMINVOKECOMMANDINFOEX
		{
			public int cbSize;

			public ShellContextMenu.CMIC fMask;

			public IntPtr hwnd;

			public IntPtr lpVerb;

			[MarshalAs(UnmanagedType.LPStr)]
			public string lpParameters;

			[MarshalAs(UnmanagedType.LPStr)]
			public string lpDirectory;

			public ShellContextMenu.SW nShow;

			public int dwHotKey;

			public IntPtr hIcon;

			[MarshalAs(UnmanagedType.LPStr)]
			public string lpTitle;

			public IntPtr lpVerbW;

			[MarshalAs(UnmanagedType.LPWStr)]
			public string lpParametersW;

			[MarshalAs(UnmanagedType.LPWStr)]
			public string lpDirectoryW;

			[MarshalAs(UnmanagedType.LPWStr)]
			public string lpTitleW;

			public ShellContextMenu.POINT ptInvoke;
		}

		[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
		private struct MENUITEMINFO
		{
			public int cbSize;

			public ShellContextMenu.MIIM fMask;

			public ShellContextMenu.MFT fType;

			public ShellContextMenu.MFS fState;

			public uint wID;

			public IntPtr hSubMenu;

			public IntPtr hbmpChecked;

			public IntPtr hbmpUnchecked;

			public IntPtr dwItemData;

			[MarshalAs(UnmanagedType.LPTStr)]
			public string dwTypeData;

			public int cch;

			public IntPtr hbmpItem;

			public MENUITEMINFO(string text)
			{
				this.cbSize = ShellContextMenu.cbMenuItemInfo;
				this.dwTypeData = text;
				this.cch = text.Length;
				this.fMask = (ShellContextMenu.MIIM)0u;
				this.fType = ShellContextMenu.MFT.BYCOMMAND;
				this.fState = ShellContextMenu.MFS.ENABLED;
				this.wID = 0u;
				this.hSubMenu = IntPtr.Zero;
				this.hbmpChecked = IntPtr.Zero;
				this.hbmpUnchecked = IntPtr.Zero;
				this.dwItemData = IntPtr.Zero;
				this.hbmpItem = IntPtr.Zero;
			}
		}

		private struct STGMEDIUM
		{
			public ShellContextMenu.TYMED tymed;

			public IntPtr hBitmap;

			public IntPtr hMetaFilePict;

			public IntPtr hEnhMetaFile;

			public IntPtr hGlobal;

			public IntPtr lpszFileName;

			public IntPtr pstm;

			public IntPtr pstg;

			public IntPtr pUnkForRelease;
		}

		[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
		private struct POINT
		{
			public int x;

			public int y;

			public POINT(int x, int y)
			{
				this.x = x;
				this.y = y;
			}
		}

		[Flags]
		private enum SHGNO
		{
			NORMAL = 0,
			INFOLDER = 1,
			FOREDITING = 4096,
			FORADDRESSBAR = 16384,
			FORPARSING = 32768
		}

		[Flags]
		private enum SFGAO : uint
		{
			BROWSABLE = 134217728u,
			CANCOPY = 1u,
			CANDELETE = 32u,
			CANLINK = 4u,
			CANMONIKER = 4194304u,
			CANMOVE = 2u,
			CANRENAME = 16u,
			CAPABILITYMASK = 375u,
			COMPRESSED = 67108864u,
			CONTENTSMASK = 2147483648u,
			DISPLAYATTRMASK = 1032192u,
			DROPTARGET = 256u,
			ENCRYPTED = 8192u,
			FILESYSANCESTOR = 268435456u,
			FILESYSTEM = 1073741824u,
			FOLDER = 536870912u,
			GHOSTED = 32768u,
			HASPROPSHEET = 64u,
			HASSTORAGE = 4194304u,
			HASSUBFOLDER = 2147483648u,
			HIDDEN = 524288u,
			ISSLOW = 16384u,
			LINK = 65536u,
			NEWCONTENT = 2097152u,
			NONENUMERATED = 1048576u,
			READONLY = 262144u,
			REMOVABLE = 33554432u,
			SHARE = 131072u,
			STORAGE = 8u,
			STORAGEANCESTOR = 8388608u,
			STORAGECAPMASK = 1891958792u,
			STREAM = 4194304u,
			VALIDATE = 16777216u
		}

		[Flags]
		private enum SHCONTF
		{
			FOLDERS = 32,
			NONFOLDERS = 64,
			INCLUDEHIDDEN = 128,
			INIT_ON_FIRST_NEXT = 256,
			NETPRINTERSRCH = 512,
			SHAREABLE = 1024,
			STORAGE = 2048
		}

		[Flags]
		private enum CMF : uint
		{
			NORMAL = 0u,
			DEFAULTONLY = 1u,
			VERBSONLY = 2u,
			EXPLORE = 4u,
			NOVERBS = 8u,
			CANRENAME = 16u,
			NODEFAULT = 32u,
			INCLUDESTATIC = 64u,
			EXTENDEDVERBS = 256u,
			RESERVED = 4294901760u
		}

		[Flags]
		private enum GCS : uint
		{
			VERBA = 0u,
			HELPTEXTA = 1u,
			VALIDATEA = 2u,
			VERBW = 4u,
			HELPTEXTW = 5u,
			VALIDATEW = 6u
		}

		[Flags]
		private enum TPM : uint
		{
			LEFTBUTTON = 0u,
			RIGHTBUTTON = 2u,
			LEFTALIGN = 0u,
			CENTERALIGN = 4u,
			RIGHTALIGN = 8u,
			TOPALIGN = 0u,
			VCENTERALIGN = 16u,
			BOTTOMALIGN = 32u,
			HORIZONTAL = 0u,
			VERTICAL = 64u,
			NONOTIFY = 128u,
			RETURNCMD = 256u,
			RECURSE = 1u,
			HORPOSANIMATION = 1024u,
			HORNEGANIMATION = 2048u,
			VERPOSANIMATION = 4096u,
			VERNEGANIMATION = 8192u,
			NOANIMATION = 16384u,
			LAYOUTRTL = 32768u
		}

		private enum CMD_CUSTOM
		{
			ExpandCollapse = 30001
		}

		[Flags]
		private enum CMIC : uint
		{
			HOTKEY = 32u,
			ICON = 16u,
			FLAG_NO_UI = 1024u,
			UNICODE = 16384u,
			NO_CONSOLE = 32768u,
			ASYNCOK = 1048576u,
			NOZONECHECKS = 8388608u,
			SHIFT_DOWN = 268435456u,
			CONTROL_DOWN = 1073741824u,
			FLAG_LOG_USAGE = 67108864u,
			PTINVOKE = 536870912u
		}

		[Flags]
		private enum SW
		{
			HIDE = 0,
			SHOWNORMAL = 1,
			NORMAL = 1,
			SHOWMINIMIZED = 2,
			SHOWMAXIMIZED = 3,
			MAXIMIZE = 3,
			SHOWNOACTIVATE = 4,
			SHOW = 5,
			MINIMIZE = 6,
			SHOWMINNOACTIVE = 7,
			SHOWNA = 8,
			RESTORE = 9,
			SHOWDEFAULT = 10
		}

		[Flags]
		private enum WM : uint
		{
			ACTIVATE = 6u,
			ACTIVATEAPP = 28u,
			AFXFIRST = 864u,
			AFXLAST = 895u,
			APP = 32768u,
			ASKCBFORMATNAME = 780u,
			CANCELJOURNAL = 75u,
			CANCELMODE = 31u,
			CAPTURECHANGED = 533u,
			CHANGECBCHAIN = 781u,
			CHAR = 258u,
			CHARTOITEM = 47u,
			CHILDACTIVATE = 34u,
			CLEAR = 771u,
			CLOSE = 16u,
			COMMAND = 273u,
			COMPACTING = 65u,
			COMPAREITEM = 57u,
			CONTEXTMENU = 123u,
			COPY = 769u,
			COPYDATA = 74u,
			CREATE = 1u,
			CTLCOLORBTN = 309u,
			CTLCOLORDLG = 310u,
			CTLCOLOREDIT = 307u,
			CTLCOLORLISTBOX = 308u,
			CTLCOLORMSGBOX = 306u,
			CTLCOLORSCROLLBAR = 311u,
			CTLCOLORSTATIC = 312u,
			CUT = 768u,
			DEADCHAR = 259u,
			DELETEITEM = 45u,
			DESTROY = 2u,
			DESTROYCLIPBOARD = 775u,
			DEVICECHANGE = 537u,
			DEVMODECHANGE = 27u,
			DISPLAYCHANGE = 126u,
			DRAWCLIPBOARD = 776u,
			DRAWITEM = 43u,
			DROPFILES = 563u,
			ENABLE = 10u,
			ENDSESSION = 22u,
			ENTERIDLE = 289u,
			ENTERMENULOOP = 529u,
			ENTERSIZEMOVE = 561u,
			ERASEBKGND = 20u,
			EXITMENULOOP = 530u,
			EXITSIZEMOVE = 562u,
			FONTCHANGE = 29u,
			GETDLGCODE = 135u,
			GETFONT = 49u,
			GETHOTKEY = 51u,
			GETICON = 127u,
			GETMINMAXINFO = 36u,
			GETOBJECT = 61u,
			GETSYSMENU = 787u,
			GETTEXT = 13u,
			GETTEXTLENGTH = 14u,
			HANDHELDFIRST = 856u,
			HANDHELDLAST = 863u,
			HELP = 83u,
			HOTKEY = 786u,
			HSCROLL = 276u,
			HSCROLLCLIPBOARD = 782u,
			ICONERASEBKGND = 39u,
			IME_CHAR = 646u,
			IME_COMPOSITION = 271u,
			IME_COMPOSITIONFULL = 644u,
			IME_CONTROL = 643u,
			IME_ENDCOMPOSITION = 270u,
			IME_KEYDOWN = 656u,
			IME_KEYLAST = 271u,
			IME_KEYUP = 657u,
			IME_NOTIFY = 642u,
			IME_REQUEST = 648u,
			IME_SELECT = 645u,
			IME_SETCONTEXT = 641u,
			IME_STARTCOMPOSITION = 269u,
			INITDIALOG = 272u,
			INITMENU = 278u,
			INITMENUPOPUP = 279u,
			INPUTLANGCHANGE = 81u,
			INPUTLANGCHANGEREQUEST = 80u,
			KEYDOWN = 256u,
			KEYFIRST = 256u,
			KEYLAST = 264u,
			KEYUP = 257u,
			KILLFOCUS = 8u,
			LBUTTONDBLCLK = 515u,
			LBUTTONDOWN = 513u,
			LBUTTONUP = 514u,
			LVM_GETEDITCONTROL = 4120u,
			LVM_SETIMAGELIST = 4099u,
			MBUTTONDBLCLK = 521u,
			MBUTTONDOWN = 519u,
			MBUTTONUP = 520u,
			MDIACTIVATE = 546u,
			MDICASCADE = 551u,
			MDICREATE = 544u,
			MDIDESTROY = 545u,
			MDIGETACTIVE = 553u,
			MDIICONARRANGE = 552u,
			MDIMAXIMIZE = 549u,
			MDINEXT = 548u,
			MDIREFRESHMENU = 564u,
			MDIRESTORE = 547u,
			MDISETMENU = 560u,
			MDITILE = 550u,
			MEASUREITEM = 44u,
			MENUCHAR = 288u,
			MENUCOMMAND = 294u,
			MENUDRAG = 291u,
			MENUGETOBJECT = 292u,
			MENURBUTTONUP = 290u,
			MENUSELECT = 287u,
			MOUSEACTIVATE = 33u,
			MOUSEFIRST = 512u,
			MOUSEHOVER = 673u,
			MOUSELAST = 522u,
			MOUSELEAVE = 675u,
			MOUSEMOVE = 512u,
			MOUSEWHEEL = 522u,
			MOVE = 3u,
			MOVING = 534u,
			NCACTIVATE = 134u,
			NCCALCSIZE = 131u,
			NCCREATE = 129u,
			NCDESTROY = 130u,
			NCHITTEST = 132u,
			NCLBUTTONDBLCLK = 163u,
			NCLBUTTONDOWN = 161u,
			NCLBUTTONUP = 162u,
			NCMBUTTONDBLCLK = 169u,
			NCMBUTTONDOWN = 167u,
			NCMBUTTONUP = 168u,
			NCMOUSEHOVER = 672u,
			NCMOUSELEAVE = 674u,
			NCMOUSEMOVE = 160u,
			NCPAINT = 133u,
			NCRBUTTONDBLCLK = 166u,
			NCRBUTTONDOWN = 164u,
			NCRBUTTONUP = 165u,
			NEXTDLGCTL = 40u,
			NEXTMENU = 531u,
			NOTIFY = 78u,
			NOTIFYFORMAT = 85u,
			NULL = 0u,
			PAINT = 15u,
			PAINTCLIPBOARD = 777u,
			PAINTICON = 38u,
			PALETTECHANGED = 785u,
			PALETTEISCHANGING = 784u,
			PARENTNOTIFY = 528u,
			PASTE = 770u,
			PENWINFIRST = 896u,
			PENWINLAST = 911u,
			POWER = 72u,
			PRINT = 791u,
			PRINTCLIENT = 792u,
			QUERYDRAGICON = 55u,
			QUERYENDSESSION = 17u,
			QUERYNEWPALETTE = 783u,
			QUERYOPEN = 19u,
			QUEUESYNC = 35u,
			QUIT = 18u,
			RBUTTONDBLCLK = 518u,
			RBUTTONDOWN = 516u,
			RBUTTONUP = 517u,
			RENDERALLFORMATS = 774u,
			RENDERFORMAT = 773u,
			SETCURSOR = 32u,
			SETFOCUS = 7u,
			SETFONT = 48u,
			SETHOTKEY = 50u,
			SETICON = 128u,
			SETMARGINS = 211u,
			SETREDRAW = 11u,
			SETTEXT = 12u,
			SETTINGCHANGE = 26u,
			SHOWWINDOW = 24u,
			SIZE = 5u,
			SIZECLIPBOARD = 779u,
			SIZING = 532u,
			SPOOLERSTATUS = 42u,
			STYLECHANGED = 125u,
			STYLECHANGING = 124u,
			SYNCPAINT = 136u,
			SYSCHAR = 262u,
			SYSCOLORCHANGE = 21u,
			SYSCOMMAND = 274u,
			SYSDEADCHAR = 263u,
			SYSKEYDOWN = 260u,
			SYSKEYUP = 261u,
			TCARD = 82u,
			TIMECHANGE = 30u,
			TIMER = 275u,
			TVM_GETEDITCONTROL = 4367u,
			TVM_SETIMAGELIST = 4361u,
			UNDO = 772u,
			UNINITMENUPOPUP = 293u,
			USER = 1024u,
			USERCHANGED = 84u,
			VKEYTOITEM = 46u,
			VSCROLL = 277u,
			VSCROLLCLIPBOARD = 778u,
			WINDOWPOSCHANGED = 71u,
			WINDOWPOSCHANGING = 70u,
			WININICHANGE = 26u,
			SH_NOTIFY = 1025u
		}

		[Flags]
		private enum MFT : uint
		{
			GRAYED = 3u,
			DISABLED = 3u,
			CHECKED = 8u,
			SEPARATOR = 2048u,
			RADIOCHECK = 512u,
			BITMAP = 4u,
			OWNERDRAW = 256u,
			MENUBARBREAK = 32u,
			MENUBREAK = 64u,
			RIGHTORDER = 8192u,
			BYCOMMAND = 0u,
			BYPOSITION = 1024u,
			POPUP = 16u
		}

		[Flags]
		private enum MFS : uint
		{
			GRAYED = 3u,
			DISABLED = 3u,
			CHECKED = 8u,
			HILITE = 128u,
			ENABLED = 0u,
			UNCHECKED = 0u,
			UNHILITE = 0u,
			DEFAULT = 4096u
		}

		[Flags]
		private enum MIIM : uint
		{
			BITMAP = 128u,
			CHECKMARKS = 8u,
			DATA = 32u,
			FTYPE = 256u,
			ID = 2u,
			STATE = 1u,
			STRING = 64u,
			SUBMENU = 4u,
			TYPE = 16u
		}

		[Flags]
		private enum TYMED
		{
			ENHMF = 64,
			FILE = 2,
			GDI = 16,
			HGLOBAL = 1,
			ISTORAGE = 8,
			ISTREAM = 4,
			MFPICT = 32,
			NULL = 0
		}

		[Guid("000214E6-0000-0000-C000-000000000046"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
		[ComImport]
		private interface IShellFolder
		{
			[PreserveSig]
			int ParseDisplayName(IntPtr hwnd, IntPtr pbc, [MarshalAs(UnmanagedType.LPWStr)] string pszDisplayName, ref uint pchEaten, out IntPtr ppidl, ref ShellContextMenu.SFGAO pdwAttributes);

			[PreserveSig]
			int EnumObjects(IntPtr hwnd, ShellContextMenu.SHCONTF grfFlags, out IntPtr enumIDList);

			[PreserveSig]
			int BindToObject(IntPtr pidl, IntPtr pbc, ref Guid riid, out IntPtr ppv);

			[PreserveSig]
			int BindToStorage(IntPtr pidl, IntPtr pbc, ref Guid riid, out IntPtr ppv);

			[PreserveSig]
			int CompareIDs(IntPtr lParam, IntPtr pidl1, IntPtr pidl2);

			[PreserveSig]
			int CreateViewObject(IntPtr hwndOwner, Guid riid, out IntPtr ppv);

			[PreserveSig]
			int GetAttributesOf(uint cidl, [MarshalAs(UnmanagedType.LPArray)] IntPtr[] apidl, ref ShellContextMenu.SFGAO rgfInOut);

			[PreserveSig]
			int GetUIObjectOf(IntPtr hwndOwner, uint cidl, [MarshalAs(UnmanagedType.LPArray)] IntPtr[] apidl, ref Guid riid, IntPtr rgfReserved, out IntPtr ppv);

			[PreserveSig]
			int GetDisplayNameOf(IntPtr pidl, ShellContextMenu.SHGNO uFlags, IntPtr lpName);

			[PreserveSig]
			int SetNameOf(IntPtr hwnd, IntPtr pidl, [MarshalAs(UnmanagedType.LPWStr)] string pszName, ShellContextMenu.SHGNO uFlags, out IntPtr ppidlOut);
		}

		[Guid("000214e4-0000-0000-c000-000000000046"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
		[ComImport]
		private interface IContextMenu
		{
			[PreserveSig]
			int QueryContextMenu(IntPtr hmenu, uint iMenu, uint idCmdFirst, uint idCmdLast, ShellContextMenu.CMF uFlags);

			[PreserveSig]
			int InvokeCommand(ref ShellContextMenu.CMINVOKECOMMANDINFOEX info);

			[PreserveSig]
			int GetCommandString(uint idcmd, ShellContextMenu.GCS uflags, uint reserved, [MarshalAs(UnmanagedType.LPArray)] byte[] commandstring, int cch);
		}

		[Guid("000214f4-0000-0000-c000-000000000046"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
		[ComImport]
		private interface IContextMenu2
		{
			[PreserveSig]
			int QueryContextMenu(IntPtr hmenu, uint iMenu, uint idCmdFirst, uint idCmdLast, ShellContextMenu.CMF uFlags);

			[PreserveSig]
			int InvokeCommand(ref ShellContextMenu.CMINVOKECOMMANDINFOEX info);

			[PreserveSig]
			int GetCommandString(uint idcmd, ShellContextMenu.GCS uflags, uint reserved, [MarshalAs(UnmanagedType.LPWStr)] StringBuilder commandstring, int cch);

			[PreserveSig]
			int HandleMenuMsg(uint uMsg, IntPtr wParam, IntPtr lParam);
		}

		[Guid("bcfce0a0-ec17-11d0-8d10-00a0c90f2719"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
		[ComImport]
		private interface IContextMenu3
		{
			[PreserveSig]
			int QueryContextMenu(IntPtr hmenu, uint iMenu, uint idCmdFirst, uint idCmdLast, ShellContextMenu.CMF uFlags);

			[PreserveSig]
			int InvokeCommand(ref ShellContextMenu.CMINVOKECOMMANDINFOEX info);

			[PreserveSig]
			int GetCommandString(uint idcmd, ShellContextMenu.GCS uflags, uint reserved, [MarshalAs(UnmanagedType.LPWStr)] StringBuilder commandstring, int cch);

			[PreserveSig]
			int HandleMenuMsg(uint uMsg, IntPtr wParam, IntPtr lParam);

			[PreserveSig]
			int HandleMenuMsg2(uint uMsg, IntPtr wParam, IntPtr lParam, IntPtr plResult);
		}

		private const int MAX_PATH = 260;

		private const uint CMD_FIRST = 1u;

		private const uint CMD_LAST = 30000u;

		private const int S_OK = 0;

		private const int S_FALSE = 1;

		private ShellContextMenu.IContextMenu _oContextMenu;

		private ShellContextMenu.IContextMenu2 _oContextMenu2;

		private ShellContextMenu.IContextMenu3 _oContextMenu3;

		private ShellContextMenu.IShellFolder _oDesktopFolder;

		private ShellContextMenu.IShellFolder _oParentFolder;

		private IntPtr[] _arrPIDLs;

		private string _strParentFolder;

		private static int cbMenuItemInfo = Marshal.SizeOf(typeof(ShellContextMenu.MENUITEMINFO));

		private static int cbInvokeCommand = Marshal.SizeOf(typeof(ShellContextMenu.CMINVOKECOMMANDINFOEX));

		private static Guid IID_IShellFolder = new Guid("{000214E6-0000-0000-C000-000000000046}");

		private static Guid IID_IContextMenu = new Guid("{000214e4-0000-0000-c000-000000000046}");

		private static Guid IID_IContextMenu2 = new Guid("{000214f4-0000-0000-c000-000000000046}");

		private static Guid IID_IContextMenu3 = new Guid("{bcfce0a0-ec17-11d0-8d10-00a0c90f2719}");

		public ShellContextMenu()
		{
			this.CreateHandle(new CreateParams());
		}

		~ShellContextMenu()
		{
			this.ReleaseAll();
		}

		private bool GetContextMenuInterfaces(ShellContextMenu.IShellFolder oParentFolder, IntPtr[] arrPIDLs, out IntPtr ctxMenuPtr)
		{
			int uIObjectOf = oParentFolder.GetUIObjectOf(IntPtr.Zero, (uint)arrPIDLs.Length, arrPIDLs, ref ShellContextMenu.IID_IContextMenu, IntPtr.Zero, out ctxMenuPtr);
			bool result;
			if (0 == uIObjectOf)
			{
				this._oContextMenu = (ShellContextMenu.IContextMenu)Marshal.GetTypedObjectForIUnknown(ctxMenuPtr, typeof(ShellContextMenu.IContextMenu));
				result = true;
			}
			else
			{
				ctxMenuPtr = IntPtr.Zero;
				this._oContextMenu = null;
				result = false;
			}
			return result;
		}

		protected override void WndProc(ref Message m)
		{
			if (this._oContextMenu != null && m.Msg == 287 && (ShellHelper.HiWord(m.WParam) & 2048u) == 0u && (ShellHelper.HiWord(m.WParam) & 16u) == 0u)
			{
				string empty = string.Empty;
				if (ShellHelper.LoWord(m.WParam) == 30001u)
				{
				}
			}
			if (this._oContextMenu2 != null && (m.Msg == 279 || m.Msg == 44 || m.Msg == 43))
			{
				if (this._oContextMenu2.HandleMenuMsg((uint)m.Msg, m.WParam, m.LParam) == 0)
				{
					return;
				}
			}
			if (this._oContextMenu3 != null && m.Msg == 288)
			{
				if (this._oContextMenu3.HandleMenuMsg2((uint)m.Msg, m.WParam, m.LParam, IntPtr.Zero) == 0)
				{
					return;
				}
			}
			base.WndProc(ref m);
		}

		private void InvokeCommand(ShellContextMenu.IContextMenu oContextMenu, uint nCmd, string strFolder, Point pointInvoke)
		{
			ShellContextMenu.CMINVOKECOMMANDINFOEX cMINVOKECOMMANDINFOEX = default(ShellContextMenu.CMINVOKECOMMANDINFOEX);
			cMINVOKECOMMANDINFOEX.cbSize = ShellContextMenu.cbInvokeCommand;
			cMINVOKECOMMANDINFOEX.lpVerb = (IntPtr)((long)((ulong)(nCmd - 1u)));
			cMINVOKECOMMANDINFOEX.lpDirectory = strFolder;
			cMINVOKECOMMANDINFOEX.lpVerbW = (IntPtr)((long)((ulong)(nCmd - 1u)));
			cMINVOKECOMMANDINFOEX.lpDirectoryW = strFolder;
			cMINVOKECOMMANDINFOEX.fMask = (ShellContextMenu.CMIC.UNICODE | ShellContextMenu.CMIC.PTINVOKE | (((Control.ModifierKeys & Keys.Control) != Keys.None) ? ShellContextMenu.CMIC.CONTROL_DOWN : ((ShellContextMenu.CMIC)0u)) | (((Control.ModifierKeys & Keys.Shift) != Keys.None) ? ShellContextMenu.CMIC.SHIFT_DOWN : ((ShellContextMenu.CMIC)0u)));
			cMINVOKECOMMANDINFOEX.ptInvoke = new ShellContextMenu.POINT(pointInvoke.X, pointInvoke.Y);
			cMINVOKECOMMANDINFOEX.nShow = ShellContextMenu.SW.SHOWNORMAL;
			oContextMenu.InvokeCommand(ref cMINVOKECOMMANDINFOEX);
		}

		private void ReleaseAll()
		{
			if (null != this._oContextMenu)
			{
				Marshal.ReleaseComObject(this._oContextMenu);
				this._oContextMenu = null;
			}
			if (null != this._oContextMenu2)
			{
				Marshal.ReleaseComObject(this._oContextMenu2);
				this._oContextMenu2 = null;
			}
			if (null != this._oContextMenu3)
			{
				Marshal.ReleaseComObject(this._oContextMenu3);
				this._oContextMenu3 = null;
			}
			if (null != this._oDesktopFolder)
			{
				Marshal.ReleaseComObject(this._oDesktopFolder);
				this._oDesktopFolder = null;
			}
			if (null != this._oParentFolder)
			{
				Marshal.ReleaseComObject(this._oParentFolder);
				this._oParentFolder = null;
			}
			if (null != this._arrPIDLs)
			{
				this.FreePIDLs(this._arrPIDLs);
				this._arrPIDLs = null;
			}
		}

		private ShellContextMenu.IShellFolder GetDesktopFolder()
		{
			IntPtr zero = IntPtr.Zero;
			if (null == this._oDesktopFolder)
			{
				int num = ShellContextMenu.SHGetDesktopFolder(out zero);
				if (0 != num)
				{
					throw new ShellContextMenuException("Failed to get the desktop shell folder");
				}
				this._oDesktopFolder = (ShellContextMenu.IShellFolder)Marshal.GetTypedObjectForIUnknown(zero, typeof(ShellContextMenu.IShellFolder));
			}
			return this._oDesktopFolder;
		}

		private ShellContextMenu.IShellFolder GetParentFolder(string folderName)
		{
			ShellContextMenu.IShellFolder result;
			if (null == this._oParentFolder)
			{
				ShellContextMenu.IShellFolder desktopFolder = this.GetDesktopFolder();
				if (null == desktopFolder)
				{
					result = null;
					return result;
				}
				IntPtr zero = IntPtr.Zero;
				uint num = 0u;
				ShellContextMenu.SFGAO sFGAO = (ShellContextMenu.SFGAO)0u;
				int num2 = desktopFolder.ParseDisplayName(IntPtr.Zero, IntPtr.Zero, folderName, ref num, out zero, ref sFGAO);
				if (0 != num2)
				{
					result = null;
					return result;
				}
				IntPtr intPtr = Marshal.AllocCoTaskMem(524);
				Marshal.WriteInt32(intPtr, 0, 0);
				num2 = this._oDesktopFolder.GetDisplayNameOf(zero, ShellContextMenu.SHGNO.FORPARSING, intPtr);
				StringBuilder stringBuilder = new StringBuilder(260);
				ShellContextMenu.StrRetToBuf(intPtr, zero, stringBuilder, 260);
				Marshal.FreeCoTaskMem(intPtr);
				intPtr = IntPtr.Zero;
				this._strParentFolder = stringBuilder.ToString();
				IntPtr zero2 = IntPtr.Zero;
				num2 = desktopFolder.BindToObject(zero, IntPtr.Zero, ref ShellContextMenu.IID_IShellFolder, out zero2);
				Marshal.FreeCoTaskMem(zero);
				if (0 != num2)
				{
					result = null;
					return result;
				}
				this._oParentFolder = (ShellContextMenu.IShellFolder)Marshal.GetTypedObjectForIUnknown(zero2, typeof(ShellContextMenu.IShellFolder));
			}
			result = this._oParentFolder;
			return result;
		}

		protected IntPtr[] GetPIDLs(FileInfo[] arrFI)
		{
			IntPtr[] result;
			if (arrFI == null || 0 == arrFI.Length)
			{
				result = null;
			}
			else
			{
				ShellContextMenu.IShellFolder parentFolder = this.GetParentFolder(arrFI[0].DirectoryName);
				if (null == parentFolder)
				{
					result = null;
				}
				else
				{
					IntPtr[] array = new IntPtr[arrFI.Length];
					int num = 0;
					for (int i = 0; i < arrFI.Length; i++)
					{
						FileInfo fileInfo = arrFI[i];
						uint num2 = 0u;
						ShellContextMenu.SFGAO sFGAO = (ShellContextMenu.SFGAO)0u;
						IntPtr zero = IntPtr.Zero;
						int num3 = parentFolder.ParseDisplayName(IntPtr.Zero, IntPtr.Zero, fileInfo.Name, ref num2, out zero, ref sFGAO);
						if (0 != num3)
						{
							this.FreePIDLs(array);
							result = null;
							return result;
						}
						array[num] = zero;
						num++;
					}
					result = array;
				}
			}
			return result;
		}

		protected IntPtr[] GetPIDLs(DirectoryInfo[] arrFI)
		{
			IntPtr[] result;
			if (arrFI == null || 0 == arrFI.Length)
			{
				result = null;
			}
			else
			{
				ShellContextMenu.IShellFolder parentFolder = this.GetParentFolder(arrFI[0].Parent.FullName);
				if (null == parentFolder)
				{
					result = null;
				}
				else
				{
					IntPtr[] array = new IntPtr[arrFI.Length];
					int num = 0;
					for (int i = 0; i < arrFI.Length; i++)
					{
						DirectoryInfo directoryInfo = arrFI[i];
						uint num2 = 0u;
						ShellContextMenu.SFGAO sFGAO = (ShellContextMenu.SFGAO)0u;
						IntPtr zero = IntPtr.Zero;
						int num3 = parentFolder.ParseDisplayName(IntPtr.Zero, IntPtr.Zero, directoryInfo.Name, ref num2, out zero, ref sFGAO);
						if (0 != num3)
						{
							this.FreePIDLs(array);
							result = null;
							return result;
						}
						array[num] = zero;
						num++;
					}
					result = array;
				}
			}
			return result;
		}

		protected void FreePIDLs(IntPtr[] arrPIDLs)
		{
			if (null != arrPIDLs)
			{
				for (int i = 0; i < arrPIDLs.Length; i++)
				{
					if (arrPIDLs[i] != IntPtr.Zero)
					{
						Marshal.FreeCoTaskMem(arrPIDLs[i]);
						arrPIDLs[i] = IntPtr.Zero;
					}
				}
			}
		}

		private void InvokeContextMenuDefault(FileInfo[] arrFI)
		{
			this.ReleaseAll();
			IntPtr intPtr = IntPtr.Zero;
			IntPtr zero = IntPtr.Zero;
			try
			{
				this._arrPIDLs = this.GetPIDLs(arrFI);
				if (null == this._arrPIDLs)
				{
					this.ReleaseAll();
				}
				else if (!this.GetContextMenuInterfaces(this._oParentFolder, this._arrPIDLs, out zero))
				{
					this.ReleaseAll();
				}
				else
				{
					intPtr = ShellContextMenu.CreatePopupMenu();
					int num = this._oContextMenu.QueryContextMenu(intPtr, 0u, 1u, 30000u, ShellContextMenu.CMF.DEFAULTONLY | (((Control.ModifierKeys & Keys.Shift) != Keys.None) ? ShellContextMenu.CMF.EXTENDEDVERBS : ShellContextMenu.CMF.NORMAL));
					uint menuDefaultItem = (uint)ShellContextMenu.GetMenuDefaultItem(intPtr, false, 0u);
					if (menuDefaultItem >= 1u)
					{
						this.InvokeCommand(this._oContextMenu, menuDefaultItem, arrFI[0].DirectoryName, Control.MousePosition);
					}
					ShellContextMenu.DestroyMenu(intPtr);
					intPtr = IntPtr.Zero;
				}
			}
			catch
			{
				throw;
			}
			finally
			{
				if (intPtr != IntPtr.Zero)
				{
					ShellContextMenu.DestroyMenu(intPtr);
				}
				this.ReleaseAll();
			}
		}

		public int ShowContextMenu(FileInfo[] files, Point pointScreen, string[] AddedItems)
		{
			this.ReleaseAll();
			this._arrPIDLs = this.GetPIDLs(files);
			return this.ShowContextMenu(pointScreen, AddedItems);
		}

		public int ShowContextMenu(DirectoryInfo[] dirs, Point pointScreen, string[] AddedItems)
		{
			this.ReleaseAll();
			this._arrPIDLs = this.GetPIDLs(dirs);
			return this.ShowContextMenu(pointScreen, AddedItems);
		}

		public void ShowContextMenu(Point pointScreen)
		{
			IntPtr intPtr = IntPtr.Zero;
			IntPtr zero = IntPtr.Zero;
			IntPtr zero2 = IntPtr.Zero;
			IntPtr zero3 = IntPtr.Zero;
			try
			{
				if (null == this._arrPIDLs)
				{
					this.ReleaseAll();
				}
				else if (!this.GetContextMenuInterfaces(this._oParentFolder, this._arrPIDLs, out zero))
				{
					this.ReleaseAll();
				}
				else
				{
					intPtr = ShellContextMenu.CreatePopupMenu();
					int num = this._oContextMenu.QueryContextMenu(intPtr, 0u, 1u, 30000u, ShellContextMenu.CMF.EXPLORE | (((Control.ModifierKeys & Keys.Shift) != Keys.None) ? ShellContextMenu.CMF.EXTENDEDVERBS : ShellContextMenu.CMF.NORMAL));
					Marshal.QueryInterface(zero, ref ShellContextMenu.IID_IContextMenu2, out zero2);
					Marshal.QueryInterface(zero, ref ShellContextMenu.IID_IContextMenu3, out zero3);
					this._oContextMenu2 = (ShellContextMenu.IContextMenu2)Marshal.GetTypedObjectForIUnknown(zero2, typeof(ShellContextMenu.IContextMenu2));
					this._oContextMenu3 = (ShellContextMenu.IContextMenu3)Marshal.GetTypedObjectForIUnknown(zero3, typeof(ShellContextMenu.IContextMenu3));
					uint num2 = ShellContextMenu.TrackPopupMenuEx(intPtr, ShellContextMenu.TPM.RETURNCMD, pointScreen.X, pointScreen.Y, base.Handle, IntPtr.Zero);
					ShellContextMenu.DestroyMenu(intPtr);
					intPtr = IntPtr.Zero;
					if (num2 != 0u)
					{
						this.InvokeCommand(this._oContextMenu, num2, this._strParentFolder, pointScreen);
					}
				}
			}
			catch
			{
				throw;
			}
			finally
			{
				if (intPtr != IntPtr.Zero)
				{
					ShellContextMenu.DestroyMenu(intPtr);
				}
				if (zero != IntPtr.Zero)
				{
					Marshal.Release(zero);
				}
				if (zero2 != IntPtr.Zero)
				{
					Marshal.Release(zero2);
				}
				if (zero3 != IntPtr.Zero)
				{
					Marshal.Release(zero3);
				}
				this.ReleaseAll();
			}
		}

		public int ShowContextMenu(Point pointScreen, string[] AddedItems)
		{
			IntPtr intPtr = IntPtr.Zero;
			IntPtr zero = IntPtr.Zero;
			IntPtr zero2 = IntPtr.Zero;
			IntPtr zero3 = IntPtr.Zero;
			int num = -1;
			int result;
			try
			{
				if (null == this._arrPIDLs)
				{
					this.ReleaseAll();
					result = -2;
				}
				else if (!this.GetContextMenuInterfaces(this._oParentFolder, this._arrPIDLs, out zero))
				{
					this.ReleaseAll();
					result = -2;
				}
				else
				{
					intPtr = ShellContextMenu.CreatePopupMenu();
					int num2 = this._oContextMenu.QueryContextMenu(intPtr, 0u, 1u, 30000u, ShellContextMenu.CMF.EXPLORE | (((Control.ModifierKeys & Keys.Shift) != Keys.None) ? ShellContextMenu.CMF.EXTENDEDVERBS : ShellContextMenu.CMF.NORMAL));
					Marshal.QueryInterface(zero, ref ShellContextMenu.IID_IContextMenu2, out zero2);
					Marshal.QueryInterface(zero, ref ShellContextMenu.IID_IContextMenu3, out zero3);
					this._oContextMenu2 = (ShellContextMenu.IContextMenu2)Marshal.GetTypedObjectForIUnknown(zero2, typeof(ShellContextMenu.IContextMenu2));
					this._oContextMenu3 = (ShellContextMenu.IContextMenu3)Marshal.GetTypedObjectForIUnknown(zero3, typeof(ShellContextMenu.IContextMenu3));
					for (int i = 0; i < AddedItems.Length; i++)
					{
						ShellAPI.InsertMenu(intPtr, (uint)i, ShellAPI.MFT.BYPOSITION, (uint)(30001 + i), AddedItems[i]);
					}
					ShellAPI.InsertMenu(intPtr, (uint)AddedItems.Length, ShellAPI.MFT.SEPARATOR | ShellAPI.MFT.BYPOSITION, (uint)(30001 + AddedItems.Length), "-");
					uint num3 = ShellContextMenu.TrackPopupMenuEx(intPtr, ShellContextMenu.TPM.RETURNCMD, pointScreen.X, pointScreen.Y, base.Handle, IntPtr.Zero);
					ShellContextMenu.DestroyMenu(intPtr);
					intPtr = IntPtr.Zero;
					if (AddedItems.Length > 0 && num3 >= 30001u && (ulong)num3 <= (ulong)((long)(AddedItems.Length - 1 + 30001)))
					{
						num = (int)(num3 - 30001u);
					}
					else if (num3 != 0u)
					{
						this.InvokeCommand(this._oContextMenu, num3, this._strParentFolder, pointScreen);
					}
					result = num;
				}
			}
			catch
			{
				Console.WriteLine("Error in Context Menu generation");
				result = -1;
			}
			finally
			{
				if (intPtr != IntPtr.Zero)
				{
					ShellContextMenu.DestroyMenu(intPtr);
				}
				if (zero != IntPtr.Zero)
				{
					Marshal.Release(zero);
				}
				if (zero2 != IntPtr.Zero)
				{
					Marshal.Release(zero2);
				}
				if (zero3 != IntPtr.Zero)
				{
					Marshal.Release(zero3);
				}
				this.ReleaseAll();
			}
			return result;
		}

		private void WindowsHookInvoked(object sender, HookEventArgs e)
		{
			ShellContextMenu.CWPSTRUCT cWPSTRUCT = (ShellContextMenu.CWPSTRUCT)Marshal.PtrToStructure(e.lParam, typeof(ShellContextMenu.CWPSTRUCT));
			if (this._oContextMenu2 != null && (cWPSTRUCT.message == 279 || cWPSTRUCT.message == 44 || cWPSTRUCT.message == 43))
			{
				if (this._oContextMenu2.HandleMenuMsg((uint)cWPSTRUCT.message, cWPSTRUCT.wparam, cWPSTRUCT.lparam) == 0)
				{
					return;
				}
			}
			if (this._oContextMenu3 != null && cWPSTRUCT.message == 288)
			{
				if (this._oContextMenu3.HandleMenuMsg2((uint)cWPSTRUCT.message, cWPSTRUCT.wparam, cWPSTRUCT.lparam, IntPtr.Zero) == 0)
				{
				}
			}
		}

		[DllImport("shell32.dll")]
		private static extern int SHGetDesktopFolder(out IntPtr ppshf);

		[DllImport("shlwapi.dll", CharSet = CharSet.Auto, SetLastError = true)]
		private static extern int StrRetToBuf(IntPtr pstr, IntPtr pidl, StringBuilder pszBuf, int cchBuf);

		[DllImport("user32.dll", CharSet = CharSet.Auto, ExactSpelling = true)]
		private static extern uint TrackPopupMenuEx(IntPtr hmenu, ShellContextMenu.TPM flags, int x, int y, IntPtr hwnd, IntPtr lptpm);

		[DllImport("user32", CharSet = CharSet.Auto, SetLastError = true)]
		private static extern IntPtr CreatePopupMenu();

		[DllImport("user32", CharSet = CharSet.Auto, SetLastError = true)]
		private static extern bool DestroyMenu(IntPtr hMenu);

		[DllImport("user32", CharSet = CharSet.Auto, SetLastError = true)]
		private static extern int GetMenuDefaultItem(IntPtr hMenu, bool fByPos, uint gmdiFlags);
	}
}
