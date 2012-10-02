using System;

namespace PRI.ProductivityExtensions.StringExtensions
{
	public static partial class Stringable
	{
		/// <summary>
		/// Returns the last few characters of the string with a length
		/// specified by the given parameter. If the string's length is less than the 
		/// given length the complete string is returned. If length is zero or 
		/// less an empty string is returned
		/// </summary>
		/// <param name="s">the string to process</param>
		/// <param name="length">Number of characters to return</param>
		/// <returns></returns>
		// PR: source http://www.extensionmethod.net/Details.aspx?ID=58
		// Author: C.F. Meijers
		public static string Right(this string s, int length)
		{
			length = Math.Max(length, 0);

			return s.Length > length ? s.Substring(s.Length - length, length) : s;
		}

		/// <summary>
		/// Returns the first few characters of the string with a length
		/// specified by the given parameter. If the string's length is less than the 
		/// given length the complete string is returned. If length is zero or 
		/// less an empty string is returned
		/// </summary>
		/// <param name="s">the string to process</param>
		/// <param name="length">Number of characters to return</param>
		/// <returns></returns>
		// PR: source http://www.extensionmethod.net/Details.aspx?ID=57
		// Author: C.F. Meijers
		public static string Left(this string s, int length)
		{
			length = Math.Max(length, 0);

			return s.Length > length ? s.Substring(0, length) : s;
		}
	}
}