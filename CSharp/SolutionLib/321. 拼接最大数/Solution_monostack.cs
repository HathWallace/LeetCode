//https://leetcode-cn.com/problems/create-maximum-number/solution/pin-jie-zui-da-shu-by-leetcode-solution/
using System;

namespace SolutionLib._321._拼接最大数
{
    public class Solution_monostack
    {
        public int[] MaxNumber(int[] nums1, int[] nums2, int k)
        {
            int m = nums1.Length, n = nums2.Length;

            if (m + n == k) return MerageMax(nums1, nums2);

            var res = new int[k];
            for (int i = Math.Max(0, k - n); i <= Math.Min(k, m); i++)
            {
                var sub1 = MaxSub(nums1, i);
                var sub2 = MaxSub(nums2, k - i);
                var merge = MerageMax(sub1, sub2);
                if (Compare(res, 0, merge, 0) < 0) res = merge;
            }

            return res;
        }

        private int[] MerageMax(int[] nums1, int[] nums2)
        {
            int i1 = 0, i2 = 0, ik = 0, m = nums1.Length, n = nums2.Length;
            var res = new int[m + n];
            while (i1 < m || i2 < n)
            {
                if (Compare(nums1, i1, nums2, i2) > 0)
                    res[ik++] = nums1[i1++];
                else
                    res[ik++] = nums2[i2++];
            }
            return res;
        }

        private int[] MaxSub(int[] nums, int k)
        {
            var res = new int[k];
            if (k == 0) return res;
            int n = nums.Length, i = 0, ik = 0;
            while (ik < k)
            {
                if (k - ik == n - i)
                    res[ik++] = nums[i++];
                else
                {
                    int maxI = i;
                    for (int j = i + 1; j <= n - k + ik; j++)
                    {
                        maxI = nums[maxI] < nums[j] ? j : maxI;
                    }
                    res[ik++] = nums[maxI];
                    i = maxI + 1;
                }
            }
            return res;
        }

        private int Compare(int[] nums1, int beg1, int[] nums2, int beg2)
        {
            int m = nums1.Length, n = nums2.Length;
            while (beg1 < m && beg2 < n)
            {
                int diff = nums1[beg1] - nums2[beg2];
                if (diff != 0) return diff;
                beg1++;
                beg2++;
            }
            return m - beg1 - (n - beg2);
        }

    }
}