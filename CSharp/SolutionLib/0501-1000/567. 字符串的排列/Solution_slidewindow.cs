using System.Collections.Generic;

namespace SolutionLib._567._字符串的排列
{
    public class Solution_slidewindow
    {
        public bool CheckInclusion(string s1, string s2)
        {
            var need = new Dictionary<char, int>();
            foreach (var ch in s1)
            {
                if (!need.ContainsKey(ch)) need[ch] = 0;
                need[ch]++;
            }
            int s1len = s1.Length, s2len = s2.Length, vaild = 0, vaild0 = need.Count;
            var window = new Dictionary<char, int>();
            for (int i = 0; i < s2len; i++)
            {
                if (vaild == vaild0) return true;
                char rch = s2[i];
                if (need.ContainsKey(rch))
                {
                    if (!window.ContainsKey(rch)) window[rch] = 0;
                    window[rch]++;
                    if (window[rch] == need[rch]) vaild++;
                }
                if (i < s1len) continue;
                char lch = s2[i - s1len];
                if (need.ContainsKey(lch))
                {
                    if (window[lch] == need[lch]) vaild--;
                    window[lch]--;
                }
            }
            return vaild == vaild0;
        }
    }
}