using System;

namespace SolutionLib._389
{
    public class Test
    {
        public static void Run()
        {
            string s = Public.ReadStr(),
                t = Public.ReadStr();

            var _s = new Solution2();
            Console.WriteLine(_s.FindTheDifference(s, t));

        }

    }
}