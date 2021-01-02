using System;

namespace SolutionLib.剑指_Offer_07._重建二叉树
{
    public class Test
    {
        public static void Run()
        {
            var s = new Solution_stack();
            var test = s.BuildTree(Public.ReadNums(), Public.ReadNums());
            PreTravel(test);
            Console.WriteLine();
        }

        private static void PreTravel(TreeNode root)
        {
            if (root == null) return;
            Console.Write(root.val + " ");
            PreTravel(root.left);
            PreTravel(root.right);
        }

        /*
         * 测试用例：
         * preorder = [3,9,20,15,7]
         * inorder = [9,3,15,20,7]
         *
         * preorder = [3,9,8,5,4,10,20,15,7]
         * inorder = [4,5,8,10,9,3,15,20,7]
         */

    }
}