using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using PRI.ProductivityExtensions.IEnumerableExtensions;

namespace Tests
{
	[TestFixture]
	public class when_testing_creating_multicast_delegates
	{
		[Test]
		public void then_null_action_collection_returns_nop()
		{
			List<Action<int>> coll = null;
			var action = coll.Sum();
			action(42);
		}

		[Test]
		public void then_empty_action_collection_returns_nop()
		{
			var coll = new List<Action<int>>();
			var action = coll.Sum();
			action(42);
		}

		[Test]
		public void then_null_func_collection_throws()
		{
			List<Func<int, int>> coll = null;
			Assert.Throws<ArgumentException>(()=>coll.Sum());
		}

		[Test]
		public void then_empty_func_collection_throws()
		{
			var coll = new List< Func<int, int>>();
			Assert.Throws<ArgumentException>(() => coll.Sum());
		}

		[Test]
		public void then_action_collection_of_one_returns_correct_delegate()
		{
			int p = 0;
			var coll = new List<Action<int>> {x=>p=x};
			var action = coll.Sum();
			action(42);
			Assert.AreEqual(42, p);
		}

		[Test]
		public void then_action_collection_of_multiples_returns_correct_delegate()
		{
			var parameters = new List<int>();
			var coll = new List<Action<int>> {x => parameters.Add(x), y => parameters.Add(y) };
			var action = coll.Sum();
			action(21);
			Assert.AreEqual(2, parameters.Count);
			Assert.IsTrue(parameters.All(e => e == 21));
		}

		[Test]
		public void then_func_collection_of_one_returns_correct_delegate()
		{
			int p = 0;
			var coll = new List<Func<int, int>> {x=>p=x};
			var action = coll.Sum();
			var result = action(42);
			Assert.AreEqual(42, p);
			Assert.AreEqual(42, result);
		}

		[Test]
		public void then_func_collection_of_multiples_returns_correct_delegate()
		{
			var parameters = new List<int>();
			var coll = new List<Func<int, int>>
			{
				x =>
				{
					parameters.Add(x);
					return x;
				},
				y =>
				{
					parameters.Add(y);
					return y;
				}
			};
			var action = coll.Sum();
			var result = action(21);
			Assert.AreEqual(2, parameters.Count);
			Assert.AreEqual(21, result);
			Assert.IsTrue(parameters.All(e => e == 21));
		}
	}
}