using System.Collections.Generic;
using NUnit.Framework;

namespace Tests
{
	[TestFixture]
	class when_adding_range_to_collection
	{
		[Test]
		public void then_added_elements_to_empty_list_are_added()
		{
			List<string> list = new List<string>();
			list.AddRange(new[]{"one", "two", "three"});

			Assert.AreEqual(3, list.Count);
			Assert.IsTrue(list.Contains("one"));
			Assert.IsTrue(list.Contains("two"));
			Assert.IsTrue(list.Contains("three"));
		}

		[Test]
		public void then_added_elements_to_existing_list_are_added()
		{
			List<string> list = new List<string> {"three"};
			list.AddRange(new[] { "one", "two" });

			Assert.AreEqual(3, list.Count);
			Assert.IsTrue(list.Contains("one"));
			Assert.IsTrue(list.Contains("two"));
			Assert.IsTrue(list.Contains("three"));
		}
	}
}