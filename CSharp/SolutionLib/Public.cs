using System;
using System.Collections.Generic;

namespace SolutionLib
{
    public class Public
    {
        public static int ReadNum()
        {
            string str = Console.ReadLine();
            int res = 0;
            foreach (var num in str)
            {
                res = res * 10 + num - '0';
            }

            return res;
        }

        public static int[] ReadNums()
        {
            string str = Console.ReadLine();
            var res = new List<int>();
            str = str.Substring(1, str.Length - 2);
            foreach (var num in str.Split(','))
            {
                res.Add(Int32.Parse(num));
            }

            return res.ToArray();
        }

        public static void PrintNums(int[] nums)
        {
            bool flag = false;
            foreach (var num in nums)
            {
                if (flag) Console.Write(" ");
                Console.Write(num);
                flag = true;
            }

            Console.WriteLine('\n');
        }
    }
}
