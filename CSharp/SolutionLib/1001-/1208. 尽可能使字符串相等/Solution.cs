using System;

namespace SolutionLib._1208._尽可能使字符串相等
{
    public class Solution
    {
        public int EqualSubstring(string s, string t, int maxCost)
        {
            int left = 0, right = 0, slen = s.Length, cost = 0;
            while (right < slen)
            {
                cost += Math.Abs(s[right] - t[right]);
                if (cost > maxCost)
                {
                    cost -= Math.Abs(s[left] - t[left]);
                    left++;
                }
                right++;
            }
            return right - left;
        }
    }
}