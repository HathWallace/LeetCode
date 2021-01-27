using System;

namespace SolutionLib._123._买卖股票的最佳时机_III
{
    public class Test
    {
        public static void Run()
        {
            var s = new Solution();
            Console.WriteLine(s.MaxProfit(Public.ReadNums()));
        }

        /*
         * 测试用例：
         * [3,3,5,0,0,3,1,4]
         * [1,2,3,4,5]
         * [7,6,4,3,1]
         * [1,2,4,2,5,7,2,4,9,0]
         */

    }
}