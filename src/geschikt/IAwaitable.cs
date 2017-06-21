#if (NETSTANDARD2_0 || NET45 || NET451 || NET452 || NET46 || NET461 || NET462)
using System.Runtime.CompilerServices;

namespace PRI.ProductivityExtensions
{
	public interface IAwaitable : INotifyCompletion
	{
		IAwaitable GetAwaiter();
		bool IsCompleted { get; }
		void GetResult();
	}
}
#endif
