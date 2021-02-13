//https://leetcode-cn.com/problems/remove-duplicate-letters/solution/qu-chu-zhong-fu-zi-mu-by-leetcode-soluti-vuso/
using System.Text;

namespace SolutionLib._316._去除重复字母
{
    public class Solution_greedy
    {
        public string RemoveDuplicateLetters(string s)
        {
            var vis = new bool[26];
            var num = new int[26];
            for (int i = 0; i < s.Length; i++)
                num[s[i] - 'a']++;
            var sb = new StringBuilder();
            for (int i = 0; i < s.Length; i++)
            {
                char ch = s[i];
                if (!vis[ch - 'a'])
                {
                    while (sb.Length > 0 && 
                           sb[sb.Length - 1] > ch && 
                           num[sb[sb.Length - 1] - 'a'] > 0)
                    {
                        vis[sb[sb.Length - 1] - 'a'] = false;
                        sb.Remove(sb.Length - 1, 1);
                    }
                    vis[ch - 'a'] = true;
                    sb.Append(ch);
                }
                num[ch - 'a']--;
            }
            return sb.ToString();
        }
    }
}