using System;

namespace Constants
{
	public enum SPI : uint
	{
		SPI_GETBEEP = 1u,
		SPI_SETBEEP,
		SPI_GETMOUSE,
		SPI_SETMOUSE,
		SPI_GETBORDER,
		SPI_SETBORDER,
		SPI_GETKEYBOARDSPEED = 10u,
		SPI_SETKEYBOARDSPEED,
		SPI_LANGDRIVER,
		SPI_ICONHORIZONTALSPACING,
		SPI_GETSCREENSAVETIMEOUT,
		SPI_SETSCREENSAVETIMEOUT,
		SPI_GETSCREENSAVEACTIVE,
		SPI_SETSCREENSAVEACTIVE,
		SPI_GETGRIDGRANULARITY,
		SPI_SETGRIDGRANULARITY,
		SPI_SETDESKWALLPAPER,
		SPI_SETDESKPATTERN,
		SPI_GETKEYBOARDDELAY,
		SPI_SETKEYBOARDDELAY,
		SPI_ICONVERTICALSPACING,
		SPI_GETICONTITLEWRAP,
		SPI_SETICONTITLEWRAP,
		SPI_GETMENUDROPALIGNMENT,
		SPI_SETMENUDROPALIGNMENT,
		SPI_SETDOUBLECLKWIDTH,
		SPI_SETDOUBLECLKHEIGHT,
		SPI_GETICONTITLELOGFONT,
		SPI_SETDOUBLECLICKTIME,
		SPI_SETMOUSEBUTTONSWAP,
		SPI_SETICONTITLELOGFONT,
		SPI_GETFASTTASKSWITCH,
		SPI_SETFASTTASKSWITCH,
		SPI_SETDRAGFULLWINDOWS,
		SPI_GETDRAGFULLWINDOWS,
		SPI_GETNONCLIENTMETRICS = 41u,
		SPI_SETNONCLIENTMETRICS,
		SPI_GETMINIMIZEDMETRICS,
		SPI_SETMINIMIZEDMETRICS,
		SPI_GETICONMETRICS,
		SPI_SETICONMETRICS,
		SPI_SETWORKAREA,
		SPI_GETWORKAREA,
		SPI_SETPENWINDOWS,
		SPI_GETHIGHCONTRAST = 66u,
		SPI_SETHIGHCONTRAST,
		SPI_GETKEYBOARDPREF,
		SPI_SETKEYBOARDPREF,
		SPI_GETSCREENREADER,
		SPI_SETSCREENREADER,
		SPI_GETANIMATION,
		SPI_SETANIMATION,
		SPI_GETFONTSMOOTHING,
		SPI_SETFONTSMOOTHING,
		SPI_SETDRAGWIDTH,
		SPI_SETDRAGHEIGHT,
		SPI_SETHANDHELD,
		SPI_GETLOWPOWERTIMEOUT,
		SPI_GETPOWEROFFTIMEOUT,
		SPI_SETLOWPOWERTIMEOUT,
		SPI_SETPOWEROFFTIMEOUT,
		SPI_GETLOWPOWERACTIVE,
		SPI_GETPOWEROFFACTIVE,
		SPI_SETLOWPOWERACTIVE,
		SPI_SETPOWEROFFACTIVE,
		SPI_SETCURSORS,
		SPI_SETICONS,
		SPI_GETDEFAULTINPUTLANG,
		SPI_SETDEFAULTINPUTLANG,
		SPI_SETLANGTOGGLE,
		SPI_GETWINDOWSEXTENSION,
		SPI_SETMOUSETRAILS,
		SPI_GETMOUSETRAILS,
		SPI_SETSCREENSAVERRUNNING = 97u,
		SPI_SCREENSAVERRUNNING = 97u,
		SPI_GETFILTERKEYS = 50u,
		SPI_SETFILTERKEYS,
		SPI_GETTOGGLEKEYS,
		SPI_SETTOGGLEKEYS,
		SPI_GETMOUSEKEYS,
		SPI_SETMOUSEKEYS,
		SPI_GETSHOWSOUNDS,
		SPI_SETSHOWSOUNDS,
		SPI_GETSTICKYKEYS,
		SPI_SETSTICKYKEYS,
		SPI_GETACCESSTIMEOUT,
		SPI_SETACCESSTIMEOUT,
		SPI_GETSERIALKEYS,
		SPI_SETSERIALKEYS,
		SPI_GETSOUNDSENTRY,
		SPI_SETSOUNDSENTRY,
		SPI_GETSNAPTODEFBUTTON = 95u,
		SPI_SETSNAPTODEFBUTTON,
		SPI_GETMOUSEHOVERWIDTH = 98u,
		SPI_SETMOUSEHOVERWIDTH,
		SPI_GETMOUSEHOVERHEIGHT,
		SPI_SETMOUSEHOVERHEIGHT,
		SPI_GETMOUSEHOVERTIME,
		SPI_SETMOUSEHOVERTIME,
		SPI_GETWHEELSCROLLLINES,
		SPI_SETWHEELSCROLLLINES,
		SPI_GETMENUSHOWDELAY,
		SPI_SETMENUSHOWDELAY,
		SPI_GETSHOWIMEUI = 110u,
		SPI_SETSHOWIMEUI,
		SPI_GETMOUSESPEED,
		SPI_SETMOUSESPEED,
		SPI_GETSCREENSAVERRUNNING,
		SPI_GETDESKWALLPAPER,
		SPI_GETACTIVEWINDOWTRACKING = 4096u,
		SPI_SETACTIVEWINDOWTRACKING,
		SPI_GETMENUANIMATION,
		SPI_SETMENUANIMATION,
		SPI_GETCOMBOBOXANIMATION,
		SPI_SETCOMBOBOXANIMATION,
		SPI_GETLISTBOXSMOOTHSCROLLING,
		SPI_SETLISTBOXSMOOTHSCROLLING,
		SPI_GETGRADIENTCAPTIONS,
		SPI_SETGRADIENTCAPTIONS,
		SPI_GETKEYBOARDCUES,
		SPI_SETKEYBOARDCUES,
		SPI_GETMENUUNDERLINES = 4106u,
		SPI_SETMENUUNDERLINES,
		SPI_GETACTIVEWNDTRKZORDER,
		SPI_SETACTIVEWNDTRKZORDER,
		SPI_GETHOTTRACKING,
		SPI_SETHOTTRACKING,
		SPI_GETMENUFADE = 4114u,
		SPI_SETMENUFADE,
		SPI_GETSELECTIONFADE,
		SPI_SETSELECTIONFADE,
		SPI_GETTOOLTIPANIMATION,
		SPI_SETTOOLTIPANIMATION,
		SPI_GETTOOLTIPFADE,
		SPI_SETTOOLTIPFADE,
		SPI_GETCURSORSHADOW,
		SPI_SETCURSORSHADOW,
		SPI_GETMOUSESONAR,
		SPI_SETMOUSESONAR,
		SPI_GETMOUSECLICKLOCK,
		SPI_SETMOUSECLICKLOCK,
		SPI_GETMOUSEVANISH,
		SPI_SETMOUSEVANISH,
		SPI_GETFLATMENU,
		SPI_SETFLATMENU,
		SPI_GETDROPSHADOW,
		SPI_SETDROPSHADOW,
		SPI_GETBLOCKSENDINPUTRESETS,
		SPI_SETBLOCKSENDINPUTRESETS,
		SPI_GETUIEFFECTS = 4158u,
		SPI_SETUIEFFECTS,
		SPI_GETFOREGROUNDLOCKTIMEOUT = 8192u,
		SPI_SETFOREGROUNDLOCKTIMEOUT,
		SPI_GETACTIVEWNDTRKTIMEOUT,
		SPI_SETACTIVEWNDTRKTIMEOUT,
		SPI_GETFOREGROUNDFLASHCOUNT,
		SPI_SETFOREGROUNDFLASHCOUNT,
		SPI_GETCARETWIDTH,
		SPI_SETCARETWIDTH,
		SPI_GETMOUSECLICKLOCKTIME,
		SPI_SETMOUSECLICKLOCKTIME,
		SPI_GETFONTSMOOTHINGTYPE,
		SPI_SETFONTSMOOTHINGTYPE,
		SPI_GETFONTSMOOTHINGCONTRAST,
		SPI_SETFONTSMOOTHINGCONTRAST,
		SPI_GETFOCUSBORDERWIDTH,
		SPI_SETFOCUSBORDERWIDTH,
		SPI_GETFOCUSBORDERHEIGHT,
		SPI_SETFOCUSBORDERHEIGHT,
		SPI_GETFONTSMOOTHINGORIENTATION,
		SPI_SETFONTSMOOTHINGORIENTATION
	}
}
