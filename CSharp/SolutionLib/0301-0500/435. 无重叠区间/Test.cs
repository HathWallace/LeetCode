using System;

namespace SolutionLib._435._无重叠区间
{
    public class Test
    {
        public static void Run()
        {
            var s=new Solution_greedy();
            Console.WriteLine(s.EraseOverlapIntervals(Public.ReadMatrix()));
        }

        /*
         * 测试用例：
         * [[1,2],[2,3],[3,4],[1,3]]
         * [[1,2],[1,2],[1,2]]
         * [[1,2],[2,3]]
         */

    }
}