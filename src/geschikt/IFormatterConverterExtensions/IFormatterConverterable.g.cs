//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Runtime.Serialization;

namespace PRI.ProductivityExtensions.IFormatterConverterExtensions
{

	/// <summary>
	/// Class that contains extension methods that extend <seealso cref="System.Runtime.Serialization.IFormatterConverter">IFormatterConverter</seealso>
	/// </summary>
	public static partial class IFormatterConverterable
	{
		/// <summary>
		/// Extends Convert so that methods that return a specific type object given a Type parameter can be
		/// used as generic method and casting is not required.
		/// <example>
		/// iformatterconverter.Convert<int>(value);
		/// </example>
		/// </summary>
		public static T Convert<T>(this IFormatterConverter iformatterconverter, Object value)
		{
			if(iformatterconverter == null) throw new ArgumentNullException("iformatterconverter");

			return (T)iformatterconverter.Convert(value, typeof(T));
		}

	}
}
