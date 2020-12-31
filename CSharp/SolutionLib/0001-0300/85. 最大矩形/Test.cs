using System;
using System.Collections.Generic;
using IronPython.Hosting;
using Microsoft.Scripting.Hosting;

namespace SolutionLib._85._最大矩形
{
    public class Test
    {
        public static void Run()
        {
            var s = new Solution_leetcode();
            var matrix = ReadMatrix();

            foreach (var row in matrix)
            {
                foreach (var ch in row)
                {
                    Console.Write(ch.ToString() + ' ');
                }
                Console.Write('\n');
            }

            Console.WriteLine(s.MaximalRectangle(matrix));
        }

        private static char[][] ReadMatrix()
        {
            string str = Public.ReadStr();
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

    }
}