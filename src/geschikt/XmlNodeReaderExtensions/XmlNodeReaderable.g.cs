//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Xml;

namespace PRI.ProductivityExtensions.XmlNodeReaderExtensions
{

	/// <summary>
	/// Class that contains extension methods that extend <seealso cref="System.Xml.XmlNodeReader">XmlNodeReader</seealso>
	/// </summary>
	public static partial class XmlNodeReaderable
	{
		/// <summary>
		/// Extends ReadContentAs so that methods that return a specific type object given a Type parameter can be
		/// used as generic method and casting is not required.
		/// <example>
		/// xmlreader.ReadContentAs<int>(namespaceResolver);
		/// </example>
		/// </summary>
		public static T ReadContentAs<T>(this XmlNodeReader xmlreader, IXmlNamespaceResolver namespaceResolver)
		{
			if(xmlreader == null) throw new ArgumentNullException("xmlreader");

			return (T)xmlreader.ReadContentAs(typeof(T), namespaceResolver);
		}

		/// <summary>
		/// Extends ReadElementContentAs so that methods that return a specific type object given a Type parameter can be
		/// used as generic method and casting is not required.
		/// <example>
		/// xmlreader.ReadElementContentAs<int>(namespaceResolver);
		/// </example>
		/// </summary>
		public static T ReadElementContentAs<T>(this XmlNodeReader xmlreader, IXmlNamespaceResolver namespaceResolver)
		{
			if(xmlreader == null) throw new ArgumentNullException("xmlreader");

			return (T)xmlreader.ReadElementContentAs(typeof(T), namespaceResolver);
		}

		/// <summary>
		/// Extends ReadElementContentAs so that methods that return a specific type object given a Type parameter can be
		/// used as generic method and casting is not required.
		/// <example>
		/// xmlreader.ReadElementContentAs<int>(namespaceResolver, localName, namespaceURI);
		/// </example>
		/// </summary>
		public static T ReadElementContentAs<T>(this XmlNodeReader xmlreader, IXmlNamespaceResolver namespaceResolver, String localName, String namespaceURI)
		{
			if(xmlreader == null) throw new ArgumentNullException("xmlreader");

			return (T)xmlreader.ReadElementContentAs(typeof(T), namespaceResolver, localName, namespaceURI);
		}

	}
}
