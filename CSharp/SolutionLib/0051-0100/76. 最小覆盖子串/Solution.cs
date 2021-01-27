using System.Collections.Generic;

namespace SolutionLib._76._最小覆盖子串
{
    public class Solution
    {
        public string MinWindow(string s, string t)
        {
            string res = "";

            return res;
        }
    }

    //超出时间限制
    public class _Solution
    {
        public string MinWindow(string s, string t)
        {
            string res = "";
            var dict = new Dictionary<char, int>();
            for (int i = 0; i < t.Length; i++)
                if (!dict.ContainsKey(t[i])) dict[t[i]] = 1;
                else dict[t[i]]++;
            for (int i = 0; i <= s.Length - t.Length; i++)
            {
                if (!dict.ContainsKey(s[i])) continue;
                var tmp = new Dictionary<char, int>(dict);
                int j = i;
                for (; j < s.Length && tmp.Keys.Count != 0; j++)
                {
                    if (!tmp.ContainsKey(s[j])) continue;
                    tmp[s[j]]--;
                    if (tmp[s[j]] == 0) tmp.Remove(s[j]);
                }
                if (tmp.Keys.Count != 0) continue;
                if (res == "" || res.Length > j - i)
                    res = s.Substring(i, j - i);
            }
            return res;
        }
    }
}