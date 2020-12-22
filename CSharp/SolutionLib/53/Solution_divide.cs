//https://leetcode-cn.com/problems/maximum-subarray/solution/zui-da-zi-xu-he-by-leetcode-solution/

using System;

namespace SolutionLib._53
{
    public class Solution_divide
    {
        private class Result
        {
            public int Sum { get; set; }
            public int LeftMax { get; set; }
            public int RightMax { get; set; }
            public int SubMax { get; set; }
        }

        public int MaxSubArray(int[] nums)
        {
            return MaxSubArray(nums, 0, nums.Length - 1).SubMax;
        }

        private Result MaxSubArray(int[] nums, int beg, int end)
        {
            var res = new Result();
            if (beg == end)
            {
                res.Sum = res.LeftMax = res.RightMax = res.SubMax = nums[beg];
                return res;
            }

            int mid = (beg + end) / 2;
            var lRes = MaxSubArray(nums, beg, mid);
            var rRes = MaxSubArray(nums, mid + 1, end);
            res.Sum = lRes.Sum + rRes.Sum;
            res.LeftMax = Math.Max(lRes.LeftMax, lRes.Sum + rRes.LeftMax);
            res.RightMax = Math.Max(lRes.RightMax + rRes.Sum, rRes.RightMax);
            res.SubMax = Math.Max(lRes.SubMax, rRes.SubMax);
            res.SubMax = Math.Max(res.SubMax, lRes.RightMax + rRes.LeftMax);
            return res;
        }
    }
}