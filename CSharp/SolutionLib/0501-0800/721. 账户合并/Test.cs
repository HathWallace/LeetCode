using System;
using System.Collections.Generic;

namespace SolutionLib._721._账户合并
{
    public class Test
    {
        public static void Run()
        {
            var s = new Solution2();
            string s1 = "john_newyork@mail.com", s2 = "john00@mail.com";
            //Console.WriteLine((int)'_');
            //Console.WriteLine((int)'0');
            //Console.WriteLine((int)'s');
            Console.WriteLine(string.Compare(s1, s2, StringComparison.Ordinal));
            foreach (var list in s.AccountsMerge(ReadMatrix()))
            {
                Public.Print(list);
            }
        }

        private static string[][] ReadMatrix()
        {
            string str = Public.ReadStr();
            var res = new List<string[]>();
            str = str.Substring(1, str.Length - 2).Replace("],[", "]&[");

            foreach (var strs in str.Split('&'))
            {
                var ires = new List<string>();
                foreach (var s in strs.Substring(1, strs.Length - 2).Split(','))
                {
                    ires.Add(s);
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