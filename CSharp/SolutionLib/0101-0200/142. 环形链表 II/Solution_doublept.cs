namespace SolutionLib._142._环形链表_II
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
    public class Solution_doublept
    {
        public ListNode DetectCycle(ListNode head)
        {
            ListNode fast = head, slow = head, position = null;
            while (fast != null)
            {
                slow = slow.next;
                if (fast.next == null) return null;
                fast = fast.next.next;
                if (fast == slow) break;
            }
            if (fast == slow) position = head;
            while (position != null)
            {
                if (slow == position) return position;
                position = position.next;
                slow = slow.next;
            }
            return null;
        }
    }
}