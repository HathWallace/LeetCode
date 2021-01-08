using System;

namespace SolutionLib._239._滑动窗口最大值
{
    public class Test
    {
        public static void Run()
        {
            var s=new Solution_deque();
            Public.PrintNums(s.MaxSlidingWindow(Public.ReadNums(), Public.ReadNum()));
        }

        /*
         * 测试用例：
         * nums = [1,3,-1,-3,5,3,6,7], k = 3
         * nums = [1,3,1,2,0,5], k = 3
         */

    }
}