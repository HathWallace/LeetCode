using System;
using System.Collections.Generic;
using System.Threading;

namespace SolutionLib._56._合并区间
{
    public class Solution
    {
        public int[][] Merge(int[][] intervals)
        {
            var res = new List<int[]>();
            int n = intervals.Length;
            if (n == 0) return res.ToArray();
            Array.Sort(intervals, (a, b) =>
            {
                if (a[0] != b[0]) return a[0].CompareTo(b[0]);
                return b[1].CompareTo(a[1]);
            });
            var tmp = intervals[0];
            res.Add(tmp);
            for (int i = 1; i < n; i++)
            {
                if (Overlap(tmp, intervals[i]))
                    Merge(tmp, intervals[i]);
                else
                {
                    tmp = intervals[i];
                    res.Add(tmp);
                }
            }
            return res.ToArray();
        }

        private void Merge(int[] tmp, int[] interval)
        {
            tmp[0] = Math.Min(tmp[0], interval[0]);
            tmp[1] = Math.Max(tmp[1], interval[1]);
        }

        private bool Overlap(int[] tmp, int[] interval)
        {
            return tmp[1] >= interval[0];
        }

    }
}