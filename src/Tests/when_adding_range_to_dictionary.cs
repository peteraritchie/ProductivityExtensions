using System.Collections.Generic;
using NUnit.Framework;
using PRI.ProductivityExtensions.IDictionaryExtensions;

namespace Tests
{
	[TestFixture]
	public class when_adding_range_to_dictionary
	{
		[Test]
		public void then_range_added_to_empty_dictionary_adds_correctly()
		{
			Dictionary<string, string> stuff = new Dictionary<string, string>();

			stuff.AddRange(s => s.ToUpperInvariant().Remove(2), new[]{"one", "two", "three"});

			Assert.AreEqual(3, stuff.Count);
			Assert.IsTrue(stuff.ContainsKey("ON"));
			Assert.AreEqual("one", stuff["ON"]);
			Assert.IsTrue(stuff.ContainsKey("TW"));
			Assert.AreEqual("two", stuff["TW"]);
			Assert.IsTrue(stuff.ContainsKey("TH"));
			Assert.AreEqual("three", stuff["TH"]);
		}

		[Test]
		public void then_range_added_to_existing_dictionary_adds_correctly()
		{
			Dictionary<string, string> stuff = new Dictionary<string, string> {{"ONE", "one"}};

			stuff.AddRange(s => s.ToUpperInvariant(), new[] { "two", "three" });

			Assert.AreEqual(3, stuff.Count);
			Assert.IsTrue(stuff.ContainsKey("TWO"));
			Assert.AreEqual("two", stuff["TWO"]);
			Assert.IsTrue(stuff.ContainsKey("THREE"));
			Assert.AreEqual("three", stuff["THREE"]);
		}
	}
}