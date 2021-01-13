using System;
using System.Collections.Generic;

namespace SolutionLib._200._岛屿数量
{
    public class Test
    {
        public static void Run()
        {
            var s = new Solution();
            Console.WriteLine(s.NumIslands(ReadMatrix()));
        }

        private static char[][] ReadMatrix()
        {
            string str = Public.ReadStr();
            if (str.Length <= 4) return new char[][] { };
            var res = new List<char[]>();
            str = str.Substring(1, str.Length - 2).Replace("],[", "].[");

            foreach (var chs in str.Split('.'))
            {
                var ires = new List<char>();
                foreach (var ch in chs.Substring(1, chs.Length - 2).Split(','))
                {
                    ires.Add(ch[1]);
                }
                res.Add(ires.ToArray());
            }

            return res.ToArray();
        }

        /*
         * 测试用例：
         */

    }
}