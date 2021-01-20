using System.Collections.Generic;

namespace SolutionLib._437._路径总和_III
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

    public class Solution_sum
    {
        public int PathSum(TreeNode root, int sum)
        {
            var dict = new Dictionary<int, int>();
            dict[0] = 1;
            return Helper(root, sum, dict, 0);
        }

        private int Helper(TreeNode root, int sum, Dictionary<int, int> dict, int pathSum)
        {
            if (root == null) return 0;
            int res = 0;

            pathSum += root.val;
            if (dict.ContainsKey(pathSum - sum))
                res += dict[pathSum - sum];
            if (!dict.ContainsKey(pathSum))
                dict[pathSum] = 0;
            dict[pathSum]++;
            res += Helper(root.left, sum, dict, pathSum) +
                   Helper(root.right, sum, dict, pathSum);
            dict[pathSum]--;

            return res;
        }
    }

    public class _Solution_sum
    {
        public int PathSum(TreeNode root, int sum)
        {
            if (root == null) return 0;
            return Helper(root, sum) +
                   PathSum(root.left, sum) +
                   PathSum(root.right, sum);
        }

        private int Helper(TreeNode root, int sum)
        {
            if (root == null) return 0;
            sum -= root.val;
            return (sum == 0 ? 1 : 0) +
                   Helper(root.left, sum) +
                   Helper(root.right, sum);
        }
    }

}