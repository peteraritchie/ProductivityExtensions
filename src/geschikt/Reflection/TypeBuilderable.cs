using System;
using System.Reflection;
using System.Reflection.Emit;

namespace PRI.ProductivityExtensions.ReflectionExtensions
{
	public static partial class TypeBuilderable
	{
		/// <summary>
		/// Add public field to <paramref name="typeBuilder"/> of name <paramref name="filedName"/>
		/// </summary>
		/// <typeparam name="T">Type of the field</typeparam>
		/// <param name="typeBuilder"><seealso cref="TypeBuilder"/> that will have the new field</param>
		/// <param name="fieldName">Name of the field</param>
		/// <returns>The new FieldBuilder object that encapsulates the field</returns>
		public static FieldBuilder DefinePublicField<T>(this TypeBuilder typeBuilder, string fieldName)
		{
			return typeBuilder.DefineField(fieldName, typeof (T), FieldAttributes.Public);
		}

		/// <summary>
		/// Add private field to <paramref name="typeBuilder"/> of name <paramref name="filedName"/>
		/// </summary>
		/// <typeparam name="T">Type of the field</typeparam>
		/// <param name="typeBuilder"><seealso cref="TypeBuilder"/> that will have the new field</param>
		/// <param name="fieldName">Name of the field</param>
		/// <returns>The new FieldBuilder object that encapsulates the field</returns>
		public static FieldBuilder DefinePrivateField<T>(this TypeBuilder typeBuilder, string fieldName)
		{
			return typeBuilder.DefineField(fieldName, typeof(T), FieldAttributes.Private);
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
			return typeBuilder.DefineProperty(propertyName, propertyAttributes, typeof (T), null);
		}

		/// <summary>
		/// Adds a property getter method to <paramref name="typeBuilder"/> based on name of <paramref name="propertyInfo"/>
		/// </summary>
		/// <param name="typeBuilder"><seealso cref="TypeBuilder"/> that will have the new property.</param>
		/// <param name="propertyInfo"><seealso cref="PropertyInfo"/> to base name and the method.</param>
		/// <returns>the new <seealso cref="MethodBuilder"/> object that encapsulates the method</returns>
		public static MethodBuilder DefinePropertyGetter(this TypeBuilder typeBuilder, PropertyInfo propertyInfo)
		{
			return typeBuilder.DefineMethod("get_" + propertyInfo.Name,
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
		public static MethodBuilder DefinePropertySetter<T>(this TypeBuilder typeBuilder, PropertyInfo propertyInfo)
		{
			return typeBuilder.DefineMethod("set_" + propertyInfo.Name,
			                                MethodAttributes.Public | MethodAttributes.SpecialName | MethodAttributes.HideBySig,
			                                null,
			                                new[] {typeof (T)});
		}
	}
}