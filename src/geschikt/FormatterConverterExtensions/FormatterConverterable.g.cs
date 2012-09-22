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

namespace PRI.ProductivityExtensions.FormatterConverterExtensions
{

	/// <summary>
	/// Class that contains extension methods that extend <seealso cref="System.Runtime.Serialization.FormatterConverter">FormatterConverter</seealso>
	/// </summary>
	public static partial class FormatterConverterable
	{
		/// <summary>
		/// Extends Convert so that methods that return a specific type object given a Type parameter can be
		/// used as generic method and casting is not required.
		/// <example>
		/// formatterconverter.Convert<int>(value);
		/// </example>
		/// </summary>
		public static T Convert<T>(this FormatterConverter formatterconverter, Object value)
		{
			if(formatterconverter == null) throw new ArgumentNullException("formatterconverter");

			return (T)formatterconverter.Convert(value, typeof(T));
		}

	}
}
