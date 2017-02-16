using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using NUnit.Framework;
using PRI.ProductivityExtensions.IEnumerableExtensions;
using PRI.ProductivityExtensions.Reflection;
using PRI.ProductivityExtensions.ReflectionExtensions;
using FileAssert=NUnit.Framework.FileAssert;

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
		private static void GenerateAssembly(string sourceCode, string assemblyName)
		{

			var parameters = new CompilerParameters
			{
				GenerateExecutable = false,
				OutputAssembly = assemblyName,
			};

			using (var provider = CodeDomProvider.CreateProvider("CSharp"))
			{
				var results = provider.CompileAssemblyFromSource(parameters, sourceCode);
				if (results.Errors.HasErrors)
				{
					foreach (var error in results.Errors)
					{
						Trace.WriteLine(error);
					}
				}
			}
		}

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

		private class HasPrivateField
		{
			private int field;

			public HasPrivateField(int field)
			{
				this.field = field;
			}
		}

		private class InheritsHasPrivateField : HasPrivateField
		{
			public InheritsHasPrivateField(int field) : base(field)
			{
			}
		}

		[Test]
		public void GetPrivateFieldWorks()
		{
			var obj = new HasPrivateField(42);

			Assert.AreEqual(42, obj.GetPrivateFieldValue<int>("field"));
		}

		[Test]
		public void GetPrivateFieldWorksWithInheritedField()
		{
			var obj = new InheritsHasPrivateField(42);

			Assert.AreEqual(42, obj.GetPrivateFieldValue<int>("field"));
		}

		[Test]
		public void SetPrivateFieldWorks()
		{
			var obj = new HasPrivateField(42);

			obj.SetPrivateFieldValue("field", 73);
			Assert.AreEqual(73, obj.GetPrivateFieldValue<int>("field"));
		}

		[Test]
		public void SetPrivateFieldWorksWithInheritedField()
		{
			var obj = new InheritsHasPrivateField(42);

			obj.SetPrivateFieldValue("field", 73);

			Assert.AreEqual(73, obj.GetPrivateFieldValue<int>("field"));
		}

		private class HasPrivateProperty
		{
			private int Property { get; set; }

			public HasPrivateProperty(int property)
			{
				Property = property;
			}
		}

		private class InheritsHasPrivateProperty : HasPrivateProperty
		{
			public InheritsHasPrivateProperty(int property)
				: base(property)
			{
			}
		}

		[Test]
		public void GetPrivatePropertyWorks()
		{
			var obj = new HasPrivateProperty(42);

			Assert.AreEqual(42, obj.GetPrivatePropertyValue<int>("Property"));
		}

		[Test]
		public void GetPrivatePropertyWorksWithInheritedProperty()
		{
			var obj = new InheritsHasPrivateProperty(42);

			Assert.AreEqual(42, obj.GetPrivatePropertyValue<int>("Property"));
		}

		[Test]
		public void SetPrivatePropertyWorks()
		{
			var obj = new HasPrivateProperty(42);

			obj.SetPrivatePropertyValue("Property", 73);
			Assert.AreEqual(73, obj.GetPrivatePropertyValue<int>("Property"));
		}

		[Test]
		public void SetPrivatePropertyWorksWithInheritedProperty()
		{
			var obj = new InheritsHasPrivateProperty(42);


			obj.SetPrivatePropertyValue("Property", 73);

			Assert.AreEqual(73, obj.GetPrivatePropertyValue<int>("Property"));
		}

		[Test]
		public void FindTypesByAttributeInstance()
		{
			var assemblyName = "test1.dll";
			GenerateAssembly(@"namespace ClassLibrary
{
	[System.Obsolete]
	public class ClassWithAttribute
	{
		public int GetNumber()
		{
			return 42;
		}
	}
}", assemblyName);
			Assert.IsTrue(File.Exists(assemblyName));
			var types = new ObsoleteAttribute().FindAttributedTypes(".", assemblyName);
			Assert.AreEqual(1, types.Count());
		}

		[Test]
		public void FindTypesByAttributeType()
		{
			var assemblyName = "test2.dll";
			GenerateAssembly(@"namespace ClassLibrary
{
	[System.Obsolete]
	public class ClassWithAttribute
	{
		public int GetNumber()
		{
			return 42;
		}
	}
}", assemblyName);
			Assert.IsTrue(File.Exists(assemblyName));
			var types = typeof(ObsoleteAttribute).FindAttributedTypes(".", assemblyName);
			Assert.AreEqual(1, types.Count());
		}

		[Test]
		public void FindTypesByAttributeTypeInAppDomain()
		{

			var types = typeof (ObsoleteAttribute).FindAttributedTypes();
			Assert.IsTrue(types.Any());
		}

		[Test]
		public void FindTypesByAttributeInAppDomain()
		{

			var types = new ObsoleteAttribute().FindAttributedTypes();
			Assert.IsTrue(types.Any());
		}

		[Test]
		public void FindTypesByAttributeInAssemblies()
		{
			var assemblies = AppDomain.CurrentDomain.GetAssemblies();
			var types = new ObsoleteAttribute().FindAttributedTypes(assemblies);
			Assert.IsTrue(types.Any());
		}

		[Test]
		public void FindTypesByAttributeTypeInAssemblies()
		{
			var assemblies = AppDomain.CurrentDomain.GetAssemblies();
			var types = typeof(ObsoleteAttribute).FindAttributedTypes(assemblies);
			Assert.IsTrue(types.Any());
		}

		[Test]
		public void ToAssembliesDoesNotLeakLoadExceptions()
		{
			var x = new DirectoryInfo(".").GetFiles().Where(e=>e.Extension != ".msi").Select(f => f.FullName).ToAssemblies();
			var c = x.Count();
		}

		private static class ToPropertyInfoWrapper<T>
		{
			public static PropertyInfo GetPropertyInfo<TProperty>(Expression<Func<T, TProperty>> e)
			{
				return e.ToPropertyInfo();
			}
			public static PropertyDescriptor GetPropertyDescriptor<TProperty>(Expression<Func<T, TProperty>> e)
			{
				return e.ToPropertyDescriptor();
			}
	}

		[Test]
		public void ToPropertyInfoSucceeds()
		{
			var p = ToPropertyInfoWrapper<string>.GetPropertyInfo(e => e.Length);
			Assert.AreEqual("Length", p.Name);
			Assert.AreEqual(typeof(int), p.PropertyType);
			Assert.AreEqual(true, p.CanRead);
			Assert.AreEqual(false, p.CanWrite);
			Assert.AreEqual(typeof(string).GetProperties().Single(e => e.Name == "Length"), p);
		}

		[Test]
		public void ToPropertDescriptorSucceeds()
		{
			var p = ToPropertyInfoWrapper<string>.GetPropertyDescriptor(e => e.Length);
			Assert.AreEqual("Length", p.Name);
			Assert.AreEqual(typeof(int), p.PropertyType);
			Assert.AreEqual(true, p.IsReadOnly);
			Assert.AreEqual(TypeDescriptor.GetProperties(typeof(string))["Length"], p);
		}
	}
}