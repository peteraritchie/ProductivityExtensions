using System;
using System.IO;
using System.Threading;
#if NET_4_5
using System.Threading.Tasks;
#endif

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
		/// <param name="stream">The stream for which this extension method acts upon.</param>
		/// <param name="buffer">The buffer to read the data into. </param>
		/// <param name="offset">The byte offset in <paramref name="buffer"/> at which to begin writing data read from the stream. </param>
		/// <param name="count">The maximum number of bytes to read. </param>
		/// <param name="callback">An optional asynchronous callback, to be called when the read is complete. </param>
		/// <param name="state">A user-provided object that distinguishes this particular asynchronous read request from other requests. </param>
		/// <exception cref="T:System.IO.IOException">Attempted an asynchronous read past the end of the stream, or a disk error occurs. </exception>
		/// <exception cref="T:System.ArgumentException">One or more of the arguments is invalid. </exception>
		/// <exception cref="T:System.ObjectDisposedException">Methods were called after the stream was closed. </exception>
		/// <exception cref="T:System.NotSupportedException">The current Stream implementation does not support the read operation. </exception>
		/// <returns>An <see cref="T:System.IAsyncResult"/> that represents the asynchronous read, which could still be pending.</returns>
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Reliability", "CA2000:Dispose objects before losing scope",
			Justification = "'result' is used asynchronously")]
#if NET_4_5
		[Obsolete("Prefer Stream.ReadAsync")]
#endif
		public static IAsyncResult BeginReadToEnd(this Stream stream, byte[] buffer, int offset, int count, AsyncCallback callback, Object state)
		{
			if (stream == null) throw new ArgumentNullException("stream");
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
		/// <param name="stream">The stream for which this extension method acts upon.</param>
		/// <param name="buffer">The buffer to read the data into. </param>
		/// <param name="offset">The byte offset in <paramref name="buffer"/> at which to begin writing data read from the stream. </param>
		/// <param name="count">The maximum number of bytes to read. </param>
		/// <param name="callback">An optional asynchronous callback, to be called when the read is complete. </param>
		/// <exception cref="T:System.IO.IOException">Attempted an asynchronous read past the end of the stream, or a disk error occurs. </exception>
		/// <exception cref="T:System.ArgumentException">One or more of the arguments is invalid. </exception>
		/// <exception cref="T:System.ObjectDisposedException">Methods were called after the stream was closed. </exception>
		/// <exception cref="T:System.NotSupportedException">The current Stream implementation does not support the read operation. </exception>
#if NET_4_5
		[Obsolete("Prefer Stream.ReadAsync")]
#endif
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
		/// <param name="stream">The stream for which this extension method acts upon.</param>
		/// <param name="buffer">The buffer to read the data into. </param>
		/// <param name="callback">An optional asynchronous callback, to be called when the read is complete. </param>
		/// <exception cref="T:System.IO.IOException">Attempted an asynchronous read past the end of the stream, or a disk error occurs. </exception>
		/// <exception cref="T:System.ArgumentException">One or more of the arguments is invalid. </exception>
		/// <exception cref="T:System.ObjectDisposedException">Methods were called after the stream was closed. </exception>
		/// <exception cref="T:System.NotSupportedException">The current Stream implementation does not support the read operation. </exception>
		/// <returns>An <see cref="T:System.IAsyncResult"/> that represents the asynchronous read, which could still be pending.</returns>
#if NET_4_5
		[Obsolete("Prefer Stream.ReadAsync")]
#endif
		public static IAsyncResult BeginReadToEnd(this Stream stream, byte[] buffer, AsyncCallback callback)
		{
			return stream.BeginReadToEnd(buffer, 0, buffer.Length, callback, null);
		}

		/// <summary>
		/// The Asynchronous Programming Model matching End method to the corresponding BeginReadToEnd methods.
		/// </summary>
		/// <param name="stream"></param>
		/// <param name="ar">The reference to the pending asynchronous request to finish. </param><exception cref="T:System.ArgumentNullException"><paramref name="asyncResult"/> is null. </exception><exception cref="T:System.ArgumentException">A handle to the pending read operation is not available.-or-The pending operation does not support reading.</exception><exception cref="T:System.InvalidOperationException"><paramref name="asyncResult"/> did not originate from a <see cref="M:System.IO.Stream.BeginRead(System.Byte[],System.Int32,System.Int32,System.AsyncCallback,System.Object)"/> method on the current stream.</exception><exception cref="T:System.IO.IOException">The stream is closed or an internal error has occurred.</exception><filterpriority>2</filterpriority>
		/// <returns>
		/// The number of bytes read from the stream, between zero (0) and the number of bytes you requested. Streams return zero (0) only at the end of the stream, otherwise, they should block until at least one byte is available.
		/// </returns>
		/// <exception cref="T:System.ArgumentException">One or more of the arguments is invalid. </exception>
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA1801:ReviewUnusedParameters", MessageId = "stream", 
			Justification = "'stream' is required for this to be an extension method")]
#if NET_4_5
		[Obsolete("Prefer Stream.ReadAsync")]
#endif
		public static int EndReadToEnd(this Stream stream, IAsyncResult ar)
		{
			if (stream == null) throw new ArgumentNullException("stream");
			ByteArrayAsyncResult state = ar as ByteArrayAsyncResult;
			if (state == null) throw new InvalidOperationException();
			if(!state.IsCompleted)
				state.AsyncWaitHandle.WaitOne(-1);
			int endReadToEnd = state.Length;
			using (state)
			{
			}
			return endReadToEnd;
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
			private ManualResetEvent asyncWaitHandle;

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

				syncRoot = new object();
			}

			public object AsyncState { get; private set; }

			public WaitHandle AsyncWaitHandle
			{
				get
				{
					if(asyncWaitHandle != null)
						asyncWaitHandle = new ManualResetEvent(completed);
					return asyncWaitHandle;
				}
			}

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
				lock (syncRoot)
				{
					if (asyncWaitHandle != null)
					{
						((IDisposable)asyncWaitHandle).Dispose();
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
				if(asyncWaitHandle != null)
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

#if NET_4_5
		/// <summary>
		/// Extends WriteAsync so that buffer offset of 0 and call to Array.Length are not needed.
		/// <example>
		/// socket.WriteAsync(buffer);
		/// </example>
		/// </summary>
		public static Task WriteAsync(this Stream stream, byte[] buffer)
		{
			if (stream == null) throw new ArgumentNullException("stream");
			return stream.WriteAsync(buffer, 0, buffer.Length);
		}

		/// <summary>
		/// Extends ReadAsync so that buffer offset of 0 and call to Array.Length are not needed.
		/// <example>
		/// socket.ReadAsync(buffer);
		/// </example>
		/// </summary>
		public static Task<int> ReadAsync(this Stream stream, byte[] buffer)
		{
			if (stream == null) throw new ArgumentNullException("stream");
			return stream.ReadAsync(buffer, 0, buffer.Length);
		}
#endif

		/// <summary>
		/// Seek with default offset of 0.
		/// </summary>
		/// <param name="stream"><seealso cref="Stream"/> to operate on</param>
		/// <param name="seekOrigin"><seealso cref="SeekOrigin.Begin"/> to seek to start,
		/// <seealso cref="SeekOrigin.End"/> to seek to end, or <seealso cref="SeekOrigin.Current"/> to do nothing.</param>
		/// <returns></returns>
		public static long Seek(this Stream stream, SeekOrigin seekOrigin)
		{
			return stream.Seek(0, seekOrigin);
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