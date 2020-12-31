//https://leetcode-cn.com/problems/non-overlapping-intervals/solution/wu-zhong-die-qu-jian-by-leetcode-solutio-cpsb/
using System;

namespace SolutionLib._435._无重叠区间
{
    public class Solution_greedy
    {
        public int EraseOverlapIntervals(int[][] intervals)
        {
            if (intervals.Length == 0) return 0;
            Array.Sort(intervals, (interval1, interval2) =>
            {
                return interval1[1] - interval2[1];
            });
            int right = intervals[0][1];
            int ans = 1;
            for (int i = 1; i < intervals.Length; i++)
                if (intervals[i][0] >= right)
                {
                    ans++;
                    right = intervals[i][1];
                }
            return intervals.Length - ans;
        }
    }
}