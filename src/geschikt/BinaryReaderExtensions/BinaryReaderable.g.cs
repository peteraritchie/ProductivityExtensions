#if (NETSTANDARD2_0 || NETSTANDARD1_6 || NETSTANDARD1_5 || NETSTANDARD1_4 || NETSTANDARD1_3 || NETSTANDARD1_2 || NETSTANDARD1_1 || NETSTANDARD1_0 || NET45 || NET40 || NET451 || NET452 || NET46 || NET461 || NET462)
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.IO;

namespace PRI.ProductivityExtensions.BinaryReaderExtensions
{

	/// <summary>
	/// Class that contains extension methods that extend <seealso cref="System.IO.BinaryReader">BinaryReader</seealso>
	/// </summary>
	public static partial class BinaryReaderable
	{
		/// <summary>
		/// Extends Read so that buffer offset of 0 and call to Array.Length are not needed.
		/// <example>
		/// binaryreader.Read(buffer);
		/// </example>
		/// </summary>
		public static Int32 Read(this BinaryReader binaryreader, Char[] buffer)
		{
			if(binaryreader == null) throw new ArgumentNullException("binaryreader");

			if(buffer == null) throw new ArgumentNullException("buffer");

			return binaryreader.Read(buffer, 0, buffer.Length);
		}

		/// <summary>
		/// Extends Read so that buffer offset of 0 and call to Array.Length are not needed.
		/// <example>
		/// binaryreader.Read(buffer);
		/// </example>
		/// </summary>
		public static Int32 Read(this BinaryReader binaryreader, Byte[] buffer)
		{
			if(binaryreader == null) throw new ArgumentNullException("binaryreader");

			if(buffer == null) throw new ArgumentNullException("buffer");

			return binaryreader.Read(buffer, 0, buffer.Length);
		}

	}
}
#endif