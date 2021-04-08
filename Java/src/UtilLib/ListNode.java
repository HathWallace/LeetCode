package UtilLib;

import java.util.StringJoiner;

public class ListNode {
    public static String serialize(ListNode head) {
        var sj = new StringJoiner(",", "[", "]");
        var pt = head;
        while (pt != null) {
            sj.add(pt.val + "");
            pt = pt.next;
        }
        return sj.toString();
    }

    public int val;
    public ListNode next;

    public ListNode() {
        this(-1);
    }

    public ListNode(int val) {
        this(val, null);
    }

    public ListNode(int val, ListNode next) {
        this.val = val;
        this.next = next;
    }

}
