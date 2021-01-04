using System;

namespace SolutionLib._312._戳气球
{
    public class Solution_dp
    {
        public int MaxCoins(int[] nums)
        {
            int n = nums.Length;
            var val = new int[n + 2];
            var rec = new int[n + 2, n + 2];
            val[0] = val[n + 1] = 1;
            for (int i = 0; i < nums.Length; i++)
                val[i + 1] = nums[i];
            for (int l = 1; l <= n; l++)
                for (int i = 0, j = i + l + 1; j < n + 2; i++, j++)
                    for (int k = i + 1; k < j; k++)
                    {
                        int sum = val[i] * val[k] * val[j];
                        sum += rec[i, k] + rec[k, j];
                        rec[i, j] = Math.Max(rec[i, j], sum);
                    }
            return rec[0, n + 1];
        }
    }
}