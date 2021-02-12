using System;
using System.Collections.Generic;

namespace SolutionLib._1288._删除被覆盖区间
{
    public class Solution
    {
        public int RemoveCoveredIntervals(int[][] intervals)
        {
            int ans = 1, n = intervals.Length;
            if (n == 0) return 0;
            Array.Sort(intervals, (a, b) =>
            {
                if (a[0] != b[0]) return a[0].CompareTo(b[0]);
                return b[1].CompareTo(a[1]);
            });
            var tmp = intervals[0];
            for (int i = 1; i < n; i++)
            {
                if(Cover(tmp,intervals[i])) continue;
                ans++;
                tmp = intervals[i];
            }
            return ans;
        }

        private bool Cover(int[] tmp, int[] interval)
        {
            return tmp[0] <= interval[0] && tmp[1] >= interval[1];
        }
    }
}