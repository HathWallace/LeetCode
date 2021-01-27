using System.Collections.Generic;

namespace SolutionLib._19._删除链表的倒数第N个节点
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
        public ListNode RemoveNthFromEnd(ListNode head, int n)
        {
            ListNode del = head, delPre = null, pt = head;
            int dist = 0;
            while (pt != null)
            {
                if (dist < n)
                    dist++;
                else
                    del = (delPre = del).next;
                pt = pt.next;
            }
            if (delPre == null) return del.next;
            delPre.next = del.next;
            return head;
        }
    }

    public class _Solution
    {
        public ListNode RemoveNthFromEnd(ListNode head, int n)
        {
            var queue = new Queue<ListNode>();
            var pt = head;
            while (pt != null)
            {
                if (queue.Count > n) queue.Dequeue();
                queue.Enqueue(pt);
                pt = pt.next;
            }
            var node = queue.Dequeue();
            if (queue.Count == n - 1)
                return queue.Count != 0 ? queue.Dequeue() : null;
            if (n == 1)
            {
                node.next = null;
                return head;
            }
            queue.Dequeue();
            node.next = queue.Dequeue();
            return head;
        }
    }
}