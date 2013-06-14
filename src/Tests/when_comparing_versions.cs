using NUnit.Framework;
using PRI.ProductivityExtensions.VersionExtensions;

namespace Tests
{
	[TestFixture]
	public class when_comparing_versions
	{
		[Test]
		public void then_earlier_version_compared_as_earlier_correctly()
		{
			Assert.IsTrue(Versionable.WindowsVistaVersion.IsEarlierThan(Versionable.Windows8Version));
		}

		[Test]
		public void then_laster_version_compared_as_earlier_fails()
		{
			Assert.IsFalse(Versionable.Windows8Version.IsEarlierThan(Versionable.WindowsVistaVersion));
		}

		[Test]
		public void then_later_version_compared_as_later_correctly()
		{
			Assert.IsTrue(Versionable.Windows8Version.IsLaterThan(Versionable.WindowsVistaVersion));
		}

		[Test]
		public void then_ealier_version_compared_as_later_fails()
		{
			Assert.IsFalse(Versionable.WindowsVistaVersion.IsLaterThan(Versionable.Windows8Version));
		}

		[Test]
		public void then_older_version_compared_as_older_correctly()
		{
			Assert.IsTrue(Versionable.WindowsVistaVersion.IsOlderThan(Versionable.Windows8Version));
		}

		[Test]
		public void then_newer_version_compared_as_older_fails()
		{
			Assert.IsFalse(Versionable.Windows8Version.IsOlderThan(Versionable.WindowsVistaVersion));
		}

		[Test]
		public void then_newer_version_compared_as_newer_correctly()
		{
			Assert.IsTrue(Versionable.Windows8Version.IsNewerThan(Versionable.WindowsVistaVersion));
		}

		[Test]
		public void then_older_version_compared_as_newer_correctly()
		{
			Assert.IsFalse(Versionable.WindowsVistaVersion.IsNewerThan(Versionable.Windows8Version));
		}

		[Test]
		public void then_version_between_others_compares_correctly()
		{
			Assert.IsTrue(Versionable.WindowsVistaVersion.IsBetween(Versionable.Windows95Version, Versionable.Windows8Version));
		}

		[Test]
		public void then_version_not_between_others_fails()
		{
			Assert.IsFalse(Versionable.Windows95Version.IsBetween(Versionable.WindowsVistaVersion, Versionable.Windows8Version));
		}
	}
}