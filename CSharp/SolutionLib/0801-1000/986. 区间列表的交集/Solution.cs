using System;
using System.Collections.Generic;

namespace SolutionLib._986._区间列表的交集
{
    public class Solution
    {
        public int[][] IntervalIntersection(int[][] firstList, int[][] secondList)
        {
            var res = new List<int[]>();
            int i = 0, j = 0, n = firstList.Length, m = secondList.Length;
            if (n == 0 || m == 0) return res.ToArray();
            while (i < n && j < m)
            {
                int[] first = firstList[i], second = secondList[j];
                var tmp = Overlap(first, second);
                if (tmp != null) res.Add(tmp);
                if (j == m - 1 || first[1] < second[1]) i++;
                else if (i == n - 1 || first[1] > second[1]) j++;
                else
                {
                    i++;
                    j++;
                }
            }
            return res.ToArray();
        }

        private int[] Overlap(int[] inter1, int[] inter2)
        {
            var tmp = new[]
            {
                Math.Max(inter1[0], inter2[0]),
                Math.Min(inter1[1], inter2[1]),
            };
            return tmp[0] > tmp[1] ? null : tmp;
        }

    }
}