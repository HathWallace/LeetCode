using System;

namespace SolutionLib._32._最长有效括号
{
    //定义dp[i]表示以下标i字符结尾的最长有效括号的长度
    public class Solution_dp
    {
        public int LongestValidParentheses(string s)
        {
            int ans = 0;
            var dp = new int[s.Length];
            for (int i = 1; i < s.Length; i++)
            {
                if (s[i] == '(') continue;
                if (s[i - 1] == '(')
                    dp[i] = i >= 2 ? dp[i - 2] + 2 : 2;
                else
                {
                    int pt = i - dp[i - 1] - 1;
                    if (pt >= 0 && s[pt] == '(')
                        dp[i] = i - pt + 1 + (pt > 0 ? dp[pt - 1] : 0);
                }
                ans = Math.Max(ans, dp[i]);
            }
            return ans;
        }
    }

}