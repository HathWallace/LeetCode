using System;

namespace SolutionLib._188._买卖股票的最佳时机_IV
{
    public class Solution_dp
    {
        public int MaxProfit(int k, int[] prices)
        {
            int days = prices.Length;
            if (k == 0 || days == 0) return 0;
            var buy = new int[days, k + 1];
            var sale = new int[days, k + 1];

            for (int i = 0; i <= k; i++)
                buy[0, i] = -prices[0];

            for (int i = 1; i < days; i++)
            {
                buy[i, 0] = Math.Max(buy[i - 1, 0], -prices[i]);
                for (int j = 1; j <= k; j++)
                {
                    buy[i, j] = Math.Max(buy[i - 1, j], sale[i - 1, j] - prices[i]);
                    sale[i, j] = Math.Max(buy[i - 1, j - 1] + prices[i], sale[i - 1, j]);
                }
            }

            return sale[days - 1, k];
        }
    }
}