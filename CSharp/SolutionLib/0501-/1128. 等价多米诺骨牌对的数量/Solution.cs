using System;
using System.Collections.Generic;

namespace SolutionLib._1128._等价多米诺骨牌对的数量
{
    public class Solution
    {
        public int NumEquivDominoPairs(int[][] dominoes)
        {
            int ans = 0, n = dominoes.Length;
            var dict = new Dictionary<int, int>();
            for (int i = 0; i < n; i++)
            {
                int x = dominoes[i][0], y = dominoes[i][1];
                int index = Math.Min(x * n + y, x + y * n);
                if (!dict.ContainsKey(index))
                    dict[index] = 0;
                ans += dict[index];
                dict[index]++;
            }
            return ans;
        }
    }
}