using System;

namespace SolutionLib._1631._最小体力消耗路径
{
    public class Test
    {
        public static void Run()
        {
            var s = new Solution();
            var test = Public.ReadMatrix();
            Console.WriteLine(s.MinimumEffortPath(test));
            foreach (var nums in test)
            {
                Public.Print(nums);
            }
        }

        /*
         * 测试用例：
         */

    }
}