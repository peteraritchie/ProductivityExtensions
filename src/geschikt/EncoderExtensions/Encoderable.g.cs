//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Text;

namespace PRI.ProductivityExtensions.EncoderExtensions
{

	/// <summary>
	/// Class that contains extension methods that extend <seealso cref="System.Text.Encoder">Encoder</seealso>
	/// </summary>
	public static partial class Encoderable
	{
		/// <summary>
		/// Extends GetByteCount so that buffer offset of 0 and call to Array.Length are not needed.
		/// <example>
		/// encoder.GetByteCount(chars, flush);
		/// </example>
		/// </summary>
		public static Int32 GetByteCount(this Encoder encoder, Char[] chars, Boolean flush)
		{
			if(encoder == null) throw new ArgumentNullException("encoder");

			if(chars == null) throw new ArgumentNullException("chars");

			return encoder.GetByteCount(chars, 0, chars.Length, flush);
		}

		/// <summary>
		/// Extends GetBytes so that buffer offset of 0 and call to Array.Length are not needed.
		/// <example>
		/// encoder.GetBytes(chars, bytes, byteIndex, flush);
		/// </example>
		/// </summary>
		public static Int32 GetBytes(this Encoder encoder, Char[] chars, Byte[] bytes, Int32 byteIndex, Boolean flush)
		{
			if(encoder == null) throw new ArgumentNullException("encoder");

			if(chars == null) throw new ArgumentNullException("chars");

			return encoder.GetBytes(chars, 0, chars.Length, bytes, byteIndex, flush);
		}

		/// <summary>
		/// Extends Convert so that buffer offset of 0 and call to Array.Length are not needed.
		/// <example>
		/// encoder.Convert(chars, bytes, byteIndex, byteCount, flush, charsUsed, bytesUsed, completed);
		/// </example>
		/// </summary>
		public static void Convert(this Encoder encoder, Char[] chars, Byte[] bytes, Int32 byteIndex, Int32 byteCount, Boolean flush, out Int32 charsUsed, out Int32 bytesUsed, out Boolean completed)
		{
			if(encoder == null) throw new ArgumentNullException("encoder");

			if(chars == null) throw new ArgumentNullException("chars");

			encoder.Convert(chars, 0, chars.Length, bytes, byteIndex, byteCount, flush, out charsUsed, out bytesUsed, out completed);
		}

	}
}