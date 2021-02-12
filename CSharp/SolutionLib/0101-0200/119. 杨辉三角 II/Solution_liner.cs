using System.Collections.Generic;

namespace SolutionLib._119._杨辉三角_II
{
    public class Solution_liner
    {
        public IList<int> GetRow(int rowIndex)
        {
            var res = new int[rowIndex + 1];
            res[0] = res[rowIndex] = 1;
            for (int i = 1; i <= rowIndex / 2; i++)
                res[i] = res[rowIndex - i] = (int)(1L * res[i - 1] * (rowIndex - i + 1) / i);
            return res;
        }
    }
}