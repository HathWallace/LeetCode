using System;

namespace SolutionLib._205._同构字符串
{
    public class Test
    {
        public static void Run()
        {
            var s = new Solution();
            Console.WriteLine(s.IsIsomorphic(Public.ReadStr(), Public.ReadStr()));
        }
    }
}