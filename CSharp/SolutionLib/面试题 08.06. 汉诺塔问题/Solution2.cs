using System.Collections.Generic;

namespace SolutionLib.面试题_08._06._汉诺塔问题
{
    public class Solution2
    {
        public void Hanota(IList<int> A, IList<int> B, IList<int> C)
        {
            Move(A.Count, A, B, C);
        }

        public static void Move(int n, IList<int> A, IList<int> B, IList<int> C)
        {
            if (n == 1)
            {
                C.Add(A[A.Count - 1]);
                A.RemoveAt(A.Count - 1);
                return;
            }
            Move(n - 1, A, C, B);
            Move(1, A, B, C);
            Move(n - 1, B, A, C);
        }
    }
}