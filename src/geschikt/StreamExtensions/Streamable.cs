using System;
using System.IO;
using System.Threading;

namespace PRI.ProductivityExtensions.StreamExtensions
{
	static partial class Streamable
	{
		/// <summary>
		/// Asynchronously read to end of stream
		/// </summary>
		/// <example>
		///	byte[] buffer = new byte[1024];
		///	stream.BeginReadToEnd(buffer, 0, buffer.Length, ar =>
		///	                                               {
		///	                                               	int bytesRead = stream.EndRead(ar);
		///	                                               	ProcessData(buffer, bytesRead);
		///	                                               }, null);
		/// </example>
		/// <param name="stream"></param>
		/// <param name="buffer"></param>
		/// <param name="offset"></param>
		/// <param name="count"></param>
		/// <param name="callback"></param>
		/// <param name="state"></param>
		/// <returns></returns>
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Reliability", "CA2000:Dispose objects before losing scope",
			Justification = "'result' is used asynchronously")]
		public static IAsyncResult BeginReadToEnd(this Stream stream, byte[] buffer, int offset, int count, AsyncCallback callback, Object state)
		{
			byte[] tempBuffer = new byte[count];
			ByteArrayAsyncResult result = new ByteArrayAsyncResult(callback, state, buffer, offset, tempBuffer);
			ByteArrayAsyncState asyncState = new ByteArrayAsyncState { Result = result, Stream = stream };
			stream.BeginRead(tempBuffer, 0, count, OnRead, asyncState);
			return result;
		}

		/// <summary>
		/// Asynchronously read to end of stream into a given buffer at given offset, of given size.
		/// This version does not use a state Object.
		/// </summary>
		/// <example>
		///	byte[] buffer = new byte[1024];
		///	stream.BeginReadToEnd(buffer, 0, buffer.Length, ar =>
		///	                                               {
		///	                                               	int bytesRead = stream.EndRead(ar);
		///	                                               	ProcessData(buffer, bytesRead);
		///	                                               });
		/// </example>
		/// <param name="stream"></param>
		/// <param name="buffer"></param>
		/// <param name="offset"></param>
		/// <param name="count"></param>
		/// <param name="callback"></param>
		/// <param name="state"></param>
		/// <returns></returns>
		public static void BeginReadToEnd(this Stream stream, byte[] buffer, int offset, int count, AsyncCallback callback)
		{
			stream.BeginReadToEnd(buffer, offset, count, callback, null);
		}

		/// <summary>
		/// Asynchronously read to end of stream depending on size of buffer, starting at offset 0.
		/// This version does not use a state Object.
		/// </summary>
		/// <example>
		///	byte[] buffer = new byte[1024];
		///	stream.BeginReadToEnd(buffer, ar =>
		///	                                               {
		///	                                               	int bytesRead = stream.EndRead(ar);
		///	                                               	ProcessData(buffer, bytesRead);
		///	                                               });
		/// </example>
		/// <param name="stream"></param>
		/// <param name="buffer"></param>
		/// <param name="offset"></param>
		/// <param name="count"></param>
		/// <param name="callback"></param>
		/// <param name="state"></param>
		/// <returns></returns>
		public static IAsyncResult BeginReadToEnd(this Stream stream, byte[] buffer, AsyncCallback callback)
		{
			return stream.BeginReadToEnd(buffer, 0, buffer.Length, callback, null);
		}

		/// <summary>
		/// The Asynchronous Programming Model matching End method to the corresponding BeginReadToEnd methods.
		/// </summary>
		/// <param name="stream"></param>
		/// <param name="ar"></param>
		/// <returns></returns>
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA1801:ReviewUnusedParameters", MessageId = "stream", 
			Justification = "'stream' is required for this to be an extension method")]
		public static int EndReadToEnd(this Stream stream, IAsyncResult ar)
		{
			ByteArrayAsyncResult state = ar as ByteArrayAsyncResult;
			if (state == null) throw new InvalidOperationException();
			state.AsyncWaitHandle.WaitOne(-1);
			using(state)
			{
			}
			return state.Length;
		}

		private static void OnRead(IAsyncResult ar)
		{
			if (ar == null) return;
			ByteArrayAsyncState state = ar.AsyncState as ByteArrayAsyncState;
			if (state == null) return;
			int bytesRead = state.Stream.EndRead(ar);
			if (bytesRead != 0)
			{
				Array.Copy(state.Result.TempBuffer, 0, state.Result.Result, state.Result.Index, bytesRead);
				state.Result.Index += bytesRead;
				state.Result.Length = state.Result.Index;
				state.Stream.BeginRead(state.Result.TempBuffer, 0, state.Result.Result.Length - state.Result.Length, OnRead, state);
				return;
			}
			state.Result.Complete(false);
		}

		private sealed class ByteArrayAsyncResult : IAsyncResult, IDisposable
		{
			private readonly AsyncCallback callback;
			private bool completed;
			private bool completedSynchronously;
			private readonly object syncRoot;
			public readonly byte[] Result;
			public int Index;
			public readonly byte[] TempBuffer;
			public int Length;
			private readonly ManualResetEvent asyncWaitHandle;

			internal ByteArrayAsyncResult(AsyncCallback cb, object state, byte[] buffer, int offset, byte[] tempBuffer)
				: this(cb, state, buffer, offset, tempBuffer, false)
			{
			}

			private ByteArrayAsyncResult(AsyncCallback cb, object state, byte[] buffer, int offset, byte[] tempBuffer, bool completed)
			{
				callback = cb;
				AsyncState = state;
				this.completed = completed;
				completedSynchronously = completed;
				Result = buffer;
				Index = offset;
				TempBuffer = tempBuffer;

				asyncWaitHandle = new ManualResetEvent(false);
				syncRoot = new object();
			}

			public object AsyncState { get; private set; }

			public WaitHandle AsyncWaitHandle { get { return asyncWaitHandle; }}

			public bool CompletedSynchronously
			{
				get
				{
					lock (syncRoot)
					{
						return completedSynchronously;
					}
				}
			}

			public bool IsCompleted
			{
				get
				{
					lock (syncRoot)
					{
						return completed;
					}
				}
			}

			public void Dispose()
			{
				Dispose(true);
				GC.SuppressFinalize(this);
			}

			private void Dispose(bool disposing)
			{
				if (disposing)
				{
					lock (syncRoot)
					{
						if (asyncWaitHandle != null)
						{
							((IDisposable)asyncWaitHandle).Dispose();
						}
					}
				}
			}

			internal void Complete(bool didCompleteSynchronously)
			{
				lock (syncRoot)
				{
					completed = true;
					completedSynchronously =
						didCompleteSynchronously;
				}

				SignalCompletion();
			}

			private void SignalCompletion()
			{
				asyncWaitHandle.Set();

				ThreadPool.QueueUserWorkItem(InvokeCallback);
			}

			private void InvokeCallback(object state)
			{
				if (callback != null)
				{
					callback(this);
				}
			}
		}

		/// <summary>
		/// private state class to transfer state information between invocations of StreamExtensions.OnRead
		/// </summary>
		private class ByteArrayAsyncState
		{
			public ByteArrayAsyncResult Result;
			public Stream Stream;
		}
	}
}