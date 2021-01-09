using System;
using System.Collections.Generic;

namespace SolutionLib._123._买卖股票的最佳时机_III
{
    public class Solution
    {
        public int MaxProfit(int[] prices)
        {
            int days = prices.Length;
            if (days < 2) return 0;
            int buy1 = -prices[0], buy2 = -prices[0], sale1 = 0, sale2 = 0;
            for (int i = 1; i < days; i++)
            {
                buy1 = Math.Max(buy1, -prices[i]);
                sale1 = Math.Max(sale1, buy1 + prices[i]);
                buy2 = Math.Max(buy2, sale1 - prices[i]);
                sale2 = Math.Max(sale2, buy2 + prices[i]);
            }
            return sale2;
        }
    }

    public class _Solution
    {
        public int MaxProfit(int[] prices)
        {
            int days = prices.Length;
            if (days < 2) return 0;
            var buy = new int[days, 3];
            var sale = new int[days, 3];
            buy[0, 0] = buy[0, 1] = buy[0, 2] = -prices[0];
            for (int i = 1; i < days; i++)
            {
                for (int j = 1; j < 3; j++)
                {
                    buy[i, j] = Math.Max(buy[i - 1, j], sale[i, j - 1] - prices[i]);
                    sale[i, j] = Math.Max(buy[i, j] + prices[i], sale[i - 1, j]);
                }
            }
            return sale[days - 1, 2];
        }
    }
}