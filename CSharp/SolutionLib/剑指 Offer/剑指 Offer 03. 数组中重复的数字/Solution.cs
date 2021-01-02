using System.Collections.Generic;

namespace SolutionLib.剑指_Offer_03._数组中重复的数字
{
    public class Solution
    {
        public int FindRepeatNumber(int[] nums)
        {
            var set = new HashSet<int>();
            for (int i = 0; i < nums.Length; i++)
                if (!set.Add(nums[i]))
                    return nums[i];
            return -1;
        }
    }

    public class _Solution
    {
        public int FindRepeatNumber(int[] nums)
        {
            var flag = new bool[nums.Length];
            for (int i = 0; i < nums.Length; i++)
            {
                if (flag[nums[i]]) return nums[i];
                flag[nums[i]] = true;
            }
            return -1;
        }
    }
}