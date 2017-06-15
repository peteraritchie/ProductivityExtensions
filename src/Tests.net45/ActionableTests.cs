using System;
using System.IO;
using System.Text;
using NUnit.Framework;
using PRI.ProductivityExtensions.ActionExtensions;

	namespace Tests
{
	[TestFixture]
	public class ActionableTests
	{
		[Test]
		public void ActionSumWorks()
		{
			Action<TextWriter> a1 = (tw) => { tw.Write("1"); };
			Action<TextWriter> a2 = (tw) => { tw.Write("2"); };
			var mcd = new[] {a1, a2}.Sum();
			MemoryStream memoryStream = new MemoryStream();
			using (TextWriter tw = new StreamWriter(memoryStream))
			{
				mcd(tw);
			}
			var text = Encoding.UTF8.GetString(memoryStream.ToArray());
			Assert.AreEqual("12", text);
		}
	}
}