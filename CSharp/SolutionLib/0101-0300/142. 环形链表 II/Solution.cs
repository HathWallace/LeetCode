using System.Collections.Generic;

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

    public class Solution
    {
        public ListNode DetectCycle(ListNode head)
        {
            var pt = head;
            while (pt!=null)
            {
                if (pt.val == int.MaxValue) return pt;
                pt.val = int.MaxValue;
                pt = pt.next;
            }
            return null;
        }
    }

    public class _Solution
    {
        public ListNode DetectCycle(ListNode head)
        {
            var set = new HashSet<ListNode>();
            var pt = head;
            while (pt != null)
            {
                if (!set.Add(pt))
                    return pt;
                pt = pt.next;
            }
            return null;
        }
    }
}