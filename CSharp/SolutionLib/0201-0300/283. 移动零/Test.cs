using System;

namespace SolutionLib._283._移动零
{
    public class Test
    {
        public static void Run()
        {
            int[] nums = {0, 1, 0, 3, 12};

            PrintNums(nums);

            Solution s = new Solution();
            s.MoveZeroes(nums);

            PrintNums(nums);

        }

        private static void PrintNums(int[] nums)
        {
            bool flag = false;
            foreach (var num in nums)
            {
                if (flag) Console.Write(" ");
                Console.Write(num);
                flag = true;
            }

            Console.WriteLine('\n');
        }
    }
}