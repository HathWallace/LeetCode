using System;

namespace SolutionLib._72._编辑距离
{
    public class Solution
    {
        public int MinDistance(string word1, string word2)
        {
            var dp = new int[word1.Length + 1, word2.Length + 1];
            for (int i = 0; i <= word1.Length; i++)
                for (int j = 0; j <= word2.Length; j++)
                    if (i == 0 || j == 0)
                        dp[i, j] = Math.Max(i, j);
                    else if (word1[i - 1] == word2[j - 1])
                        dp[i, j] = dp[i - 1, j - 1];
                    else
                        dp[i, j] = Math.Min(Math.Min(dp[i - 1, j], dp[i, j - 1]), dp[i - 1, j - 1]) + 1;
            return dp[word1.Length, word2.Length];
        }
    }
}