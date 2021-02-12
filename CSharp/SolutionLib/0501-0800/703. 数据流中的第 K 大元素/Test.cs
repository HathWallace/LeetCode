using System;

namespace SolutionLib._703._数据流中的第_K_大元素
{
    public class Test
    {
        public static void Run()
        {
            var s = new KthLargest(Public.ReadNum(), Public.ReadNums());
            Console.WriteLine(s.Add(3));
            Console.WriteLine(s.Add(2));
            Console.WriteLine(s.Add(3));
        }
    }
}