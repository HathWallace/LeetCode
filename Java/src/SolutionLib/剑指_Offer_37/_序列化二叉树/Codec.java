package SolutionLib.剑指_Offer_37._序列化二叉树;

import UtilLib.TreeNode;

import java.util.LinkedList;
import java.util.Queue;

/**
 * Definition for a binary tree node.
 * public class TreeNode {
 * int val;
 * TreeNode left;
 * TreeNode right;
 * TreeNode(int x) { val = x; }
 * }
 */
public class Codec {

    // Encodes a tree to a single string.
    public String serialize(TreeNode root) {
        if (root == null) return "[]";
        var dataList = new LinkedList<String>();
        Queue<TreeNode> queue = new LinkedList<>();
        queue.offer(root);
        while (!queue.isEmpty()) {
            var node = queue.poll();
            if (node == null) {
                dataList.add("null");
                continue;
            }
            dataList.add(node.val + "");
            queue.offer(node.left);
            queue.offer(node.right);
        }
        while (dataList.getLast().equals("null")) {
            dataList.removeLast();
        }
        return '[' + String.join(",", dataList) + "]";
    }

    // Decodes your encoded data to tree.
    public TreeNode deserialize(String data) {
        if (data.length() <= 2) return null;
        var split = data.substring(1, data.length() - 1).split(",");
        var root = new TreeNode(Integer.parseInt(split[0]));
        int num = split.length;
        Queue<TreeNode> queue = new LinkedList<>();
        queue.offer(root);
        for (int i = 1; i < num; ) {
            var node = queue.poll();
            if (!split[i].equals("null")) {
                node.left = new TreeNode(Integer.parseInt(split[i]));
                queue.offer(node.left);
            }
            i++;
            if (i < num && !split[i].equals("null")) {
                node.right = new TreeNode(Integer.parseInt(split[i]));
                queue.offer(node.right);
            }
            i++;
        }
        return root;
    }
}

// Your Codec object will be instantiated and called as such:
// Codec codec = new Codec();
// codec.deserialize(codec.serialize(root));