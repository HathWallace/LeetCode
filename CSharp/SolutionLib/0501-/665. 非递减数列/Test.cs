using System;

namespace SolutionLib._665._非递减数列
{
    public class Test
    {
        public static void Run()
        {
            var nums = Public.ReadNums();

            var s = new Solution2();

            Console.WriteLine(s.CheckPossibility(nums));
        }
    }
}