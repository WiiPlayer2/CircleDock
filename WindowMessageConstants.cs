using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Constants
{
    class WindowMessageConstants
    {
        public const int WM_NULL = 0x0000;
        public const int WM_CREATE = 0x0001;
        public const int WM_DESTROY = 0x0002;
        public const int WM_MOVE = 0x0003;
        public const int WM_SIZE = 0x0005;
        public const int WM_ACTIVATE = 0x0006;
        public const int WM_SETFOCUS = 0x0007;
        public const int WM_KILLFOCUS = 0x0008;
        public const int WM_ENABLE = 0x000A;
        public const int WM_SETREDRAW = 0x000B;
        public const int WM_SETTEXT = 0x000C;
        public const int WM_GETTEXT = 0x000D;
        public const int WM_GETTEXTLENGTH = 0x000E;
        public const int WM_PAINT = 0x000F;
        public const int WM_CLOSE = 0x0010;
        public const int WM_QUERYENDSESSION = 0x0011;
        public const int WM_QUIT = 0x0012;
        public const int WM_QUERYOPEN = 0x0013;
        public const int WM_ERASEBKGND = 0x0014;
        public const int WM_SYSCOLORCHANGE = 0x0015;
        public const int WM_ENDSESSION = 0x0016;
        public const int WM_SHOWWINDOW = 0x0018;
        public const int WM_CTLCOLOR = 0x0019;
        public const int WM_WININICHANGE = 0x001A;
        public const int WM_SETTINGCHANGE = 0x001A;
        public const int WM_DEVMODECHANGE = 0x001B;
        public const int WM_ACTIVATEAPP = 0x001C;
        public const int WM_FONTCHANGE = 0x001D;
        public const int WM_TIMECHANGE = 0x001E;
        public const int WM_CANCELMODE = 0x001F;
        public const int WM_SETCURSOR = 0x0020;
        public const int WM_MOUSEACTIVATE = 0x0021;
        public const int WM_CHILDACTIVATE = 0x0022;
        public const int WM_QUEUESYNC = 0x0023;
        public const int WM_GETMINMAXINFO = 0x0024;
        public const int WM_PAINTICON = 0x0026;
        public const int WM_ICONERASEBKGND = 0x0027;
        public const int WM_NEXTDLGCTL = 0x0028;
        public const int WM_SPOOLERSTATUS = 0x002A;
        public const int WM_DRAWITEM = 0x002B;
        public const int WM_MEASUREITEM = 0x002C;
        public const int WM_DELETEITEM = 0x002D;
        public const int WM_VKEYTOITEM = 0x002E;
        public const int WM_CHARTOITEM = 0x002F;
        public const int WM_SETFONT = 0x0030;
        public const int WM_GETFONT = 0x0031;
        public const int WM_SETHOTKEY = 0x0032;
        public const int WM_GETHOTKEY = 0x0033;
        public const int WM_QUERYDRAGICON = 0x0037;
        public const int WM_COMPAREITEM = 0x0039;
        public const int WM_GETOBJECT = 0x003D;
        public const int WM_COMPACTING = 0x0041;
        public const int WM_COMMNOTIFY = 0x0044 ;
        public const int WM_WINDOWPOSCHANGING = 0x0046;
        public const int WM_WINDOWPOSCHANGED = 0x0047;
        public const int WM_POWER = 0x0048;
        public const int WM_COPYDATA = 0x004A;
        public const int WM_CANCELJOURNAL = 0x004B;
        public const int WM_NOTIFY = 0x004E;
        public const int WM_INPUTLANGCHANGEREQUEST = 0x0050;
        public const int WM_INPUTLANGCHANGE = 0x0051;
        public const int WM_TCARD = 0x0052;
        public const int WM_HELP = 0x0053;
        public const int WM_USERCHANGED = 0x0054;
        public const int WM_NOTIFYFORMAT = 0x0055;
        public const int WM_CONTEXTMENU = 0x007B;
        public const int WM_STYLECHANGING = 0x007C;
        public const int WM_STYLECHANGED = 0x007D;
        public const int WM_DISPLAYCHANGE = 0x007E;
        public const int WM_GETICON = 0x007F;
        public const int WM_SETICON = 0x0080;
        public const int WM_NCCREATE = 0x0081;
        public const int WM_NCDESTROY = 0x0082;
        public const int WM_NCCALCSIZE = 0x0083;
        public const int WM_NCHITTEST = 0x0084;
        public const int WM_NCPAINT = 0x0085;
        public const int WM_NCACTIVATE = 0x0086;
        public const int WM_GETDLGCODE = 0x0087;
        public const int WM_SYNCPAINT = 0x0088;
        public const int WM_NCMOUSEMOVE = 0x00A0;
        public const int WM_NCLBUTTONDOWN = 0x00A1;
        public const int WM_NCLBUTTONUP = 0x00A2;
        public const int WM_NCLBUTTONDBLCLK = 0x00A3;
        public const int WM_NCRBUTTONDOWN = 0x00A4;
        public const int WM_NCRBUTTONUP = 0x00A5;
        public const int WM_NCRBUTTONDBLCLK = 0x00A6;
        public const int WM_NCMBUTTONDOWN = 0x00A7;
        public const int WM_NCMBUTTONUP = 0x00A8;
        public const int WM_NCMBUTTONDBLCLK = 0x00A9;
        public const int WM_KEYDOWN = 0x0100;
        public const int WM_KEYUP = 0x0101;
        public const int WM_CHAR = 0x0102;
        public const int WM_DEADCHAR = 0x0103;
        public const int WM_SYSKEYDOWN = 0x0104;
        public const int WM_SYSKEYUP = 0x0105;
        public const int WM_SYSCHAR = 0x0106;
        public const int WM_SYSDEADCHAR = 0x0107;
        public const int WM_KEYLAST = 0x0108;
        public const int WM_IME_STARTCOMPOSITION = 0x010D;
        public const int WM_IME_ENDCOMPOSITION = 0x010E;
        public const int WM_IME_COMPOSITION = 0x010F;
        public const int WM_IME_KEYLAST = 0x010F;
        public const int WM_INITDIALOG = 0x0110;
        public const int WM_COMMAND = 0x0111;
        public const int WM_SYSCOMMAND = 0x0112;
        public const int WM_TIMER = 0x0113;
        public const int WM_HSCROLL = 0x0114;
        public const int WM_VSCROLL = 0x0115;
        public const int WM_INITMENU = 0x0116;
        public const int WM_INITMENUPOPUP = 0x0117;
        public const int WM_MENUSELECT = 0x011F;
        public const int WM_MENUCHAR = 0x0120;
        public const int WM_ENTERIDLE = 0x0121;
        public const int WM_MENURBUTTONUP = 0x0122;
        public const int WM_MENUDRAG = 0x0123;
        public const int WM_MENUGETOBJECT = 0x0124;
        public const int WM_UNINITMENUPOPUP = 0x0125;
        public const int WM_MENUCOMMAND = 0x0126;
        public const int WM_CTLCOLORMSGBOX = 0x0132;
        public const int WM_CTLCOLOREDIT = 0x0133;
        public const int WM_CTLCOLORLISTBOX = 0x0134;
        public const int WM_CTLCOLORBTN = 0x0135;
        public const int WM_CTLCOLORDLG = 0x0136;
        public const int WM_CTLCOLORSCROLLBAR = 0x0137;
        public const int WM_CTLCOLORSTATIC = 0x0138;
        public const int WM_MOUSEMOVE = 0x0200;
        public const int WM_LBUTTONDOWN = 0x0201;
        public const int WM_LBUTTONUP = 0x0202;
        public const int WM_LBUTTONDBLCLK = 0x0203;
        public const int WM_RBUTTONDOWN = 0x0204;
        public const int WM_RBUTTONUP = 0x0205;
        public const int WM_RBUTTONDBLCLK = 0x0206;
        public const int WM_MBUTTONDOWN = 0x0207;
        public const int WM_MBUTTONUP = 0x0208;
        public const int WM_MBUTTONDBLCLK = 0x0209;
        public const int WM_MOUSEWHEEL = 0x020A;
        public const int WM_PARENTNOTIFY = 0x0210;
        public const int WM_ENTERMENULOOP = 0x0211;
        public const int WM_EXITMENULOOP = 0x0212;
        public const int WM_NEXTMENU = 0x0213;
        public const int WM_SIZING = 0x0214;
        public const int WM_CAPTURECHANGED = 0x0215;
        public const int WM_MOVING = 0x0216;
        public const int WM_DEVICECHANGE = 0x0219;
        public const int WM_MDICREATE = 0x0220;
        public const int WM_MDIDESTROY = 0x0221;
        public const int WM_MDIACTIVATE = 0x0222;
        public const int WM_MDIRESTORE = 0x0223;
        public const int WM_MDINEXT = 0x0224;
        public const int WM_MDIMAXIMIZE = 0x0225;
        public const int WM_MDITILE = 0x0226;
        public const int WM_MDICASCADE = 0x0227;
        public const int WM_MDIICONARRANGE = 0x0228;
        public const int WM_MDIGETACTIVE = 0x0229;
        public const int WM_MDISETMENU = 0x0230;
        public const int WM_ENTERSIZEMOVE = 0x0231;
        public const int WM_EXITSIZEMOVE = 0x0232;
        public const int WM_DROPFILES = 0x0233;
        public const int WM_MDIREFRESHMENU = 0x0234;
        public const int WM_IME_SETCONTEXT = 0x0281;
        public const int WM_IME_NOTIFY = 0x0282;
        public const int WM_IME_CONTROL = 0x0283;
        public const int WM_IME_COMPOSITIONFULL = 0x0284;
        public const int WM_IME_SELECT = 0x0285;
        public const int WM_IME_CHAR = 0x0286;
        public const int WM_IME_REQUEST = 0x0288;
        public const int WM_IME_KEYDOWN = 0x0290;
        public const int WM_IME_KEYUP = 0x0291;
        public const int WM_MOUSEHOVER = 0x02A1;
        public const int WM_MOUSELEAVE = 0x02A3;
        public const int WM_CUT = 0x0300;
        public const int WM_COPY = 0x0301;
        public const int WM_PASTE = 0x0302;
        public const int WM_CLEAR = 0x0303;
        public const int WM_UNDO = 0x0304;
        public const int WM_RENDERFORMAT = 0x0305;
        public const int WM_RENDERALLFORMATS = 0x0306;
        public const int WM_DESTROYCLIPBOARD = 0x0307;
        public const int WM_DRAWCLIPBOARD = 0x0308;
        public const int WM_PAINTCLIPBOARD = 0x0309;
        public const int WM_VSCROLLCLIPBOARD = 0x030A;
        public const int WM_SIZECLIPBOARD = 0x030B;
        public const int WM_ASKCBFORMATNAME = 0x030C;
        public const int WM_CHANGECBCHAIN = 0x030D;
        public const int WM_HSCROLLCLIPBOARD = 0x030E;
        public const int WM_QUERYNEWPALETTE = 0x030F;
        public const int WM_PALETTEISCHANGING = 0x0310;
        public const int WM_PALETTECHANGED = 0x0311;
        public const int WM_HOTKEY = 0x0312;
        public const int WM_PRINT = 0x0317;
        public const int WM_PRINTCLIENT = 0x0318;
        public const int WM_HANDHELDFIRST = 0x0358;
        public const int WM_HANDHELDLAST = 0x035F;
        public const int WM_AFXFIRST = 0x0360;
        public const int WM_AFXLAST = 0x037F;
        public const int WM_PENWINFIRST = 0x0380;
        public const int WM_PENWINLAST = 0x038F;
        public const int WM_APP = 0x8000;
        public const int WM_USER = 0x0400;
        public const int WM_REFLECT = WM_USER + 0x1c00;
    }

    class SendKeysConstants
    {
        public const int VK_LBUTTON = 0x01;   //Left mouse button 
        public const int VK_RBUTTON = 0x02;   //Right mouse button 
        public const int VK_CANCEL = 0x03;   //Control-break processing 
        public const int VK_MBUTTON = 0x04;   //Middle mouse button (three-button mouse) 
        public const int VK_BACK = 0x08;   //BACKSPACE key 
        public const int VK_TAB = 0x09;   //TAB key 
        public const int VK_CLEAR = 0x0C;   //CLEAR key 
        public const int VK_RETURN = 0x0D;   //ENTER key 
        public const int VK_SHIFT = 0x10;   //SHIFT key 
        public const int VK_CONTROL = 0x11;   //CTRL key 
        public const int VK_MENU = 0x12;   //ALT key 
        public const int VK_PAUSE = 0x13;   //PAUSE key 
        public const int VK_CAPITAL = 0x14;   //CAPS LOCK key 
        public const int VK_ESCAPE = 0x1B;   //ESC key 
        public const int VK_SPACE = 0x20;   //SPACEBAR 
        public const int VK_PRIOR = 0x21;   //PAGE UP key 
        public const int VK_NEXT = 0x22;   //PAGE DOWN key 
        public const int VK_END = 0x23;   //END key 
        public const int VK_HOME = 0x24;   //HOME key 
        public const int VK_LEFT = 0x25;   //LEFT ARROW key 
        public const int VK_UP = 0x26;   //UP ARROW key 
        public const int VK_RIGHT = 0x27;   //RIGHT ARROW key 
        public const int VK_DOWN = 0x28;   //DOWN ARROW key 
        public const int VK_SELECT = 0x29;   //SELECT key 
        public const int VK_PRINT = 0x2A;   //PRINT key 
        public const int VK_EXECUTE = 0x2B;   //EXECUTE key 
        public const int VK_SNAPSHOT = 0x2C;   //PRINT SCREEN key 
        public const int VK_INSERT = 0x2D;   //INS key 
        public const int VK_DELETE = 0x2E;   //DEL key 
        public const int VK_HELP = 0x2F;   //HELP key 
        public const int VK_0 = 0x30;   //0 key 
        public const int VK_1 = 0x31;   //1 key 
        public const int VK_2 = 0x32;   //2 key 
        public const int VK_3 = 0x33;   //3 key 
        public const int VK_4 = 0x34;   //4 key 
        public const int VK_5 = 0x35;   //5 key 
        public const int VK_6 = 0x36;    //6 key 
        public const int VK_7 = 0x37;    //7 key 
        public const int VK_8 = 0x38;   //8 key 
        public const int VK_9 = 0x39;    //9 key 
        public const int VK_A = 0x41;   //A key 
        public const int VK_B = 0x42;   //B key 
        public const int VK_C = 0x43;   //C key 
        public const int VK_D = 0x44;   //D key 
        public const int VK_E = 0x45;   //E key 
        public const int VK_F = 0x46;   //F key 
        public const int VK_G = 0x47;   //G key 
        public const int VK_H = 0x48;   //H key 
        public const int VK_I = 0x49;    //I key 
        public const int VK_J = 0x4A;   //J key 
        public const int VK_K = 0x4B;   //K key 
        public const int VK_L = 0x4C;   //L key 
        public const int VK_M = 0x4D;   //M key 
        public const int VK_N = 0x4E;    //N key 
        public const int VK_O = 0x4F;   //O key 
        public const int VK_P = 0x50;    //P key 
        public const int VK_Q = 0x51;   //Q key 
        public const int VK_R = 0x52;   //R key 
        public const int VK_S = 0x53;   //S key 
        public const int VK_T = 0x54;   //T key 
        public const int VK_U = 0x55;   //U key 
        public const int VK_V = 0x56;   //V key 
        public const int VK_W = 0x57;   //W key 
        public const int VK_X = 0x58;   //X key 
        public const int VK_Y = 0x59;   //Y key 
        public const int VK_Z = 0x5A;    //Z key 
        public const int VK_NUMPAD0 = 0x60;   //Numeric keypad 0 key 
        public const int VK_NUMPAD1 = 0x61;   //Numeric keypad 1 key 
        public const int VK_NUMPAD2 = 0x62;   //Numeric keypad 2 key 
        public const int VK_NUMPAD3 = 0x63;   //Numeric keypad 3 key 
        public const int VK_NUMPAD4 = 0x64;   //Numeric keypad 4 key 
        public const int VK_NUMPAD5 = 0x65;   //Numeric keypad 5 key 
        public const int VK_NUMPAD6 = 0x66;   //Numeric keypad 6 key 
        public const int VK_NUMPAD7 = 0x67;   //Numeric keypad 7 key 
        public const int VK_NUMPAD8 = 0x68;   //Numeric keypad 8 key 
        public const int VK_NUMPAD9 = 0x69;   //Numeric keypad 9 key 
        public const int VK_SEPARATOR = 0x6C;   //Separator key 
        public const int VK_SUBTRACT = 0x6D;   //Subtract key 
        public const int VK_DECIMAL = 0x6E;   //Decimal key 
        public const int VK_DIVIDE = 0x6F;   //Divide key 
        public const int VK_F1 = 0x70;   //F1 key 
        public const int VK_F2 = 0x71;   //F2 key 
        public const int VK_F3 = 0x72;   //F3 key 
        public const int VK_F4 = 0x73;   //F4 key 
        public const int VK_F5 = 0x74;   //F5 key 
        public const int VK_F6 = 0x75;   //F6 key 
        public const int VK_F7 = 0x76;   //F7 key 
        public const int VK_F8 = 0x77;   //F8 key 
        public const int VK_F9 = 0x78;   //F9 key 
        public const int VK_F10 = 0x79;   //F10 key 
        public const int VK_F11 = 0x7A;   //F11 key 
        public const int VK_F12 = 0x7B;   //F12 key 
        public const int VK_SCROLL = 0x91;   //SCROLL LOCK key 
        public const int VK_LSHIFT = 0xA0;   //Left SHIFT key 
        public const int VK_RSHIFT = 0xA1;   //Right SHIFT key 
        public const int VK_LCONTROL = 0xA2;   //Left CONTROL key 
        public const int VK_RCONTROL = 0xA3;    //Right CONTROL key 
        public const int VK_LMENU = 0xA4;      //Left MENU key 
        public const int VK_RMENU = 0xA5;   //Right MENU key 
        public const int VK_PLAY = 0xFA;   //Play key 
        public const int VK_ZOOM = 0xFB; //Zoom key 
    }

    class WindowStyles
    {
        //public const int WS_CHILD = 0x40000000;
        //public const int WS_VISIBLE = 0x10000000;


        public const int WS_OVERLAPPED = 0x00000000;
        public const uint WS_POPUP = 0x80000000;
        public const int WS_CHILD = 0x40000000;
        public const int WS_MINIMIZE = 0x20000000;
        public const int WS_VISIBLE = 0x10000000;
        public const int WS_DISABLED = 0x08000000;
        public const int WS_CLIPSIBLINGS = 0x04000000;
        public const int WS_CLIPCHILDREN = 0x02000000;
        public const int WS_MAXIMIZE = 0x01000000;
        public const int WS_CAPTION = 0x00C00000;     /* WS_BORDER | WS_DLGFRAME  */
        public const int WS_BORDER = 0x00800000;
        public const int WS_DLGFRAME = 0x00400000;
        public const int WS_VSCROLL = 0x00200000;
        public const int WS_HSCROLL = 0x00100000;
        public const int WS_SYSMENU = 0x00080000;
        public const int WS_THICKFRAME = 0x00040000;
        public const int WS_GROUP = 0x00020000;
        public const int WS_TABSTOP = 0x00010000;

        public const int WS_MINIMIZEBOX = 0x00020000;
        public const int WS_MAXIMIZEBOX = 0x00010000;



        public const int WS_TILED = WS_OVERLAPPED;
        public const int WS_ICONIC = WS_MINIMIZE;
        public const int WS_SIZEBOX = WS_THICKFRAME;
        public const int WS_TILEDWINDOW = WS_OVERLAPPEDWINDOW;

        // Common Window Styles

        public const int WS_OVERLAPPEDWINDOW =
            (WS_OVERLAPPED |
              WS_CAPTION |
              WS_SYSMENU |
              WS_THICKFRAME |
              WS_MINIMIZEBOX |
              WS_MAXIMIZEBOX);

        public const int WS_POPUPWINDOW =
            (unchecked((int)WS_POPUP) |
              WS_BORDER |
              WS_SYSMENU);

        public const int WS_CHILDWINDOW = WS_CHILD;
    }

    class WindowExStyles
    {
        /// <summary>
        /// Specifies that a window created with this style accepts drag-drop files.
        /// </summary>
        public const int WS_EX_ACCEPTFILES = 0x00000010;
        /// <summary>
        /// Forces a top-level window onto the taskbar when the window is visible.
        /// </summary>
        public const int WS_EX_APPWINDOW = 0x00040000;
        /// <summary>
        /// Specifies that a window has a border with a sunken edge.
        /// </summary>
        public const int WS_EX_CLIENTEDGE = 0x00000200;
        /// <summary>
        /// Windows XP: Paints all descendants of a window in bottom-to-top painting order using double-buffering. For more information, see Remarks. This cannot be used if the window has a class style of either CS_OWNDC or CS_CLASSDC. 
        /// </summary>
        public const int WS_EX_COMPOSITED = 0x02000000;
        /// <summary>
        /// Includes a question mark in the title bar of the window. When the user clicks the question mark, the cursor changes to a question mark with a pointer. If the user then clicks a child window, the child receives a WM_HELP message. The child window should pass the message to the parent window procedure, which should call the WinHelp function using the HELP_WM_HELP command. The Help application displays a pop-up window that typically contains help for the child window.
        /// WS_EX_CONTEXTHELP cannot be used with the WS_MAXIMIZEBOX or WS_MINIMIZEBOX styles.
        /// </summary>
        public const int WS_EX_CONTEXTHELP = 0x00000400;
        /// <summary>
        /// The window itself contains child windows that should take part in dialog box navigation. If this style is specified, the dialog manager recurses into children of this window when performing navigation operations such as handling the TAB key, an arrow key, or a keyboard mnemonic.
        /// </summary>
        public const int WS_EX_CONTROLPARENT = 0x00010000;
        /// <summary>
        /// Creates a window that has a double border; the window can, optionally, be created with a title bar by specifying the WS_CAPTION style in the dwStyle parameter.
        /// </summary>
        public const int WS_EX_DLGMODALFRAME = 0x00000001;
        /// <summary>
        /// Windows 2000/XP: Creates a layered window. Note that this cannot be used for child windows. Also, this cannot be used if the window has a class style of either CS_OWNDC or CS_CLASSDC. 
        /// </summary>
        public const int WS_EX_LAYERED = 0x00080000;
        /// <summary>
        /// Arabic and Hebrew versions of Windows 98/Me, Windows 2000/XP: Creates a window whose horizontal origin is on the right edge. Increasing horizontal values advance to the left. 
        /// </summary>
        public const int WS_EX_LAYOUTRTL = 0x00400000;
        /// <summary>
        /// Creates a window that has generic left-aligned properties. This is the default.
        /// </summary>
        public const int WS_EX_LEFT = 0x00000000;
        /// <summary>
        /// If the shell language is Hebrew, Arabic, or another language that supports reading order alignment, the vertical scroll bar (if present) is to the left of the client area. For other languages, the style is ignored.
        /// </summary>
        public const int WS_EX_LEFTSCROLLBAR = 0x00004000;
        /// <summary>
        /// The window text is displayed using left-to-right reading-order properties. This is the default.
        /// </summary>
        public const int WS_EX_LTRREADING = 0x00000000;
        /// <summary>
        /// Creates a multiple-document interface (MDI) child window.
        /// </summary>
        public const int WS_EX_MDICHILD = 0x00000040;
        /// <summary>
        /// Windows 2000/XP: A top-level window created with this style does not become the foreground window when the user clicks it. The system does not bring this window to the foreground when the user minimizes or closes the foreground window. 
        /// To activate the window, use the SetActiveWindow or SetForegroundWindow function.
        /// The window does not appear on the taskbar by default. To force the window to appear on the taskbar, use the WS_EX_APPWINDOW style.
        /// </summary>
        public const int WS_EX_NOACTIVATE = 0x08000000;
        /// <summary>
        /// Windows 2000/XP: A window created with this style does not pass its window layout to its child windows.
        /// </summary>
        public const int WS_EX_NOINHERITLAYOUT = 0x00100000;
        /// <summary>
        /// Specifies that a child window created with this style does not send the WM_PARENTNOTIFY message to its parent window when it is created or destroyed.
        /// </summary>
        public const int WS_EX_NOPARENTNOTIFY = 0x00000004;
        /// <summary>
        /// Combines the WS_EX_CLIENTEDGE and WS_EX_WINDOWEDGE styles.
        /// </summary>
        public const int WS_EX_OVERLAPPEDWINDOW = WS_EX_WINDOWEDGE | WS_EX_CLIENTEDGE;
        /// <summary>
        /// Combines the WS_EX_WINDOWEDGE, WS_EX_TOOLWINDOW, and WS_EX_TOPMOST styles.
        /// </summary>
        public const int WS_EX_PALETTEWINDOW = WS_EX_WINDOWEDGE | WS_EX_TOOLWINDOW | WS_EX_TOPMOST;
        /// <summary>
        /// The window has generic "right-aligned" properties. This depends on the window class. This style has an effect only if the shell language is Hebrew, Arabic, or another language that supports reading-order alignment; otherwise, the style is ignored.
        /// Using the WS_EX_RIGHT style for static or edit controls has the same effect as using the SS_RIGHT or ES_RIGHT style, respectively. Using this style with button controls has the same effect as using BS_RIGHT and BS_RIGHTBUTTON styles.
        /// </summary>
        public const int WS_EX_RIGHT = 0x00001000;
        /// <summary>
        /// Vertical scroll bar (if present) is to the right of the client area. This is the default.
        /// </summary>
        public const int WS_EX_RIGHTSCROLLBAR = 0x00000000;
        /// <summary>
        /// If the shell language is Hebrew, Arabic, or another language that supports reading-order alignment, the window text is displayed using right-to-left reading-order properties. For other languages, the style is ignored.
        /// </summary>
        public const int WS_EX_RTLREADING = 0x00002000;
        /// <summary>
        /// Creates a window with a three-dimensional border style intended to be used for items that do not accept user input.
        /// </summary>
        public const int WS_EX_STATICEDGE = 0x00020000;
        /// <summary>
        /// Creates a tool window; that is, a window intended to be used as a floating toolbar. A tool window has a title bar that is shorter than a normal title bar, and the window title is drawn using a smaller font. A tool window does not appear in the taskbar or in the dialog that appears when the user presses ALT+TAB. If a tool window has a system menu, its icon is not displayed on the title bar. However, you can display the system menu by right-clicking or by typing ALT+SPACE. 
        /// </summary>
        public const int WS_EX_TOOLWINDOW = 0x00000080;
        /// <summary>
        /// Specifies that a window created with this style should be placed above all non-topmost windows and should stay above them, even when the window is deactivated. To add or remove this style, use the SetWindowPos function.
        /// </summary>
        public const int WS_EX_TOPMOST = 0x00000008;
        /// <summary>
        /// Specifies that a window created with this style should not be painted until siblings beneath the window (that were created by the same thread) have been painted. The window appears transparent because the bits of underlying sibling windows have already been painted.
        /// To achieve transparency without these restrictions, use the SetWindowRgn function.
        /// </summary>
        public const int WS_EX_TRANSPARENT = 0x00000020;
        /// <summary>
        /// Specifies that a window has a border with a raised edge.
        /// </summary>
        public const int WS_EX_WINDOWEDGE = 0x00000100;
    }

}
