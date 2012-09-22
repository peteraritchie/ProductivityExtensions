//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Windows.Forms;

namespace PRI.ProductivityExtensions.DataGridViewCellStyleConverterExtensions
{

	/// <summary>
	/// Class that contains extension methods that extend <seealso cref="System.Windows.Forms.DataGridViewCellStyleConverter">DataGridViewCellStyleConverter</seealso>
	/// </summary>
	public static partial class DataGridViewCellStyleConverterable
	{
		/// <summary>
		/// Extends ConvertTo so that methods that return a specific type object given a Type parameter can be
		/// used as generic method and casting is not required.
		/// <example>
		/// typeconverter.ConvertTo<int>(value);
		/// </example>
		/// </summary>
		public static T ConvertTo<T>(this DataGridViewCellStyleConverter typeconverter, Object value)
		{
			if(typeconverter == null) throw new ArgumentNullException("typeconverter");

			return (T)typeconverter.ConvertTo(value, typeof(T));
		}

		/// <summary>
		/// Extends ConvertTo so that methods that return a specific type object given a Type parameter can be
		/// used as generic method and casting is not required.
		/// <example>
		/// datagridviewcellstyleconverter.ConvertTo<int>(context, culture, value);
		/// </example>
		/// </summary>
		public static T ConvertTo<T>(this DataGridViewCellStyleConverter datagridviewcellstyleconverter, System.ComponentModel.ITypeDescriptorContext context, System.Globalization.CultureInfo culture, Object value)
		{
			if(datagridviewcellstyleconverter == null) throw new ArgumentNullException("datagridviewcellstyleconverter");

			return (T)datagridviewcellstyleconverter.ConvertTo(context, culture, value, typeof(T));
		}

	}
}
