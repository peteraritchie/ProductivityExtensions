using System;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Tests
{
	[TestFixture]
	public class when_wrapping_task_with_apm
	{
		[Test]
		public void then_wait_before_end_results_in_completed_task()
		{
			//begin
			IAsyncResult asyncResult = Task.Factory.StartNew(() => { });
			// WaitOne before End
			asyncResult.AsyncWaitHandle.WaitOne();
			var task = (Task) asyncResult;
			//end
			Assert.IsTrue(task.IsCompleted);
		}

		[Test]
		public void then_end_results_in_completed_task()
		{
			//begin
			IAsyncResult asyncResult = Task.Factory.StartNew(() => { });
			//end
			var task = (Task)asyncResult;
			task.Wait();
			Assert.IsTrue(task.IsCompleted);
		}

		[Test]
		public void then_end_results_in_correct_value()
		{
			//begin
			IAsyncResult asyncResult = Task.Factory.StartNew(() => 42);
			//end
			var task = (Task<int>)asyncResult;
			Assert.AreEqual(42, task.Result);
		}
	}
}