using System;

namespace SolutionLib._1360._日期之间隔几天
{
    public class Solution
    {
        public int DaysBetweenDates(string date1, string date2)
        {
            if (date1.CompareTo(date2) > 0) return DaysBetweenDates(date2, date1);
            return (GetDateTime(date2) - GetDateTime(date1)).Days;
        }

        private DateTime GetDateTime(string date)
        {
            var split = date.Split('-');
            return new DateTime(int.Parse(split[0]), int.Parse(split[1]), int.Parse(split[2]));
        }
    }
}