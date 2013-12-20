using System;

namespace PRI.ProductivityExtensions.VersionExtensions
{
	public static class Versionable
	{
		public static Version WindowsVistaVersion = new Version(6,0,6000);
		public static Version WindowsVistaSP22Version = new Version(6, 0, 6002);
		public static Version Windows95Version = new Version(4, 0, 950);
		public static Version Windows98Version = new Version(4, 10, 1998);
		public static Version Windows98SEVersion = new Version(4, 10, 2222);
		public static Version WindowsMeVersion = new Version(4, 90, 3000);
		public static Version WindowsNT4Version = new Version(4, 0, 1381);
		public static Version Windows2000Version = new Version(5, 0, 2195);
		public static Version Windows2003Version = new Version(5, 2, 3790);
		public static Version Windows2003R2Version = new Version(4, 90, 0);
		public static Version WindowsXPVersion = new Version(5, 1, 2600);
		public static Version Windows2008Version = new Version(6, 0, 6001);
		public static Version Windows2008R2Version = new Version(6, 1, 7600, 16385);
		public static Version Windows7Version = new Version(6, 1, 7600);
		public static Version Windows7SP1Version = new Version(6, 1, 7601);
		public static Version Windows8Version = new Version(6, 2, 9200);
		public static Version Windows2012Version = new Version(6, 2, 9200);

		public static bool IsEarlierThan(this Version leftVersion, Version rightVersion)
		{
			return leftVersion < rightVersion;
		}

		public static bool IsVerisonOrEarlierThan(this Version leftVersion, Version rightVersion)
		{
			return leftVersion <= rightVersion;
		}

		public static bool IsOlderThan(this Version leftVersion, Version rightVersion)
		{
			return leftVersion < rightVersion;
		}

		public static bool IsVersionOrOlderThan(this Version leftVersion, Version rightVersion)
		{
			return leftVersion <= rightVersion;
		}

		public static bool IsLaterThan(this Version leftVersion, Version rightVersion)
		{
			return leftVersion > rightVersion;
		}

		public static bool IsVersionOrLaterThan(this Version leftVersion, Version rightVersion)
		{
			return leftVersion >= rightVersion;
		}

		public static bool IsNewerThan(this Version leftVersion, Version rightVersion)
		{
			return leftVersion > rightVersion;
		}

		public static bool IsVersionOrNewerThan(this Version leftVersion, Version rightVersion)
		{
			return leftVersion > rightVersion;
		}

		// TODO: pull up to generic
		public static bool IsBetween(this Version middle, Version leftVersion, Version rightVersion)
		{
			return middle > leftVersion && middle < rightVersion;
		}
	}
}