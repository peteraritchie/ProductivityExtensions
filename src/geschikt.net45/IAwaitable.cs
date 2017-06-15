#if NET4_5
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
