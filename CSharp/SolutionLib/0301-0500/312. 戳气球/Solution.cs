namespace SolutionLib._312._戳气球
{
    public class Solution
    {
        public int MaxCoins(int[] nums)
        {
            if (nums.Length <= 0) return 0;
            var dp = new int[nums.Length];
            dp[0] = nums[0];
            return dp[nums.Length - 1];
        }
    }
}