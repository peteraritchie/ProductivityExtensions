using System;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;

namespace PRI.ProductivityExtensions.TaskExtensions
{
	public static class Taskable
	{
		/// from: http://blogs.msdn.com/b/pfxteam/archive/2011/06/27/10179452.aspx
		/// <summary>
		/// Converts an executing task from a TAP implementation to another that can be used in an APM implementation
		/// </summary>
		/// <typeparam name="TResult">inferred type of the result</typeparam>
		/// <param name="task"><see cref="Task&lt;TResult&gt;"/> object that is executing</param>
		/// <param name="callback"><see cref="AsyncCallback"/> from the Begin* method.</param>
		/// <param name="state">Optional state</param>
		/// <example>
		/// static IAsyncResult BeginFoo(AsyncCallback callback, object state)
		/// {
		/// 	return FooAsync().ToApm(callback, state);
		/// }
		/// 
		/// static int EndFoo(IAsyncResult asyncResult) 
		/// { 
		///    return ((Task<int>)asyncResult).Result; 
		/// }
		/// </example>
		/// <returns>New task that can be cast to <see cref="IAsyncResult"/>.</returns>
		public static Task<TResult> ToApm<TResult>(this Task<TResult> task, AsyncCallback callback, object state)
		{
			if (task == null) throw new ArgumentNullException(nameof(task));
			var tcs = new TaskCompletionSource<TResult>(state);

			task.
				ContinueWith(
					_ =>
					{
						if (task.IsFaulted) tcs.TrySetException(task.Exception.InnerExceptions);
						else if (task.IsCanceled) tcs.TrySetCanceled();
						else tcs.TrySetResult(task.Result);

						if (callback != null) callback(tcs.Task);
					},
					CancellationToken.None, TaskContinuationOptions.None, TaskScheduler.Default);

			return tcs.Task;
		}

		/// from: http://blogs.msdn.com/b/pfxteam/archive/2011/06/27/10179452.aspx
		/// <summary>
		/// Converts an executing task from a TAP implementation to another that can be used in an APM implementation
		/// </summary>
		/// <param name="task"><see cref="Task&lt;TResult&gt;"/> object that is executing</param>
		/// <param name="callback"><see cref="AsyncCallback"/> from the Begin* method.</param>
		/// <param name="state">Optional state</param>
		/// <example>
		/// static IAsyncResult BeginFoo(AsyncCallback callback, object state)
		/// {
		/// 	return FooAsync().ToApm(callback, state);
		/// }
		/// 
		/// static void EndFoo(IAsyncResult asyncResult) 
		/// { 
		///    ((Task)asyncResult).Result; 
		/// }
		/// </example>
		/// <returns>New task that can be cast to <see cref="IAsyncResult"/>.</returns>
		public static Task ToApm(this Task task, AsyncCallback callback, object state)
		{
			if (task == null) throw new ArgumentNullException(nameof(task));
			var tcs = new TaskCompletionSource<object>(state);

			task.
				ContinueWith(
					_ =>
					{
						if (task.IsFaulted) tcs.TrySetException(task.Exception.InnerExceptions);
						else if (task.IsCanceled) tcs.TrySetCanceled();
						else tcs.TrySetResult(null);

						if (callback != null) callback(tcs.Task);
					},
					CancellationToken.None, TaskContinuationOptions.None, TaskScheduler.Default);

			return tcs.Task;
		}

#if NET_4_5
		public static ConfiguredTaskAwaitable ContinueOnTaskContext(this Task task)
		{
			return task.ConfigureAwait(continueOnCapturedContext: false);
		}
#endif // NET_4_5
	}
}