using System;
using System.Collections.Generic;

namespace SolutionLib._703._数据流中的第_K_大元素
{
    public class KthLargest2
    {
        private class Heap
        {
            private Comparison<int> higher;
            private List<int> heap = new List<int>();
            private int count => heap.Count;

            public Heap(int[] nums = null)
            {
                higher = (a, b) => { return b.CompareTo(a); };
                heap.Add(higher(0, 1) > 0 ? int.MinValue : int.MaxValue);
                if (nums == null) return;
                heap.AddRange(nums);
                for (int i = 1; i < count; i++)
                    PermeateUp(i);
            }

            public void Push(int item)
            {
                heap.Add(item);
                PermeateUp(count - 1);
            }

            public int Pop()
            {
                int top = heap[1];
                heap[1] = heap[count - 1];
                heap.RemoveAt(count - 1);
                PermeateDown(1);
                return top;
            }

            public int Peek()
            {
                return heap[1];
            }

            public int Count()
            {
                return count - 1;
            }

            private void PermeateUp(int child)
            {
                int parent = child / 2;
                if (higher(heap[parent], heap[child]) >= 0) return;
                int tmp = heap[parent];
                heap[parent] = heap[child];
                heap[child] = tmp;
                PermeateUp(parent);
            }

            private void PermeateDown(int parent)
            {
                int child = parent * 2;
                if (child >= count)
                    return;
                if (child + 1 < count && higher(heap[child + 1], heap[child]) >= 0)
                    child++;
                if (higher(heap[parent], heap[child]) >= 0) return;
                int tmp = heap[parent];
                heap[parent] = heap[child];
                heap[child] = tmp;
                PermeateDown(child);
            }

        }

        private int k;
        private Heap kHeap;

        public KthLargest2(int k, int[] nums)
        {
            this.k = k;
            kHeap = new Heap(nums);
            for (int i = 0; i < nums.Length - k; i++)
                kHeap.Pop();
        }

        public int Add(int val)
        {
            kHeap.Push(val);
            if (kHeap.Count() > k) kHeap.Pop();
            return kHeap.Peek();
        }

    }


    public class KthLargest
    {
        private class Heap
        {
            private Comparison<int> higher;
            private List<int> heap = new List<int>();
            private int count => heap.Count;

            public Heap(bool isMaxHeap, int[] nums = null)
            {
                if (isMaxHeap)
                    higher = (a, b) => { return a.CompareTo(b); };
                else
                    higher = (a, b) => { return b.CompareTo(a); };
                heap.Add(higher(0, 1) > 0 ? int.MinValue : int.MaxValue);
                if (nums == null) return;
                heap.AddRange(nums);
                for (int i = 1; i < count; i++)
                    PermeateUp(i);
            }

            public void Push(int item)
            {
                heap.Add(item);
                PermeateUp(count - 1);
            }

            public int Pop()
            {
                int top = heap[1];
                heap[1] = heap[count - 1];
                heap.RemoveAt(count - 1);
                PermeateDown(1);
                return top;
            }

            public int Peek()
            {
                return heap[1];
            }

            private void PermeateUp(int child)
            {
                int parent = child / 2;
                if (higher(heap[parent], heap[child]) >= 0) return;
                int tmp = heap[parent];
                heap[parent] = heap[child];
                heap[child] = tmp;
                PermeateUp(parent);
            }

            private void PermeateDown(int parent)
            {
                int child = parent * 2;
                if (child >= count)
                    return;
                if (child + 1 < count && higher(heap[child + 1], heap[child]) >= 0)
                    child++;
                if (higher(heap[parent], heap[child]) >= 0) return;
                int tmp = heap[parent];
                heap[parent] = heap[child];
                heap[child] = tmp;
                PermeateDown(child);
            }

        }

        private Heap remain_heap;
        private Heap k_1_heap;

        public KthLargest(int k, int[] nums)
        {
            remain_heap = new Heap(true, nums);
            k_1_heap = new Heap(false);
            for (int i = 0; i < k - 1; i++)
                k_1_heap.Push(remain_heap.Pop());
        }

        public int Add(int val)
        {
            k_1_heap.Push(val);
            remain_heap.Push(k_1_heap.Pop());
            return remain_heap.Peek();
        }

    }

    /**
     * Your KthLargest object will be instantiated and called as such:
     * KthLargest obj = new KthLargest(k, nums);
     * int param_1 = obj.Add(val);
     */
}