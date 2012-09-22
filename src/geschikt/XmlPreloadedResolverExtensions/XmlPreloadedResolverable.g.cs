//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Xml.Resolvers;

namespace PRI.ProductivityExtensions.XmlPreloadedResolverExtensions
{

	/// <summary>
	/// Class that contains extension methods that extend <seealso cref="System.Xml.Resolvers.XmlPreloadedResolver">XmlPreloadedResolver</seealso>
	/// </summary>
	public static partial class XmlPreloadedResolverable
	{
		/// <summary>
		/// Extends GetEntity so that methods that return a specific type object given a Type parameter can be
		/// used as generic method and casting is not required.
		/// <example>
		/// xmlpreloadedresolver.GetEntity<int>(absoluteUri, role);
		/// </example>
		/// </summary>
		public static T GetEntity<T>(this XmlPreloadedResolver xmlpreloadedresolver, Uri absoluteUri, String role)
		{
			if(xmlpreloadedresolver == null) throw new ArgumentNullException("xmlpreloadedresolver");

			return (T)xmlpreloadedresolver.GetEntity(absoluteUri, role, typeof(T));
		}

	}
}
