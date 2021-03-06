namespace SolutionLib._114._二叉树展开为链表
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
    public class Solution
    {
        public void Flatten(TreeNode root)
        {
            if (root == null) return;
            Flatten(root.left);
            Flatten(root.right);
            if (root.left == null) return;
            var last = root.left;
            while (last.right != null)
                last = last.right;
            last.right = root.right;
            root.right = root.left;
            root.left = null;
        }
    }
}