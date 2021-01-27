using System;

namespace SolutionLib._628._三个数的最大乘积
{
    public class Solution
    {
        public int MaximumProduct(int[] nums)
        {
            int min1, min2, max1, max2, max3;
            min1 = min2 = int.MaxValue;
            max1 = max2 = max3 = int.MinValue;
            foreach (var num in nums)
            {
                if (num < min1)
                {
                    min2 = min1;
                    min1 = num;
                }
                else if (num < min2)
                    min2 = num;

                if (num > max1)
                {
                    max3 = max2;
                    max2 = max1;
                    max1 = num;
                }
                else if (num > max2)
                {
                    max3 = max2;
                    max2 = num;
                }
                else if (num > max3)
                    max3 = num;

            }
            return Math.Max(max1 * max2 * max3, min1 * min2 * max1);
        }
    }

    public class _Solution
    {
        public int MaximumProduct(int[] nums)
        {
            int len = nums.Length;
            Array.Sort(nums);
            return Math.Max(
                nums[0] * nums[1] * nums[len - 1],
                nums[len - 3] * nums[len - 2] * nums[len - 1]
            );
        }
    }

}