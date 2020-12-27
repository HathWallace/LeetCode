using System.Collections.Generic;

namespace SolutionLib._205._同构字符串
{
    public class Solution
    {
        public bool IsIsomorphic(string s, string t)
        {
            if (s.Length != t.Length) return false;
            var dicts = new Dictionary<char, int>();
            var dictt = new Dictionary<char, int>();
            for (int i = 0; i < s.Length; i++)
            {
                if (!dicts.ContainsKey(s[i]) && !dictt.ContainsKey(t[i]))
                {
                    dicts[s[i]] = s[i] - t[i];
                    dictt[t[i]] = t[i] - s[i];
                }
                else if (!dicts.ContainsKey(s[i]) || !dictt.ContainsKey(t[i]) || dicts[s[i]] != s[i] - t[i] || dictt[t[i]] != t[i] - s[i])
                    return false;
            }
            return true;
        }
    }
}