#if (NETSTANDARD2_0 || NET45 || NET451 || NET452 || NET46 || NET461 || NET462)
using System;
using System.Net.Sockets;
using System.Threading;
using System.Threading.Tasks;
using PRI.ProductivityExtensions.SocketAsyncEventArgsExtensions;

namespace PRI.ProductivityExtensions.SocketExtensions
{
	public partial class Socketable
	{
#if NET45
#region based on code from http://blogs.msdn.com/b/pfxteam/archive/2011/12/15/10248293.aspx
		private sealed class SocketAwaitable : IAwaitable
		{
			private static readonly Action SENTINEL = () => { };
			private Action continuation;

			internal readonly SocketAsyncEventArgs EventArgs;

			public SocketAwaitable(SocketAsyncEventArgs eventArgs)
			{
				EventArgs = eventArgs ?? throw new ArgumentNullException(nameof(eventArgs));
				eventArgs.Completed += delegate
				{
					(continuation ?? Interlocked.CompareExchange(
						ref continuation, SENTINEL, null))?.Invoke();
				};
			}

			internal void Reset()
			{
				IsCompleted = false;
				continuation = null;
			}

			public IAwaitable GetAwaiter()
			{
				return this;
			}

			public bool IsCompleted { get; internal set; }

			public void OnCompleted(Action action)
			{
				if (continuation == SENTINEL ||
					Interlocked.CompareExchange(
						ref continuation, action, null) == SENTINEL)
				{
					Task.Run(action);
				}
			}

			public void GetResult()
			{
				if (EventArgs.SocketError != SocketError.Success)
					throw new SocketException((int)EventArgs.SocketError);
			}
		}

		private static IAwaitable SendAsync(this Socket socket,
												 SocketAwaitable awaitable)
		{
			awaitable.Reset();
			if (!socket.SendAsync(awaitable.EventArgs))
				awaitable.IsCompleted = true;
			return awaitable;
		}

		public static IAwaitable SendAsync(this Socket socket, byte[] buffer)
		{
			var args = new SocketAsyncEventArgs();
			args.SetBuffer(buffer);
			var awaitable = new SocketAwaitable(args);
			return socket.SendAsync(awaitable);
		}

		private static SocketAwaitable ReceiveAsync(this Socket socket,
													SocketAwaitable awaitable)
		{
			awaitable.Reset();
			if (!socket.ReceiveAsync(awaitable.EventArgs))
				awaitable.IsCompleted = true;
			return awaitable;
		}

		public static async Task<int> ReceiveAsync(this Socket s, byte[] buffer)
		{
			var args = new SocketAsyncEventArgs();
			args.SetBuffer(buffer);
			var awaitable = new SocketAwaitable(args);
			int totalBytesRead = 0;
			while (true)
			{
				await s.ReceiveAsync(awaitable);
				int bytesRead = args.BytesTransferred;
				if (bytesRead <= 0) break;
				totalBytesRead = bytesRead;
			}
			return totalBytesRead;
		}
#endregion msdn blog
#endif // NET4_5
	}
}
#endif