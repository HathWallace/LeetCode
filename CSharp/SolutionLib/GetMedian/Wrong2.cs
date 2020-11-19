using System;

namespace SolutionLib.GetMedian
{
    public class Wrong2
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

                if (n1 <= 1 || n2 <= 1) break;

                double median1 = GetMedian(nums1, left1, right1),
                       median2 = GetMedian(nums2, left2, right2);
                int rn = Math.Min(n1 / 2, n2 / 2);

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

            if (n1 == 1 && n2 != 1)
            {
                return MedianInArrayAndNum(nums1[left1], nums2, left2, right2);
            }

            if (n1 != 1 && n2 == 1)
            {
                return MedianInArrayAndNum(nums2[right2], nums1, left1, right1);
            }

            return GetMedian(nums1[left1], nums2[right2]);
        }

        private double MedianInArrayAndNum(int num, int[] nums, int left, int right)
        {
            double median = GetMedian(nums, ref left, ref right);

            if (num < nums[left])
            {
                if (left == right)
                {
                    return GetMedian(nums[left - 1], nums[left]);
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
                    return GetMedian(nums[right], nums[right + 1]);
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
