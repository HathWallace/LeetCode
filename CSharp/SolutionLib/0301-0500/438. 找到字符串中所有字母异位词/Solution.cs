using System.Collections.Generic;

namespace SolutionLib._438._找到字符串中所有字母异位词
{
    public class Solution
    {
        public IList<int> FindAnagrams(string s, string p)
        {
            var res = new List<int>();
            int slen = s.Length, plen = p.Length, vaild = 0;
            var need = new Dictionary<char, int>();
            var window = new Dictionary<char, int>();
            foreach (var ch in p)
            {
                if (!need.ContainsKey(ch)) need[ch] = 0;
                need[ch]++;
            }
            for (int i = 0; i < slen; i++)
            {
                char rch = s[i];
                if (need.ContainsKey(rch))
                {
                    if (!window.ContainsKey(rch)) window[rch] = 0;
                    window[rch]++;
                    if (window[rch] == need[rch]) vaild++;
                }
                if (i >= plen && need.ContainsKey(s[i - plen]))
                {
                    char lch = s[i - plen];
                    if (window[lch] == need[lch]) vaild--;
                    window[lch]--;
                }
                if (vaild == need.Count) res.Add(i - plen + 1);
            }
            return res;
        }
    }
}