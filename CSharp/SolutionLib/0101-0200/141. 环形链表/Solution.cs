namespace SolutionLib._141._环形链表
{
    /**
     * Definition for singly-linked list.
     * public class ListNode {
     *     public int val;
     *     public ListNode next;
     *     public ListNode(int x) {
     *         val = x;
     *         next = null;
     *     }
     * }
     */
    public class Solution
    {
        public bool HasCycle(ListNode head)
        {
            ListNode pt1 = head, pt2 = head;
            while (pt2 != null)
            {
                pt1 = pt1.next;
                pt2 = pt2.next?.next;
                if (pt1 == pt2) return pt1 != null;
            }
            return false;
        }
    }
}