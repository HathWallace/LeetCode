namespace SolutionLib._4._寻找两个正序数组的中位数
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

    
}
