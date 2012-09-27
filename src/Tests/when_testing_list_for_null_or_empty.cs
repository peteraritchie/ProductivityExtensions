using System.Collections.Generic;
using NUnit.Framework;
using PRI.ProductivityExtensions.ICollectionableExtensions;

namespace Tests
{
	[TestFixture]
	class when_testing_list_for_null_or_empty
	{
		[Test]
		public void then_empty_list_is_null_or_empty()
		{
			var list = new List<int>();
			Assert.IsTrue(list.IsNullOrEmpty());
		}

		[Test]
		public void then_populated_list_is_null_or_empty()
		{
			var list = new List<int>{1};
			Assert.IsFalse(list.IsNullOrEmpty());
		}

		[Test]
		public void then_null_list_is_null_or_empty()
		{
			List<int> list = null;
			Assert.IsTrue(list.IsNullOrEmpty());
		}
	}
}