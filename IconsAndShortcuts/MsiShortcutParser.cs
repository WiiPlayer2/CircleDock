using System;
using System.Runtime.InteropServices;
using System.Text;

namespace IconsAndShortcuts
{
	public class MsiShortcutParser
	{
		public enum InstallState
		{
			NotUsed = -7,
			BadConfig,
			Incomplete,
			SourceAbsent,
			MoreData,
			InvalidArg,
			Unknown,
			Broken,
			Advertised,
			Removed = 1,
			Absent,
			Local,
			Source,
			Default
		}

		public const int MaxFeatureLength = 38;

		public const int MaxGuidLength = 38;

		public const int MaxPathLength = 1024;

		[DllImport("msi.dll", CharSet = CharSet.Auto)]
		private static extern int MsiGetShortcutTarget(string targetFile, StringBuilder productCode, StringBuilder featureID, StringBuilder componentCode);

		[DllImport("msi.dll", CharSet = CharSet.Auto)]
		private static extern MsiShortcutParser.InstallState MsiGetComponentPath(string productCode, string componentCode, StringBuilder componentPath, ref int componentPathBufferSize);

		public static string ParseShortcut(string file)
		{
			StringBuilder stringBuilder = new StringBuilder(39);
			StringBuilder featureID = new StringBuilder(39);
			StringBuilder stringBuilder2 = new StringBuilder(39);
			MsiShortcutParser.MsiGetShortcutTarget(file, stringBuilder, featureID, stringBuilder2);
			int capacity = 1024;
			StringBuilder stringBuilder3 = new StringBuilder(capacity);
			MsiShortcutParser.InstallState installState = MsiShortcutParser.MsiGetComponentPath(stringBuilder.ToString(), stringBuilder2.ToString(), stringBuilder3, ref capacity);
			string result;
			if (installState == MsiShortcutParser.InstallState.Local)
			{
				result = stringBuilder3.ToString();
			}
			else
			{
				result = null;
			}
			return result;
		}
	}
}
