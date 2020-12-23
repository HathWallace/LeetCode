﻿using System;
using SolutionLib._72._编辑距离;

namespace RunCode
{
    class Program
    {
        private static string Title => typeof(Test)
            .Namespace
            .Substring("SolutionLib".Length + 1)
            .Replace('_', ' ');

        static void Main(string[] args)
        {
            Console.WriteLine(Title + '\n');
            do
            {
                Test.Run();
                Console.WriteLine("输入回车继续，其他键退出。\n");
            } while (Console.ReadKey().KeyChar == '\r');
        }

    }
}
