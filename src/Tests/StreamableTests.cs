using System;
using System.ComponentModel;
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

				int bytesRead = -1;
				var a = s.BeginReadToEnd(buffer, ar =>
				                                 {
				                                 	bytesRead = s.EndReadToEnd(ar);
				                                 });
				bool finished = a.AsyncWaitHandle.WaitOne(10.Seconds());
				Assert.IsTrue(finished);
				Assert.AreEqual(2048, bytesRead);
				Assert.AreEqual(data, Encoding.Unicode.GetString(buffer));
			}
		}
	}
}
 