using System.Collections.Generic;

namespace SolutionLib._169._多数元素
{
    public class Solution_moore
    {
        public int MajorityElement(int[] nums)
        {
            int count = 1;
            int candidate = nums[0];
            for (int i = 1; i < nums.Length; i++)
            {
                if (count == 0)
                    candidate = nums[i];
                count += candidate == nums[i] ? 1 : -1;
            }
            return candidate;
        }
    }
}