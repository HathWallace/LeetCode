package UtilLib;

import java.util.LinkedList;
import java.util.Queue;

public class TreeNode {
    private static TreeNodeCodec codec = new TreeNodeCodec();

    public static String serialize(TreeNode root) {
        return codec.serialize(root);
    }

    public static TreeNode deserialize(String data) {
        return codec.deserialize(data);
    }

    public int val;
    public TreeNode left;
    public TreeNode right;

    public TreeNode(int x, TreeNode l, TreeNode r) {
        val = x;
        left = l;
        right = r;
    }

    public TreeNode(int x) {
        this(x, null, null);
    }

}

/**
 * Definition for a binary tree node.
 * public class TreeNode {
 * int val;
 * TreeNode left;
 * TreeNode right;
 * TreeNode(int x) { val = x; }
 * }
 */
class TreeNodeCodec extends AbsCodec<TreeNode> {
    // Encodes a tree to a single string.
    @Override
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
    @Override
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
