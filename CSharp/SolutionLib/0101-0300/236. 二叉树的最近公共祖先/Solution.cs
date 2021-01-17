namespace SolutionLib._236._二叉树的最近公共祖先
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
        public TreeNode LowestCommonAncestor(TreeNode root, TreeNode p, TreeNode q)
        {
            if (root == null)
                return null;
            if (root == p || root == q)
                return root;
            var leftRes = LowestCommonAncestor(root.left, p, q);
            var rightRes = LowestCommonAncestor(root.right, p, q);
            if (leftRes != null && rightRes != null)
                return root;
            return leftRes ?? rightRes;
        }
    }
}