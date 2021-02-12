using System.Collections.Generic;

namespace SolutionLib._119._杨辉三角_II
{
    public class Solution
    {
        public IList<int> GetRow(int rowIndex)
        {
            var rows = new int[2][];
            rows[0] = new int[rowIndex + 1];
            rows[0][0] = 1;
            rows[1] = new int[rowIndex + 1];
            for (int i = 1; i <= rowIndex; i++)
            {
                var now = rows[i % 2];
                var pre = rows[(i - 1) % 2];
                now[0] = now[i] = 1;
                for (int j = 1; j < i; j++)
                    now[j] = pre[j - 1] + pre[j];
            }
            return rows[rowIndex % 2];
        }
    }

    public class __Solution
    {
        public IList<int> GetRow(int rowIndex)
        {
            return Generate(rowIndex + 1)[rowIndex];
        }

        public IList<IList<int>> Generate(int numRows)
        {
            var res = new List<IList<int>>();
            if (numRows == 0) return res;
            res.Add(new List<int> { 1 });
            for (int i = 1; i < numRows; i++)
            {
                var list = new List<int>();
                list.Add(1);
                for (int j = 1; j < i; j++)
                    list.Add(res[i - 1][j - 1] + res[i - 1][j]);
                list.Add(1);
                res.Add(list);
            }
            return res;
        }

    }

    //超出时间限制
    public class _Solution
    {
        private int[,] C;

        public IList<int> GetRow(int rowIndex)
        {
            C = new int[rowIndex + 1, rowIndex + 1];
            var res = new List<int>();
            for (int i = 0; i <= rowIndex; i++)
                res.Add(GetCombNum(rowIndex, i));
            return res;
        }

        private int GetCombNum(int n, int m)
        {
            if (C[n, m] != 0) return C[n, m];
            if (m == 0 || m == n) return C[n, m] = 1;
            return GetCombNum(n - 1, m) + GetCombNum(n - 1, m - 1);
        }

    }
}