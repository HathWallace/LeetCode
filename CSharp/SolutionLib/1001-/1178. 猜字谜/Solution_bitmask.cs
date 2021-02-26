using System.Collections.Generic;

namespace SolutionLib._1178._猜字谜
{
    public class Solution_bitmask
    {
        public IList<int> FindNumOfValidWords(string[] words, string[] puzzles)
        {
            var res = new List<int>();
            var dict = new Dictionary<int, int>();
            foreach (var word in words)
            {
                int mask = 0;
                foreach (var ch in word) mask |= 1 << (ch - 'a');
                if (!dict.ContainsKey(mask)) dict[mask] = 0;
                dict[mask]++;
            }
            foreach (var puzzle in puzzles)
            {
                int ans = 0;
                for (int choose = 0; choose < 1 << 6; choose++)
                {
                    int mask = 1 << (puzzle[0] - 'a');
                    for (int i = 1; i <= 6; i++)
                    {
                        if ((choose & (1 << (i - 1))) == 0) continue;
                        mask |= 1 << (puzzle[i] - 'a');
                    }
                    if (dict.ContainsKey(mask)) ans += dict[mask];
                }
                res.Add(ans);
            }
            return res;
        }
    }
}