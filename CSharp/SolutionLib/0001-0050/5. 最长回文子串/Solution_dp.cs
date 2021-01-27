namespace SolutionLib._5._最长回文子串
{
    public class Solution_dp
    {
        public string LongestPalindrome(string s)
        {
            int len = s.Length;
            var dp = new bool[len, len];
            string ans = "";
            for (int l = 1; l <= len; l++)
            {
                for (int i = 0; i + l <= len; i++)
                {
                    int j = i + l - 1;
                    if (l == 1)
                        dp[i, j] = true;
                    else if (l == 2)
                        dp[i, j] = s[i] == s[j];
                    else
                        dp[i, j] = dp[i + 1, j - 1] && s[i] == s[j];
                    if (dp[i, j] && l > ans.Length)
                        ans = s.Substring(i, l);
                }
            }
            return ans;
        }
    }
}
