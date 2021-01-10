using System;
using System.Collections.Generic;

namespace SolutionLib.面试题_08._06._汉诺塔问题
{
    public class Test
    {
        public static void Run()
        {
            var s = new Solution2();
            var A = new List<int> {3, 2, 1, 0};
            var B = new List<int>();
            var C = new List<int>();
            s.Hanota(A, B, C);
            //Move('A', 'B', 'C', 4);
            Public.Print(A.ToArray());
            Public.Print(B.ToArray());
            Public.Print(C.ToArray());
        }

        static void Move(char a, char b, char c, int num)
        {
            if (num == 0) return;
            Move(a, c, b, num - 1);
            Console.WriteLine(a + "->" + c);
            Move(b, a, c, num - 1);
        }
    }
}