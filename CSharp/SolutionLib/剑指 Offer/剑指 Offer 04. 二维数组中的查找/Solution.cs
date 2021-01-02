namespace SolutionLib.剑指_Offer_04._二维数组中的查找
{
    public class Solution
    {
        public bool FindNumberIn2DArray(int[][] matrix, int target)
        {
            if (matrix.Length == 0) return false;
            int n = matrix.Length, m = matrix[0].Length, mr = m - 1;
            if (m == 0) return false;
            for (int i = 0; i < n; i++)
            {
                if (matrix[i][0] > target) break;
                if (matrix[i][m - 1] < target) continue;
                int l = 0, r = mr;
                while (l <= r)
                {
                    int mid = (l + r) / 2,
                        compare = target - matrix[i][mid];
                    if (compare == 0) return true;
                    if (compare < 0) r = (mr = mid) - 1;
                    if (compare > 0) l = mid + 1;
                }
            }
            return false;
        }
    }
}