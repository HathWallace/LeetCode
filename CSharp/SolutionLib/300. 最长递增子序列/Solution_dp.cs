//https://leetcode-cn.com/problems/longest-increasing-subsequence/solution/zui-chang-shang-sheng-zi-xu-lie-by-leetcode-soluti/
using System;

namespace SolutionLib._300._最长递增子序列
{
    public class Solution_dp
    {
        public int LengthOfLIS(int[] nums)
        {
            var dp = new int[nums.Length];
            int res = int.MinValue;
            dp[0] = 1;
            for (int i = 1; i < nums.Length; i++)
            {
                dp[i] = 1;
                for (int j = 0; j < i; j++)
                    if (nums[i] > nums[j] && dp[i] < dp[j] + 1)
                        dp[i] = dp[j] + 1;
            }
            for (int i = 0; i < dp.Length; i++)
                res = Math.Max(res, dp[i]);
            return res;
        }
    }
}