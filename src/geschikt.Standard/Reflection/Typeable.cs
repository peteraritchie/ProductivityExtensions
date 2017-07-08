#if (NETCOREAPP1_0 || NETCOREAPP1_1 || NETCOREAPP2_0 || NETSTANDARD2_0 || NETSTANDARD1_6 || NETSTANDARD1_5 || NETSTANDARD1_4 || NETSTANDARD1_3 || NETSTANDARD1_2 || NETSTANDARD1_1 || NETSTANDARD1_0 || NET45 || NET40 || NET451 || NET452 || NET46 || NET461 || NET462)
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
#if (NET40 || NET45 || NET451 || NET452 || NET46 || NET461 || NET462)
using PRI.ProductivityExtensions.IEnumerableExtensions;
#endif

namespace PRI.ProductivityExtensions.ReflectionExtensions
{
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'Typeable'
	public static partial class Typeable
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'Typeable'
	{
#if NETSTANDARD1_0
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'Typeable.IsStatic(Type)'
		public static bool IsStatic(this Type type)
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'Typeable.IsStatic(Type)'
		{
			if (type == null)
			{
				throw new ArgumentNullException(nameof(type));
			}
#if (NET40 || NET45)
			return type.IsAbstract && type.IsSealed;
#else
			return type.GetTypeInfo().IsAbstract && type.GetTypeInfo().IsSealed;
#endif
		}

#if (NETSTANDARD2_0 || NETSTANDARD1_6 || NETSTANDARD1_5 || NETSTANDARD1_4 || NETSTANDARD1_3 || NETSTANDARD1_2 || NETSTANDARD1_1 || NETSTANDARD1_0)
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
#endif

#if (NETSTANDARD2_0 || NETSTANDARD1_6 || NETSTANDARD1_5 || NETSTANDARD1_4 || NETSTANDARD1_3 || NETSTANDARD1_2 || NETSTANDARD1_1 || NETSTANDARD1_0)
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
			{
				return typeInfo.GenericTypeArguments;
			}
#endif
			else
			{
#if (NETSTANDARD2_0 || NETSTANDARD1_6 || NETSTANDARD1_5 || NETSTANDARD1_4 || NETSTANDARD1_3 || NET45 || NET40 || NET451 || NET452 || NET46 || NET461 || NET462)
				return Type.EmptyTypes;
#else
				return new Type[0];
#endif
			}
#endif
		}
#endif
#if NETSTANDARD1_0
#if (NETSTANDARD2_0 || NETSTANDARD1_6 || NETSTANDARD1_5 || NETSTANDARD1_4 || NETSTANDARD1_3 || NETSTANDARD1_2 || NETSTANDARD1_1 || NETSTANDARD1_0)
		/// <summary>
		/// Tests if <paramref name="type" /> has attribute <typeparamref name="TAttribute"/>
		/// </summary>
		/// <typeparam name="TAttribute"></typeparam>
		/// <param name="type"></param>
		/// <returns></returns>
		public static bool HasAttribute<TAttribute>(this Type type)
			where TAttribute : Attribute
		{
			if (type == null)
			{
				throw new ArgumentNullException(nameof(type));
			}

			return type.HasAttribute(typeof(TAttribute));
		}
#endif
#endif

		/// <summary>
		/// Tests if <paramref name="type" /> has attribute <paramref name="attributeType" />
		/// </summary>
		/// <param name="type"></param>
		/// <param name="attributeType"></param>
		/// <returns>true if attributed with <paramref name="attributeType" />, false otherwise.</returns>
		public static bool HasAttribute(this Type type, Type attributeType)
		{
#if (NET40 || NET45)
			return type.GetCustomAttributes(attributeType, false).Length > 0;
#else
			return type.GetTypeInfo().GetCustomAttributes(attributeType, false).Any();
#endif
		}
#endif

#if NETSTANDARD1_0
#if (NETSTANDARD2_0 || NETSTANDARD1_6 || NETSTANDARD1_5 || NETSTANDARD1_4 || NETSTANDARD1_3 || NETSTANDARD1_2 || NETSTANDARD1_1 || NETSTANDARD1_0 || NET45 || NET40 || NET451 || NET452 || NET46 || NET461 || NET462)
		/// <summary>
		/// Test if <paramref name="type" /> implements interface <typeparamref name="TInterface"/>
		/// </summary>
		/// <typeparam name="TInterface"></typeparam>
		/// <param name="type"></param>
		/// <returns></returns>
		public static bool ImplementsInterface<TInterface>(this Type type)
		{
			if (type == null)
			{
				throw new ArgumentNullException(nameof(type));
			}
#if (NET40 || NET45)
			return typeof(TInterface).IsAssignableFrom(type);
#else
			return typeof(TInterface).GetTypeInfo().IsAssignableFrom(type.GetTypeInfo());
#endif
		}

		/// <summary>
		/// tests if <paramref name="type" /> implements interface <paramref name="interfaceType" />
		/// </summary>
		/// <param name="type"></param>
		/// <param name="interfaceType"></param>
		/// <returns></returns>
#if (NETSTANDARD2_0 || NETSTANDARD1_6 || NETSTANDARD1_5 || NETSTANDARD1_4 || NETSTANDARD1_3 || NETSTANDARD1_2 || NETSTANDARD1_1 || NETSTANDARD1_0 || NET45 || NET40 || NET451 || NET452 || NET46 || NET461 || NET462)
		public static bool ImplementsInterface(this Type type, Type interfaceType)
#else
		public static bool ImplementsInterface(this TypeInfo type, Type interfaceType)
#endif
		{
			if (interfaceType == null)
			{
				throw new ArgumentNullException(nameof(interfaceType));
			}

			if (type == null)
			{
				throw new ArgumentNullException(nameof(type));
			}
#if (NETSTANDARD2_0 || NETSTANDARD1_6 || NETSTANDARD1_5 || NET45 || NET40 || NET451 || NET452 || NET46 || NET461 || NET462)
			if (interfaceType.IsGenericType && interfaceType.ContainsGenericParameters)
			{
				return type.GetInterfaces().Any(t => t.IsGenericType && t.GetGenericTypeDefinition() == interfaceType);
			}

			return interfaceType.IsAssignableFrom(type);
#else
			var interfacTypeInfo = interfaceType.GetTypeInfo();
			var typeInfo = type.GetTypeInfo();
			if (interfacTypeInfo.IsGenericType && interfacTypeInfo.ContainsGenericParameters)
			{
				return typeInfo.ImplementedInterfaces.Any(t => t.GetTypeInfo().IsGenericType && t.GetTypeInfo().GetGenericTypeDefinition() == interfaceType);
			}

			return interfacTypeInfo.IsAssignableFrom(typeInfo);
#endif
		}
#endif
#endif

#if (NETSTANDARD2_0 || NET45 || NET40 || NET451 || NET452 || NET46 || NET461 || NET462)
		private static IEnumerable<Type> ByPredicate(IEnumerable<Assembly> assemblies, Predicate<Type> predicate)
#else
		private static IEnumerable<TypeInfo> ByPredicate(IEnumerable<Assembly> assemblies, Predicate<TypeInfo> predicate)
#endif
		{
			return from assembly in assemblies
#if (NETSTANDARD1_0 || NETSTANDARD1_1 || NETSTANDARD1_2 || NETSTANDARD1_3 || NETSTANDARD1_4)
				   from type in assembly.DefinedTypes
#else
				   from type in assembly.GetTypes()
#endif
				   where !type.IsAbstract && type.IsClass && predicate(type)
				   select type;
		}

#if (NETSTANDARD2_0 || NET45 || NET40 || NET451 || NET452 || NET46 || NET461 || NET462)
		/// <summary>
		/// Get a collection of types that implement interface <param name="interfaceType" />
		/// </summary>
		/// <param name="interfaceType"></param>
		/// <returns></returns>
		public static IEnumerable<Type> ByImplementedInterface(this Type interfaceType)
		{
#if (NET40 || NET45 || NET451 || NET452 || NET46 || NET461 || NET462)
			if (!interfaceType.IsInterface) throw new ArgumentException("Type is not an interface", nameof(interfaceType));
			var assemblies = AppDomain.CurrentDomain.GetAssemblies();
			return ByPredicate(assemblies, type => type.ImplementsInterface(interfaceType));
#elif (NETSTANDARD2_0)
			if (!interfaceType.GetTypeInfo().IsInterface) throw new ArgumentException("Type is not an interface", "interfaceType");
			var assemblies = AppDomain.CurrentDomain.GetAssemblies();
			return ByPredicate(assemblies, type => type.ImplementsInterface(interfaceType));
#endif
		}

			/// <summary>
			/// Get a collection of types that implement interface <param name="interfaceType" /> within namespace named <paramref name="namespaceName"/>
			/// </summary>
			/// <param name="interfaceType"></param>
			/// <param name="namespaceName"></param>
			/// <returns></returns>
			public static IEnumerable<Type> ByImplementedInterface(this Type interfaceType, string namespaceName)
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

#if (NETSTANDARD2_0 || NET45 || NET40 || NET451 || NET452 || NET46 || NET461 || NET462)
		/// <summary>
		/// get a collection of types that implement <paramref name="interfaceType"/> for assemblies filenames matching <paramref name="wildcard"/> in directory <paramref name="directory"/>
		/// </summary>
		/// <param name="interfaceType"></param>
		/// <param name="directory"></param>
		/// <param name="wildcard"></param>
		/// <returns></returns>
		public static IEnumerable<Type> ByImplementedInterfaceInDirectory(this Type interfaceType, string directory, string wildcard)
		{
			if (!interfaceType.IsInterface) throw new ArgumentException("Type is not an interface", nameof(interfaceType));
			return ByPredicate(System.IO.Directory.GetFiles(directory, wildcard).ToAssemblies(), type => ImplementsInterface(type, interfaceType));
		}
#endif

#if (NETSTANDARD2_0 || NET45 || NET40 || NET451 || NET452 || NET46 || NET461 || NET462)
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
			if (!interfaceType.IsInterface) throw new ArgumentException("Type is not an interface", "TInterface");
			return ByPredicate(System.IO.Directory.GetFiles(directory, wildcard).ToAssemblies(),
				type => (type.Namespace ?? string.Empty).StartsWith(namespaceName) && ImplementsInterface(type, interfaceType));
		}
#endif
#if NETSTANDARD1_0
#if (NETSTANDARD2_0 || NETSTANDARD1_6 || NETSTANDARD1_5 || NETSTANDARD1_4 || NETSTANDARD1_3 || NETSTANDARD1_2 || NETSTANDARD1_1 || NETSTANDARD1_0)
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
#endif
#endif
	}
}
#endif