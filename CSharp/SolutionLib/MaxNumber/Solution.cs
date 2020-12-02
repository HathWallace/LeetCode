namespace SolutionLib.MaxNumber
{
    public class Solution
    {
        public int[] MaxNumber(int[] nums1, int[] nums2, int k)
        {
            int i1 = 0, i2 = 0, ik = 0;
            var res = new int[k];
            while (i1 < nums1.Length && i2 < nums2.Length && ik < k)
            {
                if (nums1[i1] >= nums2[i2])
                {
                    res[ik++] = nums1[i1++];
                }
                else
                {
                    res[ik++] = nums2[i2++];
                }
            }

            if (ik < k)
            {
                if (i1 < nums1.Length)
                {
                    while (i1 < nums1.Length)
                    {
                        res[ik++] = nums1[i1++];
                    }
                }
                else if (i2 < nums2.Length)
                {
                    while (i2 < nums2.Length)
                    {
                        res[ik++] = nums2[i2++];
                    }
                }
            }

            return res;
        }
    }
}