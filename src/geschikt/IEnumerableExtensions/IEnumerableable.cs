using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reflection;
using PRI.ProductivityExtensions.ICollectionableExtensions;

namespace PRI.ProductivityExtensions.IEnumerableExtensions
{
	/// <summary>
	/// class that contains extension methods that extend <seealso cref="IEnumerable{T}"/>
	/// </summary>
	public static partial class IEnumerableable
	{
		public static Collection<T> ToCollection<T>(this IEnumerable<T> enumerable)
		{
			if (enumerable == null) throw new ArgumentNullException("enumerable");

			var list = enumerable as IList<T>;
			if (list != null)
			{
				return new Collection<T>(list);
			}
			var collection = new Collection<T>();
			collection.AddRange(enumerable);

			return collection;
		}

		public static IEnumerable<Assembly> ToAssemblies(this IEnumerable<string> filenames)
		{
			foreach (var f in filenames)
			{
				Assembly loadFrom;
				try
				{
					loadFrom = Assembly.LoadFrom(f);
				}
				catch (BadImageFormatException)
				{
					// ignore anything that can't be loaded
					continue;
				}
				catch (ReflectionTypeLoadException)
				{
					// ignore anything that can't be loaded
					continue;
				}
				yield return loadFrom;
			}
		}
	}
}