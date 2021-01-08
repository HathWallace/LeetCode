using System;

namespace SolutionLib._198._打家劫舍
{
    public class Solution
    {
        public int Rob(int[] nums)
        {
            if (nums.Length == 0) return 0;
            if (nums.Length == 1) return nums[0];
            int first = nums[0];
            int second = Math.Max(nums[0], nums[1]);
            for (int i = 2; i < nums.Length; i++)
            {
                int tmp = second;
                second = Math.Max(first + nums[i], second);
                first = tmp;
            }
            return second;
        }
    }

    public class _Solution
    {
        public int Rob(int[] nums)
        {
            if (nums.Length == 0) return 0;
            var dp = new int[2, nums.Length];
            dp[1, 0] = nums[0];
            for (int i = 1; i < nums.Length; i++)
            {
                dp[0, i] = Math.Max(dp[0, i - 1], dp[1, i - 1]);
                dp[1, i] = Math.Max(dp[0, i - 1], i - 2 < 0 ? 0 : dp[1, i - 2]) + nums[i];
            }
            return Math.Max(dp[0, nums.Length - 1], dp[1, nums.Length - 1]);
        }
    }
}