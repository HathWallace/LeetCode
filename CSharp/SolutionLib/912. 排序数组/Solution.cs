using System;

namespace SolutionLib._912._排序数组
{
    public class Solution
    {
        public int[] SortArray(int[] nums)
        {
            for (int i = 0; i < nums.Length; i++)
            {
                for (int j = i; j > 0 && nums[(j - 1) / 2] < nums[j]; j = (j - 1) / 2)
                {
                    int tmp = nums[j];
                    nums[j] = nums[(j - 1) / 2];
                    nums[(j - 1) / 2] = tmp;
                }
            }
            for (int length = nums.Length - 1; length > 0; length--)
            {
                int tmp = nums[length];
                nums[length] = nums[0];
                nums[0] = tmp;
                for (int i = 0; 2 * i + 1 < length;)
                {
                    int child = 2 * i + 1;
                    if (child + 1 < length && nums[child + 1] > nums[child]) child++;
                    if (nums[i] < nums[child])
                    {
                        int _tmp = nums[child];
                        nums[child] = nums[i];
                        nums[i] = _tmp;
                        i = child;
                    }
                    else
                        break;
                }
            }
            return nums;
        }
    }

    public class _Solution
    {
        private class MinHeap
        {
            public int[] heap = new int[1] { int.MinValue };

            private int length = 0;

            private int maxLen = 1;

            private void DoubleSpace()
            {
                var tmp = new int[maxLen *= 2];
                Array.Copy(heap, tmp, length + 1);
                heap = tmp;
            }

            private void PermeateUp()
            {
                for (int i = length; heap[i / 2] > heap[i]; i /= 2)
                {
                    int tmp = heap[i / 2];
                    heap[i / 2] = heap[i];
                    heap[i] = tmp;
                }
            }

            private void PermeateDown()
            {
                for (int i = 1; 2 * i <= length;)
                {
                    int child = 2 * i;
                    if (child + 1 <= length && heap[child] > heap[child + 1]) child++;
                    if (heap[i] > heap[child])
                    {
                        int tmp = heap[child];
                        heap[child] = heap[i];
                        heap[i] = tmp;
                        i = child;
                    }
                    else
                        break;
                }
            }

            public void Push(int num)
            {
                if (length >= maxLen - 1) DoubleSpace();
                heap[++length] = num;
                PermeateUp();
            }

            public int Pop()
            {
                int res = heap[1];
                heap[1] = heap[length];
                length--;
                PermeateDown();
                return res;
            }
        }

        public int[] SortArray(int[] nums)
        {
            var heap = new MinHeap();
            for (int i = 0; i < nums.Length; i++)
            {
                heap.Push(nums[i]);
            }
            for (int i = 0; i < nums.Length; i++)
            {
                nums[i] = heap.Pop();
            }
            return nums;
        }
    }
}