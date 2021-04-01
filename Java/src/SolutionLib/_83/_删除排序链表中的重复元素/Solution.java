package SolutionLib._83._删除排序链表中的重复元素;

import UtilLib.ListNode;

/**
 * Definition for singly-linked list.
 * public class ListNode {
 * int val;
 * ListNode next;
 * ListNode() {}
 * ListNode(int val) { this.val = val; }
 * ListNode(int val, ListNode next) { this.val = val; this.next = next; }
 * }
 */
public class Solution {
    public ListNode deleteDuplicates(ListNode head) {
        var pt = head;
        while (pt != null) {
            var orgin = pt;
            while (pt.next != null && pt.val == pt.next.val) pt = pt.next;
            orgin.next = pt.next;
            pt = pt.next;
        }
        return head;
    }
}