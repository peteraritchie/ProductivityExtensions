using System.Collections.Generic;
using NUnit.Framework;
using PRI.ProductivityExtensions.IListExtensions;

namespace Tests
{
	[TestFixture]
	class when_swapping_list_values
	{
		[Test]
		public void then_different_values_are_swapped()
		{
			var list = new List<int> {1, 3, 2};
			list.SwapValues(1, 2);
			Assert.AreEqual(3, list.Count);

			Assert.AreEqual(2, list[1]);
			Assert.AreEqual(3, list[2]);
		}

		[Test]
		public void then_list_size_does_not_change()
		{
			var list = new List<int> { 1, 3, 2 };
			list.SwapValues(1, 2);
			Assert.AreEqual(3, list.Count);
		}

		[Test]
		public void then_non_swaped_values_are_unchanged()
		{
			var list = new List<int> { 1, 3, 2 };
			list.SwapValues(1, 2);

			Assert.AreEqual(1, list[0]);
		}
	}
}