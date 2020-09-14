using System;

namespace SolutionLib.GetMedian
{
    public class Wrong1
    {
        public double FindMedianSortedArrays(int[] nums1, int[] nums2)
        {
            return 0;
        }

        private double OneIsEmpty(int[] nums)
        {
            return GetMedian(nums, 0, nums.Length - 1);
        }

        private double NoseToTail(int[] nose, int noseL, int noseR, int[] tail, int tailL, int tailR)
        {
            int nl = noseR - noseL + 1,
                tl = tailR - tailL + 1;

            if (nl > tl) return GetMedian(nose, noseL, noseR - tl);
            if (nl < tl) return GetMedian(tail, tailL + nl, tailR);
            return (nose[noseR] + tail[tailL]) / 2.0;
        }

        private double NoseToTail(int[] nose, int[] tail)
        {
            //int nl = nose.Length,
            //    tl = tail.Length;

            //if (nl > tl) return GetMedian(nose, 0, nl - 1 - tl);
            //if (nl < tl) return GetMedian(tail, nl, tl - 1);
            //return (nose[nl - 1] + tail[0]) / 2.0;
            return NoseToTail(nose, 0, nose.Length - 1, tail, 0, tail.Length - 1);
        }

        private double Include(int[] interior, int[] exterior)
        {
            int il = interior.Length,
                el = exterior.Length,
                frontL, frontR, hideL, hideR;

            FindInArray(interior[0], exterior, out frontL, out frontR);
            FindInArray(interior[il - 1], exterior, out hideL, out hideR);

            int front = frontL + 1,
                hide = el - hideR;

            if (front < hide) return NoseToTail(interior, 0, il - 1, exterior, hideR, el - 1 - front);
            if (front > hide) return NoseToTail(exterior, hide + 1, frontL, interior, 0, il - 1);
            return GetMedian(interior, 0, il - 1);
        }

        private double Overlap(int[] left, int[] right)
        {
            int ll = left.Length,
                rl = right.Length,
                frontL, frontR, hideL, hideR;

            FindInArray(right[0], left, out frontL, out frontR);
            FindInArray(left[ll - 1], right, out hideL, out hideR);

            int front = frontL + 1,
                hide = rl - hideR;

            if (front < hide) return GetMedian(right, 0, rl - 1 - front);
            if (front > hide) return GetMedian(left, hide, ll - 1);
            return GetMedian(left, frontR, ll - 1);
        }

        private void FindInArray(int num, int[] nums, out int left, out int right)
        {
            left = 0;
            right = nums.Length - 1;
            double cp = num;

            while (true)
            {
                int n = right - left + 1;
                if (n <= 2) break;

                double median = GetMedian(nums, left, right);
                if (cp > median) left = n / 2;
                if (cp < median) right = n / 2 - 1;
                if (cp == median)
                {
                    int d = 1 - n % 2;
                    left = n / 2 - d;
                    right = n / 2;
                }
            }
        }

        private double GetMedian(int[] nums, int left, int right)
        {
            int mid = (right + left) / 2;
            if ((right - left + 1) % 2 == 1)
                return nums[mid];
            else
                return (nums[mid] + nums[mid + 1]) / 2.0;
        }
    }

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
