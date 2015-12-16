using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using PRI.ProductivityExtensions.IEnumerableExtensions;

namespace PRI.ProductivityExtensions.ReflectionExtensions
{
	public static partial class Typeable
	{
		public static bool IsStatic(this Type type)
		{
			if (type == null) throw new ArgumentNullException("type");
			return type.IsAbstract && type.IsSealed;
		}

		public static bool IsOpenGenericType(this Type type)
		{
			return type.GetGenericTypeArguments().Length == 0 && type.IsGenericType;
		}

		public static Type[] GetGenericTypeArguments(this Type type)
		{
#if NET_4_5
			return type.GenericTypeArguments;
#else
			if (type.IsGenericType && !type.IsGenericTypeDefinition)
				return type.GetGenericArguments();
			else
				return Type.EmptyTypes;
#endif
		}

		/// <summary>
		/// Tests if <param name="type"></param> has attribute <param name="TAttributes"></param>
		/// </summary>
		/// <typeparam name="TAttribute"></typeparam>
		/// <param name="type"></param>
		/// <returns></returns>
		public static bool HasAttribute<TAttribute>(this Type type) where TAttribute : Attribute
		{
			if (type == null) throw new ArgumentNullException("type");
			return type.HasAttribute(typeof (TAttribute));
		}

		/// <summary>
		/// Tests if <param name="type"></param> has attribute <paramref name="attributeType"/>
		/// </summary>
		/// <param name="type"></param>
		/// <param name="attributeType"></param>
		/// <returns>true if attributed with <paramref name="attributeType"/>, false otherwise.</returns>
		public static bool HasAttribute(this Type type, Type attributeType)
		{
			return type.GetCustomAttributes(attributeType, false).Length > 0;
		}

		/// <summary>
		/// Test if <param name="type"> implements interface <typeparamref name="TInterface"/>
		/// </summary>
		/// <typeparam name="TInterface"></typeparam>
		/// <param name="type"></param>
		/// <returns></returns>
		public static bool ImplementsInterface<TInterface>(this Type type)
		{
			if (type == null) throw new ArgumentNullException("type");
			return typeof(TInterface).IsAssignableFrom(type);
		}

		/// <summary>
		/// tests if <param name="type"> implements interface <param name="interfaceType"></typeparam>
		/// </summary>
		/// <param name="type"></param>
		/// <param name="interfaceType"></param>
		/// <returns></returns>
		public static bool ImplementsInterface(this Type type, Type interfaceType)
		{
			if (interfaceType == null) throw new ArgumentNullException("interfaceType");
			if (type == null) throw new ArgumentNullException("type");
			if (interfaceType.IsGenericType && interfaceType.ContainsGenericParameters)
			{
				return type.GetInterfaces().Any(t => t.IsGenericType && t.GetGenericTypeDefinition() == interfaceType);
			}
			return interfaceType.IsAssignableFrom(type);
		}

		private static IEnumerable<Type> ByPredicate(IEnumerable<Assembly> assemblies, Predicate<Type> predicate)
		{
			return from assembly in assemblies
				   from type in assembly.GetTypes()
				   where !type.IsAbstract && type.IsClass && predicate(type)
				   select type;
		}

		/// <summary>
		/// Get a collection of types that implement interface <param name="interfaceType"></typeparam>
		/// </summary>
		/// <param name="interfaceType"></param>
		/// <returns></returns>
		public static IEnumerable<Type> ByImplementedInterface(this Type interfaceType)
		{
			if (!interfaceType.IsInterface) throw new ArgumentException("Type is not an interface", "interfaceType");
			var assemblies = AppDomain.CurrentDomain.GetAssemblies();
			return ByPredicate(assemblies, type => type.ImplementsInterface(interfaceType));
		}

		/// <summary>
		/// Get a collection of types that implement interface <param name="interfaceType"></typeparam> within namespace named <paramref name="namespaceName"/>
		/// </summary>
		/// <param name="interfaceType"></param>
		/// <param name="namespaceName"></param>
		/// <returns></returns>
		public static IEnumerable<Type> ByImplementedInterface(this Type interfaceType, string namespaceName)
		{
			if (string.IsNullOrWhiteSpace(namespaceName)) throw new ArgumentNullException("namespaceName");
			if (!interfaceType.IsInterface) throw new ArgumentException("Type is not an interface", "interfaceType");
			var assemblies = AppDomain.CurrentDomain.GetAssemblies();
			return ByPredicate(assemblies,
				type => (type.Namespace ?? string.Empty).StartsWith(namespaceName) && type.ImplementsInterface(interfaceType));
		}

		/// <summary>
		/// get a collection of types that implement <paramref name="interfaceType"/> for assemblies filenames matching <paramref name="wildcard"/> in directory <paramref name="directory"/>
		/// </summary>
		/// <param name="interfaceType"></param>
		/// <param name="directory"></param>
		/// <param name="wildcard"></param>
		/// <returns></returns>
		public static IEnumerable<Type> ByImplementedInterfaceInDirectory(this Type interfaceType, string directory, string wildcard)
		{
			if (!interfaceType.IsInterface) throw new ArgumentException("Type is not an interface", "TInterface");
			return ByPredicate(System.IO.Directory.GetFiles(directory, wildcard).ToAssemblies(), type => ImplementsInterface(type, interfaceType));
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
			if (!interfaceType.IsInterface) throw new ArgumentException("Type is not an interface", "TInterface");
			return ByPredicate(System.IO.Directory.GetFiles(directory, wildcard).ToAssemblies(),
				type => (type.Namespace ?? string.Empty).StartsWith(namespaceName) && ImplementsInterface(type, interfaceType));
		}

		/// <summary>
		/// Gets the default constructor for <paramref name="type"/>
		/// </summary>
		/// <param name="type">The type to get the default destructor</param>
		/// <returns><seealso cref="ConstructorInfo"/> about the default constructor.</returns>
		public static ConstructorInfo GetConstructor(this Type type)
		{
			return type.GetConstructor(new Type[0]);
		}
	}
}