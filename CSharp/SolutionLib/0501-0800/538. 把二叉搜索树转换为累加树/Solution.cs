namespace SolutionLib._538._把二叉搜索树转换为累加树
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
        public TreeNode ConvertBST(TreeNode root)
        {
            int add = 0;
            GreaterSumTree(root, ref add);
            return root;
        }

        private void GreaterSumTree(TreeNode root, ref int add)
        {
            if (root == null) return;
            GreaterSumTree(root.right, ref add);
            add = root.val += add;
            GreaterSumTree(root.left, ref add);
        }
    }

}