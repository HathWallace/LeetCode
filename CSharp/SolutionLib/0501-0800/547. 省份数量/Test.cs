using System;

namespace SolutionLib._547._省份数量
{
    public class Test
    {
        public static void Run()
        {
            var s = new Solution_BFS();
            Console.WriteLine(s.FindCircleNum(Public.ReadMatrix()));
        }

        /*
         * 测试用例：
         * [[1,1,0],[1,1,0],[0,0,1]]
         * [[1,0,0],[0,1,0],[0,0,1]]
         * [[1,0,0,1],[0,1,1,0],[0,1,1,1],[1,0,1,1]]
         */

    }
}