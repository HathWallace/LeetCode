using System;

namespace SolutionLib._121._买卖股票的最佳时机
{
    public class Solution
    {
        public int MaxProfit(int[] prices)
        {
            if (prices.Length < 2) return 0;
            int profit = 0, buy = prices[0];
            for (int i = 1; i < prices.Length; i++)
            {
                buy = Math.Min(buy, prices[i]);
                profit = Math.Max(profit, prices[i] - buy);
            }
            return profit;
        }
    }
}