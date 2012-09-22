using System;
using System.Linq;
using System.Reflection;

namespace PRI.ProductivityExtensions.ReflectionExtensions
{
	public static class CustomAttributeProviderExtensions
	{
		public static bool ContainsAttribute(this ICustomAttributeProvider t, string attr)
		{
			if (t == null) throw new ArgumentNullException("t");

			return t.GetCustomAttributes(true).Any(i => i.GetType().Name == attr);
		}
	}
}