using System;

namespace SolutionLib._424._替换后的最长重复字符
{
    public class Solution_doublept
    {
        public int CharacterReplacement(string s, int k)
        {
            var num = new int[26];
            int n = s.Length, maxN = 0, left = 0, right = 0;
            while (right<n)
            {
                num[s[right] - 'A']++;
                maxN = Math.Max(maxN, num[s[right] - 'A']);
                if (right - left + 1 - maxN > k)
                {
                    num[s[left] - 'A']--;
                    left++;
                }
                right++;
            }
            return right - left;
        }
    }
}