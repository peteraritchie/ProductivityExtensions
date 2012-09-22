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

namespace PRI.ProductivityExtensions.TextReaderExtensions
{

	/// <summary>
	/// Class that contains extension methods that extend <seealso cref="System.IO.TextReader">TextReader</seealso>
	/// </summary>
	public static partial class TextReaderable
	{
		/// <summary>
		/// Extends Read so that buffer offset of 0 and call to Array.Length are not needed.
		/// <example>
		/// textreader.Read(buffer);
		/// </example>
		/// </summary>
		public static Int32 Read(this TextReader textreader, Char[] buffer)
		{
			if(textreader == null) throw new ArgumentNullException("textreader");

			if(buffer == null) throw new ArgumentNullException("buffer");

			return textreader.Read(buffer, 0, buffer.Length);
		}

		/// <summary>
		/// Extends ReadBlock so that buffer offset of 0 and call to Array.Length are not needed.
		/// <example>
		/// textreader.ReadBlock(buffer);
		/// </example>
		/// </summary>
		public static Int32 ReadBlock(this TextReader textreader, Char[] buffer)
		{
			if(textreader == null) throw new ArgumentNullException("textreader");

			if(buffer == null) throw new ArgumentNullException("buffer");

			return textreader.ReadBlock(buffer, 0, buffer.Length);
		}

	}
}
