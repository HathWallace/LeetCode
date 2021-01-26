using System;

namespace SolutionLib._62._不同路径
{
    public class Solution_math
    {
        public int UniquePaths(int m, int n)
        {
            long ans = 1;
            if (m > n)
            {
                int tmp = m;
                m = n;
                n = tmp;
            }
            for (int x = n, y = 1; y < m; x++, y++)
                ans = ans * x / y;
            return (int)ans;
        }
    }

    public class _Solution_math
    {
        private int[,] log;

        public int UniquePaths(int m, int n)
        {
            log = new int[m + n, m + n];
            return Comb(m + n - 2, Math.Min(m, n) - 1);
        }

        private int Comb(int n, int m)
        {
            if (m == 0 || m == n) return 1;
            if (log[n, m] != 0) return log[n, m];
            return log[n, m] = Comb(n - 1, m - 1) + Comb(n - 1, m);
        }

    }

}