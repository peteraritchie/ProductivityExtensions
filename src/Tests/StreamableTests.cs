using System.IO;
using System.Text;
using System.Threading;
using NUnit.Framework;
using PRI.ProductivityExtensions.StreamExtensions;
using PRI.ProductivityExtensions.TemporalExtensions;

namespace Tests
{
	[TestFixture]
	public class StreamableTests
	{
		[Test]
		public void BeginReadToEndReadsCorrectly()
		{
			string data = new string('X', 1024);
			using (var s = new MemoryStream(Encoding.Unicode.GetBytes(data)))
			{
				byte[] buffer = new byte[2048];
				ManualResetEventSlim resetEvent = new ManualResetEventSlim();
				long bytesRead = -1;
				var a = s.BeginReadToEnd(buffer,
				                         ar =>
					                         {
						                         Interlocked.Exchange(ref bytesRead, s.EndReadToEnd(ar));
						                         resetEvent.Set();
					                         });

				Assert.IsTrue(resetEvent.Wait(10.Seconds()));
				Assert.AreEqual(2048, Interlocked.Read(ref bytesRead));
				Assert.AreEqual(data, Encoding.Unicode.GetString(buffer));
			}
		}
	}
}
 