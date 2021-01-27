namespace SolutionLib._2._两数相加
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
        public ListNode AddTwoNumbers(ListNode l1, ListNode l2)
        {
            return AddTwoNumbers(0, l1, l2);
        }

        private ListNode AddTwoNumbers(int advanced, ListNode node1, ListNode node2)
        {
            if (node1 == null && node2 == null)
                return advanced == 0 ? null : new ListNode(advanced);
            int val = advanced + (node1?.val ?? 0) + (node2?.val ?? 0);
            var head = new ListNode(val % 10);
            head.next = AddTwoNumbers(val / 10, node1?.next, node2?.next);
            return head;
        }

    }

    public class _Solution
    {
        public ListNode AddTwoNumbers(ListNode l1, ListNode l2)
        {
            int advanced = 0;
            return Adding(ref advanced, l1, l2);
        }

        private ListNode Adding(ref int advanced, ListNode node1, ListNode node2 = null)
        {
            if (node1 == null) return advanced == 0 ? null : new ListNode(advanced);
            int res = node1.val + advanced;
            if (node2 != null) res += node2.val;
            var node = new ListNode(res % 10);
            advanced = res / 10;
            node.next = node1.next != null
                ? Adding(ref advanced, node1.next, node2?.next)
                : Adding(ref advanced, node2?.next);
            return node;
        }

    }

}