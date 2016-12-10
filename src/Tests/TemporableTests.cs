using System;
using NUnit.Framework;
using PRI.ProductivityExtensions.TemporalExtensions;

namespace Tests
{
	[TestFixture]
	public class TemporableTests
	{
		[Test]
		public void EndOfDayHasCorrectResult()
		{
			DateTime dateTime = new DateTime(1970, 11, 5, 12, 30, 20);
			var actual = dateTime.EndOfDay();
			Assert.AreEqual(dateTime.Date, actual.Date);
			Assert.AreEqual(dateTime.Day + 1, actual.AddSeconds(1).Day);
		}

		[Test]
		public void BeginningOfDayHasCorrectResult()
		{
			DateTime dateTime = new DateTime(1970, 11, 5, 12, 30, 20);
			var actual = dateTime.BeginningOfDay();
			Assert.AreEqual(dateTime.Date, actual.Date);
			Assert.AreEqual(dateTime.Day, actual.Add(new TimeSpan(0, 23, 59, 59)).Day);
			Assert.AreEqual(0, actual.Second);
			Assert.AreEqual(0, actual.Minute);
			Assert.AreEqual(0, actual.Hour);
		}

		[Test]
		public void FromHasCorrectResult()
		{
			DateTime dateTime = new DateTime(1970, 11, 5, 12, 30, 20);
			DateTime actual = new TimeSpan(1, 0, 0, 0).From(dateTime);
			Assert.AreEqual(dateTime.AddDays(1).Date, actual.Date);
			Assert.AreEqual(dateTime.Second, actual.Second);
			Assert.AreEqual(dateTime.Minute, actual.Minute);
			Assert.AreEqual(dateTime.Hour, actual.Hour);
		}

		[Test]
		public void SinceHasCorrectResult()
		{
			DateTime dateTime = new DateTime(1970, 11, 5, 12, 30, 20);
			DateTime actual = new TimeSpan(1, 0, 0, 0).Since(dateTime);
			Assert.AreEqual(dateTime.AddDays(1).Date, actual.Date);
			Assert.AreEqual(dateTime.Second, actual.Second);
			Assert.AreEqual(dateTime.Minute, actual.Minute);
			Assert.AreEqual(dateTime.Hour, actual.Hour);
		}

		[Test]
		public void YearsResultsInCorrectNumberOfDays()
		{
			TimeSpan actual = 10.Years();

			Assert.AreEqual(3650, actual.TotalDays);
		}

		[Test]
		public void MonthsResultsInCorrectNumberOfDays()
		{
			TimeSpan actual = 10.Months();

			Assert.AreEqual(300, actual.TotalDays);
		}

		[Test]
		public void DaysResultsInCorrectNumberOfDays()
		{
			TimeSpan actual = 10.Days();

			Assert.AreEqual(10, actual.TotalDays);
		}

		[Test]
		public void HoursResultsInCorrectNumberOfHours()
		{
			TimeSpan actual = 10.Hours();

			Assert.AreEqual(10, actual.TotalHours);
		}

		[Test]
		public void MinutesResultsInCorrectNumberOfMinutes()
		{
			TimeSpan actual = 10.Minutes();

			Assert.AreEqual(10, actual.TotalMinutes);
		}

		[Test]
		public void SecondsResultsInCorrectNumberOfSeconds()
		{
			TimeSpan actual = 10.Seconds();

			Assert.AreEqual(10, actual.TotalSeconds);
		}

		[Test]
		public void SecondResultsInCorrectNumberOfSeconds()
		{
			TimeSpan actual = 1.Second();

			Assert.AreEqual(1, actual.TotalSeconds);
		}

		[Test]
		public void SecondWithValueOtherThan1ResultsInException()
		{
			Assert.Throws<ArgumentOutOfRangeException>(() => 2.Second());
		}

		[Test]
		public void MillisecondsResultsInCorrectNumberOfMilliseconds()
		{
			TimeSpan actual = 1100.Milliseconds();

			Assert.AreEqual(1100, actual.TotalMilliseconds);
		}

		[Test]
		public void AgoResultsInCorrectDateTime()
		{
			DateTime expected = DateTime.Now.AddMinutes(-10);
			DateTime actual = new TimeSpan(0, 0, 10, 0).Ago();
			var timeSpan = actual - expected;
			Assert.IsTrue(timeSpan.TotalMilliseconds < 10);
		}

		[Test]
		public void DoubleResultsInTwiceTheTime()
		{
			var actual = new TimeSpan(0, 0, 10, 0).Double();
			Assert.AreEqual(20, actual.TotalMinutes);
		}

		[Test]
		public void RoundToHoursWorks()
		{
			var actual = new TimeSpan(0, 13, 25, 0).RoundToHours();

			Assert.AreEqual(13, actual.TotalHours);
		}

		[Test]
		public void RoundToMinutesWorks()
		{
			var actual = new TimeSpan(0, 13, 25, 17).RoundToMinutes();

			Assert.AreEqual(13 * 60 + 25, actual.TotalMinutes);
		}

		[Test]
		public void RoundToSecondsWorks()
		{
			var actual = new TimeSpan(0, 1, 1, 17, 333).RoundToSeconds();

			Assert.AreEqual(60 * 60 + 60 + 17, actual.TotalSeconds);
		}

		[Test]
		public void MillionWorks()
		{
			Assert.AreEqual(1000000, 1.Million());
		}

		[Test]
		public void ThousandWorks()
		{
			Assert.AreEqual(1000, 1.Thousand());
		}

		[Test]
		public void ToEnglishStringWorks()
		{
			string actual = new TimeSpan(1, 2, 3, 4).ToEnglishString();

			Assert.AreEqual("1 days and 2 hours", actual);
		}
	}
}