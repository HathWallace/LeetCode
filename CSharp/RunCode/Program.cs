using System;
using SolutionLib._724._寻找数组的中心索引;

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
                Test.Run();
                Console.WriteLine("输入回车继续，其他键退出。\n");
            } while (Console.ReadKey().KeyChar == '\r');
        }

    }
}
