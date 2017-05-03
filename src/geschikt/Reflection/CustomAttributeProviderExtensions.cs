using System;
using System.Linq;
using System.Reflection;

namespace PRI.ProductivityExtensions.ReflectionExtensions
{
	/// <summary>
	/// Extensions to <seealso cref="ICustomAttributeProvider"/>
	/// </summary>
	public static class CustomAttributeProviderExtensions
	{
		/// <summary>
		/// Tests if <paramref name="t"/> has any custom attributes defined with the type name <paramref name="attr"/>
		/// </summary>
		/// <param name="t">The provider to check for types with given attribute type names.</param>
		/// <param name="attr">Name of the attribute to check fo</param>
		/// <returns>true - <paramref name="t"/> has the attribute defined.
		/// false - <paramref name="t"/> does not have the attribute defined.</returns>
		public static bool ContainsAttribute(this ICustomAttributeProvider t, string attr)
		{
			if (t == null) throw new ArgumentNullException("t");

			return t.GetCustomAttributes(true).Any(i => i.GetType().Name == attr);
		}
	}
}