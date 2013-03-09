using System.Collections.Generic;
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
		public void OpenGenericTypeIsOpenGenericType()
		{
			Assert.IsTrue(typeof(IList<>).IsOpenGenericType());
		}

		[Test]
		public void ClosedGenericTypeIsNotOpenGenericType()
		{
			Assert.IsFalse(typeof(IList<int>).IsOpenGenericType());
		}

#if NET_4_5
		[Test]
		public void OpenGenericTypesHaveNoGenericTypeArguments()
		{
			var type = typeof (IList<>);
			Assert.IsTrue(type.GetGenericTypeArguments() == type.GenericTypeArguments);
		}
		[Test]
		public void ClosedGenericTypesHaveCorrectGenericTypeArgumentCount()
		{
			var type = typeof (IList<int>);
			Assert.IsTrue(type.GetGenericTypeArguments() == type.GenericTypeArguments);
		}
#else
		[Test]
		public void OpenGenericTypesHaveNoGenericTypeArguments()
		{
			var type = typeof(IList<>);
			Assert.AreEqual(0, type.GetGenericTypeArguments().Length);
		}
		[Test]
		public void ClosedGenericTypesHaveCorrectGenericTypeArgumentCount()
		{
			var type = typeof(IList<int>);
			Assert.AreEqual(1, type.GetGenericTypeArguments().Length);
		}
#endif

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