using System;
using System.Collections.Generic;

namespace SolutionLib._321._拼接最大数
{
    public class Solution
    {
        public int[] MaxNumber(int[] nums1, int[] nums2, int k)
        {
            var res = new int[k];
            int maxi = Math.Min(k, nums1.Length);
            for (int i = Math.Max(0, k - nums2.Length); i <= maxi; i++)
            {
                var sub = Joint(MaxSubNumber(nums1, i), MaxSubNumber(nums2, k - i));
                if (Compare(sub, 0, res, 0) > 0)
                    res = sub;
            }
            return res;
        }

        private int Compare(int[] nums1, int beg1, int[] nums2, int beg2)
        {
            if (nums1 == null) return -1;
            if (nums2 == null) return 1;
            int m = nums1.Length, n = nums2.Length, i = beg1, j = beg2;
            for (; i < m && j < n; i++, j++)
                if (nums1[i] != nums2[j]) return nums1[i] - nums2[j];
            return (m - i) - (n - j);
        }

        private int[] MaxSubNumber(int[] nums, int k)
        {
            if (k == 0) return null;
            var res = new int[k];
            int top = -1, remain = nums.Length - k;
            for (int i = 0; i < nums.Length; i++)
            {
                while (top >= 0 && remain > 0 && res[top] < nums[i])
                {
                    top--;
                    remain--;
                }
                if (top < k - 1) res[++top] = nums[i];
                else remain--;
            }
            return res;
        }

        private int[] Joint(int[] nums1, int[] nums2)
        {
            if (nums1 == null) return nums2;
            if (nums2 == null) return nums1;
            var res = new int[nums1.Length + nums2.Length];
            for (int i = 0, j = 0, k = 0; i < nums1.Length || j < nums2.Length; k++)
                if (Compare(nums1, i, nums2, j) > 0)
                    res[k] = nums1[i++];
                else
                    res[k] = nums2[j++];
            return res;
        }

    }
}