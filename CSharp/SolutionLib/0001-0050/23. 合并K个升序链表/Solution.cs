using System.Collections.Generic;

namespace SolutionLib._23._合并K个升序链表
{
    /**
     * Definition for singly-linked list.
     * public class ListNode {
     *     public int val;
     *     public ListNode next;
     *     public ListNode(int val=0, ListNode next=null) {
     *         this.val = val;
     *         this.next = next;
     *     }
     * }
     */
    public class Solution
    {
        private class MinHeap
        {
            private List<ListNode> heap = new List<ListNode>
            {
                new ListNode(int.MinValue),
            };

            public int Length => heap.Count - 1;

            private void PermeateUp(int child)
            {
                int parent = child / 2;
                if (heap[parent].val <= heap[child].val) return;
                ListNode tmp = heap[parent];
                heap[parent] = heap[child];
                heap[child] = tmp;
                PermeateUp(parent);
            }

            private void PermeateDown(int parent)
            {
                int child = parent * 2;
                if (child > Length) return;
                if (child + 1 <= Length && heap[child + 1].val < heap[child].val)
                    child++;
                if (heap[parent].val <= heap[child].val) return;
                ListNode tmp = heap[parent];
                heap[parent] = heap[child];
                heap[child] = tmp;
                PermeateDown(child);
            }

            public void Push(ListNode node)
            {
                if (node == null) return;
                heap.Add(node);
                PermeateUp(Length);
            }

            public ListNode Pop()
            {
                if (Length < 1) return null;
                var res = heap[1];
                heap[1] = heap[Length];
                heap.RemoveAt(Length);
                PermeateDown(1);
                return res;
            }

        }

        public ListNode MergeKLists(ListNode[] lists)
        {
            var heap = new MinHeap();
            foreach (var list in lists)
                heap.Push(list);
            return MergeKLists(heap);
        }

        private ListNode MergeKLists(MinHeap heap)
        {
            var node = heap.Pop();
            if (node == null) return null;
            if (heap.Length == 0) return node;
            var head = node;
            heap.Push(node.next);
            head.next = MergeKLists(heap);
            return head;
        }

    }
}