namespace SolutionLib._509._斐波那契数
{
    public class Solution_fastpower
    {
        public int Fib(int n)
        {
            if (n < 1) return 0;
            return Multiple(Pow(new[,] { { 1, 1 }, { 1, 0 } }, n - 1), new[,] { { 1 }, { 0 } })[0, 0];
        }

        private int[,] Multiple(int[,] a, int[,] b)
        {
            var res = new int[a.GetLength(0), b.GetLength(1)];
            for (int i = 0; i < a.GetLength(0); i++)
                for (int j = 0; j < b.GetLength(1); j++)
                    for (int k = 0; k < a.GetLength(1); k++)
                        res[i, j] += a[i, k] * b[k, j];
            return res;
        }

        private int[,] Pow(int[,] x, int n)
        {
            var res = new int[x.GetLength(0), x.GetLength(1)];
            for (int i = 0; i < x.GetLength(0); i++) res[i, i] = 1;
            while (n > 0)
            {
                if ((n & 1) == 1) res = Multiple(res, x);
                n >>= 1;
                x = Multiple(x, x);
            }
            return res;
        }

    }
}