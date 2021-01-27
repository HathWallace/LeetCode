using System;

namespace SolutionLib._64._最小路径和
{
    public class Solution
    {
        public int MinPathSum(int[][] grid)
        {
            int m = grid.Length, n = grid[0].Length;
            var dp = new int[m, n];
            dp[0, 0] = grid[0][0];
            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (i == 0 && j == 0) continue;
                    dp[i, j] = int.MaxValue;
                    if (i != 0)
                        dp[i, j] = Math.Min(dp[i, j], dp[i - 1, j] + grid[i][j]);
                    if (j != 0)
                        dp[i, j] = Math.Min(dp[i, j], dp[i, j - 1] + grid[i][j]);

                }
            }
            return dp[m - 1, n - 1];
        }
    }
}