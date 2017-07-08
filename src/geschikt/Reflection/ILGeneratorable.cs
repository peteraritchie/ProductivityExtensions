#if (NET4O || NET45 || NET451 || NET452 || NET46 || NET461 || NET462)
using System.Reflection;
using System.Reflection.Emit;

namespace PRI.ProductivityExtensions.ReflectionExtensions
{
	/// <summary>
	/// Extension methods for <seealso cref="ILGenerator"/>
	/// </summary>
	public static partial class ILGeneratorable
	{
		/// <summary>
		/// Emit code that will get the value from <paramref name="field"/>
		/// </summary>
		/// <param name="generator">Generator that will emit the instructions</param>
		/// <param name="field">Field to read</param>
		public static void EmitBackingFieldGetter(this ILGenerator generator, FieldInfo field)
		{
			generator.Emit(OpCodes.Ldarg_0);
			generator.Emit(OpCodes.Ldfld, field);
			generator.Emit(OpCodes.Ret);
		}

		/// <summary>
		/// Emit code that will set the value <paramref name="field"/> based argument on stack
		/// </summary>
		/// <param name="generator">Generator that will emit the instructions</param>
		/// <param name="field">Field to write</param>
		public static void EmitBackingFieldSetter(this ILGenerator generator, FieldInfo field)
		{
			generator.Emit(OpCodes.Ldarg_0);
			generator.Emit(OpCodes.Ldarg_1);
			generator.Emit(OpCodes.Stfld, field);
			generator.Emit(OpCodes.Ret);
		}
	}
}
#endif