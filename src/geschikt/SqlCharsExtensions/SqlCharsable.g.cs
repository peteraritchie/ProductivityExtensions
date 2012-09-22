//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Data.SqlTypes;

namespace PRI.ProductivityExtensions.SqlCharsExtensions
{

	/// <summary>
	/// Class that contains extension methods that extend <seealso cref="System.Data.SqlTypes.SqlChars">SqlChars</seealso>
	/// </summary>
	public static partial class SqlCharsable
	{
		/// <summary>
		/// Extends Read so that buffer offset of 0 and call to Array.Length are not needed.
		/// <example>
		/// sqlchars.Read(offset, buffer);
		/// </example>
		/// </summary>
		public static Int64 Read(this SqlChars sqlchars, Int64 offset, Char[] buffer)
		{
			if(sqlchars == null) throw new ArgumentNullException("sqlchars");

			if(buffer == null) throw new ArgumentNullException("buffer");

			return sqlchars.Read(offset, buffer, 0, buffer.Length);
		}

		/// <summary>
		/// Extends Write so that buffer offset of 0 and call to Array.Length are not needed.
		/// <example>
		/// sqlchars.Write(offset, buffer);
		/// </example>
		/// </summary>
		public static void Write(this SqlChars sqlchars, Int64 offset, Char[] buffer)
		{
			if(sqlchars == null) throw new ArgumentNullException("sqlchars");

			if(buffer == null) throw new ArgumentNullException("buffer");

			sqlchars.Write(offset, buffer, 0, buffer.Length);
		}

	}
}
