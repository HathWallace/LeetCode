using System;

namespace SolutionLib._1202._交换字符串中的元素
{
    public class Test
    {
        public static void Run()
        {
            var s = new Solution_unionfind();
            Console.WriteLine(s.SmallestStringWithSwaps(Public.ReadStr(), Public.ReadMatrix()));
        }

        /*
         * 测试用例：
         * dcab,[[0,3],[1,2]]
         * dcab,[[0,3],[1,2],[0,2]]
         * cba,[[0,1],[1,2]]
         */

    }
}