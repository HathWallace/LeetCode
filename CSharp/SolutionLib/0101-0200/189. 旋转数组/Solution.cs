using System;

namespace SolutionLib._189._旋转数组
{
    public class Solution
    {
        public void Rotate(int[] nums, int k)
        {

        }
    }

    public class _Solution
    {
        public void Rotate(int[] nums, int k)
        {
            var res = new int[nums.Length];
            int size = nums.Length;
            for (int i = 0; i < size; i++)
                res[(i + k) % size] = nums[i];
            Array.Copy(res, nums, size);
        }
    }

}