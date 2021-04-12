package SolutionLib2._25._K个一组翻转链表;

import UtilLib.ACM_IO;
import UtilLib.ListNode;

public class Test {
    private ACM_IO io;

    public Test(ACM_IO io) {
        this.io = io;
    }

    public void run() {
        var s = new Solution();
        var head = ListNode.deserialize(io.getStr());
        var res = s.reverseKGroup(head, io.getNum());
        io.println(ListNode.serialize(res));
    }

}
