using System;
using System.Collections.Generic;

namespace SolutionLib
{
    public class Public
    {
        public static string ReadStr()
        {
            Console.WriteLine("输入一个字符串：");
            return ReadLine();
        }

        public static string[] ReadStrs()
        {
            Console.WriteLine("输入一组字符串，以回车结尾：");
            return GetStrings(ReadLine());
        }

        public static int ReadNum()
        {
            Console.WriteLine("输入一个数，以回车结尾：");
            return GetNum(ReadLine());
        }

        public static int[] ReadNums()
        {
            Console.WriteLine("输入一组数，以回车结尾：");
            return GetNums(ReadLine());
        }

        public static int[][] ReadMatrix()
        {
            Console.WriteLine("输入一个二维数组，以回车结尾：");
            return Get2DNums(ReadLine());
        }

        public static ListNode ReadList(int[] nums)
        {
            if (nums.Length == 0) return null;
            var head = new ListNode(nums[0]);
            var pt = head;
            for (int i = 1; i < nums.Length; i++)
            {
                pt.next = new ListNode(nums[i]);
                pt = pt.next;
            }
            return head;
        }

        public static ListNode ReadList()
        {
            return ReadList(ReadNums());
        }

        public static void Print<T>(IEnumerable<T> results)
        {
            bool flag = false;
            Console.Write('[');
            foreach (var result in results)
            {
                if (flag) Console.Write(",");
                Console.Write(result);
                flag = true;
            }
            Console.Write(']');

            Console.WriteLine();
        }

        public static void Print(ListNode head, bool isHead)
        {
            if (head == null)
            {
                Console.Write(isHead ? "链表为空\n" : "");
                return;
            }
            Console.Write((isHead ? "" : "->") + head.val);
            Print(head.next, false);

            if (isHead)
                Console.WriteLine();
        }

        private static string ReadLine()
        {
            return Console.ReadLine();
        }

        private static int GetNum(string str)
        {
            return int.Parse(str);
        }

        private static string[] GetStrings(string str)
        {
            if (str.Length <= 2) return null;
            var res = new List<string>();
            str = str.Substring(1, str.Length - 2);
            foreach (var s in str.Split(','))
            {
                if (s == "") continue;
                res.Add(s);
            }

            return res.ToArray();
        }

        private static int[] GetNums(string str)
        {
            var res = new List<int>();
            if (str.Length <= 2)
                return res.ToArray();
            foreach (var num in GetStrings(str))
                res.Add(GetNum(num));

            return res.ToArray();
        }

        private static int[][] Get2DNums(string str)
        {
            if (str.Length <= 4) return new int[][] { };
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
