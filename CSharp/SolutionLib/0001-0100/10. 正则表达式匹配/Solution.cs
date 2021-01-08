namespace SolutionLib._10._正则表达式匹配
{
    public class Solution
    {
        public bool IsMatch(string s, string p)
        {
            int m = s.Length, n = p.Length;
            var dp = new bool[m + 1, n + 1];
            dp[0, 0] = true;
            for (int i = 0; i <= m; i++)
                for (int j = 1; j <= n; j++)
                    if (i == 0)
                        dp[i, j] = p[j - 1] == '*' && dp[i, j - 2];
                    else if (p[j - 1] != '*')
                        dp[i, j] = dp[i - 1, j - 1] && Match(s[i - 1], p[j - 1]);
                    else
                        dp[i, j] = dp[i, j - 2] || Match(s[i - 1], p[j - 2]) && dp[i - 1, j];
            return dp[m, n];
        }

        private bool Match(char sch, char pch)
        {
            return pch == '.' || sch == pch;
        }

    }
}