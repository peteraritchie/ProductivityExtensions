using System.Reflection.Emit;

namespace PRI.ProductivityExtensions.ReflectionExtensions
{
	/// <summary>
	/// class that contains information about an IL Instruction
	/// </summary>
	public class IlInstruction
	{
		/// <summary>
		/// Opcode of the instruction
		/// </summary>
		public OpCode Code { get; set; }

		/// <summary>
		/// Optional operand of the instruction
		/// </summary>
		public object Operand { get; set; }

		/// <summary>
		/// construct an IlInstruction based on the OpCode
		/// </summary>
		/// <param name="code"></param>
		public IlInstruction(OpCode code)
		{
			Code = code;
		}
	}
}