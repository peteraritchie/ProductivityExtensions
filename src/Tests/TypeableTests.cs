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

		private int n = 0;
		[Test]
		public void IsStaticOnNonStaticTypeReturnsFalse()
		{
			object o = GetValue();
			TypeableTests t = (TypeableTests) o;
			var actual = typeof (InstanceClass).IsStatic();
			Assert.IsFalse(actual);
		}

		private object GetValue()
		{
			return null;
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