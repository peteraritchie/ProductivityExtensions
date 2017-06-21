#if (NET4O || NET45 || NET451 || NET452 || NET46 || NET461 || NET462)
using System.Reflection;
using System.Reflection.Emit;

namespace PRI.ProductivityExtensions.ReflectionExtensions
{
	/// <summary>
	/// class that contains extension methods that extend <seealso cref="ModuleBuilder"/>
	/// </summary>
	public static partial class ModuleBuilderable
	{
		/// <summary>
		/// Adds a public class to the module encapsulated by the <paramref name="moduleBuilder"/> of name <paramref name="name"/>
		/// </summary>
		/// <param name="moduleBuilder"><seealso cref="ModuleBuilder"/> to add class to</param>
		/// <param name="name">Name of the class</param>
		/// <returns>TypeBuilder object that encapsulates the new class.</returns>
		public static TypeBuilder DefineClass(this ModuleBuilder moduleBuilder, string name)
		{
			return moduleBuilder.DefineType(name, TypeAttributes.Class | TypeAttributes.Public);
		}
	}
}
#endif