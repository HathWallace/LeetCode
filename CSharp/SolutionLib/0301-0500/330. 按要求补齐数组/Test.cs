using System;

namespace SolutionLib._330._按要求补齐数组
{
    public class Test
    {
        public static void Run()
        {
            var s = new Solution_greedy();
            Console.WriteLine(s.MinPatches(Public.ReadNums(), Public.ReadNum()));
            //Console.WriteLine(log2(Public.ReadNum()));
            Console.WriteLine(int.MaxValue);
        }

        private static int log2(int n)
        {
            int count = 0, div = 0;
            for (;n>1;n=n>>1)
            {
                count++;
                if (div == 0 && n % 2 != 0) div = 1;
            }
            return count + div;
        }

        /*
         * 测试用例：
         * nums = [1,3], n = 6
         * nums = [1,5,10], n = 20
         * nums = [1,2,2], n = 5
         * nums = [1,2,31,33], n = 2147483647
         */

    }
}