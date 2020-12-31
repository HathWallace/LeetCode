using System;

namespace SolutionLib._135._分发糖果
{
    public class Test
    {
        public static void Run()
        {
            var s = new Solution();
            var _s = new _Solution();
            var nums = Public.ReadNums();
            Console.WriteLine(s.Candy(nums));
            Console.WriteLine(_s.Candy(nums));
        }
    }
}
