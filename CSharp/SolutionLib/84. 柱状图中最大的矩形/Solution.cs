using System;

namespace SolutionLib._84._柱状图中最大的矩形
{
    public class Solution
    {
        public int LargestRectangleArea(int[] heights)
        {
            int ret = 0;
            for (int i = heights.Length - 1; i >= 0; i--)
            {
                int minH = int.MaxValue;
                for (int j = i; j >= 0; j--)
                {
                    minH = Math.Min(minH, heights[j]);
                    ret = Math.Max(ret, minH * (i - j + 1));
                }
            }
            return ret;
        }
    }
}