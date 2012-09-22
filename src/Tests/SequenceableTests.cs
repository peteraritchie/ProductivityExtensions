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
	}
}