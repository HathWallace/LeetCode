using System;
using System.Collections.Generic;

namespace SolutionLib.GetMedian
{
    public class Test
    {
        public static void Run()
        {
            //int[] nums1 = {1},
            //    nums2 = {4, 5, 6, 7},
            //    nums3 = {8, 9, 10},
            //    nums4 = {6, 7, 7},
            //    nums5 = {-1, 3},
            //    nums6 = {2, 3, 4};

            Solution2 s = new Solution2();

            List<int> nums1 = new List<int>();
            List<int> nums2 = new List<int>();
            string s1 = Console.ReadLine(), s2 = Console.ReadLine();

            s1 = s1.Substring(1, s1.Length - 2);
            s2 = s2.Substring(1, s2.Length - 2);
            foreach (var num in s1.Split(','))
            {
                if (num == "") continue;
                nums1.Add(Int32.Parse(num));
            }

            foreach (var num in s2.Split(','))
            {
                if (num == "") continue;
                nums2.Add(Int32.Parse(num));
            }

            Console.WriteLine(s.FindMedianSortedArrays(nums1.ToArray(), nums2.ToArray()));


        }
    }
}
