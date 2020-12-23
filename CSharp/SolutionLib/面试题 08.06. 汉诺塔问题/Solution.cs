using System;
using System.Collections.Generic;
using System.Linq;

namespace SolutionLib.面试题_08._06._汉诺塔问题
{
    public class Solution
    {
        class MyClass
        {
            public IList<int> Pillars;
            public string Name;

            public MyClass(IList<int> Pillars, string Name)
            {
                this.Pillars = Pillars;
                this.Name = Name;
            }
        }

        public void Hanota(IList<int> A, IList<int> B, IList<int> C)
        {
            MyClass _A = new MyClass(A, "A"),
                _B = new MyClass(B, "B"),
                _C = new MyClass(C, "C");
            Move(_A, _B, _C);
        }

        private void Move(MyClass A, MyClass B, MyClass C)
        {
            Console.WriteLine($"Move({A.Name},{B.Name},{C.Name})");
            if (A.Pillars.Count == 0) return;
            int big = A.Pillars[0];
            A.Pillars.RemoveAt(0);
            Move(A, C, B);
            C.Pillars.Add(big);
            Console.WriteLine(A.Name + "->" + C.Name);
            Move(B, A, C);
        }
    }
}