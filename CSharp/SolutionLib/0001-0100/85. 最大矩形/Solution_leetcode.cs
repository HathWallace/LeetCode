//https://leetcode-cn.com/problems/maximal-rectangle/solution/zui-da-ju-xing-by-leetcode-solution-bjlu/

using System;

namespace SolutionLib._85._最大矩形
{
    public class Solution_leetcode
    {
        public int MaximalRectangle(char[][] matrix)
        {
            if (matrix.Length == 0) return 0;
            int m = matrix.Length, n = matrix[0].Length;
            var left = new int[m, n];
            int ret = 0;
            for (int i = 0; i < m; i++)
                for (int j = 0; j < n; j++)
                {
                    if (matrix[i][j] != '1')
                    {
                        left[i, j] = 0;
                        continue;
                    }
                    int w = left[i, j] = j == 0 ? 1 : left[i, j - 1] + 1;
                    for (int h = 1; h <= i + 1; h++)
                    {
                        w = Math.Min(w, left[i + 1 - h, j]);
                        if (w == 0 || ret >= w * (i + 1)) break;
                        ret = Math.Max(ret, w * h);
                    }
                }
            return ret;
        }
    }
}
