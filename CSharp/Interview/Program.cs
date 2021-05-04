using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace CSharp
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] nums = new[] { 3, 2, 4, 1, 5 };
            Console.WriteLine(string.Join(",", nums));
            new Solution().FastSort(nums);
            Console.WriteLine(string.Join(",", nums));
            Console.ReadKey();
        }
    }

    class Solution
    {
        public void FastSort(int[] nums)
        {
            FastSort(nums, 0, nums.Length - 1);
        }

        private void FastSort(int[] nums, int left, int right)
        {
            if (right - left <= 0) return;
            int partition = nums[left], lo = left, hi = right + 1;
            while (true)
            {
                lo++;
                hi--;
                while (nums[lo] < partition && lo <= right) lo++;
                while (nums[hi] > partition && hi > left) hi--;
                if (lo >= hi) break;
                Swap(nums, lo, hi);
            }
            Swap(nums, hi, left);
            FastSort(nums, left, hi - 1);
            FastSort(nums, hi + 1, right);
        }

        private void Swap(int[] nums, int x, int y)
        {
            int tmp = nums[x];
            nums[x] = nums[y];
            nums[y] = tmp;
        }
    }

}