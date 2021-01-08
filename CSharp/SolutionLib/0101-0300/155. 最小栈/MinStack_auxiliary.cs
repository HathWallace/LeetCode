//https://leetcode-cn.com/problems/min-stack/solution/zui-xiao-zhan-by-leetcode-solution/

using System;
using System.Collections.Generic;

namespace SolutionLib._155._最小栈
{
    //辅助栈方法
    public class MinStack_auxiliary
    {
        private Stack<int> stack = new Stack<int>();

        private Stack<int> minStack = new Stack<int>();

        /** initialize your data structure here. */
        public MinStack_auxiliary()
        {
            minStack.Push(int.MaxValue);
        }

        public void Push(int x)
        {
            stack.Push(x);
            minStack.Push(Math.Min(minStack.Peek(), stack.Peek()));
        }

        public void Pop()
        {
            stack.Pop();
            minStack.Pop();
        }

        public int Top()
        {
            return stack.Peek();
        }

        public int GetMin()
        {
            return minStack.Peek();
        }
    }

    /**
     * Your MinStack object will be instantiated and called as such:
     * MinStack obj = new MinStack();
     * obj.Push(x);
     * obj.Pop();
     * int param_3 = obj.Top();
     * int param_4 = obj.GetMin();
     */
}