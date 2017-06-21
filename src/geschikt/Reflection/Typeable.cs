#if (NETSTANDARD2_0 || NETSTANDARD1_6 || NETSTANDARD1_5 || NETSTANDARD1_4 || NETSTANDARD1_3 || NETSTANDARD1_2 || NETSTANDARD1_1 || NETSTANDARD1_0 || NET45 || NET40 || NET451 || NET452 || NET46 || NET461 || NET462)
using System;
#if (NET45 || NET40 || NET451 || NET452 || NET46 || NET461 || NET462)
using System.Collections.Generic;
#endif
using System.Linq;
using System.Reflection;
#if (NET45 || NET40 || NET451 || NET452 || NET46 || NET461 || NET462)
using PRI.ProductivityExtensions.IEnumerableExtensions;
#endif

namespace PRI.ProductivityExtensions.ReflectionExtensions
{
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'Typeable'
	public static partial class Typeable
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'Typeable'
	{
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'Typeable.IsStatic(Type)'
		public static bool IsStatic(this Type type)
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'Typeable.IsStatic(Type)'
		{
			if (type == null) throw new ArgumentNullException(nameof(type));
#if (NET40 || NET45)
			return type.IsAbstract && type.IsSealed;
#else
			return type.GetTypeInfo().IsAbstract && type.GetTypeInfo().IsSealed;
#endif
		}

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'Typeable.IsOpenGenericType(Type)'
		public static bool IsOpenGenericType(this Type type)
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'Typeable.IsOpenGenericType(Type)'
		{
#if (NET40 || NET45)
			return type.GetGenericTypeArguments().Length == 0 && type.IsGenericType;
#else
			return type.GetGenericTypeArguments().Length == 0 && type.GetTypeInfo().IsGenericType;
#endif
		}

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'Typeable.GetGenericTypeArguments(Type)'
		public static Type[] GetGenericTypeArguments(this Type type)
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'Typeable.GetGenericTypeArguments(Type)'
		{
#if (NET45 || NET451 || NET452 || NET46 || NET461 || NET462)
			return type.GenericTypeArguments;
#else
#if NET40
			if (type.IsGenericType && !type.IsGenericTypeDefinition)
				return type.GetGenericArguments();
#else
			var typeInfo = type.GetTypeInfo();
			if (typeInfo.IsGenericType && !typeInfo.IsGenericTypeDefinition)
				return typeInfo.GenericTypeArguments;
#endif
			else
#if (NETSTANDARD2_0 || NETSTANDARD1_6 || NETSTANDARD1_5 || NETSTANDARD1_4 || NETSTANDARD1_3 || NET45 || NET40 || NET451 || NET452 || NET46 || NET461 || NET462)
				return Type.EmptyTypes;
#else
				return new Type[0];
#endif
#endif
		}

#pragma warning disable CS1572 // XML comment has a param tag for 'TAttributes', but there is no parameter by that name
#pragma warning disable CS1571 // XML comment has a duplicate param tag for 'type'
		/// <summary>
		/// Tests if <param name="type"></param> has attribute <param name="TAttributes"></param>
		/// </summary>
		/// <typeparam name="TAttribute"></typeparam>
		/// <param name="type"></param>
		/// <returns></returns>
		public static bool HasAttribute<TAttribute>(this Type type) where TAttribute : Attribute
#pragma warning restore CS1571 // XML comment has a duplicate param tag for 'type'
#pragma warning restore CS1572 // XML comment has a param tag for 'TAttributes', but there is no parameter by that name
		{
			if (type == null) throw new ArgumentNullException(nameof(type));
			return type.HasAttribute(typeof (TAttribute));
		}

#pragma warning disable CS1571 // XML comment has a duplicate param tag for 'type'
		/// <summary>
		/// Tests if <param name="type"></param> has attribute <paramref name="attributeType"/>
		/// </summary>
		/// <param name="type"></param>
		/// <param name="attributeType"></param>
		/// <returns>true if attributed with <paramref name="attributeType"/>, false otherwise.</returns>
		public static bool HasAttribute(this Type type, Type attributeType)
#pragma warning restore CS1571 // XML comment has a duplicate param tag for 'type'
		{
#if (NET40 || NET45)
			return type.GetCustomAttributes(attributeType, false).Length > 0;
#else
			return type.GetTypeInfo().GetCustomAttributes(attributeType, false).Any();
#endif
		}

#pragma warning disable CS1570 // XML comment has badly formed XML -- 'End tag 'summary' does not match the start tag 'param'.'
#pragma warning disable CS1570 // XML comment has badly formed XML -- 'Expected an end tag for element 'summary'.'
		/// <summary>
		/// Test if <param name="type"> implements interface <typeparamref name="TInterface"/>
		/// </summary>
		/// <typeparam name="TInterface"></typeparam>
		/// <param name="type"></param>
		/// <returns></returns>
		public static bool ImplementsInterface<TInterface>(this Type type)
#pragma warning restore CS1570 // XML comment has badly formed XML -- 'Expected an end tag for element 'summary'.'
#pragma warning restore CS1570 // XML comment has badly formed XML -- 'End tag 'summary' does not match the start tag 'param'.'
		{
			if (type == null) throw new ArgumentNullException(nameof(type));
#if (NET40 || NET45)
			return typeof(TInterface).IsAssignableFrom(type);
#else
			return typeof(TInterface).GetTypeInfo().IsAssignableFrom(type.GetTypeInfo());
#endif
		}

#if (NETSTANDARD2_0 || NETSTANDARD1_6 || NETSTANDARD1_5 || NET45 || NET40 || NET451 || NET452 || NET46 || NET461 || NET462)
#pragma warning disable CS1570 // XML comment has badly formed XML -- 'End tag 'summary' does not match the start tag 'param'.'
#pragma warning disable CS1570 // XML comment has badly formed XML -- 'End tag 'typeparam' does not match the start tag 'param'.'
#pragma warning disable CS1570 // XML comment has badly formed XML -- 'Expected an end tag for element 'summary'.'
		/// <summary>
		/// tests if <param name="type"> implements interface <param name="interfaceType"></typeparam>
		/// </summary>
		/// <param name="type"></param>
		/// <param name="interfaceType"></param>
		/// <returns></returns>
		public static bool ImplementsInterface(this Type type, Type interfaceType)
#pragma warning restore CS1570 // XML comment has badly formed XML -- 'Expected an end tag for element 'summary'.'
#pragma warning restore CS1570 // XML comment has badly formed XML -- 'End tag 'typeparam' does not match the start tag 'param'.'
#pragma warning restore CS1570 // XML comment has badly formed XML -- 'End tag 'summary' does not match the start tag 'param'.'
		{
			if (interfaceType == null) throw new ArgumentNullException(nameof(interfaceType));
			if (type == null) throw new ArgumentNullException(nameof(type));
#if (NET40 || NET45)
			if (interfaceType.IsGenericType && interfaceType.ContainsGenericParameters)
			{
				return type.GetInterfaces().Any(t => t.IsGenericType && t.GetGenericTypeDefinition() == interfaceType);
			}
			return interfaceType.IsAssignableFrom(type);
#else
			var typeInfo = interfaceType.GetTypeInfo();
			if (typeInfo.IsGenericType && typeInfo.ContainsGenericParameters)
			{
				return type.GetTypeInfo().GetInterfaces().Any(t => t.GetTypeInfo().IsGenericType && t.GetTypeInfo().GetGenericTypeDefinition() == interfaceType);
			}
			return typeInfo.IsAssignableFrom(type.GetTypeInfo());
#endif
		}

		private static IEnumerable<Type> ByPredicate(IEnumerable<Assembly> assemblies, Predicate<Type> predicate)
		{
			return from assembly in assemblies
				   from type in assembly.GetTypes()
				   where !type.IsAbstract && type.IsClass && predicate(type)
				   select type;
		}
#endif

#if (NETSTANDARD2_0 || NET45 || NET40 || NET451 || NET452 || NET46 || NET461 || NET462)
#pragma warning disable CS1570 // XML comment has badly formed XML -- 'End tag 'typeparam' does not match the start tag 'param'.'
		/// <summary>
		/// Get a collection of types that implement interface <param name="interfaceType"></typeparam>
		/// </summary>
		/// <param name="interfaceType"></param>
		/// <returns></returns>
		public static IEnumerable<Type> ByImplementedInterface(this Type interfaceType)
#pragma warning restore CS1570 // XML comment has badly formed XML -- 'End tag 'typeparam' does not match the start tag 'param'.'
		{
#if (NET40 || NET45)
			if (!interfaceType.IsInterface) throw new ArgumentException("Type is not an interface", nameof(interfaceType));
			var assemblies = AppDomain.CurrentDomain.GetAssemblies();
			return ByPredicate(assemblies, type => type.ImplementsInterface(interfaceType));
#elif (NETSTANDARD2_0)
			if (!interfaceType.GetTypeInfo().IsInterface) throw new ArgumentException("Type is not an interface", "interfaceType");
			var assemblies = AppDomain.CurrentDomain.GetAssemblies();
			return ByPredicate(assemblies, type => type.ImplementsInterface(interfaceType));
#endif
		}

#pragma warning disable CS1570 // XML comment has badly formed XML -- 'End tag 'typeparam' does not match the start tag 'param'.'
			/// <summary>
			/// Get a collection of types that implement interface <param name="interfaceType"></typeparam> within namespace named <paramref name="namespaceName"/>
			/// </summary>
			/// <param name="interfaceType"></param>
			/// <param name="namespaceName"></param>
			/// <returns></returns>
			public static IEnumerable<Type> ByImplementedInterface(this Type interfaceType, string namespaceName)
#pragma warning restore CS1570 // XML comment has badly formed XML -- 'End tag 'typeparam' does not match the start tag 'param'.'
		{
			if (string.IsNullOrWhiteSpace(namespaceName)) throw new ArgumentNullException(nameof(namespaceName));
#if (NET45 || NET40 || NET451 || NET452 || NET46 || NET461 || NET462)
			if (!interfaceType.IsInterface) throw new ArgumentException("Type is not an interface", nameof(interfaceType));
			var assemblies = AppDomain.CurrentDomain.GetAssemblies();
			return ByPredicate(assemblies,
				type => (type.Namespace ?? string.Empty).StartsWith(namespaceName) && type.ImplementsInterface(interfaceType));
#elif (NETSTANDARD2_0)
			if (!interfaceType.GetTypeInfo().IsInterface) throw new ArgumentException("Type is not an interface", "interfaceType");
			var assemblies = AppDomain.CurrentDomain.GetAssemblies();
			return ByPredicate(assemblies,
				type => (type.Namespace ?? string.Empty).StartsWith(namespaceName) && type.GetTypeInfo().ImplementsInterface(interfaceType));
#endif
		}
#endif

#if (NETSTANDARD2_0 || NETSTANDARD1_6 || NETSTANDARD1_5 || NET45 || NET40 || NET451 || NET452 || NET46 || NET461 || NET462)
		/// <summary>
		/// get a collection of types that implement <paramref name="interfaceType"/> for assemblies filenames matching <paramref name="wildcard"/> in directory <paramref name="directory"/>
		/// </summary>
		/// <param name="interfaceType"></param>
		/// <param name="directory"></param>
		/// <param name="wildcard"></param>
		/// <returns></returns>
		public static IEnumerable<Type> ByImplementedInterfaceInDirectory(this Type interfaceType, string directory, string wildcard)
		{
#if (NET45 || NET40 || NET451 || NET452 || NET46 || NET461 || NET462)
			if (!interfaceType.IsInterface) throw new ArgumentException("Type is not an interface", nameof(interfaceType));
			return ByPredicate(System.IO.Directory.GetFiles(directory, wildcard).ToAssemblies(), type => ImplementsInterface(type, interfaceType));
#else
			if (!interfaceType.GetTypeInfo().IsInterface) throw new ArgumentException("Type is not an interface", "TInterface");
			return ByPredicate(System.IO.Directory.GetFiles(directory, wildcard).ToAssemblies(), type => ImplementsInterface(type, interfaceType));
#endif
		}

		/// <summary>
		/// get a collection of types that implement <paramref name="interfaceType"/> for assemblies filenames matching <paramref name="wildcard"/> in directory <paramref name="directory"/> within namespace named <paramref name="namespaceName"/>
		/// </summary>
		/// <param name="interfaceType"></param>
		/// <param name="directory"></param>
		/// <param name="wildcard"></param>
		/// <param name="namespaceName"></param>
		/// <returns></returns>
		public static IEnumerable<Type> ByImplementedInterfaceInDirectory(this Type interfaceType, string directory, string wildcard, string namespaceName)
		{
#if (NET45 || NET40 || NET451 || NET452 || NET46 || NET461 || NET462)
			if (!interfaceType.IsInterface) throw new ArgumentException("Type is not an interface", "TInterface");
			return ByPredicate(System.IO.Directory.GetFiles(directory, wildcard).ToAssemblies(),
				type => (type.Namespace ?? string.Empty).StartsWith(namespaceName) && ImplementsInterface(type, interfaceType));
#else
			if (!interfaceType.GetTypeInfo().IsInterface) throw new ArgumentException("Type is not an interface", "TInterface");
			return ByPredicate(System.IO.Directory.GetFiles(directory, wildcard).ToAssemblies(),
				type => (type.Namespace ?? string.Empty).StartsWith(namespaceName) && ImplementsInterface(type, interfaceType));
#endif
		}
#endif

		/// <summary>
		/// Gets the default constructor for <paramref name="type"/>
		/// </summary>
		/// <param name="type">The type to get the default destructor</param>
		/// <returns><seealso cref="ConstructorInfo"/> about the default constructor.</returns>
		public static ConstructorInfo GetConstructor(this Type type)
		{
#if (NET45 || NET40 || NET451 || NET452 || NET46 || NET461 || NET462)
			return type.GetConstructor(new Type[0]);
#else
			return type.GetTypeInfo().DeclaredConstructors.Single(e => !e.GetParameters().Any());
#endif
		}
	}
}
#endif