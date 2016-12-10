using System.Threading;
using System.Threading.Tasks;
using NUnit.Framework;
using PRI.ProductivityExtensions.TaskExtensions;

namespace Tests.net45
{
	[TestFixture]
	// ReSharper disable once InconsistentNaming
	public class when_configuring_await
	{
		[Test]
		public async Task then_continue_on_task_context_succeeds()
		{
			int threadId = Thread.CurrentThread.ManagedThreadId;
			// ReSharper disable once NotAccessedVariable
			int threadIdInTask = -1;

			var task = Task.Factory.StartNew(() =>
			{
				// keep the task running until await
				Thread.Sleep(100);
				threadIdInTask = Thread.CurrentThread.ManagedThreadId;
			}, TaskCreationOptions.LongRunning);
			await task.ContinueOnTaskContext();
			var threadIdAfterAwait = Thread.CurrentThread.ManagedThreadId;
			Assert.AreNotEqual(threadId, threadIdAfterAwait);
		}
	}
}