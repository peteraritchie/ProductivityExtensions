using System;
using System.Reflection;
using NUnit.Framework;
using PRI.ProductivityExtensions.ReflectionExtensions;

namespace Tests
{
	[TestFixture]
	public class ReflectableTests
	{
		#region stubs
// ReSharper disable UnusedMember.Local
		[Serializable]
		private class AttributedClass
		{
			[Obsolete]
			public void Method()
			{
			}

			[Obsolete]
			public int Field;
			[Obsolete]
			public int Property { get; set; }
		}
		private class UnattributedClass
		{
			public void Method()
			{
				var x = new AttributedClass();
#pragma warning disable 612,618
				x.Method();
#pragma warning restore 612,618
			}

			public int Field;
			public int Property { get; set; }
		}
// ReSharper restore UnusedMember.Local
		#endregion // stubs

		[Test]
		public void AssemblyGetCustomAttributeReturnsNonNullForAssemblyWithAttribute()
		{
			var value = Assembly.GetExecutingAssembly().GetCustomAttribute<AssemblyCopyrightAttribute>();
			Assert.IsNotNull(value);
		}

		[Test]
		public void AssemblyGetCustomAttributeReturnsNullForAssemblyWithoutAttribute()
		{
			var value = Assembly.GetExecutingAssembly().GetCustomAttribute<SerializableAttribute>();
			Assert.IsNull(value);
		}

		[Test]
		public void MemberInfoGetCustomAttributeReturnsNullFoTypeWithoutAttribute()
		{
			var value = typeof(UnattributedClass).GetCustomAttribute<SerializableAttribute>();
			Assert.IsNull(value);
		}

		[Test]
		public void MemberInfoGetCustomAttributeReturnsNotNullForTypeWithAttribute()
		{
			var value = typeof(AttributedClass).GetCustomAttribute<SerializableAttribute>();
			Assert.IsNotNull(value);
		}

		[Test]
		public void MemberInfoGetCustomAttributeReturnsNullForMemberWithoutAttribute()
		{
			var value = typeof(UnattributedClass).GetMethod("Method").GetCustomAttribute<ObsoleteAttribute>();
			Assert.IsNull(value);
		}

		[Test]
		public void MemberInfoGetCustomAttributeReturnsNotNullForMethodWithAttribute()
		{
			var value = typeof(AttributedClass).GetMethod("Method").GetCustomAttribute<ObsoleteAttribute>();
			Assert.IsNotNull(value);
		}

		[Test]
		public void MemberInfoGetCustomAttributeReturnsNullForFieldWithoutAttribute()
		{
			var value = typeof(UnattributedClass).GetField("Field").GetCustomAttribute<ObsoleteAttribute>();
			Assert.IsNull(value);
		}

		[Test]
		public void MemberInfoGetCustomAttributeReturnsNotNullForFieldWithAttribute()
		{
			var value = typeof(AttributedClass).GetField("Field").GetCustomAttribute<ObsoleteAttribute>();
			Assert.IsNotNull(value);
		}

		[Test]
		public void MemberInfoGetCustomAttributeReturnsNullForPropertyWithoutAttribute()
		{
			var value = typeof(UnattributedClass).GetProperty("Property").GetCustomAttribute<ObsoleteAttribute>();
			Assert.IsNull(value);
		}

		[Test]
		public void MemberInfoGetCustomAttributeReturnsNotNullForPropertyWithtAttribute()
		{
			var value = typeof(AttributedClass).GetProperty("Property").GetCustomAttribute<ObsoleteAttribute>();
			Assert.IsNotNull(value);
		}

		[Test]
		public void ReferncesMethodFindsReferencedMethod()
		{
#pragma warning disable 612,618
			var b = typeof (UnattributedClass).ReferencesMethod<AttributedClass>(@class => @class.Method());
#pragma warning restore 612,618
			Assert.IsTrue(b);
		}

		[Test]
		public void ReferencedMethodsDoesNotFindNonReferencedMethod()
		{
// ReSharper disable ReturnValueOfPureMethodIsNotUsed
			var b = typeof(UnattributedClass).ReferencesMethod<String>(@class => @class.Clone());
// ReSharper restore ReturnValueOfPureMethodIsNotUsed
			Assert.IsFalse(b);
		}

		[Test]
		public void TypeReferencesConstructorFindsReferencedConstructor()
		{
			var b = typeof(UnattributedClass).ReferencesConstructor<AttributedClass>();
			Assert.IsTrue(b);
		}

		[Test]
		public void TypeReferencesConstructorDoesNotFindsNonReferencedConstructor()
		{
			var b = typeof(UnattributedClass).ReferencesConstructor<String>();
			Assert.IsFalse(b);
		}

		[Test]
		public void AssemblyReferencesConstructorFindsReferencedConstructor()
		{
			var b = Assembly.GetExecutingAssembly().ReferencesConstructor<AttributedClass>();
			Assert.IsTrue(b);
		}

		[Test]
		public void AssemblyReferencesConstructorDoesNotFindsNonReferencedConstructor()
		{
			var b = typeof(string).Assembly.ReferencesConstructor<AttributedClass>();
			Assert.IsFalse(b);
		}
	}
}