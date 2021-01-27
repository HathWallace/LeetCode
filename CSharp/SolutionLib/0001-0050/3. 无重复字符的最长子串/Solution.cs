using System;
using System.Collections.Generic;

namespace SolutionLib._3._无重复字符的最长子串
{
    public class Solution
    {
        public int LengthOfLongestSubstring(string s)
        {
            var set = new HashSet<char>();
            int ans = 0, l = 0, r = -1, slen = s.Length;
            while (r < slen)
            {
                r++;
                if (r >= slen || !set.Add(s[r]))
                {
                    ans = Math.Max(ans, set.Count);
                    if (r >= slen) break;
                    while (s[l] != s[r])
                        set.Remove(s[l++]);
                    l++;
                }
            }
            return ans;
        }
    }

    public class _Solution
    {
        public int LengthOfLongestSubstring(string s)
        {
            if (s == "") return 0;
            var dict = new Dictionary<char, int>();
            int ans = 0, l = 0, r = -1, slen = s.Length;
            while (r < slen)
            {
                r++;
                if (r < slen && !dict.ContainsKey(s[r]))
                    dict[s[r]] = r;
                else
                {
                    ans = Math.Max(ans, dict.Count);
                    if (r >= slen) break;
                    while (l < dict[s[r]])
                        dict.Remove(s[l++]);
                    l++;
                    dict[s[r]] = r;
                }
            }
            return ans;
        }
    }
}