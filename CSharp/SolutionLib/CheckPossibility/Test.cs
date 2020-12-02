using System;

namespace SolutionLib.CheckPossibility
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