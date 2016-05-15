using System.Collections.Generic;
using NUnit.Framework;
using PRI.ProductivityExtensions.SequenceExtensions;

namespace Tests
{
	[TestFixture]
	public class SequenceableTests
	{
		[Test]
		public void SequenceEqualOfEqualSequencesReturnsTrue()
		{
			var l1 = new List<int> {1, 2, 3};
			var l2 = new List<int> {9, 1, 2, 3};
			Assert.IsTrue(l1.SequenceEqual(l2, 1));
		}
		[Test]
		public void SequenceEqualOfDifferenSequencesReturnsFalse()
		{
			var l1 = new List<int> { 1, 2, 3 };
			var l2 = new List<int> { 9, 3,2,1 };
			Assert.IsFalse(l1.SequenceEqual(l2, 1));
		}
		[Test]
		public void SequenceEqualOfDifferenSizeSequencesReturnsFalse()
		{
			var l1 = new List<int> { 1, 2, 3 };
			var l2 = new List<int> { 9 };
			Assert.IsFalse(l1.SequenceEqual(l2, 1));
		}

		[Test]
		public void SequenceEquality50Percent()
		{
			var l1 = new List<int> { 1, 2 };
			var l2 = new List<int> { 1 };
			Assert.AreEqual(50, l1.SequenceEquality(l2, EqualityComparer<int>.Default));
		}

		[Test]
		public void SequenceEqualityMinus50Percent()
		{
			var l1 = new List<int> { 1, 2 };
			var l2 = new List<int> { 1 };
			Assert.AreEqual(-50, l2.SequenceEquality(l1, EqualityComparer<int>.Default));
		}

		[Test]
		public void SequenceEquality33Percent()
		{
			var l1 = new List<int> { 1, 2, 3 };
			var l2 = new List<int> { 1 };
			Assert.AreEqual(33, l1.SequenceEquality(l2, EqualityComparer<int>.Default));
		}

		[Test]
		public void SequenceEqualityMinus33Percent()
		{
			var l1 = new List<int> { 1, 2, 3 };
			var l2 = new List<int> { 1 };
			Assert.AreEqual(-33, l2.SequenceEquality(l1, EqualityComparer<int>.Default));
		}

		[Test]
		public void SequenceEquality66Percent()
		{
			var l1 = new List<int> { 1, 2, 3 };
			var l2 = new List<int> { 1, 2 };
			Assert.AreEqual(66, l1.SequenceEquality(l2, EqualityComparer<int>.Default));
		}

		[Test]
		public void SequenceEqualityMinus66Percent()
		{
			var l1 = new List<int> { 1, 2, 3 };
			var l2 = new List<int> { 1, 2 };
			Assert.AreEqual(-66, l2.SequenceEquality(l1, EqualityComparer<int>.Default));
		}

		[Test]
		public void SequenceEquality25Percent()
		{
			var l1 = new List<int> { 1, 2, 3,4  };
			var l2 = new List<int> { 1 };
			Assert.AreEqual(25, l1.SequenceEquality(l2, EqualityComparer<int>.Default));
		}

		[Test]
		public void SequenceEqualityMinus25Percent()
		{
			var l1 = new List<int> { 1, 2, 3, 4 };
			var l2 = new List<int> { 1 };
			Assert.AreEqual(-25, l2.SequenceEquality(l1, EqualityComparer<int>.Default));
		}


		[Test]
		public void SequenceEquality75Percent()
		{
			var l1 = new List<int> { 1, 2, 3,4  };
			var l2 = new List<int> { 1, 2, 3 };
			Assert.AreEqual(75, l1.SequenceEquality(l2, EqualityComparer<int>.Default));
		}

		[Test]
		public void SequenceEqualityMinus75Percent()
		{
			var l1 = new List<int> { 1, 2, 3, 4 };
			var l2 = new List<int> { 1, 2, 3 };
			Assert.AreEqual(-75, l2.SequenceEquality(l1, EqualityComparer<int>.Default));
		}
		[Test]
		public void SequenceEqualityEqual()
		{
			var l1 = new List<int> { 1, 2 };
			var l2 = new List<int> { 1, 2 };
			Assert.AreEqual(0, l2.SequenceEquality(l1, EqualityComparer<int>.Default));
		}
	}
}