﻿using NUnit.Framework;
using PRI.ProductivityExtensions.StringExtensions;

namespace Tests
{
	[TestFixture]
	public class StringableTests
	{
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
	}
}