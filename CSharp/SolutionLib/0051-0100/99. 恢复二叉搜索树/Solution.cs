using System.Collections.Generic;

namespace SolutionLib._99._恢复二叉搜索树
{
    /**
     * Definition for a binary tree node.
     * public class TreeNode {
     *     public int val;
     *     public TreeNode left;
     *     public TreeNode right;
     *     public TreeNode(int val=0, TreeNode left=null, TreeNode right=null) {
     *         this.val = val;
     *         this.left = left;
     *         this.right = right;
     *     }
     * }
     */
    public class Solution2
    {
        private TreeNode pre = null;
        private TreeNode wrong1 = null;
        private TreeNode wrong2 = null;

        public void RecoverTree(TreeNode root)
        {
            Travel(root);

            int tmp = wrong1.val;
            wrong1.val = wrong2.val;
            wrong2.val = tmp;
        }

        private void Travel(TreeNode root)
        {
            if (root == null) return;
            Travel(root.left);
            if (pre != null && pre.val > root.val)
            {
                if (wrong1 == null)
                {
                    wrong1 = pre;
                    wrong2 = root;
                }
                else
                {
                    wrong2 = root;
                    return;
                }
            }
            pre = root;
            Travel(root.right);
        }

    }

    public class Solution
    {
        public void RecoverTree(TreeNode root)
        {
            var list = new List<TreeNode>();
            Travel(root, list);
            TreeNode pre = null, wrong1 = null, wrong2 = null;
            foreach (var node in list)
            {
                if (pre != null && pre.val > node.val)
                {
                    if (wrong1 == null)
                    {
                        wrong1 = pre;
                        wrong2 = node;
                    }
                    else
                    {
                        wrong2 = node;
                        break;
                    }
                }
                pre = node;
            }

            int tmp = wrong1.val;
            wrong1.val = wrong2.val;
            wrong2.val = tmp;
        }

        private void Travel(TreeNode root, List<TreeNode> list)
        {
            if (root == null) return;
            Travel(root.left, list);
            list.Add(root);
            Travel(root.right, list);
        }

    }
}