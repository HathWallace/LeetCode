using System;
using System.Collections.Generic;

namespace SolutionLib._239._滑动窗口最大值
{
    //超出时间限制
    public class Solution
    {
        public int[] MaxSlidingWindow(int[] nums, int k)
        {
            var res = new List<int>();
            var heap = new int[k + 1];
            heap[0] = int.MaxValue;
            for (int i = 0; i < nums.Length; i++)
                if (i < k)
                {
                    heap[i + 1] = nums[i];
                    PermeateUp(heap, i + 1);
                    if (i == k - 1) res.Add(heap[1]);
                }
                else
                {
                    int index = FindIndex(heap, 1, nums[i - k], k);
                    heap[index] = nums[i];
                    if (heap[index] > heap[index / 2])
                        PermeateUp(heap, index);
                    else
                        PermeateDown(heap, index, k);
                    res.Add(heap[1]);
                }
            return res.ToArray();
        }

        private void PermeateUp(int[] heap, int child)
        {
            int parent = child / 2;
            if (heap[child] <= heap[parent]) return;
            int tmp = heap[child];
            heap[child] = heap[parent];
            heap[parent] = tmp;
            PermeateUp(heap, parent);
        }

        private void PermeateDown(int[] heap, int parent, int k)
        {
            int child = parent * 2;
            if (child > k) return;
            if (child + 1 <= k && heap[child + 1] > heap[child]) child++;
            if (heap[parent] >= heap[child]) return;
            int tmp = heap[child];
            heap[child] = heap[parent];
            heap[parent] = tmp;
            PermeateDown(heap, child, k);
        }

        private int FindIndex(int[] heap, int parent, int num, int k)
        {
            if (parent > k || heap[parent] < num) return -1;
            if (heap[parent] == num) return parent;
            int i1 = FindIndex(heap, parent * 2, num, k);
            int i2 = FindIndex(heap, parent * 2 + 1, num, k);
            return Math.Max(i1, i2);
        }

    }

    //超出时间限制
    public class ___Solution
    {
        public int[] MaxSlidingWindow(int[] nums, int k)
        {
            var res = new List<int>();
            var heap = new int[k + 1];
            heap[0] = int.MaxValue;
            var dict = new Dictionary<int, int>();
            for (int i = 0; i < nums.Length; i++)
                if (i < k)
                {
                    heap[i + 1] = nums[i];
                    dict[heap[i + 1]] = i + 1;
                    PermeateUp(heap, i + 1);
                    if (i == k - 1) res.Add(heap[1]);
                    dict = GetDict(heap);
                }
                else
                {
                    int index = dict[nums[i - k]];
                    dict.Remove(nums[i - k]);
                    heap[index] = nums[i];
                    dict[heap[index]] = index;
                    if (heap[index] > heap[index / 2])
                        PermeateUp(heap, index);
                    else
                        PermeateDown(heap, index, k);
                    res.Add(heap[1]);
                    dict = GetDict(heap);
                }
            return res.ToArray();
        }

        private void PermeateUp(int[] heap, int child)
        {
            int parent = child / 2;
            if (heap[child] <= heap[parent]) return;
            int tmp = heap[child];
            heap[child] = heap[parent];
            heap[parent] = tmp;
            PermeateUp(heap, parent);
        }

        private void PermeateDown(int[] heap, int parent, int k)
        {
            int child = parent * 2;
            if (child > k) return;
            if (child + 1 <= k && heap[child + 1] > heap[child]) child++;
            if (heap[parent] >= heap[child]) return;
            int tmp = heap[child];
            heap[child] = heap[parent];
            heap[parent] = tmp;
            PermeateDown(heap, child, k);
        }

        private Dictionary<int, int> GetDict(int[] heap)
        {
            var dict = new Dictionary<int, int>();
            for (int i = 0; i < heap.Length; i++)
            {
                dict[heap[i]] = i;
            }
            return dict;
        }
    }

    //执行出错
    public class __Solution
    {
        public int[] MaxSlidingWindow(int[] nums, int k)
        {
            var res = new List<int>();
            var heap = new int[k + 1];
            heap[0] = int.MaxValue;
            var dict = new Dictionary<int, int>();
            for (int i = 0; i < nums.Length; i++)
                if (i < k)
                {
                    heap[i + 1] = nums[i];
                    dict[heap[i + 1]] = i + 1;
                    PermeateUp(heap, i + 1, dict);
                    if (i == k - 1) res.Add(heap[1]);
                }
                else
                {
                    int index = dict[nums[i - k]];
                    dict.Remove(nums[i - k]);
                    heap[index] = nums[i];
                    dict[heap[index]] = index;
                    if (heap[index] > heap[index / 2])
                        PermeateUp(heap, index, dict);
                    else
                        PermeateDown(heap, index, k, dict);
                    res.Add(heap[1]);
                }
            return res.ToArray();
        }

        private void PermeateUp(int[] heap, int child, Dictionary<int, int> dict)
        {
            int parent = child / 2;
            if (heap[child] <= heap[parent]) return;
            int tmp = heap[child];
            heap[child] = heap[parent];
            heap[parent] = tmp;
            dict[heap[child]] = child;
            dict[heap[parent]] = parent;
            PermeateUp(heap, parent, dict);
        }

        private void PermeateDown(int[] heap, int parent, int k, Dictionary<int, int> dict)
        {
            int child = parent * 2;
            if (child > k) return;
            if (child + 1 <= k && heap[child + 1] > heap[child]) child++;
            if (heap[parent] >= heap[child]) return;
            int tmp = heap[child];
            heap[child] = heap[parent];
            heap[parent] = tmp;
            dict[heap[child]] = child;
            dict[heap[parent]] = parent;
            PermeateDown(heap, child, k, dict);
        }

    }

    public class _Solution
    {
        private class MaxHeap
        {
            private List<int> heap = new List<int> { int.MaxValue };

            public int Count => heap.Count - 1;

            public int Peek => heap[1];

            private void PermeateUp(int child)
            {
                int parent = child / 2;
                if (heap[child] <= heap[parent]) return;
                int tmp = heap[child];
                heap[child] = heap[parent];
                heap[parent] = tmp;
                PermeateUp(parent);
            }

            private void PermeateDown(int parent)
            {
                int child = parent * 2;
                if (child > Count) return;
                if (child + 1 <= Count && heap[child + 1] > heap[child]) child++;
                if (heap[parent] >= heap[child]) return;
                int tmp = heap[child];
                heap[child] = heap[parent];
                heap[parent] = tmp;
                PermeateDown(child);
            }

            public void Push(int num)
            {
                heap.Add(num);
                PermeateUp(Count);
            }

            public int Pop()
            {
                int res = heap[1];
                heap[1] = heap[Count];
                heap.RemoveAt(Count);
                PermeateDown(1);
                return res;
            }

        }

        public int[] MaxSlidingWindow(int[] nums, int k)
        {
            var res = new List<int>();
            var heap = new MaxHeap();

            for (int i = 0; i < nums.Length; i++)
            {
                if (heap.Count < k) heap.Push(nums[i]);
                else
                {
                    res.Add(heap.Peek);
                }
            }

            return res.ToArray();
        }
    }

}