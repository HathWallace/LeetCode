using System.Collections.Generic;

namespace SolutionLib._155._最小栈
{
    public class MinStack
    {
        private List<int> stack = new List<int> { int.MinValue };

        private List<int> heap = new List<int> { 0 };

        /** initialize your data structure here. */
        public MinStack()
        {
        }

        public void Push(int x)
        {
            stack.Add(x);
            heap.Add(stack.Count - 1);
            PermeateUp(heap.Count - 1);
        }

        public void Pop()
        {
            int index = DFS(1, stack.Count - 1);
            heap[index] = heap[heap.Count - 1];
            heap.RemoveAt(heap.Count - 1);
            stack.RemoveAt(stack.Count - 1);
            if (index < heap.Count && Compare(heap[index], heap[index / 2]) < 0)
                PermeateUp(index);
            else
                PermeateDown(index);
        }

        public int Top()
        {
            return stack[stack.Count - 1];
        }

        public int GetMin()
        {
            return stack[heap[1]];
        }

        private int Compare(int i1, int i2)
        {
            return stack[i1] > stack[i2] ? 1 : stack[i1] == stack[i2] ? 0 : -1;
        }

        private int DFS(int parent, int num)
        {
            if (parent >= heap.Count || Compare(heap[parent], num) > 0) return -1;
            if (heap[parent] == num && Compare(heap[parent], num) == 0) return parent;
            int res1 = DFS(parent * 2, num);
            if (res1 != -1) return res1;
            int res2 = DFS(parent * 2 + 1, num);
            return res2;
        }

        private void PermeateUp(int child)
        {
            int parent = child / 2;
            if (Compare(heap[parent], heap[child]) <= 0) return;
            int tmp = heap[child];
            heap[child] = heap[parent];
            heap[parent] = tmp;
            PermeateUp(parent);
        }

        private void PermeateDown(int parent)
        {
            int child = parent * 2;
            if (child >= heap.Count) return;
            if (child + 1 < heap.Count && Compare(heap[child + 1], heap[child]) < 0) child++;
            if (Compare(heap[child], heap[parent]) > 0) return;
            int tmp = heap[parent];
            heap[parent] = heap[child];
            heap[child] = tmp;
            PermeateDown(child);
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