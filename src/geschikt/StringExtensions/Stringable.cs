using System;
using System.Collections.Generic;
using System.Linq;

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

		/// <summary>
		/// Replace any instances of individual elements in <paramref name="chars"/> with <paramref name="c"/>
		/// in <paramref name="text"/>.
		/// </summary>
		/// <param name="text">string to search within.</param>
		/// <param name="chars">individual characters to search for.</param>
		/// <param name="c">character to replace any found characters with.</param>
		/// <returns></returns>
		public static string ReplaceEach(this string text, IEnumerable<char> chars, char c)
		{
			return string.Join(c.ToString(System.Globalization.CultureInfo.InvariantCulture),
				text.Split(chars.ToArray()));
		}
	}
}