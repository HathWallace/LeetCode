using System;
using SolutionLib._1178._猜字谜;

namespace RunCode
{
    class Program
    {
        static void Main(string[] args)
        {
            string title = typeof(Test)
                .Namespace?
                .Substring("SolutionLib".Length + 1)
                .Replace('_', ' ');
            if (title[0] == ' ') title = title.Substring(1);
            Console.WriteLine(title + '\n');
            do
            {
                try
                {
                    Test.Run();
                    Console.WriteLine("输入回车继续，其他键退出。\n");
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            } while (Console.ReadKey().KeyChar == '\r');
        }

    }
}
