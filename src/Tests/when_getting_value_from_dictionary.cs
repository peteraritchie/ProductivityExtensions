using System.Collections.Generic;
using NUnit.Framework;
using PRI.ProductivityExtensions.IDictionaryExtensions;

namespace Tests
{
	[TestFixture]
	class when_getting_value_from_dictionary
	{
		[Test]
		public void then_get_value_returns_correct_value()
		{
			Dictionary<string, string> stuff = new Dictionary<string, string> { { "ONE", "one" } };
			Assert.AreEqual("one", stuff.GetValue("ONE"));
		}

	}
}