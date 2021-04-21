package SolutionLib2._222._完全二叉树的节点个数;

import UtilLib.TreeNode;

class Solution_binary {
    public int countNodes(TreeNode root) {
        if (root == null) return 0;
        int level = 0;
        TreeNode pt = root;
        while (pt != null) {
            level++;
            pt = pt.left;
        }
        int left = 1 << (level - 1), right = (left << 1) - 1;
        while (left < right) {
            int mid = left + (right - left + 1) / 2;
            if (existNode(root, mid, level)) left = mid;
            else right = mid - 1;
        }
        return left;
    }

    private boolean existNode(TreeNode root, int num, int level) {
        int bits = 1 << (level - 2);
        while (root != null && bits > 0) {
            if ((bits & num) == 0) root = root.left;
            else root = root.right;
            bits >>= 1;
        }
        return root != null;
    }
}
