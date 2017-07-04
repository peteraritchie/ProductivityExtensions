using System;
using System.Globalization;
using System.Text;

namespace PRI.ProductivityExtensions.ByteArrayExtensions
{
	/// <summary>
	/// class that contains extension methods that extend <seealso cref="T:byte[]"/>
	/// </summary>
	// ReSharper disable once PartialTypeWithSinglePart
	public static partial class ByteArrayable
	{
		/// <summary>
		/// Converts a byte array into a continuous hex string
		/// </summary>
		/// <param name="buffer">buffer that contains the bytes</param>
		/// <param name="offset">offset into the buffer to start</param>
		/// <param name="length">how many types to process</param>
		/// <returns>string of hex characters</returns>
		/// <exception cref="IndexOutOfRangeException">if <paramref name="offset"/> is less than 0 or <paramref name="length"/> is longer than the buffer</exception>
		public static string AsHexString(this byte[] buffer, int offset, int length)
		{
			StringBuilder stringBuilder = new StringBuilder();
			int lineOctet = 0;
			for (int i = offset; i < length; ++i)
			{
				byte b = buffer[i];
				if (lineOctet > 16)
				{
					stringBuilder.Append(Environment.NewLine);
					lineOctet = 0;
				}
				stringBuilder.Append(string.Format("{0} ", b.ToString("X2", CultureInfo.CurrentCulture)));
			}
			return stringBuilder.ToString();
		}

		/// <summary>
		/// Converts a byte array into a continuous hex string
		/// </summary>
		/// <param name="buffer">buffer that contains the bytes</param>
		/// <returns>string of hex characters</returns>
		public static string AsHexString(this byte[] buffer)
		{
			return AsHexString(buffer, 0, buffer.Length);
		}
	}
}