namespace SolutionLib._714._买卖股票的最佳时机含手续费
{
    public class Solution//ERROR
    {
        public int MaxProfit(int[] prices, int fee)
        {
            int earn = 0, now = 0;

            for (int i = 0; i < prices.Length; i++)
            {
                if (now == 0)
                {
                    now -= prices[i];
                    continue;
                }

                if (now + prices[i] - fee > 0)
                {
                    earn += now + prices[i] - fee;
                    now = 0;
                }
                
            }

            return earn;
        }
    }
}
