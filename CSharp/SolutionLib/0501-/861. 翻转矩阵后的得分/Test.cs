using System;

namespace SolutionLib._861._翻转矩阵后的得分
{
    public class Test
    {
        public static void Run()
        {
            var matrix = Public.ReadMatrix();

            var s = new Solution2();

            Console.WriteLine(s.MatrixScore(matrix));
        }
    }
}