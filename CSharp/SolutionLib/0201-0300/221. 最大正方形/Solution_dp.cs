using System;

namespace SolutionLib._221._最大正方形
{
    public class Solution_dp2
    {
        public int MaximalSquare(char[][] matrix)
        {
            int n = matrix.Length, m = matrix[0].Length, ans = 0;
            var dp = new int[m];
            for (int i = 0; i < n; i++)
            {
                int leftTop = 0;
                for (int j = 0; j < m; j++)
                {
                    int tmp = dp[j];
                    if (matrix[i][j] == '0')
                        dp[j] = 0;
                    else if (i == 0 || j == 0)
                        dp[j] = 1;
                    else
                        dp[j] = Math.Min(leftTop, Math.Min(dp[j], dp[j - 1])) + 1;
                    leftTop = tmp;
                    ans = Math.Max(ans, dp[j]);
                }
            }
            return ans * ans;
        }
    }

    public class Solution_dp
    {
        public int MaximalSquare(char[][] matrix)
        {
            int n = matrix.Length, m = matrix[0].Length, ans = 0;
            var dp = new int[n, m];
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    if (matrix[i][j] == '0') continue;
                    if (i == 0 || j == 0)
                        dp[i, j] = 1;
                    else
                        dp[i, j] = Math.Min(dp[i - 1, j - 1], Math.Min(dp[i - 1, j], dp[i, j - 1])) + 1;
                    ans = Math.Max(ans, dp[i, j]);
                }
            }
            return ans * ans;
        }
    }
}