using System;

namespace SolutionLib._124._二叉树中的最大路径和
{
    public class Test
    {
        public static void Run()
        {
            var root = GetTree(Public.ReadStrs());
            var s = new Solution();
            Console.WriteLine(s.MaxPathSum(root));
        }

        private static TreeNode GetTree(string[] nums)
        {
            var nodes = new TreeNode[nums.Length + 1];
            nodes[0] = new TreeNode(int.MaxValue);
            for (int i = 1; i <= nums.Length; i++)
            {
                if (nums[i - 1] == "null") continue;
                nodes[i] = new TreeNode(int.Parse(nums[i - 1]));
                if (i % 2 == 0) nodes[i / 2].left = nodes[i];
                else nodes[i / 2].right = nodes[i];
            }

            return nodes[1];
        }

        /*
         * 测试用例：
         * [1,2,3]
         * [-10,9,20,null,null,15,7]
         * [1,-2,3]
         * [5,4,8,11,null,13,4,7,2,null,null,null,1]
         */

    }
}