using System;
using System.Collections.Generic;

namespace SolutionLib.GetMedian
{
    public class Solution1
    {
        public double FindMedianSortedArrays(int[] nums1, int[] nums2)
        {
            int left1 = 0,
                right1 = nums1.Length - 1,
                left2 = 0,
                right2 = nums2.Length - 1;

            if (right1 == -1)
            {
                return GetMedian(nums2, left2, right2);
            }

            if (right2 == -1)
            {
                return GetMedian(nums1, left1, right1);
            }

            int n1, n2;
            while (true)
            {
                n1 = right1 - left1 + 1;
                n2 = right2 - left2 + 1;

                if (n1 <= 2 || n2 <= 2) break;

                double median1 = GetMedian(nums1, left1, right1),
                       median2 = GetMedian(nums2, left2, right2);
                int min = Math.Min(n1, n2),
                    rn = min / 2 - (min + 1) % 2;

                if (median1 == median2) return median1;
                if (median1 < median2)
                {
                    RemoveLeft(ref left1, rn);
                    RemoveRight(ref right2, rn);
                }
                if (median1 > median2)
                {
                    RemoveRight(ref right1, rn);
                    RemoveLeft(ref left2, rn);
                }

            }

            if (n1 <= 2 && n2 > 2)
            {
                if (n1 == 2)
                    return MedianInArrayAndNum(nums1[left1], nums1[right1], nums2, left2, right2);

                return MedianInArrayAndNum(nums1[left1], nums2, left2, right2);
            }

            if (n1 > 2 && n2 <= 2)
            {
                if (n2 == 2)
                    return MedianInArrayAndNum(nums2[left2], nums2[right2], nums1, left1, right1);

                return MedianInArrayAndNum(nums2[right2], nums1, left1, right1);
            }

            int i1 = left1,
                i2 = left2;
            List<int> nums = new List<int>();

            while (i1 <= right1 || i2 <= right2)
            {
                if (i2 > right2 || (i1 <= right1 && nums1[i1] <= nums2[i2]))
                {
                    nums.Add(nums1[i1]);
                    i1++;
                }
                else
                {
                    nums.Add(nums2[i2]);
                    i2++;
                }
            }

            return GetMedian(nums.ToArray(), 0, n1 + n2 - 1);
        }

        private double MedianInArrayAndNum(int num1, int num2, int[] nums, int left, int right)
        {
            double median = GetMedian(nums, ref left, ref right);

            if (num1 > num2)
            {
                int temp = num1;
                num1 = num2;
                num2 = temp;
            }

            bool in1 = num1 >= nums[left] && num1 <= nums[right], 
                 in2 = num2 >= nums[left] && num2 <= nums[right];

            if (in1 && !in2)
            {
                return GetMedian(num1, nums[right]);
            }

            if (!in1 && in2)
            {
                return GetMedian(nums[left], num2);
            }

            if (!in1 && !in2)
            {
                if (num2 < nums[left])
                {
                    if (left == right)
                    {
                        return Math.Max(nums[left - 1], num2);
                    }
                    else
                    {
                        int a = Math.Max(nums[left - 1], num2);
                        return GetMedian(a, nums[left]);
                    }
                }

                if (num1 > nums[right])
                {
                    if (left == right)
                    {
                        return Math.Min(num1, nums[right + 1]);
                    }
                    else
                    {
                        int b = Math.Min(num1, nums[right + 1]);
                        return GetMedian(nums[right], b);
                    }
                }

                return median;
            }

            return GetMedian(num1, num2);
        }

        private double MedianInArrayAndNum(int num, int[] nums, int left, int right)
        {
            double median = GetMedian(nums, ref left, ref right);

            if (num < nums[left])
            {
                if (left == right)
                {
                    int a = Math.Max(num, nums[left - 1]);
                    return GetMedian(a, nums[left]);
                }
                else
                {
                    return nums[left];
                }
            }

            if (num > nums[right])
            {
                if (left == right)
                {
                    int b = Math.Min(nums[right + 1], num);
                    return GetMedian(nums[right], b);
                }
                else
                {
                    return nums[right];
                }
            }

            return num;
        }

        private double GetMedian(int[] nums, int left, int right)
        {
            return GetMedian(nums, ref left, ref right);
        }

        private double GetMedian(int a, int b)
        {
            return (a + b) / 2.0;
        }

        private double GetMedian(int[] nums, ref int left, ref int right)
        {
            int mid = (right + left) / 2,
                deta = (right - left + 1) % 2 == 1 ? 0 : 1;
            left = mid;
            right = mid + deta;

            return (nums[left] + nums[right]) / 2.0;
        }

        private void RemoveLeft(ref int left, int count)
        {
            left += count;
        }

        private void RemoveRight(ref int right, int count)
        {
            right -= count;
        }
    }

}
