using System.Collections.Generic;

namespace SolutionLib
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
        public IList<TreeNode> GenerateTrees(int n)
        {
            var dp = new List<List<TreeNode>>();
            dp.Add(new List<TreeNode> { null });
            for (int i = 1; i <= n; i++)
            {
                var tmp = new List<TreeNode>();
                for (int j = 1; j <= i; j++)
                    foreach (var _rightNode in dp[i - j])
                    {
                        var rightNode = AddVal(_rightNode, j);
                        foreach (var leftNode in dp[j-1])
                            tmp.Add(new TreeNode(j, leftNode, rightNode));
                    }
                dp.Add(tmp);
            }
            return dp[n];
        }

        private TreeNode AddVal(TreeNode root, int add)
        {
            if (root == null) return null;
            var node = new TreeNode(root.val + add);
            node.left = AddVal(root.left, add);
            node.right = AddVal(root.right, add);
            return node;
        }
    }
}