using System;
using System.Collections.Generic;
using System.Linq;

namespace SolutionLib._480._滑动窗口中位数
{
    public class Solution
    {
        public double[] MedianSlidingWindow(int[] nums, int k)
        {
            int n = nums.Length;
            var res = new double[n - k + 1];
            var subNums = new int[k];
            for (int i = 0; i < k; i++)
                subNums[i] = nums[i];
            Array.Sort(subNums);
            res[0] = GetMedian(subNums, k);
            for (int i = k; i < n; i++)
            {
                Replace(subNums, nums[i - k], nums[i]);
                res[i - k + 1] = GetMedian(subNums, k);
            }
            return res;
        }

        private void Replace(int[] nums, int oldN, int newN)
        {
            int left = 0, right = nums.Length - 1;
            while (left < right)
            {
                int mid = (left + right) / 2;
                if (oldN == nums[mid]) left = right = mid;
                else if (oldN > nums[mid]) left = mid + 1;
                else right = mid;
            }
            if (oldN < newN)
            {
                for (left++; left < nums.Length && nums[left] < newN; left++)
                    nums[left - 1] = nums[left];
                nums[left - 1] = newN;
            }
            else
            {
                for (right--; right >= 0 && nums[right] > newN; right--)
                    nums[right + 1] = nums[right];
                nums[right + 1] = newN;
            }
        }

        private double GetMedian(int[] nums, int k)
        {
            return k % 2 == 1 ? nums[k / 2] : ((long)nums[k / 2 - 1] + nums[k / 2]) / 2.0;
        }

    }
}