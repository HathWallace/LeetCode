using System;

namespace SolutionLib._752._打开转盘锁
{
    public class Test
    {
        public static void Run()
        {
            var s = new Solution();
            Console.WriteLine(s.OpenLock(Public.ReadStrs(), Public.ReadStr()));
        }
    }
}