package SolutionLib.剑指_Offer_35._复杂链表的复制;

class Solution_O1 {
    public Node copyRandomList(Node head) {
        if (head == null) return null;
        Node oldPt = head, newPt, newHead;
        while (oldPt != null) {
            Node newNode = new Node(oldPt.val);
            newNode.next = oldPt.next;
            oldPt.next = newNode;
            oldPt = newNode.next;
        }
        oldPt = head;
        while (oldPt != null) {
            if (oldPt.random != null)
                oldPt.next.random = oldPt.random.next;
            oldPt = oldPt.next.next;
        }
        oldPt = head;
        newPt = newHead = head.next;
        while (oldPt != null) {
            oldPt.next = newPt.next;
            if (newPt.next != null)
                newPt.next = newPt.next.next;
            oldPt = oldPt.next;
            newPt = newPt.next;
        }
        return newHead;
    }
}
