using System;

namespace PRI.ProductivityExtensions.VersionExtensions
{
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'Versionable'
	public static class Versionable
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'Versionable'
	{
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'Versionable.WindowsVistaVersion'
		public static Version WindowsVistaVersion = new Version(6, 0, 6000);
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'Versionable.WindowsVistaVersion'
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'Versionable.WindowsVistaSP22Version'
		public static Version WindowsVistaSP22Version = new Version(6, 0, 6002);
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'Versionable.WindowsVistaSP22Version'
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'Versionable.Windows95Version'
		public static Version Windows95Version = new Version(4, 0, 950);
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'Versionable.Windows95Version'
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'Versionable.Windows98Version'
		public static Version Windows98Version = new Version(4, 10, 1998);
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'Versionable.Windows98Version'
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'Versionable.Windows98SEVersion'
		public static Version Windows98SEVersion = new Version(4, 10, 2222);
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'Versionable.Windows98SEVersion'
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'Versionable.WindowsMeVersion'
		public static Version WindowsMeVersion = new Version(4, 90, 3000);
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'Versionable.WindowsMeVersion'
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'Versionable.WindowsNT4Version'
		public static Version WindowsNT4Version = new Version(4, 0, 1381);
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'Versionable.WindowsNT4Version'
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'Versionable.Windows2000Version'
		public static Version Windows2000Version = new Version(5, 0, 2195);
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'Versionable.Windows2000Version'
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'Versionable.Windows2003Version'
		public static Version Windows2003Version = new Version(5, 2, 3790);
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'Versionable.Windows2003Version'
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'Versionable.Windows2003R2Version'
		public static Version Windows2003R2Version = new Version(4, 90, 0);
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'Versionable.Windows2003R2Version'
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'Versionable.WindowsXPVersion'
		public static Version WindowsXPVersion = new Version(5, 1, 2600);
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'Versionable.WindowsXPVersion'
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'Versionable.Windows2008Version'
		public static Version Windows2008Version = new Version(6, 0, 6001);
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'Versionable.Windows2008Version'
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'Versionable.Windows2008R2Version'
		public static Version Windows2008R2Version = new Version(6, 1, 7600, 16385);
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'Versionable.Windows2008R2Version'
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'Versionable.Windows7Version'
		public static Version Windows7Version = new Version(6, 1, 7600);
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'Versionable.Windows7Version'
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'Versionable.Windows7SP1Version'
		public static Version Windows7SP1Version = new Version(6, 1, 7601);
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'Versionable.Windows7SP1Version'
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'Versionable.Windows8Version'
		public static Version Windows8Version = new Version(6, 2, 9200);
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'Versionable.Windows8Version'
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'Versionable.Windows2012Version'
		public static Version Windows2012Version = new Version(6, 2, 9200);
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'Versionable.Windows2012Version'
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'Versionable.Windows8_1Version'
		public static Version Windows8_1Version = new Version(6, 3, 9600);
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'Versionable.Windows8_1Version'
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'Versionable.Windows2012R2Version'
		public static Version Windows2012R2Version = new Version(6, 3, 9700);
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'Versionable.Windows2012R2Version'
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'Versionable.Windows10Version'
		public static Version Windows10Version = new Version(10, 0, 10240);
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'Versionable.Windows10Version'

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'Versionable.IsEarlierThan(Version, Version)'
		public static bool IsEarlierThan(this Version leftVersion, Version rightVersion)
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'Versionable.IsEarlierThan(Version, Version)'
		{
			return leftVersion < rightVersion;
		}

		[Obsolete("misspelled name")]
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'Versionable.IsVerisonOrEarlierThan(Version, Version)'
		public static bool IsVerisonOrEarlierThan(this Version leftVersion, Version rightVersion)
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'Versionable.IsVerisonOrEarlierThan(Version, Version)'
		{
			return leftVersion <= rightVersion;
		}

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'Versionable.IsVersionOrEarlierThan(Version, Version)'
		public static bool IsVersionOrEarlierThan(this Version leftVersion, Version rightVersion)
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'Versionable.IsVersionOrEarlierThan(Version, Version)'
		{
			return leftVersion <= rightVersion;
		}

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'Versionable.IsOlderThan(Version, Version)'
		public static bool IsOlderThan(this Version leftVersion, Version rightVersion)
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'Versionable.IsOlderThan(Version, Version)'
		{
			return leftVersion < rightVersion;
		}

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'Versionable.IsVersionOrOlderThan(Version, Version)'
		public static bool IsVersionOrOlderThan(this Version leftVersion, Version rightVersion)
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'Versionable.IsVersionOrOlderThan(Version, Version)'
		{
			return leftVersion <= rightVersion;
		}

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'Versionable.IsLaterThan(Version, Version)'
		public static bool IsLaterThan(this Version leftVersion, Version rightVersion)
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'Versionable.IsLaterThan(Version, Version)'
		{
			return leftVersion > rightVersion;
		}

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'Versionable.IsVersionOrLaterThan(Version, Version)'
		public static bool IsVersionOrLaterThan(this Version leftVersion, Version rightVersion)
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'Versionable.IsVersionOrLaterThan(Version, Version)'
		{
			return leftVersion >= rightVersion;
		}

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'Versionable.IsNewerThan(Version, Version)'
		public static bool IsNewerThan(this Version leftVersion, Version rightVersion)
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'Versionable.IsNewerThan(Version, Version)'
		{
			return leftVersion > rightVersion;
		}

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'Versionable.IsVersionOrNewerThan(Version, Version)'
		public static bool IsVersionOrNewerThan(this Version leftVersion, Version rightVersion)
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'Versionable.IsVersionOrNewerThan(Version, Version)'
		{
			return leftVersion > rightVersion;
		}

		// TODO: pull up to generic
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'Versionable.IsBetween(Version, Version, Version)'
		public static bool IsBetween(this Version middle, Version leftVersion, Version rightVersion)
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'Versionable.IsBetween(Version, Version, Version)'
		{
			return middle > leftVersion && middle < rightVersion;
		}
	}
}