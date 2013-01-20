using System.Net;
using NUnit.Framework;
using PRI.ProductivityExtensions.IpAddressExtensions;

namespace Tests.net45
{
	[TestFixture]
	public class when_working_with_ipv4_addresses
	{
		[Test]
		public void then_loopback_should_not_be_link_local()
		{
			IPAddress ipaddress = IPAddress.Loopback;
			Assert.IsFalse(ipaddress.IsIPv4LinkLocal());
		}
		[Test]
		public void then_link_local_should_be_link_local()
		{
			IPAddress ipaddress = IPAddress.Parse("169.254.0.1");
			Assert.IsTrue(ipaddress.IsIPv4LinkLocal());
		}
	}
}
