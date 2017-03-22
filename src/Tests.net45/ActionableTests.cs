using System;
using System.Collections.Generic;
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
			var mcd = new [] {a1, a2}.Sum();
			string text;
			using (MemoryStream memoryStream = new MemoryStream())
			{
				using (TextWriter tw = new StreamWriter(memoryStream))
				{
					mcd(tw);
				}
				text = Encoding.UTF8.GetString(memoryStream.ToArray());
			}
			Assert.AreEqual("12", text);
		}
	}
}