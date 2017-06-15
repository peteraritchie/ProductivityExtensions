using NUnit.Framework;
using PRI.ProductivityExtensions.StringExtensions;

namespace Tests
{
	[TestFixture]
	public class StringableTests
	{
		[Test]
		public void LeftLessThanLength()
		{
			Assert.AreEqual("1", "12".Left(1));
		}

		[Test]
		public void LeftSameLength()
		{
			Assert.AreEqual("12", "12".Left(2));
		}

		[Test]
		public void LeftMoreThanLength()
		{
			Assert.AreEqual("12", "12".Left(3));
		}

		[Test]
		public void RightLessThanLength()
		{
			Assert.AreEqual("2", "12".Right(1));
		}

		[Test]
		public void RightSameLength()
		{
			Assert.AreEqual("12", "12".Right(2));
		}

		[Test]
		public void RightMoreThanLength()
		{
			Assert.AreEqual("12", "12".Right(3));
		}

		[Test]
		public void ReplaceEachAll()
		{
			var actual = "xyz".ReplaceEach("yzx", 'n');
			Assert.AreEqual("nnn", actual);
		}

		[Test]
		public void ReplaceEachOne()
		{
			var actual = "pxp".ReplaceEach("yzx", 'n');
			Assert.AreEqual("pnp", actual);
		}

		[Test]
		public void ReplaceEachSome()
		{
			var actual = "wxxxw".ReplaceEach("yzx", 'n');
			Assert.AreEqual("wnnnw", actual);
		}

		[Test]
		public void FirstWordWithSpaceSucceeds()
		{
			var actual = "first second".FirstWord();
			Assert.AreEqual("first", actual);
		}

		[Test]
		public void FirstWordWithoutSpaceSucceeds()
		{
			var actual = "first".FirstWord();
			Assert.AreEqual("first", actual);
		}

		[Test]
		public void InitialsWithSpaceSucceeds()
		{
			var actual = "first second".Initials();
			Assert.AreEqual("fs", actual);
		}

		[Test]
		public void InitialsWithoutSpaceSucceeds()
		{
			var actual = "first".Initials();
			Assert.AreEqual("f", actual);
		}

		[Test]
		public void EmptyStringIsEqualToStringEmpty()
		{
			Assert.IsTrue("".IsEmpty());
		}

		[Test]
		public void StringEmptyIsEmpty()
		{
			Assert.IsTrue(string.Empty.IsEmpty());
		}

		[Test]
		public void NonEmptyStringIsNotEmpty()
		{
			Assert.IsFalse("non-empty".IsEmpty());
		}

		[Test]
		public void NullStringIsNotEmpty()
		{
			Assert.IsFalse(((string)null).IsEmpty());
		}
	}
}