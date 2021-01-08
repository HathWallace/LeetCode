using System;
using System.Collections.Generic;

namespace SolutionLib._128._最长连续序列
{
    public class Solution2
    {
        public int LongestConsecutive(int[] nums)
        {
            var set = new HashSet<int>();
            int res = 0;
            foreach (var num in nums) set.Add(num);
            foreach (var num in set)
            {
                if (set.Contains(num - 1)) continue;
                int pt = num, dp = 1;
                while (set.Contains(++pt)) dp++;
                res = Math.Max(res, dp);
            }
            return res;
        }
    }

    public class Solution
    {
        public int LongestConsecutive(int[] nums)
        {
            int res = 0;
            var dict = new Dictionary<int, bool>();
            for (int i = 0; i < nums.Length; i++)
                dict[nums[i]] = false;
            for (int i = 0; i < nums.Length; i++)
            {
                if (dict[nums[i]]) continue;
                int dp = 1;
                for (int pt = nums[i] + 1; dict.ContainsKey(pt); pt++, dp++) dict[pt] = true;
                for (int pt = nums[i] - 1; dict.ContainsKey(pt); pt--, dp++) dict[pt] = true;
                res = Math.Max(res, dp);
            }
            return res;
        }
    }

    public class _Solution
    {
        public int LongestConsecutive(int[] nums)
        {
            if (nums.Length == 0) return 0;
            int res = 1, dp = 1;
            Array.Sort(nums);
            for (int i = 1; i < nums.Length; i++)
            {
                int diff = nums[i] - nums[i - 1];
                if (diff > 1) dp = 1;
                if (diff == 1) dp++;
                res = Math.Max(dp, res);
            }
            return res;
        }
    }
}