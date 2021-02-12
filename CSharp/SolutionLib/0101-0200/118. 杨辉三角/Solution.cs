using System.Collections.Generic;

namespace SolutionLib._118._杨辉三角
{
    public class Solution
    {
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
}