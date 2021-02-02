using System.Collections.Generic;
using System.Text;

namespace SolutionLib._139._单词拆分
{
    public class Solution
    {
        public bool WordBreak(string s, IList<string> wordDict)
        {
            var sb = new StringBuilder(s);
            int slen = sb.Length;
            var dp = new bool[slen];
            var set = new HashSet<string>();
            foreach (var word in wordDict)
                set.Add(word);
            for (int i = 0; i < slen; i++)
            {
                if (set.Contains(sb.ToString(0, i + 1)))
                {
                    dp[i] = true;
                    continue;
                }
                for (int j = 0; j < i; j++)
                {
                    if (dp[j] && set.Contains(sb.ToString(j + 1, i - j)))
                    {
                        dp[i] = true;
                        break;
                    }
                }
            }
            return dp[slen - 1];
        }
    }

    //超出时间限制
    public class _Solution
    {
        Dictionary<string, bool> dp = new Dictionary<string, bool>();

        public bool WordBreak(string s, IList<string> wordDict)
        {
            var set = new HashSet<string>();
            foreach (var word in wordDict)
                set.Add(word);
            return WordBreak(s, set);
        }

        private bool WordBreak(string s, HashSet<string> set)
        {
            if (dp.ContainsKey(s)) return dp[s];
            if (set.Contains(s)) return dp[s] = true;
            for (int i = 1; i <= s.Length - 1; i++)
                if (WordBreak(s.Substring(0, i), set) && WordBreak(s.Substring(i, s.Length - i), set))
                    return dp[s] = true;
            return dp[s] = false;
        }


    }

}