using System;
using System.Collections.Generic;

namespace SolutionLib._337._打家劫舍_III
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
        public int Rob(TreeNode root)
        {
            var res = DFS(root);
            return Math.Max(res[0], res[1]);
        }

        private int[] DFS(TreeNode root)
        {
            if (root == null)
                return new[] { 0, 0 };
            var left = DFS(root.left);
            var right = DFS(root.right);
            int selected = left[1] + right[1] + root.val;
            int noSelected = Math.Max(left[0], left[1]) + Math.Max(right[0], right[1]);
            return new[] { selected, noSelected };
        }

    }

    public class _Solution
    {
        Dictionary<TreeNode, int> rob = new Dictionary<TreeNode, int>();
        Dictionary<TreeNode, int> noRob = new Dictionary<TreeNode, int>();

        public int Rob(TreeNode root)
        {
            return Math.Max(Rob(root, true), Rob(root, false));
        }

        private int Rob(TreeNode root, bool action)
        {
            if (root == null) return 0;
            if (action && rob.ContainsKey(root))
                return rob[root];
            if (!action && noRob.ContainsKey(root))
                return noRob[root];
            int noRobLeft = Rob(root.left, false);
            int noRobRight = Rob(root.right, false);
            if (action)
                return rob[root] = noRobLeft + noRobRight + root.val;
            int robLeft = Rob(root.left, true);
            int robRight = Rob(root.right, true);
            noRob[root] = Math.Max(noRobLeft + robRight, robLeft + noRobRight);
            return noRob[root] = Math.Max(noRob[root], robLeft + robRight);
        }

    }
}