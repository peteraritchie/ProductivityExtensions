#if (NET4O || NET45 || NET451 || NET452 || NET46 || NET461 || NET462)
using System;
using System.Reflection;
using System.Reflection.Emit;

namespace PRI.ProductivityExtensions.ReflectionExtensions
{
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'TypeBuilderable'
	public static partial class TypeBuilderable
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'TypeBuilderable'
	{
		/// <summary>
		/// Add public field to <paramref name="typeBuilder"/> of name <paramref name="fieldName"/>
		/// </summary>
		/// <typeparam name="T">Type of the field</typeparam>
		/// <param name="typeBuilder"><seealso cref="TypeBuilder"/> that will have the new field</param>
		/// <param name="fieldName">Name of the field</param>
		/// <returns>The new FieldBuilder object that encapsulates the field</returns>
		public static FieldBuilder DefinePublicField<T>(this TypeBuilder typeBuilder, string fieldName)
		{
			return DefinePublicField(typeBuilder, fieldName, typeof(T));
		}

		/// <summary>
		/// Add public field to <paramref name="typeBuilder"/> of name <paramref name="fieldName"/>
		/// </summary>
		/// <param name="typeBuilder"><seealso cref="TypeBuilder"/> that will have the new field</param>
		/// <param name="fieldName">Name of the field</param>
		/// <param name="type">Type of the field</param>
		/// <returns>The new FieldBuilder object that encapsulates the field</returns>
		public static FieldBuilder DefinePublicField(this TypeBuilder typeBuilder, string fieldName, Type type)
		{
			return typeBuilder.DefineField(fieldName, type, FieldAttributes.Public);
		}

		/// <summary>
		/// Add private field to <paramref name="typeBuilder"/> of name <paramref name="fieldName"/>
		/// </summary>
		/// <typeparam name="T">Type of the field</typeparam>
		/// <param name="typeBuilder"><seealso cref="TypeBuilder"/> that will have the new field</param>
		/// <param name="fieldName">Name of the field</param>
		/// <returns>The new FieldBuilder object that encapsulates the field</returns>
		public static FieldBuilder DefinePrivateField<T>(this TypeBuilder typeBuilder, string fieldName)
		{
			return DefinePrivateField(typeBuilder, fieldName, typeof(T));
		}

		/// <summary>
		/// Add private field to <paramref name="typeBuilder"/> of name <paramref name="fieldName"/>
		/// </summary>
		/// <param name="typeBuilder"><seealso cref="TypeBuilder"/> that will have the new field</param>
		/// <param name="fieldName">Name of the field</param>
		/// <param name="type">Type of the field</param>
		/// <returns>The new FieldBuilder object that encapsulates the field</returns>
		public static FieldBuilder DefinePrivateField(this TypeBuilder typeBuilder, string fieldName, Type type)
		{
			return typeBuilder.DefineField(fieldName, type, FieldAttributes.Private);
		}

		/// <summary>
		/// Adds a public property to <paramref name="typeBuilder"/> of name <paramref name="propertyName"/>
		/// </summary>
		/// <typeparam name="T">Type of the property</typeparam>
		/// <param name="typeBuilder"><seealso cref="TypeBuilder"/> that will have the new property</param>
		/// <param name="propertyName">Name of the property</param>
		/// <param name="propertyAttributes"><seealso cref="PropertyAttributes"/></param>
		/// <returns>The new PropertyBuilder object that encapsulates the property</returns>
		public static PropertyBuilder DefineProperty<T>(this TypeBuilder typeBuilder, string propertyName, PropertyAttributes propertyAttributes)
		{
			return DefineProperty(typeBuilder, propertyName, typeof(T), propertyAttributes);
		}

		/// <summary>
		/// Adds a public property to <paramref name="typeBuilder"/> of name <paramref name="propertyName"/>
		/// </summary>
		/// <param name="typeBuilder"><seealso cref="TypeBuilder"/> that will have the new property</param>
		/// <param name="propertyName">Name of the property</param>
		/// <param name="type">Type of the property</param>
		/// <param name="propertyAttributes"><seealso cref="PropertyAttributes"/></param>
		/// <returns>The new PropertyBuilder object that encapsulates the property</returns>
		public static PropertyBuilder DefineProperty(this TypeBuilder typeBuilder, string propertyName, Type type, PropertyAttributes propertyAttributes)
		{
			return typeBuilder.DefineProperty(propertyName, propertyAttributes, type, null);
		}

		/// <summary>
		/// Adds a property getter method to <paramref name="typeBuilder"/> based on name of <paramref name="propertyInfo"/>
		/// </summary>
		/// <param name="typeBuilder"><seealso cref="TypeBuilder"/> that will have the new property.</param>
		/// <param name="propertyInfo"><seealso cref="PropertyInfo"/> to base name and the method.</param>
		/// <returns>the new <seealso cref="MethodBuilder"/> object that encapsulates the method</returns>
		public static MethodBuilder DefinePropertyGetter(this TypeBuilder typeBuilder, PropertyInfo propertyInfo)
		{
			return typeBuilder.DefineMethod(
				"get_" + propertyInfo.Name,
			                                MethodAttributes.Public | MethodAttributes.SpecialName | MethodAttributes.HideBySig,
			                                propertyInfo.PropertyType,
			                                Type.EmptyTypes);
		}

		/// <summary>
		/// Adds a property setter method to <paramref name="typeBuilder"/> based on name of <paramref name="propertyInfo"/>
		/// </summary>
		/// <param name="typeBuilder"><seealso cref="TypeBuilder"/> that will have the new property.</param>
		/// <param name="propertyInfo"><seealso cref="PropertyInfo"/> to base name and the method.</param>
		/// <returns>the new <seealso cref="MethodBuilder"/> object that encapsulates the method</returns>
		public static MethodBuilder DefinePropertySetter(this TypeBuilder typeBuilder, PropertyInfo propertyInfo)
		{
			return typeBuilder.DefineMethod(
				"set_" + propertyInfo.Name,
			                                MethodAttributes.Public | MethodAttributes.SpecialName | MethodAttributes.HideBySig,
			                                null,
			                                new[] { propertyInfo.PropertyType });
		}

		/// <summary>
		/// Adds a private property getter method to <paramref name="typeBuilder"/> based on name of <paramref name="propertyInfo"/>
		/// </summary>
		/// <param name="typeBuilder"><seealso cref="TypeBuilder"/> that will have the new property.</param>
		/// <param name="propertyInfo"><seealso cref="PropertyInfo"/> to base name and the method.</param>
		/// <returns>the new <seealso cref="MethodBuilder"/> object that encapsulates the method</returns>
		public static MethodBuilder DefinePrivatePropertyGetter(this TypeBuilder typeBuilder, PropertyInfo propertyInfo)
		{
			return typeBuilder.DefineMethod(
				"get_" + propertyInfo.Name,
											MethodAttributes.Private | MethodAttributes.SpecialName | MethodAttributes.HideBySig,
											propertyInfo.PropertyType,
											Type.EmptyTypes);
		}

		/// <summary>
		/// Adds a private property setter method to <paramref name="typeBuilder"/> based on name of <paramref name="propertyInfo"/>
		/// </summary>
		/// <param name="typeBuilder"><seealso cref="TypeBuilder"/> that will have the new property.</param>
		/// <param name="propertyInfo"><seealso cref="PropertyInfo"/> to base name and the method.</param>
		/// <returns>the new <seealso cref="MethodBuilder"/> object that encapsulates the method</returns>
		public static MethodBuilder DefinePrivatePropertySetter(this TypeBuilder typeBuilder, PropertyInfo propertyInfo)
		{
			return typeBuilder.DefineMethod(
				"set_" + propertyInfo.Name,
											MethodAttributes.Private | MethodAttributes.SpecialName | MethodAttributes.HideBySig,
											null,
											new[] { propertyInfo.PropertyType });
		}

		private static readonly CustomAttributeBuilder CompilerGeneratedAttributeBuilder =
			new CustomAttributeBuilder(
				typeof(System.Runtime.CompilerServices.CompilerGeneratedAttribute).GetConstructor(),
									   new object[0]);

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'TypeBuilderable.CreatePublicAutoProperty<T>(TypeBuilder, string)'
		public static PropertyBuilder CreatePublicAutoProperty<T>(this TypeBuilder typeBuilder, string propertName)
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'TypeBuilderable.CreatePublicAutoProperty<T>(TypeBuilder, string)'
		{
			return CreatePublicAutoProperty(typeBuilder, propertName, typeof(T));
		}

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'TypeBuilderable.CreatePublicAutoProperty(TypeBuilder, string, Type)'
		public static PropertyBuilder CreatePublicAutoProperty(this TypeBuilder typeBuilder, string propertyName, Type propertyType)
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'TypeBuilderable.CreatePublicAutoProperty(TypeBuilder, string, Type)'
		{
			var field = typeBuilder.
				DefinePrivateField(
					string.Format("<{0}>k__BackingField", propertyName),
								   propertyType);

			field.SetCustomAttribute(CompilerGeneratedAttributeBuilder);

			var property = typeBuilder.DefineProperty(propertyName, propertyType, PropertyAttributes.HasDefault);

			var propertyGetter = typeBuilder.DefinePropertyGetter(property);

			propertyGetter.SetCustomAttribute(CompilerGeneratedAttributeBuilder);

			propertyGetter.GetILGenerator().EmitBackingFieldGetter(field);

			var propertySetter = typeBuilder.DefinePropertySetter(property);

			propertySetter.SetCustomAttribute(CompilerGeneratedAttributeBuilder);

			propertySetter.GetILGenerator().EmitBackingFieldSetter(field);

			property.SetGetMethod(propertyGetter);
			property.SetSetMethod(propertySetter);

			return property;
		}

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'TypeBuilderable.CreatePrivateAutoProperty<T>(TypeBuilder, string)'
		public static PropertyBuilder CreatePrivateAutoProperty<T>(this TypeBuilder typeBuilder, string propertName)
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'TypeBuilderable.CreatePrivateAutoProperty<T>(TypeBuilder, string)'
		{
			return CreatePrivateAutoProperty(typeBuilder, propertName, typeof(T));
		}

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'TypeBuilderable.CreatePrivateAutoProperty(TypeBuilder, string, Type)'
		public static PropertyBuilder CreatePrivateAutoProperty(this TypeBuilder typeBuilder, string propertyName, Type propertyType)
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'TypeBuilderable.CreatePrivateAutoProperty(TypeBuilder, string, Type)'
		{
			var field = typeBuilder.
				DefinePrivateField(
					string.Format("<{0}>k__BackingField", propertyName),
								   propertyType);

			field.SetCustomAttribute(CompilerGeneratedAttributeBuilder);

			var property = typeBuilder.DefineProperty(propertyName, propertyType, PropertyAttributes.HasDefault);

			var propertyGetter = typeBuilder.DefinePrivatePropertyGetter(property);

			propertyGetter.SetCustomAttribute(CompilerGeneratedAttributeBuilder);

			propertyGetter.GetILGenerator().EmitBackingFieldGetter(field);

			var propertySetter = typeBuilder.DefinePrivatePropertySetter(property);

			propertySetter.SetCustomAttribute(CompilerGeneratedAttributeBuilder);

			propertySetter.GetILGenerator().EmitBackingFieldSetter(field);

			property.SetGetMethod(propertyGetter);
			property.SetSetMethod(propertySetter);

			return property;
		}

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'TypeBuilderable.CreateReadonlyAutoProperty<T>(TypeBuilder, string)'
		public static PropertyBuilder CreateReadonlyAutoProperty<T>(this TypeBuilder typeBuilder, string propertName)
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'TypeBuilderable.CreateReadonlyAutoProperty<T>(TypeBuilder, string)'
		{
			return CreateReadonlyAutoProperty(typeBuilder, propertName, typeof(T));
		}

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'TypeBuilderable.CreateReadonlyAutoProperty(TypeBuilder, string, Type)'
		public static PropertyBuilder CreateReadonlyAutoProperty(this TypeBuilder typeBuilder, string propertyName, Type propertyType)
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'TypeBuilderable.CreateReadonlyAutoProperty(TypeBuilder, string, Type)'
		{
			var field = typeBuilder.
				DefinePrivateField(
					string.Format("<{0}>k__BackingField", propertyName),
								   propertyType);

			field.SetCustomAttribute(CompilerGeneratedAttributeBuilder);

			var property = typeBuilder.DefineProperty(propertyName, propertyType, PropertyAttributes.HasDefault);

			var propertyGetter = typeBuilder.DefinePropertyGetter(property);

			propertyGetter.SetCustomAttribute(CompilerGeneratedAttributeBuilder);

			propertyGetter.GetILGenerator().EmitBackingFieldGetter(field);

			var propertySetter = typeBuilder.DefinePrivatePropertySetter(property);

			propertySetter.SetCustomAttribute(CompilerGeneratedAttributeBuilder);

			propertySetter.GetILGenerator().EmitBackingFieldSetter(field);

			property.SetGetMethod(propertyGetter);
			property.SetSetMethod(propertySetter);

			return property;
		}
	}
}
#endif