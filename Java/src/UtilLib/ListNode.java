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

    public static ListNode deserialize(String data) {
        ListNode head = new ListNode(), pt = head;
        var split = data.substring(1, data.length() - 1).split(",");
        for (var val : split) {
            pt.next = new ListNode(Integer.parseInt(val));
            pt = pt.next;
        }
        return head.next;
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
