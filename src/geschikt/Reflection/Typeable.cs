using System;

namespace PRI.ProductivityExtensions.ReflectionExtensions
{
	public static class Typeable
	{
		public static bool IsStatic(this Type type)
		{
			if (type == null) throw new ArgumentNullException("type");
			return type.IsAbstract && type.IsSealed;
		}
	}
}