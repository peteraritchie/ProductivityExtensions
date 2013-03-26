using System;
using System.Threading;
using System.Threading.Tasks;
using NUnit.Framework;
using PRI.ProductivityExtensions.TaskExtensions;

namespace Tests
{
	[TestFixture]
	public class when_wrapping_task_with_apm
	{
		[Test]
		public void then_wait_before_end_results_in_completed_task()
		{
			//begin
			IAsyncResult asyncResult = Task.Factory.StartNew(() => { }).ToApm(_ => { }, null);
			// WaitOne before End
			asyncResult.AsyncWaitHandle.WaitOne();
			var task = (Task) asyncResult;
			//end
			Assert.IsTrue(task.IsCompleted);
		}

		[Test]
		public void then_callback_is_invoked_on_different_thread()
		{
			int testThreadId = Thread.CurrentThread.ManagedThreadId;
			int callbackThreadId = -1;
			// begin
			IAsyncResult asyncResult =
				Task.Factory.StartNew(() => { }).ToApm(ar =>
					                                       {
						                                       callbackThreadId = Thread.CurrentThread.ManagedThreadId;
					                                       }, null);
			// End
			asyncResult.AsyncWaitHandle.WaitOne();
			Assert.AreNotEqual(testThreadId, callbackThreadId);
		}

		[Test]
		public void then_end_results_in_completed_task()
		{
			//begin
			IAsyncResult asyncResult = Task.Factory.StartNew(() => { }).ToApm(_ => { }, null);
			//end
			var task = (Task)asyncResult;
			task.Wait();
			Assert.IsTrue(task.IsCompleted);
		}

		[Test]
		public void then_end_results_in_correct_value()
		{
			//begin
			IAsyncResult asyncResult = Task.Factory.StartNew(() => 42).ToApm(_ => { }, null);
			//end
			var task = (Task<int>)asyncResult;
			Assert.AreEqual(42, task.Result);
		}
	}

}