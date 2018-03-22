using System;

namespace Constants
{
	internal class WindowMessageConstants
	{
		public const int WM_NULL = 0;

		public const int WM_CREATE = 1;

		public const int WM_DESTROY = 2;

		public const int WM_MOVE = 3;

		public const int WM_SIZE = 5;

		public const int WM_ACTIVATE = 6;

		public const int WM_SETFOCUS = 7;

		public const int WM_KILLFOCUS = 8;

		public const int WM_ENABLE = 10;

		public const int WM_SETREDRAW = 11;

		public const int WM_SETTEXT = 12;

		public const int WM_GETTEXT = 13;

		public const int WM_GETTEXTLENGTH = 14;

		public const int WM_PAINT = 15;

		public const int WM_CLOSE = 16;

		public const int WM_QUERYENDSESSION = 17;

		public const int WM_QUIT = 18;

		public const int WM_QUERYOPEN = 19;

		public const int WM_ERASEBKGND = 20;

		public const int WM_SYSCOLORCHANGE = 21;

		public const int WM_ENDSESSION = 22;

		public const int WM_SHOWWINDOW = 24;

		public const int WM_CTLCOLOR = 25;

		public const int WM_WININICHANGE = 26;

		public const int WM_SETTINGCHANGE = 26;

		public const int WM_DEVMODECHANGE = 27;

		public const int WM_ACTIVATEAPP = 28;

		public const int WM_FONTCHANGE = 29;

		public const int WM_TIMECHANGE = 30;

		public const int WM_CANCELMODE = 31;

		public const int WM_SETCURSOR = 32;

		public const int WM_MOUSEACTIVATE = 33;

		public const int WM_CHILDACTIVATE = 34;

		public const int WM_QUEUESYNC = 35;

		public const int WM_GETMINMAXINFO = 36;

		public const int WM_PAINTICON = 38;

		public const int WM_ICONERASEBKGND = 39;

		public const int WM_NEXTDLGCTL = 40;

		public const int WM_SPOOLERSTATUS = 42;

		public const int WM_DRAWITEM = 43;

		public const int WM_MEASUREITEM = 44;

		public const int WM_DELETEITEM = 45;

		public const int WM_VKEYTOITEM = 46;

		public const int WM_CHARTOITEM = 47;

		public const int WM_SETFONT = 48;

		public const int WM_GETFONT = 49;

		public const int WM_SETHOTKEY = 50;

		public const int WM_GETHOTKEY = 51;

		public const int WM_QUERYDRAGICON = 55;

		public const int WM_COMPAREITEM = 57;

		public const int WM_GETOBJECT = 61;

		public const int WM_COMPACTING = 65;

		public const int WM_COMMNOTIFY = 68;

		public const int WM_WINDOWPOSCHANGING = 70;

		public const int WM_WINDOWPOSCHANGED = 71;

		public const int WM_POWER = 72;

		public const int WM_COPYDATA = 74;

		public const int WM_CANCELJOURNAL = 75;

		public const int WM_NOTIFY = 78;

		public const int WM_INPUTLANGCHANGEREQUEST = 80;

		public const int WM_INPUTLANGCHANGE = 81;

		public const int WM_TCARD = 82;

		public const int WM_HELP = 83;

		public const int WM_USERCHANGED = 84;

		public const int WM_NOTIFYFORMAT = 85;

		public const int WM_CONTEXTMENU = 123;

		public const int WM_STYLECHANGING = 124;

		public const int WM_STYLECHANGED = 125;

		public const int WM_DISPLAYCHANGE = 126;

		public const int WM_GETICON = 127;

		public const int WM_SETICON = 128;

		public const int WM_NCCREATE = 129;

		public const int WM_NCDESTROY = 130;

		public const int WM_NCCALCSIZE = 131;

		public const int WM_NCHITTEST = 132;

		public const int WM_NCPAINT = 133;

		public const int WM_NCACTIVATE = 134;

		public const int WM_GETDLGCODE = 135;

		public const int WM_SYNCPAINT = 136;

		public const int WM_NCMOUSEMOVE = 160;

		public const int WM_NCLBUTTONDOWN = 161;

		public const int WM_NCLBUTTONUP = 162;

		public const int WM_NCLBUTTONDBLCLK = 163;

		public const int WM_NCRBUTTONDOWN = 164;

		public const int WM_NCRBUTTONUP = 165;

		public const int WM_NCRBUTTONDBLCLK = 166;

		public const int WM_NCMBUTTONDOWN = 167;

		public const int WM_NCMBUTTONUP = 168;

		public const int WM_NCMBUTTONDBLCLK = 169;

		public const int WM_KEYDOWN = 256;

		public const int WM_KEYUP = 257;

		public const int WM_CHAR = 258;

		public const int WM_DEADCHAR = 259;

		public const int WM_SYSKEYDOWN = 260;

		public const int WM_SYSKEYUP = 261;

		public const int WM_SYSCHAR = 262;

		public const int WM_SYSDEADCHAR = 263;

		public const int WM_KEYLAST = 264;

		public const int WM_IME_STARTCOMPOSITION = 269;

		public const int WM_IME_ENDCOMPOSITION = 270;

		public const int WM_IME_COMPOSITION = 271;

		public const int WM_IME_KEYLAST = 271;

		public const int WM_INITDIALOG = 272;

		public const int WM_COMMAND = 273;

		public const int WM_SYSCOMMAND = 274;

		public const int WM_TIMER = 275;

		public const int WM_HSCROLL = 276;

		public const int WM_VSCROLL = 277;

		public const int WM_INITMENU = 278;

		public const int WM_INITMENUPOPUP = 279;

		public const int WM_MENUSELECT = 287;

		public const int WM_MENUCHAR = 288;

		public const int WM_ENTERIDLE = 289;

		public const int WM_MENURBUTTONUP = 290;

		public const int WM_MENUDRAG = 291;

		public const int WM_MENUGETOBJECT = 292;

		public const int WM_UNINITMENUPOPUP = 293;

		public const int WM_MENUCOMMAND = 294;

		public const int WM_CTLCOLORMSGBOX = 306;

		public const int WM_CTLCOLOREDIT = 307;

		public const int WM_CTLCOLORLISTBOX = 308;

		public const int WM_CTLCOLORBTN = 309;

		public const int WM_CTLCOLORDLG = 310;

		public const int WM_CTLCOLORSCROLLBAR = 311;

		public const int WM_CTLCOLORSTATIC = 312;

		public const int WM_MOUSEMOVE = 512;

		public const int WM_LBUTTONDOWN = 513;

		public const int WM_LBUTTONUP = 514;

		public const int WM_LBUTTONDBLCLK = 515;

		public const int WM_RBUTTONDOWN = 516;

		public const int WM_RBUTTONUP = 517;

		public const int WM_RBUTTONDBLCLK = 518;

		public const int WM_MBUTTONDOWN = 519;

		public const int WM_MBUTTONUP = 520;

		public const int WM_MBUTTONDBLCLK = 521;

		public const int WM_MOUSEWHEEL = 522;

		public const int WM_PARENTNOTIFY = 528;

		public const int WM_ENTERMENULOOP = 529;

		public const int WM_EXITMENULOOP = 530;

		public const int WM_NEXTMENU = 531;

		public const int WM_SIZING = 532;

		public const int WM_CAPTURECHANGED = 533;

		public const int WM_MOVING = 534;

		public const int WM_DEVICECHANGE = 537;

		public const int WM_MDICREATE = 544;

		public const int WM_MDIDESTROY = 545;

		public const int WM_MDIACTIVATE = 546;

		public const int WM_MDIRESTORE = 547;

		public const int WM_MDINEXT = 548;

		public const int WM_MDIMAXIMIZE = 549;

		public const int WM_MDITILE = 550;

		public const int WM_MDICASCADE = 551;

		public const int WM_MDIICONARRANGE = 552;

		public const int WM_MDIGETACTIVE = 553;

		public const int WM_MDISETMENU = 560;

		public const int WM_ENTERSIZEMOVE = 561;

		public const int WM_EXITSIZEMOVE = 562;

		public const int WM_DROPFILES = 563;

		public const int WM_MDIREFRESHMENU = 564;

		public const int WM_IME_SETCONTEXT = 641;

		public const int WM_IME_NOTIFY = 642;

		public const int WM_IME_CONTROL = 643;

		public const int WM_IME_COMPOSITIONFULL = 644;

		public const int WM_IME_SELECT = 645;

		public const int WM_IME_CHAR = 646;

		public const int WM_IME_REQUEST = 648;

		public const int WM_IME_KEYDOWN = 656;

		public const int WM_IME_KEYUP = 657;

		public const int WM_MOUSEHOVER = 673;

		public const int WM_MOUSELEAVE = 675;

		public const int WM_CUT = 768;

		public const int WM_COPY = 769;

		public const int WM_PASTE = 770;

		public const int WM_CLEAR = 771;

		public const int WM_UNDO = 772;

		public const int WM_RENDERFORMAT = 773;

		public const int WM_RENDERALLFORMATS = 774;

		public const int WM_DESTROYCLIPBOARD = 775;

		public const int WM_DRAWCLIPBOARD = 776;

		public const int WM_PAINTCLIPBOARD = 777;

		public const int WM_VSCROLLCLIPBOARD = 778;

		public const int WM_SIZECLIPBOARD = 779;

		public const int WM_ASKCBFORMATNAME = 780;

		public const int WM_CHANGECBCHAIN = 781;

		public const int WM_HSCROLLCLIPBOARD = 782;

		public const int WM_QUERYNEWPALETTE = 783;

		public const int WM_PALETTEISCHANGING = 784;

		public const int WM_PALETTECHANGED = 785;

		public const int WM_HOTKEY = 786;

		public const int WM_PRINT = 791;

		public const int WM_PRINTCLIENT = 792;

		public const int WM_HANDHELDFIRST = 856;

		public const int WM_HANDHELDLAST = 863;

		public const int WM_AFXFIRST = 864;

		public const int WM_AFXLAST = 895;

		public const int WM_PENWINFIRST = 896;

		public const int WM_PENWINLAST = 911;

		public const int WM_APP = 32768;

		public const int WM_USER = 1024;

		public const int WM_REFLECT = 8192;

		public const int WM_NCMOUSELEAVE = 674;

		public const int WM_NCMOUSEHOVER = 672;
	}
}
