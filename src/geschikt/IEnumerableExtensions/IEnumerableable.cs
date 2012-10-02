using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using PRI.ProductivityExtensions.ICollectionableExtensions;

namespace PRI.ProductivityExtensions.IEnumerableExtensions
{
	public static partial class IEnumerableable
	{
		public static Collection<T> ToCollection<T>(this IEnumerable<T> enumerable)
		{
			enumerable.Cast<string>();
			
			if (enumerable is IList<T>)
			{
				return new Collection<T>((IList<T>) enumerable);
			}
			Collection<T> collection = new Collection<T>();
			collection.AddRange(enumerable);

			return collection;
		}
	}
}