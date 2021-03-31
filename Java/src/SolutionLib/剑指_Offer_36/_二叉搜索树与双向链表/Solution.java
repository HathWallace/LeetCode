package SolutionLib.剑指_Offer_36._二叉搜索树与双向链表;

import SolutionLib.ListNode;

/*
// Definition for a Node.
class Node {
    public int val;
    public Node left;
    public Node right;

    public Node() {}

    public Node(int _val) {
        val = _val;
    }

    public Node(int _val,Node _left,Node _right) {
        val = _val;
        left = _left;
        right = _right;
    }
};
*/
public class Solution {
    public Node treeToDoublyList(Node root) {
        var nodes = treeToList(root);
        if (nodes == null) return null;
        join(nodes[1], nodes[0]);
        return nodes[0];
    }

    private Node[] treeToList(Node root) {
        if (root == null) return null;
        var leftNodes = treeToList(root.left);
        var rightNodes = treeToList(root.right);
        var res = new Node[2];
        if (leftNodes != null) {
            res[0] = leftNodes[0];
            join(leftNodes[1], root);
        } else res[0] = root;
        if (rightNodes != null) {
            res[1] = rightNodes[1];
            join(root, rightNodes[0]);
        } else res[1] = root;
        return res;
    }

    private void join(Node a, Node b) {
        a.right = b;
        b.left = a;
    }

}

class Node {
    public int val;
    public Node left;
    public Node right;

    public Node() {
    }

    public Node(int _val) {
        val = _val;
    }

    public Node(int _val, Node _left, Node _right) {
        val = _val;
        left = _left;
        right = _right;
    }
}