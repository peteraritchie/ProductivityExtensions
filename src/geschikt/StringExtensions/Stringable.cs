using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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

		/// <summary>
		/// Truncate string <paramref name="text"/> to a maximim length of <paramref name="maxLength"/>
		/// </summary>
		/// <param name="text"></param>
		/// <param name="maxLength"></param>
		/// <returns></returns>
		public static string Truncate(this string text, int maxLength)
		{
			if (text == null) return null;
			return text.Substring(0, Math.Min(text.Length, maxLength));
		}

		/// <summary>
		/// Convert a string value to an int.
		/// </summary>
		/// <param name="source"></param>
		/// <returns>null if textual value is not an int or the int value.</returns>
		public static int? ToIntOrNull(this string source)
		{
			int results;
			if (!int.TryParse(source, out results))
			{
				return null;
			}
			return results;
		}

		/// <summary>
		/// Convert a string value to an int.
		/// </summary>
		/// <param name="source"></param>
		/// <returns>0 if textual value is not an int or the int value.</returns>
		public static int ToIntOrDefault(this string source)
		{
			int results;
			return !int.TryParse(source, out results) ? default(int) : results;
		}

		/// <summary>
		/// Convert a string value to an int.
		/// </summary>
		/// <param name="source"></param>
		/// <param name="defaultValue"></param>
		/// <returns><paramref name="defaultValue"/> if textual value is not an int or the int value.</returns>
		public static int ToInt(this string source, int defaultValue = 0)
		{
			int results;
			return !int.TryParse(source, out results) ? defaultValue : results;
		}

		/// <summary>
		/// Convert a string value to a long.
		/// </summary>
		/// <param name="source"></param>
		/// <returns>null if textual value is not a long or the long value.</returns>
		public static long? ToLongOrNull(this string source)
		{
			long results;
			if (!long.TryParse(source, out results))
			{
				return null;
			}
			return results;
		}


		/// <summary>
		/// Convert a string value to a long.
		/// </summary>
		/// <param name="source"></param>
		/// <returns>0L if textual value is not a long or the long value.</returns>
		public static long ToLongOrDefault(this string source)
		{
			long results;
			if (!long.TryParse(source, out results))
			{
				return default(long);
			}
			return results;
		}


		/// <summary>
		/// Convert a string value to a DateTime.
		/// </summary>
		/// <param name="source"></param>
		/// <returns>null if textual value is not a DateTime or the DateTime value.</returns>
		public static DateTime? ToDateTimeOrNull(this string source)
		{
			DateTime results;
			if (!DateTime.TryParse(source, out results))
			{
				return null;
			}
			return results;
		}

		/// <summary>
		/// Convert a string value to a TimeSpan.
		/// </summary>
		/// <param name="source"></param>
		/// <returns>null if textual value is not a TimeSpan or the TimeSpan value.</returns>
		public static TimeSpan? ToTimeSpanOrNull(this string source)
		{
			TimeSpan time;
			if (TimeSpan.TryParse(source, out time))
				return time;
			return null;
		}

		/// <summary>
		/// Convert a string value to double.
		/// </summary>
		/// <param name="source"></param>
		/// <returns>null if textual value is not a double or the double value.</returns>
		public static double? ToDoubleOrNull(this string source)
		{
			double results;
			if (!double.TryParse(source, out results))
			{
				return null;
			}
			return results;
		}

		/// <summary>
		/// Convert a string value to double.
		/// </summary>
		/// <param name="source"></param>
		/// <returns>0d if textual value is not a double or the double value.</returns>
		public static double ToDoubleOrDefault(this string source)
		{
			double results;
			if (!double.TryParse(source, out results))
			{
				return default(double);
			}
			return results;
		}

		/// <summary>
		/// Convert a string value to decimal.
		/// </summary>
		/// <param name="source"></param>
		/// <returns>null if textual value is not a decimal or the decimal value.</returns>
		public static decimal? ToDecimalOrNull(this string source)
		{
			decimal results;
			if (!decimal.TryParse(source, out results))
			{
				return null;
			}
			return results;
		}

		/// <summary>
		/// Convert a string value to decimal.
		/// </summary>
		/// <param name="source"></param>
		/// <returns>0M if textual value is not a decimal or the decimal value.</returns>
		public static decimal ToDecimalOrDefault(this string source)
		{
			decimal results;
			return !decimal.TryParse(source, out results) ? default(decimal) : results;
		}

		/// <summary>
		/// conert a string to a boolean. Ignore-compare of "True" for true, and "False" for false.
		/// </summary>
		/// <param name="source"></param>
		/// <returns>null if non-boolean textual value or true/false</returns>
		public static bool? ToBoolOrNull(this string source)
		{
			bool results;
			if (!bool.TryParse(source, out results))
			{
				return null;
			}
			return results;
		}

		/// <summary>
		/// Convert a string to a GUID
		/// </summary>
		/// <param name="source"></param>
		/// <returns>GUID or null if non-GUID textual value.</returns>
		public static Guid? ToGuidOrNull(this string source)
		{
			if (string.IsNullOrEmpty(source)) return null;
			try
			{
				return new Guid(source);
			}
			catch (Exception)
			{
				return null;
			}
		}
		/// <summary>
		/// Get the first "Word" in a string--separated by space.
		/// </summary>
		/// <param name="value"></param>
		/// <returns></returns>
		public static string FirstWord(this string value)
		{
			if (value == null) return null;
			var x = value.IndexOf(" ", StringComparison.Ordinal);
			return x != -1 ? value.Substring(0, x) : value;
		}

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'Stringable.Initials(string)'
		public static string Initials(this string value)
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'Stringable.Initials(string)'
		{
			if (value == null) return null;
			var items = value.Split(' ');
			var sb = new StringBuilder();
			foreach (var e in items.Where(e => e.Length >= 1))
			{
				sb.Append(e[0]);
			}
			return sb.ToString();
		}

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'Stringable.IsEmpty(string)'
		public static bool IsEmpty(this string value)
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'Stringable.IsEmpty(string)'
		{
			return String.Empty.Equals(value);
		}
	}
}