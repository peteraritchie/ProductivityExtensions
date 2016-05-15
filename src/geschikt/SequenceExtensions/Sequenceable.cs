using System;
using System.Collections.Generic;
using System.Linq;

namespace PRI.ProductivityExtensions.SequenceExtensions
{
	public static class Sequenceable
	{
		/// <summary>
		/// Compares two sequences to see if they are equal
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

		/// <summary>
		/// Compare percentage equality of one collection to another
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="source"></param>
		/// <param name="that"></param>
		/// <param name="equalityComparer"></param>
		/// <returns></returns>
		public static int SequenceEquality<T>(this IEnumerable<T> source, IEnumerable<T> that, IEqualityComparer<T> equalityComparer)
		{
			if (source == null) throw new ArgumentNullException("source");
			if (that == null) throw new ArgumentNullException("that");
			var sourceCount = source.Count();
			if (sourceCount == 0) return 100;
			var thatCount = that.Count();
			if (thatCount == 0) return -100;

			int matches = 0;
			foreach (var e in source)
			{
				if (that.Contains(e, equalityComparer))
				{
					matches++;
				}
			}
			int p;
			if (sourceCount >= thatCount)
			{
				if (matches == 0) return 100;
				p = matches * 100 / sourceCount;
				return p == 100 ? 0 : p;
			}
			if (matches == 0) return -100;
			p = -matches * 100 / thatCount;
			return p == 100 ? 0 : p;
		}
	}
}