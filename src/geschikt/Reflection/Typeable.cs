using System;
using System.Reflection;

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