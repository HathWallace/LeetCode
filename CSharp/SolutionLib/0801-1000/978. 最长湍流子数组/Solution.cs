using System;

namespace SolutionLib._978._最长湍流子数组
{
    public class Solution
    {
        public int MaxTurbulenceSize(int[] arr)
        {
            int len = arr.Length, ans = 1, dp = 1, pre = -2;
            for (int i = 1; i < len; i++)
            {
                int sign = Math.Sign(arr[i] - arr[i - 1]);
                if (sign == 0 || pre != -2 && sign + pre != 0) dp = sign == 0 ? 1 : 2;
                else dp++;
                pre = sign;
                ans = Math.Max(ans, dp);
            }
            return ans;
        }
    }
}