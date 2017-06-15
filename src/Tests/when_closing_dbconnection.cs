using System.Data;
using NUnit.Framework;
using PRI.ProductivityExtensions.IDbConnectionExtensions;

namespace Tests
{
	[TestFixture]
	class when_closing_dbconnection
	{
		private class DbConnectionSpy: IDbConnection
		{
			public DbConnectionSpy()
			{
				State = ConnectionState.Closed;
			}

			public bool DisposeCalled { get; private set; }
			public void Dispose()
			{
				DisposeCalled = true;
			}

			public IDbTransaction BeginTransaction()
			{
				throw new System.NotImplementedException();
			}

			public IDbTransaction BeginTransaction(IsolationLevel il)
			{
				throw new System.NotImplementedException();
			}

			public void Close()
			{
				CloseCalled = true;
			}

			public bool CloseCalled { get; private set; }

			public void ChangeDatabase(string databaseName)
			{
				throw new System.NotImplementedException();
			}

			public IDbCommand CreateCommand()
			{
				throw new System.NotImplementedException();
			}

			public void Open()
			{
				throw new System.NotImplementedException();
			}

			public string ConnectionString
			{
				get { throw new System.NotImplementedException(); }
				set { throw new System.NotImplementedException(); }
			}

			public int ConnectionTimeout
			{
				get { throw new System.NotImplementedException(); }
			}

			public string Database
			{
				get { throw new System.NotImplementedException(); }
			}

			public ConnectionState State { get; set; }
		}

		[Test]
		public void then_already_closed_connection_is_not_closed()
		{
			var dbConnection = new DbConnectionSpy {State = ConnectionState.Closed};

			dbConnection.SafeClose();

			Assert.IsFalse(dbConnection.CloseCalled);
		}

		[Test]
		public void then_already_closed_connection_is_not_disposed()
		{
			var dbConnection = new DbConnectionSpy { State = ConnectionState.Closed };

			dbConnection.SafeClose();

			Assert.IsFalse(dbConnection.DisposeCalled);
		}

		[Test]
		public void then_open_connection_is_closed()
		{
			var dbConnection = new DbConnectionSpy { State = ConnectionState.Open };

			dbConnection.SafeClose();

			Assert.IsTrue(dbConnection.CloseCalled);
		}

		[Test]
		public void then_open_connection_is_not_disposed()
		{
			var dbConnection = new DbConnectionSpy { State = ConnectionState.Open };

			dbConnection.SafeClose();

			Assert.IsFalse(dbConnection.DisposeCalled);
		}

		[Test]
		public void then_open_connection_is_disposed_when_requested()
		{
			var dbConnection = new DbConnectionSpy { State = ConnectionState.Open };

			dbConnection.SafeClose(true);

			Assert.IsTrue(dbConnection.DisposeCalled);
		}

		[Test]
		public void then_already_closed_connection_is_disposed_when_requested()
		{
			var dbConnection = new DbConnectionSpy { State = ConnectionState.Closed };

			dbConnection.SafeClose(true);

			Assert.IsTrue(dbConnection.DisposeCalled);
		}
	}
}