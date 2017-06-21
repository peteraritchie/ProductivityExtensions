#if (NETSTANDARD2_0 || NETSTANDARD1_6 || NETSTANDARD1_5 || NETSTANDARD1_4 || NETSTANDARD1_3 || NETSTANDARD1_2 || NETSTANDARD1_1 || NET45 || NET40 || NET451 || NET452 || NET46 || NET461 || NET462)
using System;
using System.Net;

namespace PRI.ProductivityExtensions.IpAddressExtensions
{
	/// <summary>
	/// class that contains extension methods that extend <seealso cref="IPAddress"/>
	/// </summary>
	public static partial class IpAddressable
	{
		/// <summary>
		/// Checks if an <see cref="IPAddress"/> is IPv4 link local or not
		/// </summary>
		/// <param name="ipAddress">IPAddress to check</param>
		/// <returns>true if IP address is an IPv4 link local address</returns>
		public static bool IsIPv4LinkLocal(this IPAddress ipAddress)
		{
			if (ipAddress == null) throw new ArgumentNullException(nameof(ipAddress));
			byte[] ipBytes = ipAddress.GetAddressBytes();
			return ipBytes[0] == 169 && ipBytes[1] == 254;
		}
	}
}
#endif