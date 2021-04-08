package SolutionLib.剑指_Offer_35._复杂链表的复制;

import java.util.ArrayList;
import java.util.HashMap;
import java.util.List;

/*
// Definition for a Node.
class Node {
    int val;
    Node next;
    Node random;

    public Node(int val) {
        this.val = val;
        this.next = null;
        this.random = null;
    }
}
*/
class Solution {
    public Node copyRandomList(Node head) {
        Node ans = new Node(0), pt = ans;
        HashMap<Node, Integer> hashMap = new HashMap<>();
        List<Node> nodes = new ArrayList<>();
        List<Node> copys = new ArrayList<>();
        while (head != null) {
            pt.next = new Node(head.val);
            pt = pt.next;
            hashMap.put(head, nodes.size());
            nodes.add(head);
            copys.add(pt);
            head = head.next;
        }
        for (int i = 0; i < copys.size(); i++) {
            if (nodes.get(i).random == null) continue;
            int index = hashMap.get(nodes.get(i).random);
            copys.get(i).random = copys.get(index);
        }
        return ans.next;
    }

}