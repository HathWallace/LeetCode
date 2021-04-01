package SolutionLib._173._二叉搜索树迭代器;

import UtilLib.TreeNode;

import java.util.ArrayList;
import java.util.Iterator;
import java.util.List;
import java.util.Stack;

/**
 * Definition for a binary tree node.
 * public class TreeNode {
 * int val;
 * TreeNode left;
 * TreeNode right;
 * TreeNode() {}
 * TreeNode(int val) { this.val = val; }
 * TreeNode(int val, TreeNode left, TreeNode right) {
 * this.val = val;
 * this.left = left;
 * this.right = right;
 * }
 * }
 */

public class BSTIterator {
    private Stack<TreeNode> stk;

    public BSTIterator(TreeNode root) {
        stk = new Stack<>();
        while (root != null) {
            stk.push(root);
            root = root.left;
        }
    }

    public int next() {
        var node = stk.pop();
        int ans = node.val;
        node = node.right;
        while (node != null) {
            stk.push(node);
            node = node.left;
        }
        return ans;
    }

    public boolean hasNext() {
        return !stk.isEmpty();
    }
}

class _BSTIterator {
    private Iterator<Integer> iterator;

    public _BSTIterator(TreeNode root) {
        List<Integer> list = new ArrayList<>();
        InOrder(list, root);
        iterator = list.iterator();
    }

    public int next() {
        return iterator.next();
    }

    public boolean hasNext() {
        return iterator.hasNext();
    }

    private void InOrder(List<Integer> list, TreeNode root) {
        if (root == null) return;
        InOrder(list, root.left);
        list.add(root.val);
        InOrder(list, root.right);
    }

}

/**
 * Your BSTIterator object will be instantiated and called as such:
 * BSTIterator obj = new BSTIterator(root);
 * int param_1 = obj.next();
 * boolean param_2 = obj.hasNext();
 */
