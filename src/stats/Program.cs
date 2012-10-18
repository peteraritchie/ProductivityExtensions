using System;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Xml.XPath;
using System.Xml.Xsl;
using PRI.ProductivityExtensions.ReflectionExtensions;

namespace stats
{
	class Program
	{
		static void Main(string[] args)
		{
			if(args.Length > 1)
			{
				GenerateDocs();
				return;
			}
			int mTally = 0;
			int cTally = 0;
			foreach (var extensionMethodCount in from type in typeof(Typeable).Assembly.GetTypes() where type.IsPublic && type.IsStatic() select type.GetMethods(BindingFlags.Static | BindingFlags.Public).Count(
				method => method.ContainsAttribute("ExtensionAttribute")))
			{
				if (extensionMethodCount > 0) cTally++;
				mTally += extensionMethodCount;
			}

			Console.WriteLine("{0} classes, {1} methods.", cTally, mTally);

			mTally = 0;
			cTally = 0;
			foreach (var extensionMethodCount in from type in Assembly.LoadFrom(@"..\..\..\geschikt.wp7\bin\release\geschikt.wp7.dll").GetTypes()
												 where type.IsPublic && type.IsStatic()
												 select type.GetMethods(BindingFlags.Static | BindingFlags.Public).Count(
													 method => method.ContainsAttribute("ExtensionAttribute")))
			{
				if (extensionMethodCount > 0) cTally++;
				mTally += extensionMethodCount;
			}

			Console.WriteLine("{0} classes, {1} methods.", cTally, mTally);
			Console.ReadLine();
		}

		private static void GenerateDocs()
		{
			XPathDocument myXPathDoc = new XPathDocument(@"..\..\..\geschikt\bin\release\ProductivityExtensions.XML");
			XslCompiledTransform myXslTrans = new XslCompiledTransform();
			myXslTrans.Load(@"..\..\..\geschikt\bin\release\visual-studio-xml-doc.xsl");
			using(var stream = new FileStream("doc.html", FileMode.Create, FileAccess.Write))//MemoryStream())
			{
				using(var writer = new StreamWriter(stream))
				{
					myXslTrans.Transform(myXPathDoc, null, writer);
				}
//				var text = Encoding.ASCII.GetString(stream.ToArray());
			}
		}
	}
}
