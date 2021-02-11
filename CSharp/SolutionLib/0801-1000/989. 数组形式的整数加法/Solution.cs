using System.Collections.Generic;
using System.Linq;

namespace SolutionLib._989._数组形式的整数加法
{
    public class Solution
    {
        public IList<int> AddToArrayForm(int[] A, int K)
        {
            var res = new List<int>();
            int add = 0;
            for (int i = A.Length - 1; i >= 0; i--)
            {
                int v = A[i] + add + K % 10;
                A[i] = v % 10;
                add = v / 10;
                K /= 10;
                if (add == 0 && K == 0) return A;
            }
            while (add != 0 || K != 0)
            {
                int v = add + K % 10;
                res.Add(v % 10);
                add = v / 10;
                K /= 10;
            }
            res.Reverse();
            res.AddRange(A);
            return res.ToList();
        }
    }
}