using System.Collections.Generic;

namespace SolutionLib._76._最小覆盖子串
{
    public class Solution_slidewindow
    {
        private Dictionary<char, int> ori = new Dictionary<char, int>();
        private Dictionary<char, int> cnt = new Dictionary<char, int>();

        public string MinWindow(string s, string t)
        {
            foreach (var ch in t)
                ori[ch] = ori.ContainsKey(ch) ? ori[ch] + 1 : 1;
            int l = 0, r = -1, slen = s.Length;
            int len = int.MaxValue, ansL = -1;
            while (r < slen)
            {
                r++;
                if (r < slen && ori.ContainsKey(s[r]))
                {
                    cnt[s[r]] = cnt.ContainsKey(s[r]) ? cnt[s[r]] + 1 : 1;
                }

                while (Check() && l <= r)
                {
                    if (r - l + 1 < len)
                    {
                        len = r - l + 1;
                        ansL = l;
                    }
                    if (ori.ContainsKey(s[l]))
                    {
                        cnt[s[l]] = cnt.ContainsKey(s[l]) ? cnt[s[l]] - 1 : -1;
                    }
                    l++;
                }
            }
            return len == int.MaxValue ? "" : s.Substring(ansL, len);
        }

        private bool Check()
        {
            foreach (var key in ori.Keys)
            {
                if (!cnt.ContainsKey(key) || cnt[key] < ori[key]) return false;
            }
            return true;
        }
    }
}