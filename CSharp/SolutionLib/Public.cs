using System;
using System.Collections.Generic;

namespace SolutionLib
{
    public class Public
    {
        public static string ReadStr()
        {
            return Console.ReadLine();
        }

        public static int ReadNum()
        {
            string str = ReadStr();
            int res = 0;
            foreach (var num in str)
            {
                res = res * 10 + num - '0';
            }

            return res;
        }

        public static int[] ReadNums()
        {
            return GetNums(ReadStr());
        }

        public static int[][] ReadMatrix()
        {
            string str = ReadStr();
            var res = new List<int[]>();
            str = str.Substring(1, str.Length - 2);
            str = str.Replace("],[", "].[");
            foreach (var nums in str.Split('.'))
            {
                res.Add(GetNums(nums));
            }

            return res.ToArray();
        }

        public static void PrintNums(int[] nums)
        {
            bool flag = false;
            Console.Write('[');
            foreach (var num in nums)
            {
                if (flag) Console.Write(",");
                Console.Write(num);
                flag = true;
            }
            Console.Write(']');

            Console.WriteLine();
        }

        private static int[] GetNums(string str)
        {
            var res = new List<int>();
            str = str.Substring(1, str.Length - 2);
            foreach (var num in str.Split(','))
            {
                if (num == "") continue;

                res.Add(Int32.Parse(num));
            }

            return res.ToArray();
        }

    }
}
