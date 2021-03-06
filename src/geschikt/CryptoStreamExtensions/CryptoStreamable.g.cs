#if (NETSTANDARD1_6 || NETSTANDARD2_0 || NET45 || NET40 || NET451 || NET452 || NET46 || NET461 || NET462)
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Security.Cryptography;

namespace PRI.ProductivityExtensions.CryptoStreamExtensions
{

	/// <summary>
	/// Class that contains extension methods that extend <seealso cref="System.Security.Cryptography.CryptoStream">CryptoStream</seealso>
	/// </summary>
	public static partial class CryptoStreamable
	{
		/// <summary>
		/// Extends BeginRead so that when a state object is not needed, null does not need to be passed.
		/// <example>
		/// stream.BeginRead(buffer, offset, count, callback);
		/// </example>
		/// </summary>
		public static IAsyncResult BeginRead(this CryptoStream stream, Byte[] buffer, Int32 offset, Int32 count, AsyncCallback callback)
		{
			if(stream == null) throw new ArgumentNullException("stream");

			return stream.BeginRead(buffer, offset, count, callback, null);
		}

		/// <summary>
		/// Extends BeginRead so that buffer offset of 0 and call to Array.Length are not needed.
		/// <example>
		/// stream.BeginRead(buffer, callback);
		/// </example>
		/// </summary>
		public static IAsyncResult BeginRead(this CryptoStream stream, Byte[] buffer, AsyncCallback callback)
		{
			if(stream == null) throw new ArgumentNullException("stream");

			if(buffer == null) throw new ArgumentNullException("buffer");

			return stream.BeginRead(buffer, 0, buffer.Length, callback);
		}

		/// <summary>
		/// Extends BeginWrite so that when a state object is not needed, null does not need to be passed.
		/// <example>
		/// stream.BeginWrite(buffer, offset, count, callback);
		/// </example>
		/// </summary>
		public static IAsyncResult BeginWrite(this CryptoStream stream, Byte[] buffer, Int32 offset, Int32 count, AsyncCallback callback)
		{
			if(stream == null) throw new ArgumentNullException("stream");

			return stream.BeginWrite(buffer, offset, count, callback, null);
		}

		/// <summary>
		/// Extends BeginWrite so that buffer offset of 0 and call to Array.Length are not needed.
		/// <example>
		/// stream.BeginWrite(buffer, callback);
		/// </example>
		/// </summary>
		public static IAsyncResult BeginWrite(this CryptoStream stream, Byte[] buffer, AsyncCallback callback)
		{
			if(stream == null) throw new ArgumentNullException("stream");

			if(buffer == null) throw new ArgumentNullException("buffer");

			return stream.BeginWrite(buffer, 0, buffer.Length, callback);
		}

	}
}
#endif