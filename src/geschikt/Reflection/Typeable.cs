#if (NETCOREAPP1_0 || NETCOREAPP1_2 || NETCOREAPP2_0 || NETSTANDARD2_0 || NETSTANDARD1_6 || NETSTANDARD1_5 || NETSTANDARD1_4 || NETSTANDARD1_3 || NETSTANDARD1_2 || NETSTANDARD1_1 || NETSTANDARD1_0 || NET45 || NET40 || NET451 || NET452 || NET46 || NET461 || NET462)
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
#if (NETSTANDARD2_0 || NETSTANDARD1_6 || NETSTANDARD1_5 || NETSTANDARD1_4 || NETSTANDARD1_3 || NET45 || NET40 || NET451 || NET452 || NET46 || NET461 || NET462)
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
#if (NET40 || NET45 || NET451 || NET452 || NET46 || NET461 || NET462)
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

		/// <summary>
		/// Tests if <param name="type" /> has attribute <typeparam name="TAttribute"/>
		/// </summary>
		/// <typeparam name="TAttribute"></typeparam>
		/// <param name="type"></param>
		/// <returns></returns>
		public static bool HasAttribute<TAttribute>(this Type type) where TAttribute : Attribute
		{
			if (type == null) throw new ArgumentNullException(nameof(type));
			return type.HasAttribute(typeof (TAttribute));
		}

		/// <summary>
		/// Tests if <param name="type" /> has attribute <param name="attributeType" />
		/// </summary>
		/// <param name="type"></param>
		/// <param name="attributeType"></param>
		/// <returns>true if attributed with <paramref name="attributeType" />, false otherwise.</returns>
		public static bool HasAttribute(this Type type, Type attributeType)
		{
			return type.GetTypeInfo().GetCustomAttributes(attributeType, false).Any();
		}

		/// <summary>
		/// Test if <param name="type" /> implements interface <typeparamref name="TInterface"/>
		/// </summary>
		/// <typeparam name="TInterface"></typeparam>
		/// <param name="type"></param>
		/// <returns></returns>
		public static bool ImplementsInterface<TInterface>(this Type type)
		{
			if (type == null) throw new ArgumentNullException(nameof(type));
			return typeof(TInterface).ImplementsInterface(type);
		}

		/// <summary>
		/// tests if <param name="type" /> implements interface <param name="interfaceType" />
		/// </summary>
		/// <param name="type"></param>
		/// <param name="interfaceType"></param>
		/// <returns></returns>
		public static bool ImplementsInterface(this Type type, Type interfaceType)
		{
			if (type == null) throw new ArgumentNullException(nameof(type));
			return type.GetTypeInfo().ImplementsInterface(interfaceType);
		}

		public static bool ImplementsInterface(this TypeInfo typeTypeInfo, TypeInfo interfaceTypeInfo)
		{
			if (interfaceTypeInfo == null) throw new ArgumentNullException(nameof(interfaceTypeInfo));
			if (typeTypeInfo == null) throw new ArgumentNullException(nameof(typeTypeInfo));

			if (interfaceTypeInfo.IsGenericType && interfaceTypeInfo.ContainsGenericParameters)
			{
				var interfaceType = interfaceTypeInfo.AsType();
				return typeTypeInfo.ImplementedInterfaces
					.Select(t => t.GetTypeInfo())
					.Any(t => t.IsGenericType && t.GetGenericTypeDefinition() == interfaceType);
			}
			return interfaceTypeInfo.IsAssignableFrom(typeTypeInfo);
		}

		public static bool ImplementsInterface(this TypeInfo typeTypeInfo, Type interfaceType)
		{
			if (interfaceType == null) throw new ArgumentNullException(nameof(interfaceType));
			if (typeTypeInfo == null) throw new ArgumentNullException(nameof(typeTypeInfo));

			var interfaceTypeInfo = interfaceType.GetTypeInfo();
			if (interfaceTypeInfo.IsGenericType && interfaceTypeInfo.ContainsGenericParameters)
			{
				return typeTypeInfo.ImplementedInterfaces
					.Select(t => t.GetTypeInfo())
					.Any(t => t.IsGenericType && t.GetGenericTypeDefinition() == interfaceType);
			}
			return interfaceTypeInfo.IsAssignableFrom(typeTypeInfo);
		}

		private static IEnumerable<TypeInfo> ByPredicate(IEnumerable<Assembly> assemblies, Predicate<TypeInfo> predicate)
		{
			return from assembly in assemblies
				   from type in assembly.DefinedTypes
				   where !type.IsAbstract && type.IsClass && predicate(type)
				   select type;
		}

#if !NETSTANDARD1_0 && !NETSTANDARD1_1 && !NETSTANDARD1_2 && !NETSTANDARD1_3 && !NETSTANDARD1_4 && !NETSTANDARD1_5 && !NETSTANDARD1_6
		/// <summary>
		/// Get a collection of types that implement interface <paramref name="interfaceType" />
		/// </summary>
		/// <param name="interfaceType"></param>
		/// <returns></returns>
		public static IEnumerable<Type> ByImplementedInterface(this Type interfaceType)
		{
			if (!interfaceType.GetTypeInfo().IsInterface) throw new ArgumentException("Type is not an interface", "interfaceType");
			var assemblies = AppDomain.CurrentDomain.GetAssemblies();
			return ByPredicate(assemblies, type => type.ImplementsInterface(interfaceType)).Select(t=>t.AsType());
		}

		/// <summary>
		/// Get a collection of types that implement interface <paramref name="interfaceType" /> within namespace named <paramref name="namespaceName"/>
		/// </summary>
		/// <param name="interfaceType"></param>
		/// <param name="namespaceName"></param>
		/// <returns></returns>
		public static IEnumerable<Type> ByImplementedInterface(this Type interfaceType, string namespaceName)
		{
			if (string.IsNullOrWhiteSpace(namespaceName))
			{
				throw new ArgumentNullException(nameof(namespaceName));
			}
#if (NET45 || NET40 || NET451 || NET452 || NET46 || NET461 || NET462)
			if (!interfaceType.IsInterface)
			{
				throw new ArgumentException("Type is not an interface", nameof(interfaceType));
			}

			var assemblies = AppDomain.CurrentDomain.GetAssemblies();
			return ByPredicate(
				assemblies,
				type => (type.Namespace ?? string.Empty).StartsWith(namespaceName) && type.ImplementsInterface(interfaceType));
#elif (NETSTANDARD2_0)
			if (!interfaceType.GetTypeInfo().IsInterface) throw new ArgumentException("Type is not an interface", "interfaceType");
			var assemblies = AppDomain.CurrentDomain.GetAssemblies();
			return ByPredicate(assemblies,
				type => (type.Namespace ?? string.Empty).StartsWith(namespaceName) && type.GetTypeInfo().ImplementsInterface(interfaceType));
#endif
		}
#endif

#if !NETSTANDARD1_0 && !NETSTANDARD1_1 && !NETSTANDARD1_2 && !NETSTANDARD1_2
		/// <summary>
		/// get a collection of types that implement <paramref name="interfaceType"/> for assemblies filenames matching <paramref name="wildcard"/> in directory <paramref name="directory"/>
		/// </summary>
		/// <param name="interfaceType"></param>
		/// <param name="directory"></param>
		/// <param name="wildcard"></param>
		/// <returns></returns>
		public static IEnumerable<Type> ByImplementedInterfaceInDirectory(this Type interfaceType, string directory, string wildcard)
		{
			if (!interfaceType.GetTypeInfo().IsInterface)
			{
				throw new ArgumentException("Type is not an interface", nameof(interfaceType));
			}

			return ByPredicate(System.IO.Directory.GetFiles(directory, wildcard).ToAssemblies(),
					type => type.ImplementsInterface(interfaceType))
				.Select(t => t.AsType());
		}

		/// <summary>
		/// get a collection of types that implement <paramref name="interfaceTypeInfo"/> for assemblies filenames matching <paramref name="wildcard"/> in directory <paramref name="directory"/>
		/// </summary>
		/// <param name="interfaceTypeInfo"></param>
		/// <param name="directory"></param>
		/// <param name="wildcard"></param>
		/// <returns></returns>
		public static IEnumerable<TypeInfo> ByImplementedInterfaceInDirectory(this TypeInfo interfaceTypeInfo, string directory, string wildcard)
		{
			if (!interfaceTypeInfo.IsInterface)
			{
				throw new ArgumentException("Type is not an interface", nameof(interfaceTypeInfo));
			}

			return ByPredicate(System.IO.Directory.GetFiles(directory, wildcard).ToAssemblies(),
					type => type.ImplementsInterface(interfaceTypeInfo));
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
			if (!interfaceType.GetTypeInfo().IsInterface)
			{
				throw new ArgumentException("Type is not an interface", "TInterface");
			}

			return ByPredicate(
					System.IO.Directory.GetFiles(directory, wildcard).ToAssemblies(),
					type => (type.Namespace ?? string.Empty).StartsWith(namespaceName) && type.ImplementsInterface(interfaceType))
				.Select(t => t.AsType());
		}

		/// <summary>
		/// get a collection of types that implement <paramref name="interfaceTypeInfo"/> for assemblies filenames matching <paramref name="wildcard"/> in directory <paramref name="directory"/> within namespace named <paramref name="namespaceName"/>
		/// </summary>
		/// <param name="interfaceTypeInfo"></param>
		/// <param name="directory"></param>
		/// <param name="wildcard"></param>
		/// <param name="namespaceName"></param>
		/// <returns></returns>
		public static IEnumerable<TypeInfo> ByImplementedInterfaceInDirectory(this TypeInfo interfaceTypeInfo, string directory, string wildcard, string namespaceName)
		{
			if (!interfaceTypeInfo.IsInterface)
			{
				throw new ArgumentException("Type is not an interface", "interfaceTypeInfo");
			}

			return ByPredicate(
				System.IO.Directory.GetFiles(directory, wildcard).ToAssemblies(),
				type => (type.Namespace ?? string.Empty).StartsWith(namespaceName) && type.ImplementsInterface(interfaceTypeInfo));
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