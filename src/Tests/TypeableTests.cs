using NUnit.Framework;
using PRI.ProductivityExtensions.ReflectionExtensions;

namespace Tests
{
	[TestFixture]
	public class TypeableTests
	{
		#region stubs
		private sealed class InstanceClass
		{
		}

		private abstract class AbstractClass
		{
		}

		private class ConcreteClass : AbstractClass
		{
		}

		private static class StaticClass
		{
		}
		#endregion // stubs

		[Test]
		public void IsStaticOnNonStaticTypeReturnsFalse()
		{
			var actual = typeof (InstanceClass).IsStatic();
			Assert.IsFalse(actual);
		}

		[Test]
		public void IsStaticOnAbstractTypeReturnsFalse()
		{
			var actual = typeof(AbstractClass).IsStatic();
			Assert.IsFalse(actual);
		}

		[Test]
		public void IsStaticOnStaticTypeReturnsTrue()
		{
			var actual = typeof(StaticClass).IsStatic();
			Assert.IsTrue(actual);
		}
	}
}