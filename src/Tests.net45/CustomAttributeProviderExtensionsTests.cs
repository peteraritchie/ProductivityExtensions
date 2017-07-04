using NUnit.Framework;
using PRI.ProductivityExtensions.ReflectionExtensions;

namespace Tests
{
	[TestFixture]
	public class CustomAttributeProviderExtensionsTests
	{
		[Test]
		public void ContainsAttributeReturnsTrueForMethodThatHasAttributeApplied()
		{
			var mi = typeof (string).GetMethod("Equals", new [] {typeof(object)}) as System.Reflection.ICustomAttributeProvider;
			Assert.IsTrue(mi.ContainsAttribute("ReliabilityContractAttribute"));
		}
		[Test]
		public void ContainsAttributeReturnsTrueForMethodThatDoesNotHaveAttributeApplied()
		{
			var mi = typeof(string).GetMethod("Equals", new[] { typeof(object) });
			Assert.IsFalse(mi.ContainsAttribute("ObsoleteAttribute"));
		}
	}
}