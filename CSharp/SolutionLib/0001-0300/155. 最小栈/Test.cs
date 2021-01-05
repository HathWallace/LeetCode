using System;

namespace SolutionLib._155._最小栈
{
    public class Test
    {
        public static void Run()
        {
            var obj = new MinStack_auxiliary();
            obj.Push(2);
            obj.Push(0);
            obj.Push(3);
            obj.Push(0);
            Console.WriteLine(obj.GetMin());
            obj.Pop();
            Console.WriteLine(obj.GetMin());
            obj.Pop();
            Console.WriteLine(obj.GetMin());
            obj.Pop();
            Console.WriteLine(obj.GetMin());
        }

        /*
         * 测试用例：
         */

    }
}