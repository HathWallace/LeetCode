using System;
using System.Collections.Generic;

namespace SolutionLib._18._四数之和
{
    public class Solution
    {
        public IList<IList<int>> FourSum(int[] nums, int target)
        {
            Array.Sort(nums);
            int n = nums.Length;
            var res = new List<IList<int>>();
            for (int i = 0; i < n;)
            {
                int num = nums[i];
                var tmps = ThreeSum(nums, i + 1, target - num);
                foreach (var tmp in tmps)
                {
                    var _tmp = new List<int> { num };
                    _tmp.AddRange(tmp);
                    res.Add(_tmp);
                }
                while (i < n && nums[i] == num) i++;
            }
            return res;
        }

        public IList<IList<int>> ThreeSum(int[] nums, int start, int target)
        {
            int n = nums.Length;
            var res = new List<IList<int>>();
            for (int i = start; i < n;)
            {
                int num = nums[i];
                var tmps = TwoSum(nums, i + 1, target - num);
                foreach (var tmp in tmps)
                {
                    var _tmp = new List<int> { num };
                    _tmp.AddRange(tmp);
                    res.Add(_tmp);
                }
                while (i < n && nums[i] == num) i++;
            }
            return res;
        }

        private IList<IList<int>> TwoSum(int[] nums, int start, int target)
        {
            var res = new List<IList<int>>();
            int left = start, right = nums.Length - 1;
            while (left < right)
            {
                int ln = nums[left], rn = nums[right], sum = ln + rn;
                if (sum == target)
                    res.Add(new List<int> { ln, rn });
                if (sum <= target)
                    while (left < right && nums[left] == ln)
                        left++;
                if (sum >= target)
                    while (left < right && nums[right] == rn)
                        right--;
            }
            return res;
        }

    }
}