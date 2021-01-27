using System;

namespace SolutionLib._152._乘积最大子数组
{
    public class Solution2
    {
        public int MaxProduct(int[] nums)
        {
            int n = nums.Length, ans = int.MinValue, maxF = 1, minF = 1;
            foreach (var num in nums)
            {
                int tmp = maxF;
                maxF = Math.Max(num, Math.Max(num * maxF, num * minF));
                minF = Math.Min(num, Math.Min(num * tmp, num * minF));
                ans = Math.Max(ans, maxF);
            }
            return ans;
        }
    }

    public class Solution
    {
        public int MaxProduct(int[] nums)
        {
            int n = nums.Length, ans;
            var max = new int[n];
            var min = new int[n];
            ans = max[0] = min[0] = nums[0];
            for (int i = 1; i < n; i++)
            {
                var tmp = new[] { max[i - 1] * nums[i], min[i - 1] * nums[i], nums[i] };
                Array.Sort(tmp);
                max[i] = tmp[2];
                min[i] = tmp[0];
                ans = Math.Max(ans, max[i]);
            }
            return ans;
        }
    }

    //超出时间限制
    public class _Solution
    {
        public int MaxProduct(int[] nums)
        {
            int ans = int.MinValue;
            for (int i = 0; i < nums.Length; i++)
            {
                int dp = 1;
                for (int j = i; j >= 0; j--)
                    ans = Math.Max(ans, dp *= nums[j]);
            }
            return ans;
        }
    }

}