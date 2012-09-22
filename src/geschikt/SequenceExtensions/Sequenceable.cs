using System;
using System.Collections.Generic;

namespace PRI.ProductivityExtensions.SequenceExtensions
{
	public static class Sequenceable
	{
		/// <summary>
		/// Compares two sequences to see if they are qual
		/// </summary>
		/// <remarks>
		/// The default <see cref="EqualityComparer&lt;T&gt;"/> for <typeparamref name="TSource"/> is used 
		/// </remarks>
		/// <typeparam name="TSource"></typeparam>
		/// <param name="first"></param>
		/// <param name="second"></param>
		/// <param name="offsetIntoSecond"></param>
		/// <returns></returns>
		public static bool SequenceEqual<TSource>(this IEnumerable<TSource> first, IEnumerable<TSource> second, int offsetIntoSecond)
		{
			if (first == null) throw new ArgumentNullException("first");
			if (second == null) throw new ArgumentNullException("second");
			var comparer = EqualityComparer<TSource>.Default;
			using (IEnumerator<TSource> e1 = first.GetEnumerator())
			using (IEnumerator<TSource> e2 = second.GetEnumerator())
			{
				for (int i = 0; i < offsetIntoSecond; ++i) e2.MoveNext();
				while (e1.MoveNext())
				{
					if (!(e2.MoveNext() && comparer.Equals(e1.Current, e2.Current))) return false;
				}
			}
			return true;
		}
	}
}