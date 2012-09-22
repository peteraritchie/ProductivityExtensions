//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.ComponentModel;

namespace PRI.ProductivityExtensions.DateTimeConverterExtensions
{

	/// <summary>
	/// Class that contains extension methods that extend <seealso cref="System.ComponentModel.DateTimeConverter">DateTimeConverter</seealso>
	/// </summary>
	public static partial class DateTimeConverterable
	{
		/// <summary>
		/// Extends ConvertTo so that methods that return a specific type object given a Type parameter can be
		/// used as generic method and casting is not required.
		/// <example>
		/// datetimeconverter.ConvertTo<int>(context, culture, value);
		/// </example>
		/// </summary>
		public static T ConvertTo<T>(this DateTimeConverter datetimeconverter, ITypeDescriptorContext context, System.Globalization.CultureInfo culture, Object value)
		{
			if(datetimeconverter == null) throw new ArgumentNullException("datetimeconverter");

			return (T)datetimeconverter.ConvertTo(context, culture, value, typeof(T));
		}

		/// <summary>
		/// Extends ConvertTo so that methods that return a specific type object given a Type parameter can be
		/// used as generic method and casting is not required.
		/// <example>
		/// typeconverter.ConvertTo<int>(value);
		/// </example>
		/// </summary>
		public static T ConvertTo<T>(this DateTimeConverter typeconverter, Object value)
		{
			if(typeconverter == null) throw new ArgumentNullException("typeconverter");

			return (T)typeconverter.ConvertTo(value, typeof(T));
		}

	}
}
