using System;

namespace SolutionLib._32._最长有效括号
{
    public class Test
    {
        public static void Run()
        {
            var s = new Solution_special();
            Console.WriteLine(s.LongestValidParentheses(Public.ReadStr()));
        }

        /*
         * 测试用例：
         * (()
         * )()())
         * ()(()
         * ))))())()()(()
         * ()(())
         * )(())(()()))(
         */

    }
}