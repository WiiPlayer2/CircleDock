using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.Resources;
using System.Runtime.CompilerServices;

namespace CircleDock
{
	[GeneratedCode("System.Resources.Tools.StronglyTypedResourceBuilder", "2.0.0.0"), DebuggerNonUserCode, CompilerGenerated]
	internal class ImageResources
	{
		private static ResourceManager resourceMan;

		private static CultureInfo resourceCulture;

		[EditorBrowsable(EditorBrowsableState.Advanced)]
		internal static ResourceManager ResourceManager
		{
			get
			{
				if (object.ReferenceEquals(ImageResources.resourceMan, null))
				{
					ResourceManager resourceManager = new ResourceManager("CircleDock.ImageResources", typeof(ImageResources).Assembly);
					ImageResources.resourceMan = resourceManager;
				}
				return ImageResources.resourceMan;
			}
		}

		[EditorBrowsable(EditorBrowsableState.Advanced)]
		internal static CultureInfo Culture
		{
			get
			{
				return ImageResources.resourceCulture;
			}
			set
			{
				ImageResources.resourceCulture = value;
			}
		}

		internal static Bitmap CircleDockIconCentreImage
		{
			get
			{
				object @object = ImageResources.ResourceManager.GetObject("CircleDockIconCentreImage", ImageResources.resourceCulture);
				return (Bitmap)@object;
			}
		}

		internal static Bitmap Garbage_Can
		{
			get
			{
				object @object = ImageResources.ResourceManager.GetObject("Garbage_Can", ImageResources.resourceCulture);
				return (Bitmap)@object;
			}
		}

		internal static Bitmap General
		{
			get
			{
				object @object = ImageResources.ResourceManager.GetObject("General", ImageResources.resourceCulture);
				return (Bitmap)@object;
			}
		}

		internal static Bitmap Help
		{
			get
			{
				object @object = ImageResources.ResourceManager.GetObject("Help", ImageResources.resourceCulture);
				return (Bitmap)@object;
			}
		}

		internal static Bitmap MissingIcon
		{
			get
			{
				object @object = ImageResources.ResourceManager.GetObject("MissingIcon", ImageResources.resourceCulture);
				return (Bitmap)@object;
			}
		}

		internal static Bitmap Poof
		{
			get
			{
				object @object = ImageResources.ResourceManager.GetObject("Poof", ImageResources.resourceCulture);
				return (Bitmap)@object;
			}
		}

		internal static Bitmap sapphire_ring
		{
			get
			{
				object @object = ImageResources.ResourceManager.GetObject("sapphire_ring", ImageResources.resourceCulture);
				return (Bitmap)@object;
			}
		}

		internal ImageResources()
		{
		}
	}
}
