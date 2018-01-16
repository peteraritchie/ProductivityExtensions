using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading;
using PRI.ProductivityExtensions.ReflectionExtensions;
using Xunit;

namespace Tests.Core
{
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

		[Fact]
		public void OpenGenericTypeIsOpenGenericType()
		{
			Assert.True(typeof(IList<>).IsOpenGenericType());
		}

		[Fact]
		public void ClosedGenericTypeIsNotOpenGenericType()
		{
			Assert.False(typeof(IList<int>).IsOpenGenericType());
		}

		[Fact]
		public void OpenGenericTypesHaveNoGenericTypeArguments()
		{
			var type = typeof(IList<>);
			Assert.Equal(0, type.GetGenericTypeArguments().Length);
		}

		[Fact]
		public void ClosedGenericTypesHaveCorrectGenericTypeArgumentCount()
		{
			var type = typeof(IList<int>);
			Assert.Equal(1, type.GetGenericTypeArguments().Length);
		}

		[Fact]
		public void IsStaticOnNonStaticTypeReturnsFalse()
		{
			object o = GetValue();
			TypeableTests t = (TypeableTests)o;
			var actual = typeof(InstanceClass).IsStatic();
			Assert.False(actual);
		}

		private object GetValue()
		{
			return null;
		}

		[Fact]
		public void IsStaticOnAbstractTypeReturnsFalse()
		{
			var actual = typeof(AbstractClass).IsStatic();
			Assert.False(actual);
		}

		[Fact]
		public void IsStaticOnStaticTypeReturnsTrue()
		{
			var actual = typeof(StaticClass).IsStatic();
			Assert.True(actual);
		}

		[Fact]
		public void CanFindTypesImplementingInterfaceInDirectory()
		{
			var location = System.IO.Path.GetDirectoryName(this.GetType().GetTypeInfo().Assembly.Location);
			var types = typeof(IAsyncResult).ByImplementedInterfaceInDirectory(location, "*.dll");
			Assert.True(types.Any());
		}

		[Fact]
		public void CanFindTypesImplementingInterfaceInNamespaceInDirectory()
		{
			var location = System.IO.Path.GetDirectoryName(this.GetType().GetTypeInfo().Assembly.Location);
			var types =
				typeof(IAsyncResult).ByImplementedInterfaceInDirectory(location, "*.dll", GetType().Namespace);
			Assert.True(types.Any());
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
}