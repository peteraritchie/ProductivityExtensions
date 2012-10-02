//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Text.RegularExpressions;

namespace PRI.ProductivityExtensions.MatchEvaluatorExtensions
{

	/// <summary>
	/// Class that contains extension methods that extend <seealso cref="System.Text.RegularExpressions.MatchEvaluator">MatchEvaluator</seealso>
	/// </summary>
	public static partial class MatchEvaluatorable
	{
		/// <summary>
		/// Extends BeginInvoke so that when a state object is not needed, null does not need to be passed.
		/// <example>
		/// matchevaluator.BeginInvoke(match, callback);
		/// </example>
		/// </summary>
		public static IAsyncResult BeginInvoke(this MatchEvaluator matchevaluator, Match match, AsyncCallback callback)
		{
			if(matchevaluator == null) throw new ArgumentNullException("matchevaluator");

			return matchevaluator.BeginInvoke(match, callback, null);
		}

	}
}
