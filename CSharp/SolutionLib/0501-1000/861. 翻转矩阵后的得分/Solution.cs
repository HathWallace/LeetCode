namespace SolutionLib._861._翻转矩阵后的得分
{
    public class Solution
    {
        private int[][] A;

        public int MatrixScore(int[][] A)
        {
            this.A = A;
            return GetMaxScore();
        }

        private int GetMaxScore()
        {
            for (int i = 0; i < A.Length; i++)
            {
                if (A[i][0] == 0)
                    FlipRow(i);
            }

            for (int i = 0; i < A[0].Length; i++)
            {
                int zero = 0, one = 0;
                for (int j = 0; j < A.Length; j++)
                {
                    if (A[j][i] == 0)
                        zero++;
                    else
                        one++;
                }

                if (zero > one) FilpColumn(i);
            }

            int res = 0;
            foreach (var row in A)
            {
                res += GetNum(row);
            }

            return res;
        }

        private void FlipRow(int index)
        {
            for (int i = 0; i < A[index].Length; i++)
            {
                A[index][i] = A[index][i] ^ 1;
            }
        }

        private void FilpColumn(int index)
        {
            for (int i = 0; i < A.Length; i++)
            {
                A[i][index] = A[i][index] ^ 1;
            }
        }

        private int GetNum(int[] num)
        {
            int res = 0;
            foreach (var i in num)
            {
                res = res * 2 + i;
            }

            return res;
        }
    }
}