using System.Collections.Generic;

namespace SolutionLib._279._完全平方数
{
    public class Solution_math
    {
        public int NumSquares(int n)
        {
            while (n % 4 == 0) n /= 4;
            if (n % 8 == 7) return 4;
            var square_nums = new HashSet<int>();
            for (int i = 1; i * i <= n; i++)
                square_nums.Add(i * i);
            if (square_nums.Contains(n)) return 1;
            foreach (var squareNum in square_nums)
                if (square_nums.Contains(n - squareNum)) return 2;
            return 3;
        }
    }
}