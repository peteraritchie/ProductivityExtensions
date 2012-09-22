using System;
using System.Linq;
using System.Reflection;
using PRI.ProductivityExtensions.ReflectionExtensions;

namespace stats
{
	class Program
	{
		static void Main(string[] args)
		{
			int mTally = 0;
			int cTally = 0;
			foreach (var extensionMethodCount in from type in typeof(Typeable).Assembly.GetTypes() where type.IsPublic && type.IsStatic() select type.GetMethods(BindingFlags.Static | BindingFlags.Public).Count(
				method => method.ContainsAttribute("ExtensionAttribute")))
			{
				if (extensionMethodCount > 0) cTally++;
				mTally += extensionMethodCount;
			}

			Console.WriteLine("{0} classes, {1} methods.", cTally, mTally);
			Console.ReadLine();
		}
	}
}
