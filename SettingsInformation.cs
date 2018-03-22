using System;
using System.Collections;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Drawing;
using System.Text;

/// <summary>
/// The namespace SettingsInformation is a collection of structs that is used to hold the general dock settings for Circle Dock.
/// It is used by SettingsLoader to load the general settings from an Config.ini file and allow the program to access the data.
/// The settings are loaded from the Config.ini file into memory to allow for faster performance.
/// Individual dock item settings are dealt with DockItemsInformation and DockItemSettingsLoader.
/// </summary>
namespace SettingsInformation
{
    public struct Background
    {
        /// <summary>
        /// File path to the image for the background.
        /// </summary>
        public String Path;
    }

    public struct CentreImage
    {
        /// <summary>
        /// File path to the default image for the centre image.
        /// </summary>
        public String Path;

        /// <summary>
        /// Width of the centre image in pixels.
        /// </summary>
        public int Width;

        /// <summary>
        /// Height of the centre image in pixels.
        /// </summary>
        public int Height;
    }

    public struct DockItemSize
    {
        public int DefaultWidth;
        public int DefaultHeight;
        public int MinWidth;
        public int MinHeight;
        public int MaxWidth;
        public int MaxHeight;
    }

    public struct CircleParams
    {
        public int MinRadius;
        public int CircleSeparation;
        public String Format;
        public int ConstNumItemsPerCircle;
    }

    public struct EllipseParams
    {
        public int MinHeight;
        public float AspectRatio;
    }

    public struct Language
    {
        public String path;
    }

    public struct ObjectShape
    {
        public String Shape;
    }

    public struct Folders
    {
        public String DockFolderImagePath;
    }
}
