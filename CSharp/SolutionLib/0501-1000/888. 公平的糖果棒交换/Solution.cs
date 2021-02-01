using System;
using System.Linq;

namespace SolutionLib._888._公平的糖果棒交换
{
    public class Solution
    {
        public int[] FairCandySwap(int[] A, int[] B)
        {
            int gap = (A.Sum() - B.Sum()) / 2;
            Array.Sort(A);
            Array.Sort(B);
            if (gap > 0)
                Array.Reverse(A);
            else
                Array.Reverse(B);
            for (int i = 0; i < A.Length; i++)
                for (int j = 0; j < B.Length; j++)
                    if (A[i] - B[j] == gap)
                        return new[] { A[i], B[j] };
            return null;
        }
    }
}