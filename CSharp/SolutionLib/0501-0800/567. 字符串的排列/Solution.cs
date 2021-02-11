using System.Collections.Generic;

namespace SolutionLib._567._字符串的排列
{
    //解答错误
    public class Solution
    {
        public bool CheckInclusion(string s1, string s2)
        {
            var need = new Dictionary<char, int>();
            foreach (var ch in s1)
            {
                if (!need.ContainsKey(ch)) need[ch] = 0;
                need[ch]++;
            }
            int left = 0, right = 0, vaild = 0, slen = s2.Length, vaild0 = need.Count, redundance = 0;
            var window = new Dictionary<char, int>();
            while (right < slen)
            {
                char rch = s2[right++];
                if (!need.ContainsKey(rch))
                {
                    window.Clear();
                    vaild = 0;
                    left = right;
                    continue;
                }
                if (!window.ContainsKey(rch)) window[rch] = 0;
                window[rch]++;
                if (window[rch] == need[rch]) vaild++;
                if (window[rch] == need[rch] + 1) redundance++;
                while (vaild >= vaild0)
                {
                    char lch = s2[left];
                    if (window[lch] == need[lch]) break;
                    left++;
                    window[lch]--;
                    if (window[lch] == need[lch]) redundance--;
                }
                if (vaild >= vaild0 && redundance == 0) return true;
            }
            return false;
        }
    }
}