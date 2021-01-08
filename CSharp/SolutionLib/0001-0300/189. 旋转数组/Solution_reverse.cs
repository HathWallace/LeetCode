using System;

namespace SolutionLib._189._旋转数组
{
    public class Solution_reverse
    {
        public void Rotate(int[] nums, int k)
        {
            if (k % nums.Length == 0) return;
            Array.Reverse(nums, 0, nums.Length);
            Array.Reverse(nums, 0, k % nums.Length);
            Array.Reverse(nums, k % nums.Length, nums.Length - k % nums.Length);
        }
    }
}