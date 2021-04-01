package UtilLib;

public class Test {
    public static void run() {
        var head = ListNode.deserialize(Public.readStr());
        System.out.println(ListNode.serialize(head));
    }
}
