using System;
using PRI.ProductivityExtensions.TemporalExtensions;
using Xunit;

namespace Tests.Core
{
	public class TemporableTests
	{
		[Fact]
		public void EndOfDayHasCorrectResult()
		{
			DateTime dateTime = new DateTime(1970, 11, 5, 12, 30, 20);
			var actual = dateTime.EndOfDay();
			Assert.Equal(dateTime.Date, actual.Date);
			Assert.Equal(dateTime.Day + 1, actual.AddSeconds(1).Day);
		}

		[Fact]
		public void BeginningOfDayHasCorrectResult()
		{
			DateTime dateTime = new DateTime(1970, 11, 5, 12, 30, 20);
			var actual = dateTime.BeginningOfDay();
			Assert.Equal(dateTime.Date, actual.Date);
			Assert.Equal(dateTime.Day, actual.Add(new TimeSpan(0, 23, 59, 59)).Day);
			Assert.Equal(0, actual.Second);
			Assert.Equal(0, actual.Minute);
			Assert.Equal(0, actual.Hour);
		}

		[Fact]
		public void FromHasCorrectResult()
		{
			DateTime dateTime = new DateTime(1970, 11, 5, 12, 30, 20);
			DateTime actual = new TimeSpan(1, 0, 0, 0).From(dateTime);
			Assert.Equal(dateTime.AddDays(1).Date, actual.Date);
			Assert.Equal(dateTime.Second, actual.Second);
			Assert.Equal(dateTime.Minute, actual.Minute);
			Assert.Equal(dateTime.Hour, actual.Hour);
		}

		[Fact]
		public void SinceHasCorrectResult()
		{
			DateTime dateTime = new DateTime(1970, 11, 5, 12, 30, 20);
			DateTime actual = new TimeSpan(1, 0, 0, 0).Since(dateTime);
			Assert.Equal(dateTime.AddDays(1).Date, actual.Date);
			Assert.Equal(dateTime.Second, actual.Second);
			Assert.Equal(dateTime.Minute, actual.Minute);
			Assert.Equal(dateTime.Hour, actual.Hour);
		}

		[Fact]
		public void YearsResultsInCorrectNumberOfDays()
		{
			TimeSpan actual = 10.Years();

			Assert.Equal(3650, actual.TotalDays);
		}

		[Fact]
		public void MonthsResultsInCorrectNumberOfDays()
		{
			TimeSpan actual = 10.Months();

			Assert.Equal(300, actual.TotalDays);
		}

		[Fact]
		public void DaysResultsInCorrectNumberOfDays()
		{
			TimeSpan actual = 10.Days();

			Assert.Equal(10, actual.TotalDays);
		}

		[Fact]
		public void HoursResultsInCorrectNumberOfHours()
		{
			TimeSpan actual = 10.Hours();

			Assert.Equal(10, actual.TotalHours);
		}

		[Fact]
		public void MinutesResultsInCorrectNumberOfMinutes()
		{
			TimeSpan actual = 10.Minutes();

			Assert.Equal(10, actual.TotalMinutes);
		}

		[Fact]
		public void SecondsResultsInCorrectNumberOfSeconds()
		{
			TimeSpan actual = 10.Seconds();

			Assert.Equal(10, actual.TotalSeconds);
		}

		[Fact]
		public void SecondResultsInCorrectNumberOfSeconds()
		{
			TimeSpan actual = 1.Second();

			Assert.Equal(1, actual.TotalSeconds);
		}

		[Fact]
		public void SecondWithValueOtherThan1ResultsInException()
		{
			Assert.Throws<ArgumentOutOfRangeException>(() => { TimeSpan actual = 2.Second(); });
		}

		[Fact]
		public void MillisecondsResultsInCorrectNumberOfMilliseconds()
		{
			TimeSpan actual = 1100.Milliseconds();

			Assert.Equal(1100, actual.TotalMilliseconds);
		}

		[Fact]
		public void AgoResultsInCorrectDateTime()
		{
			var dateTime = DateTime.Now;
			DateTime expected = dateTime.AddMinutes(-10);
			DateTime actual = new TimeSpan(0, 0, 10, 0).Ago(dateTime);
			Assert.Equal(expected.AddMilliseconds(-expected.Millisecond), actual.AddMilliseconds(-actual.Millisecond));
		}

		[Fact]
		public void DoubleResultsInTwiceTheTime()
		{
			var actual = new TimeSpan(0, 0, 10, 0).Double();
			Assert.Equal(20, actual.TotalMinutes);
		}

		[Fact]
		public void RoundToHoursWorks()
		{
			var actual = new TimeSpan(0, 13, 25, 0).RoundToHours();

			Assert.Equal(13, actual.TotalHours);
		}

		[Fact]
		public void RoundToMinutesWorks()
		{
			var actual = new TimeSpan(0, 13, 25, 17).RoundToMinutes();

			Assert.Equal((13 * 60) + 25, actual.TotalMinutes);
		}

		[Fact]
		public void RoundToSecondsWorks()
		{
			var actual = new TimeSpan(0, 1, 1, 17, 333).RoundToSeconds();

			Assert.Equal((60 * 60) + 60 + 17, actual.TotalSeconds);
		}

		[Fact]
		public void MillionWorks()
		{
			Assert.Equal(1000000, 1.Million());
		}

		[Fact]
		public void ThousandWorks()
		{
			Assert.Equal(1000, 1.Thousand());
		}

		[Fact]
		public void ToEnglishStringWorks()
		{
			string actual = new TimeSpan(1, 2, 3, 4).ToEnglishString();

			Assert.Equal("1 days and 2 hours", actual);
		}

		[Fact]
		public void ToSortableDateWorksWithOneDigitDay()
		{
			string actual = new DateTime(1999, 5, 5, 1, 2, 3).ToSortableDate();

			Assert.Equal("1999-05-05", actual);
		}

		[Fact]
		public void ToSortableDateWorksWithTwoDigitDay()
		{
			string actual = new DateTime(1999, 5, 31, 1, 2, 3).ToSortableDate();

			Assert.Equal("1999-05-31", actual);
		}

		[Fact]
		public void ToSortableDateWorksWithTwoDigitMonth()
		{
			string actual = new DateTime(1999, 11, 30, 1, 2, 3).ToSortableDate();

			Assert.Equal("1999-11-30", actual);
		}
	}
}
