using System.Data;
using NUnit.Framework;
using PRI.ProductivityExtensions.DataColumnExcentions;

namespace Tests
{
	[TestFixture]
	public class DataColumnableTests
	{
		[Test]
		public void AddCorrectlyAddsNewColumn()
		{
			var sut = new DataTable();
			const string expectedValue = "My Column";
			sut.Columns.Add<string>(expectedValue);
			Assert.AreEqual(1, sut.Columns.Count);
			Assert.AreEqual(expectedValue, sut.Columns[0].ColumnName);
		}
	}
}