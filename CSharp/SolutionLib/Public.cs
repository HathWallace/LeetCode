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
            Console.WriteLine("输入一个数，以回车结尾：");
            return GetNum(ReadStr());
        }

        public static int[] ReadNums()
        {
            Console.WriteLine("输入一组数，以回车结尾：");
            return GetNums(ReadStr());
        }

        public static int[][] ReadMatrix()
        {
            Console.WriteLine("输入一个二维数组，以回车结尾：");
            return Get2DNums(ReadStr());
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

        private static int GetNum(string str)
        {
            return int.Parse(str);
        }

        private static int[] GetNums(string str)
        {
            var res = new List<int>();
            str = str.Substring(1, str.Length - 2);
            foreach (var num in str.Split(','))
            {
                if (num == "") continue;
                res.Add(GetNum(num));
            }

            return res.ToArray();
        }

        private static int[][] Get2DNums(string str)
        {
            var res = new List<int[]>();
            str = str.Substring(1, str.Length - 2);
            str = str.Replace("],[", "].[");
            foreach (var nums in str.Split('.'))
            {
                res.Add(GetNums(nums));
            }

            return res.ToArray();
        }

    }
}
