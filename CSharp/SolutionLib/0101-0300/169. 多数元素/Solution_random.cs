using System;

namespace SolutionLib._169._多数元素
{
    public class Solution_random
    {
        public int MajorityElement(int[] nums)
        {
            var rand = new Random();
            while (true)
            {
                int candidate = nums[rand.Next(nums.Length - 1)];
                int count = 0;
                foreach (var num in nums)
                    if (num == candidate)
                        count++;
                if (count > nums.Length / 2)
                    return candidate;
            }
        }

    }
}