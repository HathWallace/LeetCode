using System;
using System.Linq;

namespace SolutionLib._416._分割等和子集
{
    public class Solution_dp
    {
        public bool CanPartition(int[] nums)
        {
            int sum = 0, n = nums.Length, max = int.MinValue;
            foreach (var num in nums)
            {
                sum += num;
                max = Math.Max(max, num);
            }
            if (n < 2 || sum % 2 != 0 || max > sum / 2) return false;
            int target = sum / 2;
            var dp = new bool[target + 1];
            dp[0] = dp[nums[0]] = true;
            for (int i = 1; i < n; i++)
            {
                int num = nums[i];
                for (int j = target; j >= num; j--)
                    dp[j] |= dp[j - num];
            }
            return dp[target];
        }
    }

    public class _Solution_dp
    {
        public bool CanPartition(int[] nums)
        {
            int sum = 0, n = nums.Length, max = int.MinValue;
            foreach (var num in nums)
            {
                sum += num;
                max = Math.Max(max, num);
            }
            if (n < 2 || sum % 2 != 0 || max > sum / 2) return false;
            int target = sum / 2;
            var dp = new bool[n, target + 1];
            for (int i = 0; i < n; i++) dp[i, 0] = true;
            dp[0, nums[0]] = true;
            for (int i = 1; i < n; i++) for (int j = 1; j <= target; j++)
                    dp[i, j] = dp[i - 1, j] || j >= nums[i] && dp[i - 1, j - nums[i]];
            return dp[n - 1, target];
        }
    }

}
