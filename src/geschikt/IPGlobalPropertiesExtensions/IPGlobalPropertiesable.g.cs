//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Net.NetworkInformation;

namespace PRI.ProductivityExtensions.IPGlobalPropertiesExtensions
{

	/// <summary>
	/// Class that contains extension methods that extend <seealso cref="System.Net.NetworkInformation.IPGlobalProperties">IPGlobalProperties</seealso>
	/// </summary>
	public static partial class IPGlobalPropertiesable
	{
		/// <summary>
		/// Extends BeginGetUnicastAddresses so that when a state object is not needed, null does not need to be passed.
		/// <example>
		/// ipglobalproperties.BeginGetUnicastAddresses(callback);
		/// </example>
		/// </summary>
		public static IAsyncResult BeginGetUnicastAddresses(this IPGlobalProperties ipglobalproperties, AsyncCallback callback)
		{
			if(ipglobalproperties == null) throw new ArgumentNullException("ipglobalproperties");

			return ipglobalproperties.BeginGetUnicastAddresses(callback, null);
		}

	}
}
