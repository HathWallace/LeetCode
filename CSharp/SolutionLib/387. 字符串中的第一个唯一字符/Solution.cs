using System.Collections.Generic;

namespace SolutionLib._387._字符串中的第一个唯一字符
{
    public class Solution
    {
        public int FirstUniqChar(string s)
        {
            var dict = new Dictionary<char, int>();
            foreach (var ch in s)
            {
                if (!dict.ContainsKey(ch)) dict[ch] = 1;
                else dict[ch]++;
            }
            for (int i = 0; i < s.Length; i++)
                if (dict[s[i]] == 1) return i;

            return -1;
        }
    }
}
