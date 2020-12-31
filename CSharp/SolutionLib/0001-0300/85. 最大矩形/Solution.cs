using System;

namespace SolutionLib._85._最大矩形
{
    public class Solution//超出时间限制
    {
        private bool Check(char[][] matrix, int begi, int begj, int w, int h)
        {
            for (int i = begi; i < begi + h; i++)
                for (int j = begj; j < begj + w; j++)
                    if (matrix[i][j] != '1') return false;
            return true;
        }

        public int MaximalRectangle(char[][] matrix)
        {
            if (matrix.Length == 0) return 0;
            int m = matrix.Length, n = matrix[0].Length;
            int res = 0;
            for (int w = n; w > 0; w--)
            {
                if (res >= w * m) break;
                for (int h = m; h > 0; h--)
                {
                    if (res >= w * h) continue;
                    for (int i = 0; i <= m-h; i++)
                    {
                        bool flag = false;
                        for (int j = 0; j <= n-w; j++)
                        {
                            if (Check(matrix, i, j, w, h))
                            {
                                res = w * h;
                                flag = true;
                                break;
                            }
                        }
                        if (flag) break;
                    }
                }
            }
            return res;
        }
    }

    public class _Solution
    {
        private bool TravelLine(char[][] matrix, int begi, int begj, int len, bool isRow)
        {
            for (int k = 0; k < len; k++)
                if (matrix[begi + (isRow ? 0 : k)][begj + (isRow ? k : 0)] == '0')
                    return false;
            return true;
        }

        public int MaximalRectangle(char[][] matrix)
        {
            if (matrix.Length == 0) return 0;
            int m = matrix.Length, n = matrix[0].Length;
            int res = 0;
            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (matrix[i][j] == '0') continue;
                    int w = 1, h = 1;
                    bool stopw = false, stoph = false;
                    while (!(stopw && stoph))
                    {
                        stopw = stopw || j + w >= n || !TravelLine(matrix, i, j + w, h, false);
                        stoph = stoph || i + h >= m || !TravelLine(matrix, i + h, j, w, true);
                        if (!stopw && stoph)
                        {
                            w++;
                        }
                        if (stopw && !stoph)
                        {
                            h++;
                        }
                        if (!stopw && !stoph)
                            if (matrix[i + h][j + w] == '0')
                                stopw = stoph = true;
                            else
                            {
                                w++;
                                h++;
                            }
                    }
                    res = Math.Max(res, w * h);
                }
            }
            return res;
        }
    }

}