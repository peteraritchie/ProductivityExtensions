using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using NUnit.Framework;
using PRI.ProductivityExtensions;
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
			Assert.IsTrue(typeof (IList<>).IsOpenGenericType());
		}

		[Test]
		public void ClosedGenericTypeIsNotOpenGenericType()
		{
			Assert.IsFalse(typeof (IList<int>).IsOpenGenericType());
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
			var type = typeof (IList<>);
			Assert.AreEqual(0, type.GetGenericTypeArguments().Length);
		}

		[Test]
		public void ClosedGenericTypesHaveCorrectGenericTypeArgumentCount()
		{
			var type = typeof (IList<int>);
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
			var actual = typeof (AbstractClass).IsStatic();
			Assert.IsFalse(actual);
		}

		[Test]
		public void IsStaticOnStaticTypeReturnsTrue()
		{
			var actual = typeof (StaticClass).IsStatic();
			Assert.IsTrue(actual);
		}

		[Test]
		public void CanFindTypesImplementingInterface()
		{
			var types = typeof(IAsyncResult).ByImplementedInterface();
			Assert.IsTrue(types.Any());
		}

		[Test]
		public void CanFindTypesImplementingInterfaceInNamespace()
		{
			var types =
				typeof(IAsyncResult).ByImplementedInterface(typeof(System.Threading.Tasks.Task).Namespace);
			Assert.IsTrue(types.Any());
		}

		[Test]
		public void CanFindTypesImplementingInterfaceInDirectory()
		{
			var location = System.IO.Path.GetDirectoryName(this.GetType().Assembly.Location);
			var types = typeof(IAsyncResult).ByImplementedInterfaceInDirectory(location, "*.dll");
			Assert.IsTrue(types.Any());
		}

		[Test]
		public void CanFindTypesImplementingInterfaceInNamespaceInDirectory()
		{
			var location = System.IO.Path.GetDirectoryName(this.GetType().Assembly.Location);
			var types =
				typeof(IAsyncResult).ByImplementedInterfaceInDirectory(location, "*.dll", GetType().Namespace);
			Assert.IsTrue(types.Any());
		}
	}

	// ReSharper disable once UnusedMember.Global
	// ReSharper disable once IdentifierTypo
	// ReSharper disable UnusedAutoPropertyAccessor.Local
	public class ImplementsIntewrface : IAsyncResult
	{
		public bool IsCompleted { get; private set; }
		public WaitHandle AsyncWaitHandle { get; private set; }
		public object AsyncState { get; private set; }
		public bool CompletedSynchronously { get; private set; }
	}
	// ReSharper restore UnusedAutoPropertyAccessor.Local
}