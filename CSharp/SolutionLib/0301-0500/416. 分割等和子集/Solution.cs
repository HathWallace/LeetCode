using System;
using System.Linq;

namespace SolutionLib._416._分割等和子集
{
    public class Solution
    {
        public bool CanPartition(int[] nums)
        {
            throw new InvalidOperationException();
        }
    }

    //超出时间限制
    public class _Solution
    {
        public bool CanPartition(int[] nums)
        {
            int sum = nums.Sum();
            if (sum % 2 != 0) return false;
            Array.Sort(nums);
            Array.Reverse(nums);
            return CanPartition(nums, -1, sum / 2);
        }

        private bool CanPartition(int[] nums, int begin, int sum)
        {
            if (sum < 0) return false;
            if (sum == 0) return true;
            for (int i = begin + 1; i < nums.Length; i++)
                if (CanPartition(nums, i, sum - nums[i]))
                    return true;
            return false;
        }

    }

}