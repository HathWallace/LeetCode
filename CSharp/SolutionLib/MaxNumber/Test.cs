using System;

namespace SolutionLib.MaxNumber
{
    public class Test
    {
        public static void Run()
        {
            int[] nums1 = Public.ReadNums();
            int[] nums2 = Public.ReadNums();
            int k = Public.ReadNum();

            var s = new MaxNumber.Solution();
            var res = s.MaxNumber(nums1, nums2, k);

            Public.PrintNums(res);
        }
    }
}
