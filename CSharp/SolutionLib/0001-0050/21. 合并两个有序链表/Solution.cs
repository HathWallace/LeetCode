namespace SolutionLib._21._合并两个有序链表
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
        public ListNode MergeTwoLists(ListNode l1, ListNode l2)
        {
            return Merge(l1, l2);
        }

        private ListNode Merge(ListNode l1, ListNode l2)
        {
            if (l1 == null || l2 == null)
                return l1 != null ? l1 : l2;
            if (l1.val > l2.val)
                return Merge(l2, l1);
            l1.next = Merge(l1.next, l2);
            return l1;
        }
    }
}