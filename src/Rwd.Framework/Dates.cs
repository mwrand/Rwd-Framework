using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Rwd.Framework
{

    public static class Dates
    {

        private static DateTime currentDate = DateTime.Now;
        public static DateTime CurrentDate
        {
            get { return currentDate; }
            set { currentDate = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static DateTime Default
        {
            get
            {
                return new DateTime(1, 1, 1);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static bool IsDefault(DateTime? date)
        {
            if (date == null || date == Dates.Default)
                return true;
            else if (date == new DateTime(1800, 1, 1))
                return true;
            else if (date == new DateTime(1900, 1, 1))
                return true;
            else
                return false;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static bool IsNotDefault(DateTime? date)
        {
            return !Dates.IsDefault(date);
        }

        /// <summary>
        /// Returns date of given day of the current week
        /// </summary>
        /// <returns></returns>
        public static DateTime DayOfCurrentWeek(DayOfWeek day)
        {
            int diff = Dates.CurrentDate.DayOfWeek - day;
            if (diff < 0) { diff += 7; }
            return Dates.CurrentDate.AddDays(-1 * diff).Date;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="month"></param>
        /// <param name="year"></param>
        /// <returns></returns>
        public static DateTime GetFirstDateCurrentMonth()
        {
            return DateTime.Parse(Dates.CurrentDate.Month.ToString() + "/1/" + Dates.CurrentDate.Year.ToString());
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="month"></param>
        /// <param name="year"></param>
        /// <returns></returns>
        public static DateTime GetFirstDateOfMonth(int month, int year)
        {
            return DateTime.Parse(month.ToString() + "/1/" + year.ToString());
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="month"></param>
        /// <param name="year"></param>
        /// <returns></returns>
        public static DateTime GetFirstDayOfNextMonth(int month, int year)
        {
            var firstDayOfMonth = Dates.GetFirstDateOfMonth(month, year);
            return firstDayOfMonth.AddMonths(1);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="month"></param>
        /// <param name="year"></param>
        /// <returns></returns>
        public static DateTime GetFirstDayOfNextMonth(DateTime now)
        {
            return Dates.GetFirstDayOfNextMonth(now.Month, now.Year);
        }

        /// <summary>  
        /// Converts the given month int to month name  
        /// </summary>  
        ///<param name="month">month in</param>  
        /// <param name="abbrev">return abbreviated or not</param> 
        /// <returns>Short or long month name</returns>  
        public static string GetMonthName(int month, bool abbrev)
        {
            DateTime date = new DateTime(1900, month, 1);
            if (abbrev) return date.ToString("MMM");
            return date.ToString("MMMM");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="quarter"></param>
        /// <param name="year"></param>
        /// <returns></returns>
        public static DateRange GetDateRangeByQuarter(int fromQuarter, int toQuarter, int year)
        {
            var startDate = Dates.CurrentDate;
            var endDate = Dates.CurrentDate;

            switch (fromQuarter)
            {
                case 1:
                    startDate = DateTime.Parse("1/1/" + year.ToString());
                    break;
                case 2:
                    startDate = DateTime.Parse("4/1/" + year.ToString());
                    break;
                case 3:
                    startDate = DateTime.Parse("7/1/" + year.ToString());
                    break;
                case 4:
                    startDate = DateTime.Parse("10/1/" + year.ToString());
                    break;
            }

            switch (toQuarter)
            {
                case 1:
                    endDate = DateTime.Parse("3/31/" + year.ToString());
                    break;
                case 2:
                    endDate = DateTime.Parse("6/30/" + year.ToString());
                    break;
                case 3:
                    endDate = DateTime.Parse("9/30/" + year.ToString());
                    break;
                case 4:
                    endDate = DateTime.Parse("12/31/" + year.ToString());
                    break;
            }
            return new DateRange(startDate, endDate);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="quarter"></param>
        /// <param name="year"></param>
        /// <returns></returns>
        public static DateRange GetDateRangeByQuarter(string fromQuarter, string toQuarter, int year)
        {
            return GetDateRangeByQuarter(int.Parse(fromQuarter), int.Parse(toQuarter), year);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="quarter"></param>
        /// <param name="year"></param>
        /// <returns></returns>
        public static DateRange GetDateRangeByYear(string fromYear, string toYear)
        {
            return GetDateRangeByYear(int.Parse(fromYear), int.Parse(toYear));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="quarter"></param>
        /// <param name="year"></param>
        /// <returns></returns>
        public static DateRange GetDateRangeByYear(int fromYear, int toYear)
        {
            return new DateRange(DateTime.Parse("1/1/" + fromYear.ToString()), DateTime.Parse("12/31/" + toYear.ToString()));
        }       

        /// <summary>
        /// 
        /// </summary>
        /// <param name="quarter"></param>
        /// <returns></returns>
        public static List<int> GetMonthsInQuarter(int quarter)
        {
            var month = new List<int>();
            switch (quarter)
            {
                case 1:
                    month.Add(1);
                    month.Add(2);
                    month.Add(3);
                    break;
                case 2:
                    month.Add(4);
                    month.Add(5);
                    month.Add(6);
                    break;
                case 3:
                    month.Add(7);
                    month.Add(8);
                    month.Add(9);
                    break;
                case 4:
                    month.Add(10);
                    month.Add(11);
                    month.Add(12);
                    break;
            }
            return month;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="range"></param>
        /// <returns></returns>
        public static int GetQuarterByDate(DateTime date)
        {

            var quarter = 0;
            var m = date.Month;

            if (m == 1 || m == 2 || m == 3)
                quarter = 1;
            else if (m == 4 || m == 5 || m == 6)
                quarter = 2;
            else if (m == 7 || m == 8 || m == 9)
                quarter = 3;
            else if (m == 10 || m == 11 || m == 12)
                quarter = 4;

            return quarter;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="date"></param>
        /// <param name="dayOfWeek"></param>
        /// <returns></returns>
        public static List<DateTime> GetUniqueDaysOfWeekInAMonth(DateTime date, DayOfWeek dayOfWeek)
        {
            var dates = Enumerable.Range(1, DateTime.DaysInMonth(date.Year, date.Month))
                .Select(n => new DateTime(date.Year, date.Month, n));
            // then filter the only the start of weeks  
            return (from d in dates
                    where d.DayOfWeek == dayOfWeek
                    select d).ToList();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="range"></param>
        /// <returns></returns>
        public static List<DateTime> GetUniqueMonthsinDateRange(DateRange range)
        {
            var months = new List<DateTime>();

            if (range.StartDate != null && range.EndDate != null)
            {
                var lastMonth = ((DateTime)(range.EndDate)).Month;
                var currentMonth = ((DateTime)(range.StartDate)).Month;

                for (int m = currentMonth; m <= lastMonth; m++)
                    months.Add(DateTime.Parse(m + "/1/" + ((DateTime)(range.EndDate)).Year));
            }

            return months;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="range"></param>
        /// <returns></returns>
        public static List<int> GetUniqueQuartersinDateRange(DateRange range)
        {
            var quarters = new List<int>();

            if (range.StartDate != null && range.EndDate != null)
            {
                var lastMonth = ((DateTime)(range.EndDate)).Month;
                var currentMonth = ((DateTime)(range.StartDate)).Month;

                for (int m = currentMonth; m <= lastMonth; m++)
                {
                    int quarter = 0;
                    if (m == 1 || m == 2 || m == 3)
                        quarter = 1;
                    else if (m == 4 || m == 5 || m == 6)
                        quarter = 2;
                    else if (m == 7 || m == 8 || m == 9)
                        quarter = 3;
                    else if (m == 10 || m == 11 || m == 12)
                        quarter = 4;

                    if (!quarters.Exists(n => n == quarter))
                        quarters.Add(quarter);
                }
            }

            return quarters;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="range"></param>
        /// <returns></returns>
        public static List<int> GetUniqueYearsinDateRange(DateRange range)
        {
            var years = new List<int>();

            if (range.StartDate != null && range.EndDate != null)
            {
                var lastYear = ((DateTime)(range.EndDate)).Year;
                var firstYear = ((DateTime)(range.StartDate)).Year;

                for (int y = firstYear; y <= lastYear; y++)
                    years.Add(y);
            }

            return years;
        }

    }

    public class DateRange : IEquatable<DateRange>
    {
        Nullable<DateTime> startDate, endDate;
        public DateRange() : this(new Nullable<DateTime>(), new Nullable<DateTime>()) { }
        public DateRange(Nullable<DateTime> startDate, Nullable<DateTime> endDate)
        {
            AssertStartDateFollowsEndDate(startDate, endDate);
            this.startDate = startDate;
            this.endDate = endDate;
        }
        public DateRange(string strStartDate, string strEndDate)
        {
            DateTime? startDate = null;
            DateTime? endDate = null;
            if (strStartDate.Length > 0) startDate = DateTime.Parse(strStartDate);
            if (strEndDate.Length > 0) endDate = DateTime.Parse(strEndDate);

            AssertStartDateFollowsEndDate(startDate, endDate);
            this.startDate = startDate;
            this.endDate = endDate;
        }

        public Nullable<TimeSpan> TimeSpan
        {
            get { return endDate - startDate; }
        }
        public Nullable<DateTime> StartDate
        {
            get { return startDate; }
            set
            {
                AssertStartDateFollowsEndDate(value, this.endDate);
                startDate = value;
            }
        }
        public Nullable<DateTime> EndDate
        {
            get { return endDate; }
            set
            {
                AssertStartDateFollowsEndDate(this.startDate, value);
                endDate = value;
            }
        }
        private void AssertStartDateFollowsEndDate(Nullable<DateTime> startDate,
            Nullable<DateTime> endDate)
        {
            if ((startDate.HasValue && endDate.HasValue) &&
                (endDate.Value < startDate.Value))
                throw new InvalidOperationException("Start Date must be less than or equal to End Date");
        }
        public DateRange GetIntersection(DateRange other)
        {
            if (!Intersects(other)) throw new InvalidOperationException("DateRanges do not intersect");
            return new DateRange(GetLaterStartDate(other.StartDate), GetEarlierEndDate(other.EndDate));
        }
        private Nullable<DateTime> GetLaterStartDate(Nullable<DateTime> other)
        {
            return Nullable.Compare<DateTime>(startDate, other) >= 0 ? startDate : other;
        }
        private Nullable<DateTime> GetEarlierEndDate(Nullable<DateTime> other)
        {
            //!endDate.HasValue == +infinity, not negative infinity
            //as is the case with !startDate.HasValue
            if (Nullable.Compare<DateTime>(endDate, other) == 0) return other;
            if (endDate.HasValue && !other.HasValue) return endDate;
            if (!endDate.HasValue && other.HasValue) return other;
            return (Nullable.Compare<DateTime>(endDate, other) >= 0) ? other : endDate;
        }
        public bool Intersects(DateRange other)
        {
            if ((this.startDate.HasValue && other.EndDate.HasValue &&
                other.EndDate.Value < this.startDate.Value) ||
                (this.endDate.HasValue && other.StartDate.HasValue &&
                other.StartDate.Value > this.endDate.Value) ||
                (other.StartDate.HasValue && this.endDate.HasValue &&
                this.endDate.Value < other.StartDate.Value) ||
                (other.EndDate.HasValue && this.startDate.HasValue &&
                this.startDate.Value > other.EndDate.Value))
            {
                return false;
            }
            return true;
        }
        public bool Equals(DateRange other)
        {
            if (object.ReferenceEquals(other, null)) return false;
            return ((startDate == other.StartDate) && (endDate == other.EndDate));
        }
    }

    public class DateRangeComparerByStartDate : System.Collections.IComparer,
    System.Collections.Generic.IComparer<DateRange>
    {
        public int Compare(object x, object y)
        {
            if (!(x is DateRange) || !(y is DateRange))
                throw new System.ArgumentException("Value not a DateRange");
            return Compare((DateRange)x, (DateRange)y);
        }
        public int Compare(DateRange x, DateRange y)
        {
            if (x.StartDate < y.StartDate) { return -1; }
            if (x.StartDate > y.StartDate) { return 1; }
            return 0;
        }
    }

}
