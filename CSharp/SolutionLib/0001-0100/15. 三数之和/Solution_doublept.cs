//https://leetcode-cn.com/problems/3sum/solution/hua-jie-suan-fa-15-san-shu-zhi-he-by-guanpengchn/
using System;
using System.Collections.Generic;

namespace SolutionLib._15._三数之和
{
    public class Solution_doublept
    {
        public IList<IList<int>> ThreeSum(int[] nums)
        {
            var res = new List<IList<int>>();
            Array.Sort(nums);
            for (int i = 0; i < nums.Length; i++)
            {
                if (nums[i] > 0) break;
                if (i > 0 && nums[i] == nums[i - 1]) continue;
                int L = i + 1, R = nums.Length - 1;
                while (L < R)
                {
                    int sum = nums[i] + nums[L] + nums[R];
                    if (sum == 0)
                    {
                        res.Add(new List<int> { nums[i], nums[L], nums[R] });
                        while (L < R && nums[L] == nums[L + 1]) L++;
                        while (L < R && nums[R] == nums[R - 1]) R--;
                        L++;
                        R--;
                    }
                    if (sum < 0) L++;
                    if (sum > 0) R--;
                }
            }
            return res;
        }
    }
}