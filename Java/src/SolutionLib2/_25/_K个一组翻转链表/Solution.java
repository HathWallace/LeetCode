package SolutionLib2._25._K个一组翻转链表;

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
class Solution {
    public ListNode reverseKGroup(ListNode head, int k) {
        ListNode ans = new ListNode(-1, head), pt = ans;
        int len = getLength(head);
        while (len >= k) {
            pt = reverseList(pt, k);
            len -= k;
        }
        return ans.next;
    }

    private int getLength(ListNode head) {
        int len = 0;
        while (head != null) {
            head = head.next;
            len++;
        }
        return len;
    }

    private ListNode reverseList(ListNode head, int k) {
        ListNode pre = head.next, next = pre.next, tail = pre;
        while (k > 1) {
            ListNode tmp = next.next;
            next.next = pre;
            pre = next;
            next = tmp;
            k--;
        }
        head.next = pre;
        tail.next = next;
        return tail;
    }

}
