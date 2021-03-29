package SolutionLib.剑指_Offer_24._反转链表;

import SolutionLib.ListNode;

/**
 * Definition for singly-linked list.
 * public class ListNode {
 * int val;
 * ListNode next;
 * ListNode(int x) { val = x; }
 * }
 */
public class Solution {
    public ListNode reverseList(ListNode head) {
        ListNode pre = null, pt = head;
        while (pt != null) {
            var next = pt.next;
            pt.next = pre;
            pre = pt;
            pt = next;
        }
        return pre;
    }
}