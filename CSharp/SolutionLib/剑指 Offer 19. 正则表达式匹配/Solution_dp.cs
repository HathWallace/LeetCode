//https://leetcode-cn.com/problems/zheng-ze-biao-da-shi-pi-pei-lcof/solution/zheng-ze-biao-da-shi-pi-pei-by-leetcode-s3jgn/

namespace SolutionLib.剑指_Offer_19._正则表达式匹配
{
    public class Solution_dp
    {
        public bool IsMatch(string s, string p)
        {
            int m = s.Length, n = p.Length;
            var f = new bool[m + 1, n + 1];
            f[0, 0] = true;
            for (int i = 0; i <= m; i++)
                for (int j = 1; j <= n; j++)
                    if (p[j - 1] == '*')
                        f[i, j] = f[i, j - 2] || Matches(s, p, i, j - 1) && f[i - 1, j];
                    else
                        f[i, j] = Matches(s, p, i, j) && f[i - 1, j - 1];
            return f[m, n];
        }

        public bool Matches(string s, string p, int i, int j)
        {
            if (i == 0) return false;
            if (p[j - 1] == '.') return true;
            return s[i - 1] == p[j - 1];
        }
    }
}