using System;

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
	}
}