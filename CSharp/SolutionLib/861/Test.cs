using System;

namespace SolutionLib._861
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