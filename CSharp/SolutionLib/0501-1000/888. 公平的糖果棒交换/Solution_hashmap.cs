using System.Collections.Generic;
using System.Linq;

namespace SolutionLib._888._公平的糖果棒交换
{
    public class Solution_hashmap
    {
        public int[] FairCandySwap(int[] A, int[] B)
        {
            int delta = (A.Sum() - B.Sum()) / 2;
            var set = new HashSet<int>();
            foreach (var num in A)
                set.Add(num);
            foreach (var num in B)
                if (set.Contains(num + delta))
                    return new[] {num + delta, num};
            return null;
        }
    }
}