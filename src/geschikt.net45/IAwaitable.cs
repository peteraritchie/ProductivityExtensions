using System.Runtime.CompilerServices;

namespace PRI.ProductivityExtensions
{
#if NET_4_5
	public interface IAwaitable : INotifyCompletion
	{
		IAwaitable GetAwaiter();
		bool IsCompleted { get; }
		void GetResult();
	}
#endif
}