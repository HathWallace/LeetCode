using System;

namespace SolutionLib._32._最长有效括号
{
    public class Solution_special
    {
        public int LongestValidParentheses(string s)
        {
            int ans = 0, open = 0, close = 0;
            for (int i = 0; i < s.Length; i++)
            {
                if (s[i] == '(') open++;
                else close++;
                if (open == close) ans = Math.Max(ans, open * 2);
                else if (open < close) open = close = 0;
            }
            open = close = 0;
            for (int i = s.Length - 1; i >= 0; i--)
            {
                if (s[i] == '(') open++;
                else close++;
                if (open == close) ans = Math.Max(ans, close * 2);
                else if (open > close) open = close = 0;
            }
            return ans;
        }
    }
}