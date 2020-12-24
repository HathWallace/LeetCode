using System.Collections.Generic;

namespace SolutionLib._1._两数之和
{
    public class Solution_hash
    {
        public int[] TwoSum(int[] nums, int target)
        {
            var dict = new Dictionary<int, int>();
            for (int i = 0; i < nums.Length; i++)
            {
                if (dict.ContainsKey(nums[i]))
                    return new[] {dict[nums[i]], i};
                dict[target - nums[i]] = i;
            }
            return null;
        }
    }
}