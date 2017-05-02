using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using PRI.ProductivityExtensions.IEnumerableExtensions;

namespace Tests
{
	[TestFixture]
	class when_testing_set_equality
	{
		[Test]
		public void then_two_different_size_lists_are_not_equal()
		{
			var list1 = new List<string> {"one"};
			var list2 = new List<string> { "two", "three" };

			Assert.IsFalse(list1.SetEqual(list2));
		}

		[Test]
		public void then_two_same_size_lists_with_different_elements_are_not_equal()
		{
			var list1 = new List<string> { "one", "four"};
			var list2 = new List<string> { "two", "three" };

			Assert.IsFalse(list1.SetEqual(list2));
		}

		[Test]
		public void then_two_lists_with_same_elements_different_order_are_equal()
		{
			var list1 = new List<string> { "one", "two" };
			var list2 = new List<string> { "two", "one" };

			Assert.IsTrue(list1.SetEqual(list2));
		}

		[Test]
		public void then_two_lists_with_same_elements_same_order_are_equal()
		{
			var list1 = new List<string> { "one", "two" };
			var list2 = new List<string> { "one", "two" };

			Assert.IsTrue(list1.SetEqual(list2));
		}

		[Test]
		public void then_two_lists_with_equal_elements_same_order_are_equal_with_equality()
		{
			var list1 = new List<string> { "one", "two" };
			var list2 = new List<string> { "ONE", "TWO" };

			Assert.IsTrue(list1.SetEqual(list2, new DelegateEqualityComparer<string>(s=>s.ToUpperInvariant().GetHashCode(), (x,y)=>x.ToUpperInvariant() == y.ToUpperInvariant())));
		}

		private class DelegateEqualityComparer<T> : IEqualityComparer<T>
		{
			private Func<T, int> getHashCode;
			private Func<T, T, bool> comparer;

			public DelegateEqualityComparer(Func<T, int> getHashCode, Func<T, T, bool> comparer)
			{
				if (getHashCode == null) throw new ArgumentNullException("getHashCode");
				if (comparer == null) throw new ArgumentNullException("comparer");
				this.getHashCode = getHashCode;
				this.comparer = comparer;
			}

			public bool Equals(T x, T y)
			{
				return comparer(x, y);
			}

			public int GetHashCode(T obj)
			{
				return getHashCode(obj);
			}
		}
	}
}