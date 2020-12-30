using System;

namespace SolutionLib._1046._最后一块石头的重量
{
    public class Solution
    {
        private class MaxHeap
        {
            private int[] heap = { int.MaxValue };

            private int length = 0;

            public int Length => length;

            private void DoubleSpace()
            {
                var tmp = new int[heap.Length * 2];
                Array.Copy(heap, tmp, length + 1);
                heap = tmp;
            }

            private void PremeateUp(int index)
            {
                if (heap[index] <= heap[index / 2]) return;
                int tmp = heap[index];
                heap[index] = heap[index / 2];
                heap[index / 2] = tmp;
                PremeateUp(index / 2);
            }

            private void PremeateDown(int parent)
            {
                if (parent == 0 || parent * 2 > length) return;
                int child = parent * 2;
                if (child + 1 <= length && heap[child + 1] > heap[child]) child++;
                if (heap[child] <= heap[parent]) return;
                int tmp = heap[child];
                heap[child] = heap[parent];
                heap[parent] = tmp;
                PremeateDown(child);
            }

            public void Push(int num)
            {
                if (length + 1 >= heap.Length) DoubleSpace();
                heap[++length] = num;
                PremeateUp(length);
            }

            public int Pop()
            {
                int res = heap[1];
                heap[1] = heap[length--];
                PremeateDown(1);
                return res;
            }

        }

        public int LastStoneWeight(int[] stones)
        {
            var heap = new MaxHeap();
            for (int i = 0; i < stones.Length; i++)
                heap.Push(stones[i]);
            while (heap.Length > 1)
            {
                int y = heap.Pop(), x = heap.Pop();
                if (x == y) continue;
                heap.Push(y - x);
            }
            return heap.Length >= 1 ? heap.Pop() : 0;
        }
    }
}