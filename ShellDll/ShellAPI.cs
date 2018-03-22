using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Text;

namespace ShellDll
{
	public static class ShellAPI
	{
		[StructLayout(LayoutKind.Explicit)]
		public struct STRRET
		{
			[FieldOffset(0)]
			public uint uType;

			[FieldOffset(4)]
			public IntPtr pOleStr;

			[FieldOffset(4)]
			public IntPtr pStr;

			[FieldOffset(4)]
			public uint uOffset;

			[FieldOffset(4)]
			public IntPtr cStr;
		}

		[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
		public struct SHFILEINFO
		{
			public IntPtr hIcon;

			public int iIcon;

			public ShellAPI.SFGAO dwAttributes;

			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 260)]
			public string szDisplayName;

			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 80)]
			public string szTypeName;
		}

		[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
		public struct CMINVOKECOMMANDINFOEX
		{
			public int cbSize;

			public ShellAPI.CMIC fMask;

			public IntPtr hwnd;

			public IntPtr lpVerb;

			[MarshalAs(UnmanagedType.LPStr)]
			public string lpParameters;

			[MarshalAs(UnmanagedType.LPStr)]
			public string lpDirectory;

			public ShellAPI.SW nShow;

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

			public ShellAPI.POINT ptInvoke;
		}

		[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
		public struct MENUITEMINFO
		{
			public int cbSize;

			public ShellAPI.MIIM fMask;

			public ShellAPI.MFT fType;

			public ShellAPI.MFS fState;

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
				this.cbSize = ShellAPI.cbMenuItemInfo;
				this.dwTypeData = text;
				this.cch = text.Length;
				this.fMask = (ShellAPI.MIIM)0u;
				this.fType = ShellAPI.MFT.BYCOMMAND;
				this.fState = ShellAPI.MFS.ENABLED;
				this.wID = 0u;
				this.hSubMenu = IntPtr.Zero;
				this.hbmpChecked = IntPtr.Zero;
				this.hbmpUnchecked = IntPtr.Zero;
				this.dwItemData = IntPtr.Zero;
				this.hbmpItem = IntPtr.Zero;
			}
		}

		[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
		public struct TPMPARAMS
		{
			private int cbSize;

			private ShellAPI.RECT rcExclude;
		}

		public struct COMBOBOXINFO
		{
			public int cbSize;

			public ShellAPI.RECT rcItem;

			public ShellAPI.RECT rcButton;

			public IntPtr stateButton;

			public IntPtr hwndCombo;

			public IntPtr hwndEdit;

			public IntPtr hwndList;
		}

		[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
		public struct FORMATETC
		{
			public ShellAPI.CF cfFormat;

			public IntPtr ptd;

			public ShellAPI.DVASPECT dwAspect;

			public int lindex;

			public ShellAPI.TYMED Tymd;
		}

		public struct STGMEDIUM
		{
			public ShellAPI.TYMED tymed;

			public IntPtr hBitmap;

			public IntPtr hMetaFilePict;

			public IntPtr hEnhMetaFile;

			public IntPtr hGlobal;

			public IntPtr lpszFileName;

			public IntPtr pstm;

			public IntPtr pstg;

			public IntPtr pUnkForRelease;
		}

		public struct SHDRAGIMAGE
		{
			public ShellAPI.SIZE sizeDragImage;

			public ShellAPI.POINT ptOffset;

			public IntPtr hbmpDragImage;

			public Color crColorKey;
		}

		[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
		public struct SHChangeNotifyEntry
		{
			public IntPtr pIdl;

			public bool Recursively;
		}

		public struct SHNOTIFYSTRUCT
		{
			public IntPtr dwItem1;

			public IntPtr dwItem2;
		}

		public struct STATSTG
		{
			[MarshalAs(UnmanagedType.LPWStr)]
			public string pwcsName;

			public ShellAPI.STGTY type;

			public long cbSize;

			public ShellAPI.FILETIME mtime;

			public ShellAPI.FILETIME ctime;

			public ShellAPI.FILETIME atime;

			public ShellAPI.STGM grfMode;

			public ShellAPI.LOCKTYPE grfLocksSupported;

			public Guid clsid;

			public int grfStateBits;

			public int reserved;
		}

		public struct FILETIME
		{
			public int dwLowDateTime;

			public int dwHighDateTime;
		}

		[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
		public struct POINT
		{
			public int x;

			public int y;

			public POINT(int x, int y)
			{
				this.x = x;
				this.y = y;
			}
		}

		[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
		public struct RECT
		{
			private int left;

			private int top;

			private int right;

			private int bottom;

			public RECT(Rectangle rect)
			{
				this.left = rect.Left;
				this.top = rect.Top;
				this.right = rect.Right;
				this.bottom = rect.Bottom;
			}
		}

		[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
		public struct SIZE
		{
			public int cx;

			public int cy;
		}

		public enum CSIDL
		{
			ADMINTOOLS = 48,
			ALTSTARTUP = 29,
			APPDATA = 26,
			BITBUCKET = 10,
			CDBURN_AREA = 59,
			COMMON_ADMINTOOLS = 47,
			COMMON_ALTSTARTUP = 30,
			COMMON_APPDATA = 35,
			COMMON_DESKTOPDIRECTORY = 25,
			COMMON_DOCUMENTS = 46,
			COMMON_FAVORITES = 31,
			COMMON_MUSIC = 53,
			COMMON_PICTURES,
			COMMON_PROGRAMS = 23,
			COMMON_STARTMENU = 22,
			COMMON_STARTUP = 24,
			COMMON_TEMPLATES = 45,
			COMMON_VIDEO = 55,
			CONTROLS = 3,
			COOKIES = 33,
			DESKTOP = 0,
			DESKTOPDIRECTORY = 16,
			DRIVES,
			FAVORITES = 6,
			FLAG_CREATE = 32768,
			FONTS = 20,
			HISTORY = 34,
			INTERNET = 1,
			INTERNET_CACHE = 32,
			LOCAL_APPDATA = 28,
			MYDOCUMENTS = 12,
			MYMUSIC,
			MYPICTURES = 39,
			MYVIDEO = 14,
			NETHOOD = 19,
			NETWORK = 18,
			PERSONAL = 5,
			PRINTERS = 4,
			PRINTHOOD = 27,
			PROFILE = 40,
			PROFILES = 62,
			PROGRAM_FILES = 38,
			PROGRAM_FILES_COMMON = 43,
			PROGRAMS = 2,
			RECENT = 8,
			SENDTO,
			STARTMENU = 11,
			STARTUP = 7,
			SYSTEM = 37,
			TEMPLATES = 21,
			WINDOWS = 36
		}

		[Flags]
		public enum SHGNO
		{
			NORMAL = 0,
			INFOLDER = 1,
			FOREDITING = 4096,
			FORADDRESSBAR = 16384,
			FORPARSING = 32768
		}

		[Flags]
		public enum SHGFP
		{
			TYPE_CURRENT = 0,
			TYPE_DEFAULT = 1
		}

		[Flags]
		public enum SFGAO : uint
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
		public enum SHCONTF
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
		public enum CMF : uint
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
		public enum GCS : uint
		{
			VERBA = 0u,
			HELPTEXTA = 1u,
			VALIDATEA = 2u,
			VERBW = 4u,
			HELPTEXTW = 5u,
			VALIDATEW = 6u
		}

		[Flags]
		public enum SHGFI : uint
		{
			ADDOVERLAYS = 32u,
			ATTR_SPECIFIED = 131072u,
			ATTRIBUTES = 2048u,
			DISPLAYNAME = 512u,
			EXETYPE = 8192u,
			ICON = 256u,
			ICONLOCATION = 4096u,
			LARGEICON = 0u,
			LINKOVERLAY = 32768u,
			OPENICON = 2u,
			OVERLAYINDEX = 64u,
			PIDL = 8u,
			SELECTED = 65536u,
			SHELLICONSIZE = 4u,
			SMALLICON = 1u,
			SYSICONINDEX = 16384u,
			TYPENAME = 1024u,
			USEFILEATTRIBUTES = 16u
		}

		[Flags]
		public enum FILE_ATTRIBUTE
		{
			READONLY = 1,
			HIDDEN = 2,
			SYSTEM = 4,
			DIRECTORY = 16,
			ARCHIVE = 32,
			DEVICE = 64,
			NORMAL = 128,
			TEMPORARY = 256,
			SPARSE_FILE = 512,
			REPARSE_POINT = 1024,
			COMPRESSED = 2048,
			OFFLINE = 4096,
			NOT_CONTENT_INDEXED = 8192,
			ENCRYPTED = 16384
		}

		[Flags]
		public enum TPM : uint
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

		[Flags]
		public enum CMIC : uint
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
		public enum ILD : uint
		{
			NORMAL = 0u,
			TRANSPARENT = 1u,
			MASK = 16u,
			BLEND25 = 2u,
			BLEND50 = 4u
		}

		[Flags]
		public enum SW
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
		public enum WM : uint
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
		public enum MFT : uint
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
		public enum MFS : uint
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
		public enum MIIM : uint
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

		public enum CF
		{
			BITMAP = 2,
			DIB = 8,
			DIF = 5,
			DSPBITMAP = 130,
			DSPENHMETAFILE = 142,
			DSPMETAFILEPICT = 131,
			DSPTEXT = 129,
			ENHMETAFILE = 14,
			GDIOBJFIRST = 768,
			GDIOBJLAST = 1023,
			HDROP = 15,
			LOCALE,
			MAX,
			METAFILEPICT = 3,
			OEMTEXT = 7,
			OWNERDISPLAY = 128,
			PALETTE = 9,
			PENDATA,
			PRIVATEFIRST = 512,
			PRIVATELAST = 767,
			RIFF = 11,
			SYLK = 4,
			TEXT = 1,
			TIFF = 6,
			UNICODETEXT = 13,
			WAVE = 12
		}

		[Flags]
		public enum DVASPECT
		{
			CONTENT = 1,
			DOCPRINT = 8,
			ICON = 4,
			THUMBNAIL = 2
		}

		[Flags]
		public enum TYMED
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

		[Flags]
		public enum ADVF
		{
			CACHE_FORCEBUILTIN = 16,
			CACHE_NOHANDLER = 8,
			CACHE_ONSAVE = 32,
			DATAONSTOP = 64,
			NODATA = 1,
			ONLYONCE = 4,
			PRIMEFIRST = 2
		}

		[Flags]
		public enum MK
		{
			LBUTTON = 1,
			RBUTTON = 2,
			SHIFT = 4,
			CONTROL = 8,
			MBUTTON = 16,
			ALT = 32
		}

		[Flags]
		public enum CLSCTX : uint
		{
			INPROC_SERVER = 1u,
			INPROC_HANDLER = 2u,
			LOCAL_SERVER = 4u,
			INPROC_SERVER16 = 8u,
			REMOTE_SERVER = 16u,
			INPROC_HANDLER16 = 32u,
			RESERVED1 = 64u,
			RESERVED2 = 128u,
			RESERVED3 = 256u,
			RESERVED4 = 512u,
			NO_CODE_DOWNLOAD = 1024u,
			RESERVED5 = 2048u,
			NO_CUSTOM_MARSHAL = 4096u,
			ENABLE_CODE_DOWNLOAD = 8192u,
			NO_FAILURE_LOG = 16384u,
			DISABLE_AAA = 32768u,
			ENABLE_AAA = 65536u,
			FROM_DEFAULT_CONTEXT = 131072u,
			INPROC = 3u,
			SERVER = 21u,
			ALL = 23u
		}

		[Flags]
		public enum SHCNE : uint
		{
			RENAMEITEM = 1u,
			CREATE = 2u,
			DELETE = 4u,
			MKDIR = 8u,
			RMDIR = 16u,
			MEDIAINSERTED = 32u,
			MEDIAREMOVED = 64u,
			DRIVEREMOVED = 128u,
			DRIVEADD = 256u,
			NETSHARE = 512u,
			NETUNSHARE = 1024u,
			ATTRIBUTES = 2048u,
			UPDATEDIR = 4096u,
			UPDATEITEM = 8192u,
			SERVERDISCONNECT = 16384u,
			UPDATEIMAGE = 32768u,
			DRIVEADDGUI = 65536u,
			RENAMEFOLDER = 131072u,
			FREESPACE = 262144u,
			EXTENDED_EVENT = 67108864u,
			ASSOCCHANGED = 134217728u,
			DISKEVENTS = 145439u,
			GLOBALEVENTS = 201687520u,
			ALLEVENTS = 2147483647u,
			INTERRUPT = 2147483648u
		}

		[Flags]
		public enum SHCNF
		{
			IDLIST = 0,
			PATHA = 1,
			PRINTERA = 2,
			DWORD = 3,
			PATHW = 5,
			PRINTERW = 6,
			TYPE = 255,
			FLUSH = 4096,
			FLUSHNOWAIT = 8192
		}

		[Flags]
		public enum SHCNRF
		{
			InterruptLevel = 1,
			ShellLevel = 2,
			RecursiveInterrupt = 4096,
			NewDelivery = 32768
		}

		[Flags]
		public enum STATFLAG
		{
			DEFAULT = 0,
			NONAME = 1,
			NOOPEN = 2
		}

		[Flags]
		public enum LOCKTYPE
		{
			WRITE = 1,
			EXCLUSIVE = 2,
			ONLYONCE = 4
		}

		public enum STGTY
		{
			STORAGE = 1,
			STREAM,
			LOCKBYTES,
			PROPERTY
		}

		[Flags]
		public enum STGM
		{
			DIRECT = 0,
			TRANSACTED = 65536,
			SIMPLE = 134217728,
			READ = 0,
			WRITE = 1,
			READWRITE = 2,
			SHARE_DENY_NONE = 64,
			SHARE_DENY_READ = 48,
			SHARE_DENY_WRITE = 32,
			SHARE_EXCLUSIVE = 16,
			PRIORITY = 262144,
			DELETEONRELEASE = 67108864,
			NOSCRATCH = 1048576,
			CREATE = 4096,
			CONVERT = 131072,
			FAILIFTHERE = 0,
			NOSNAPSHOT = 2097152,
			DIRECT_SWMR = 4194304
		}

		public enum STGMOVE
		{
			MOVE,
			COPY,
			SHALLOWCOPY
		}

		[Flags]
		public enum STGC
		{
			DEFAULT = 0,
			OVERWRITE = 1,
			ONLYIFCURRENT = 2,
			DANGEROUSLYCOMMITMERELYTODISKCACHE = 4,
			CONSOLIDATE = 8
		}

		[Flags]
		public enum QITIPF
		{
			DEFAULT = 0,
			USENAME = 1,
			LINKNOTARGET = 2,
			LINKUSETARGET = 4,
			USESLOWTIP = 8
		}

		public const int MAX_PATH = 260;

		public const uint CMD_FIRST = 1u;

		public const uint CMD_LAST = 30000u;

		public const int S_OK = 0;

		public const int S_FALSE = 1;

		public const int DRAGDROP_S_DROP = 262400;

		public const int DRAGDROP_S_CANCEL = 262401;

		public const int DRAGDROP_S_USEDEFAULTCURSORS = 262402;

		public static int cbFileInfo = Marshal.SizeOf(typeof(ShellAPI.SHFILEINFO));

		public static int cbMenuItemInfo = Marshal.SizeOf(typeof(ShellAPI.MENUITEMINFO));

		public static int cbTpmParams = Marshal.SizeOf(typeof(ShellAPI.TPMPARAMS));

		public static int cbInvokeCommand = Marshal.SizeOf(typeof(ShellAPI.CMINVOKECOMMANDINFOEX));

		public static Guid IID_DesktopGUID = new Guid("{00021400-0000-0000-C000-000000000046}");

		public static Guid IID_IShellFolder = new Guid("{000214E6-0000-0000-C000-000000000046}");

		public static Guid IID_IContextMenu = new Guid("{000214e4-0000-0000-c000-000000000046}");

		public static Guid IID_IContextMenu2 = new Guid("{000214f4-0000-0000-c000-000000000046}");

		public static Guid IID_IContextMenu3 = new Guid("{bcfce0a0-ec17-11d0-8d10-00a0c90f2719}");

		public static Guid IID_IDropTarget = new Guid("{00000122-0000-0000-C000-000000000046}");

		public static Guid IID_IDataObject = new Guid("{0000010e-0000-0000-C000-000000000046}");

		public static Guid IID_IQueryInfo = new Guid("{00021500-0000-0000-C000-000000000046}");

		public static Guid IID_IPersistFile = new Guid("{0000010b-0000-0000-C000-000000000046}");

		public static Guid CLSID_DragDropHelper = new Guid("{4657278A-411B-11d2-839A-00C04FD918D0}");

		public static Guid CLSID_NewMenu = new Guid("{D969A300-E7FF-11d0-A93B-00A0C90F2719}");

		public static Guid IID_IDragSourceHelper = new Guid("{DE5BF786-477A-11d2-839D-00C04FD918D0}");

		public static Guid IID_IDropTargetHelper = new Guid("{4657278B-411B-11d2-839A-00C04FD918D0}");

		public static Guid IID_IShellExtInit = new Guid("{000214e8-0000-0000-c000-000000000046}");

		public static Guid IID_IStream = new Guid("{0000000c-0000-0000-c000-000000000046}");

		public static Guid IID_IStorage = new Guid("{0000000B-0000-0000-C000-000000000046}");

		[DllImport("shell32", CharSet = CharSet.Auto, SetLastError = true)]
		public static extern IntPtr SHGetFileInfo(string pszPath, ShellAPI.FILE_ATTRIBUTE dwFileAttributes, ref ShellAPI.SHFILEINFO sfi, int cbFileInfo, ShellAPI.SHGFI uFlags);

		[DllImport("shell32", CharSet = CharSet.Auto, SetLastError = true)]
		public static extern IntPtr SHGetFileInfo(IntPtr ppidl, ShellAPI.FILE_ATTRIBUTE dwFileAttributes, ref ShellAPI.SHFILEINFO sfi, int cbFileInfo, ShellAPI.SHGFI uFlags);

		[DllImport("shell32.dll")]
		public static extern int SHGetFolderPath(IntPtr hwndOwner, ShellAPI.CSIDL nFolder, IntPtr hToken, ShellAPI.SHGFP dwFlags, StringBuilder pszPath);

		[DllImport("shell32.dll")]
		public static extern int SHGetDesktopFolder(out IntPtr ppshf);

		[DllImport("Shell32", CharSet = CharSet.Ansi, ExactSpelling = true, SetLastError = true)]
		public static extern int SHGetSpecialFolderLocation(IntPtr hwndOwner, ShellAPI.CSIDL nFolder, out IntPtr ppidl);

		[DllImport("shell32.dll")]
		public static extern int SHBindToParent(IntPtr pidl, ref Guid riid, out IntPtr ppv, out IntPtr ppidlLast);

		[DllImport("shell32.dll", CharSet = CharSet.Auto, EntryPoint = "#2")]
		public static extern uint SHChangeNotifyRegister(IntPtr hwnd, ShellAPI.SHCNRF fSources, ShellAPI.SHCNE fEvents, ShellAPI.WM wMsg, int cEntries, [MarshalAs(UnmanagedType.LPArray)] ShellAPI.SHChangeNotifyEntry[] pfsne);

		[DllImport("shell32.dll", CharSet = CharSet.Auto, EntryPoint = "#4")]
		public static extern bool SHChangeNotifyDeregister(uint hNotify);

		[DllImport("shell32.dll")]
		public static extern bool SHGetPathFromIDList(IntPtr pidl, StringBuilder pszPath);

		[DllImport("shell32.dll", CharSet = CharSet.Ansi, ExactSpelling = true, SetLastError = true)]
		public static extern bool ILIsEqual(IntPtr pidl1, IntPtr pidl2);

		[DllImport("shlwapi.dll", CharSet = CharSet.Auto, SetLastError = true)]
		public static extern int StrRetToBuf(IntPtr pstr, IntPtr pidl, StringBuilder pszBuf, int cchBuf);

		[DllImport("user32", CharSet = CharSet.Auto, SetLastError = true)]
		public static extern IntPtr SendMessage(IntPtr hWnd, ShellAPI.WM wMsg, int wParam, IntPtr lParam);

		[DllImport("user32.dll", CharSet = CharSet.Ansi, ExactSpelling = true, SetLastError = true)]
		public static extern bool DestroyIcon(IntPtr hIcon);

		[DllImport("user32.dll", CharSet = CharSet.Auto, ExactSpelling = true)]
		public static extern uint TrackPopupMenuEx(IntPtr hmenu, ShellAPI.TPM flags, int x, int y, IntPtr hwnd, IntPtr lptpm);

		[DllImport("user32", CharSet = CharSet.Auto, SetLastError = true)]
		public static extern IntPtr CreatePopupMenu();

		[DllImport("user32", CharSet = CharSet.Auto, SetLastError = true)]
		public static extern bool DestroyMenu(IntPtr hMenu);

		[DllImport("user32", CharSet = CharSet.Auto, SetLastError = true)]
		public static extern bool AppendMenu(IntPtr hMenu, ShellAPI.MFT uFlags, uint uIDNewItem, [MarshalAs(UnmanagedType.LPTStr)] string lpNewItem);

		[DllImport("user32", CharSet = CharSet.Auto, SetLastError = true)]
		public static extern bool InsertMenu(IntPtr hmenu, uint uPosition, ShellAPI.MFT uflags, uint uIDNewItem, [MarshalAs(UnmanagedType.LPTStr)] string lpNewItem);

		[DllImport("user32", CharSet = CharSet.Auto, SetLastError = true)]
		public static extern bool InsertMenuItem(IntPtr hMenu, uint uItem, bool fByPosition, ref ShellAPI.MENUITEMINFO lpmii);

		[DllImport("user32", CharSet = CharSet.Auto, SetLastError = true)]
		public static extern bool RemoveMenu(IntPtr hMenu, uint uPosition, ShellAPI.MFT uFlags);

		[DllImport("user32", CharSet = CharSet.Auto, SetLastError = true)]
		public static extern bool GetMenuItemInfo(IntPtr hMenu, uint uItem, bool fByPos, ref ShellAPI.MENUITEMINFO lpmii);

		[DllImport("user32", CharSet = CharSet.Auto, SetLastError = true)]
		public static extern bool SetMenuItemInfo(IntPtr hMenu, uint uItem, bool fByPos, ref ShellAPI.MENUITEMINFO lpmii);

		[DllImport("user32", CharSet = CharSet.Auto, SetLastError = true)]
		public static extern int GetMenuDefaultItem(IntPtr hMenu, bool fByPos, uint gmdiFlags);

		[DllImport("user32", CharSet = CharSet.Auto, SetLastError = true)]
		public static extern bool SetMenuDefaultItem(IntPtr hMenu, uint uItem, bool fByPos);

		[DllImport("user32", CharSet = CharSet.Auto, SetLastError = true)]
		public static extern IntPtr GetSubMenu(IntPtr hMenu, int nPos);

		[DllImport("user32", CharSet = CharSet.Auto, SetLastError = true)]
		public static extern bool GetComboBoxInfo(IntPtr hwndCombo, ref ShellAPI.COMBOBOXINFO info);

		[DllImport("comctl32", CharSet = CharSet.Auto, SetLastError = true)]
		public static extern int ImageList_ReplaceIcon(IntPtr himl, int index, IntPtr hicon);

		[DllImport("comctl32", CharSet = CharSet.Auto, SetLastError = true)]
		public static extern int ImageList_Add(IntPtr himl, IntPtr hbmImage, IntPtr hbmMask);

		[DllImport("comctl32", CharSet = CharSet.Ansi, ExactSpelling = true, SetLastError = true)]
		public static extern IntPtr ImageList_GetIcon(IntPtr himl, int index, ShellAPI.ILD flags);

		[DllImport("ole32.dll", CharSet = CharSet.Auto, SetLastError = true)]
		public static extern int RevokeDragDrop(IntPtr hWnd);

		[DllImport("ole32.dll", CharSet = CharSet.Auto, SetLastError = true)]
		public static extern void ReleaseStgMedium(ref ShellAPI.STGMEDIUM pmedium);

		[DllImport("ole32.dll", CharSet = CharSet.Auto, SetLastError = true)]
		public static extern int CoCreateInstance(ref Guid rclsid, IntPtr pUnkOuter, ShellAPI.CLSCTX dwClsContext, ref Guid riid, out IntPtr ppv);

		[DllImport("ole32.dll", CharSet = CharSet.Auto, SetLastError = true)]
		public static extern int OleGetClipboard(out IntPtr ppDataObj);

		public static DateTime FileTimeToDateTime(ShellAPI.FILETIME fileTime)
		{
			long fileTime2 = ((long)fileTime.dwHighDateTime << 32) + (long)fileTime.dwLowDateTime;
			return DateTime.FromFileTimeUtc(fileTime2);
		}
	}
}
