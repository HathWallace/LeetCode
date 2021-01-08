using System;

namespace SolutionLib._22._括号生成
{
    public class Test
    {
        public static void Run()
        {
            var s = new Solution_backtrack();
            foreach (var str in s.GenerateParenthesis(Public.ReadNum()))
            {
                Console.WriteLine(str);
            }
        }

        /*
         * 测试用例：
         */

    }
}