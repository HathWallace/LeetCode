using System;

namespace SolutionLib._53._最大子序和
{
    public class Solution
    {
        public int MaxSubArray(int[] nums)
        {
            int res = int.MinValue, sum = 0;
            for (int i = 0; i < nums.Length; i++)
            {
                sum = Math.Max(sum + nums[i], nums[i]);
                res = Math.Max(sum, res);
            }
            return res;
        }
    }
}