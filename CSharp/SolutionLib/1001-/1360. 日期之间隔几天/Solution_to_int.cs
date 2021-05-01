using System;

namespace SolutionLib._1360._日期之间隔几天
{
    public class Solution_to_int
    {
        public int DaysBetweenDates(string date1, string date2)
        {
            return Math.Abs(DateToInt(date1) - DateToInt(date2));
        }

        private int DateToInt(string date)
        {
            int y, m, d, ans = 0;
            GetDate(date, out y, out m, out d);
            ans += d - 1;
            m--;
            while (m > 0)
            {
                ans += GetMonth(y, m--);
            }
            ans += 365 * (y - 1971);
            ans += (y - 1) / 4 - 1971 / 4;
            ans -= (y - 1) / 100 - 1971 / 100;
            ans += (y - 1) / 400 - 1971 / 400;
            return ans;
        }

        private void GetDate(string date, out int y, out int m, out int d)
        {
            var split = date.Split('-');
            y = int.Parse(split[0]);
            m = int.Parse(split[1]);
            d = int.Parse(split[2]);
        }

        private int GetMonth(int y, int m)
        {
            switch (m)
            {
                case 1:
                case 3:
                case 5:
                case 7:
                case 8:
                case 10:
                case 12:
                    return 31;
                case 4:
                case 6:
                case 9:
                case 11:
                    return 30;
                case 2:
                    return IsLeapYear(y) ? 29 : 28;
            }
            return 0;
        }

        private bool IsLeapYear(int y)
        {
            return y % 4 == 0 && (y % 100 != 0 || y % 400 == 0);
        }
    }
}