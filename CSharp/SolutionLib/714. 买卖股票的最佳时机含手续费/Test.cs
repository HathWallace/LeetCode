using System;

namespace SolutionLib._714._买卖股票的最佳时机含手续费
{
    public class Test
    {
        public static void Run()
        {
            var prices = Public.ReadNums();
            var fee = Public.ReadNum();

            var s = new Solution2();

            Console.WriteLine(s.MaxProfit(prices, fee));
        }
    }
}
