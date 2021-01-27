namespace SolutionLib._86._分隔链表
{
    /**
     * Definition for singly-linked list.
     * public class ListNode {
     *     public int val;
     *     public ListNode next;
     *     public ListNode(int x) { val = x; }
     * }
     */
    public class Solution
    {
        public ListNode Partition(ListNode head, int x)
        {
            ListNode pt = head, insertPos = null, pre = null;
            bool flag = false;
            while (pt != null)
            {
                if (!flag || pt.val >= x)
                {
                    if (!flag && pt.val >= x)
                    {
                        insertPos = pre;
                        flag = true;
                    }
                    pre = pt;
                    pt = pt.next;
                    continue;
                }
                if (insertPos != null)
                {
                    var tmp = pt;
                    var tmp2 = insertPos.next;
                    pt = pt.next;
                    pre.next = tmp.next;
                    insertPos.next = tmp;
                    tmp.next = tmp2;
                    insertPos = insertPos.next;
                }
                else
                {
                    var tmp = pt;
                    pt = pt.next;
                    pre.next = tmp.next;
                    tmp.next = head;
                    head = tmp;
                    insertPos = head;
                }
            }
            return head;
        }
    }
}