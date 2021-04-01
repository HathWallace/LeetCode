package UtilLib;

import SolutionLib.剑指_Offer_37._序列化二叉树.Codec;

import java.util.StringJoiner;

public class ListNode {
    private static ListNodeCodec codec = new ListNodeCodec();

    public static String serialize(ListNode head) {
        return codec.serialize(head);
    }

    public static ListNode deserialize(String data) {
        return codec.deserialize(data);
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

class ListNodeCodec extends AbsCodec<ListNode> {
    @Override
    public String serialize(ListNode root) {
        var sj = new StringJoiner(",", "[", "]");
        var pt = root;
        while (pt != null) {
            sj.add(pt.val + "");
            pt = pt.next;
        }
        return sj.toString();
    }

    @Override
    public ListNode deserialize(String data) {
        ListNode head = new ListNode(), pt = head;
        var split = data.substring(1, data.length() - 1).split(",");
        for (var val : split) {
            pt.next = new ListNode(Integer.parseInt(val));
            pt = pt.next;
        }
        return head.next;
    }

}