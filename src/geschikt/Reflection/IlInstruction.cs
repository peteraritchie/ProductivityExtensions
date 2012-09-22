using System.Reflection.Emit;

namespace PRI.ProductivityExtensions.ReflectionExtensions
{
	public class IlInstruction
	{
		public OpCode Code { get; set; }

		public object Operand { get; set; }

		public IlInstruction(OpCode code)
		{
			Code = code;
		}
	}
}