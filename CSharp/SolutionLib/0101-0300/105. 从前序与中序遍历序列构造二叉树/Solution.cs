using System.Collections.Generic;

namespace SolutionLib._105._从前序与中序遍历序列构造二叉树
{
    /**
     * Definition for a binary tree node.
     * public class TreeNode {
     *     public int val;
     *     public TreeNode left;
     *     public TreeNode right;
     *     public TreeNode(int x) { val = x; }
     * }
     */
    public class Solution
    {
        private int[] preorder;
        private int[] inorder;
        private Dictionary<int, int> dict = new Dictionary<int, int>();

        public TreeNode BuildTree(int[] preorder, int[] inorder)
        {
            this.preorder = preorder;
            this.inorder = inorder;
            for (int i = 0; i < inorder.Length; i++)
                dict[inorder[i]] = i;

            return BuildTree(0, 0, preorder.Length);
        }

        private TreeNode BuildTree(int preI, int inI, int num)
        {
            if (num <= 0)
                return null;
            if (num == 1)
                return new TreeNode(preorder[preI]);
            var root = new TreeNode(preorder[preI]);
            int leftN = dict[root.val] - inI;
            root.left = BuildTree(preI + 1, inI, leftN);
            root.right = BuildTree(preI + 1 + leftN, inI + leftN + 1, num - leftN - 1);
            return root;
        }

    }
}