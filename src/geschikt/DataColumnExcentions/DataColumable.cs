#if (NETSTANDARD2_0 || NET4_0 || NET4_5)
using System;
using System.Data;

namespace PRI.ProductivityExtensions.DataColumnExcentions
{
	/// <summary>
	/// class that contains extension methods that extend <seealso cref="DataColumnCollection"/>
	/// </summary>
	public static class DataColumable
	{
		/// <summary>
		/// Adds a generic Add&lt;T&gt; to DataColumnCollection to avoid Add(typeof(T), "columnName")
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="dataColumnCollection"></param>
		/// <param name="columnName"></param>
		public static void Add<T>(this DataColumnCollection dataColumnCollection, string columnName)
		{
			if (dataColumnCollection == null) throw new ArgumentNullException(nameof(dataColumnCollection));
			dataColumnCollection.Add(columnName, typeof(T));
		}
	}
}
#endif