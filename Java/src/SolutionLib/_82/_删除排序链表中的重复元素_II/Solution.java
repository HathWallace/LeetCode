package SolutionLib._82._删除排序链表中的重复元素_II;

import UtilLib.ListNode;

/**
 * Definition for singly-linked list.
 * public class UtilLib.ListNode {
 * int val;
 * UtilLib.ListNode next;
 * UtilLib.ListNode() {}
 * UtilLib.ListNode(int val) { this.val = val; }
 * UtilLib.ListNode(int val, UtilLib.ListNode next) { this.val = val; this.next = next; }
 * }
 */
public class Solution {
    public ListNode deleteDuplicates(ListNode head) {
        ListNode pt = head, pre = null;
        while (pt != null) {
            var orign = pt;
            while (pt.next != null && pt.val == pt.next.val)
                pt = pt.next;
            if (orign != pt) {
                if (pre == null) head = pt.next;
                else pre.next = pt.next;
            } else pre = pt;
            pt = pt.next;
        }
        return head;
    }
}