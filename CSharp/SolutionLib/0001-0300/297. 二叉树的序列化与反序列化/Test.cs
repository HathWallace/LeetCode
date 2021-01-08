using System;

namespace SolutionLib._297._二叉树的序列化与反序列化
{
    public class Test
    {
        public static void Run()
        {
            var c = new Codec_pre();
            var root = c.deserialize(Public.ReadStr());
            PreOrder(root);
            Console.WriteLine();
            PostOrder(root);
            Console.WriteLine();
            Console.WriteLine(c.serialize(root));
        }

        private static void PreOrder(TreeNode root)
        {
            if (root == null) return;
            Console.Write(root.val + " ");
            PreOrder(root.left);
            PreOrder(root.right);
        }

        private static void PostOrder(TreeNode root)
        {
            if (root == null) return;
            PostOrder(root.left);
            PostOrder(root.right);
            Console.Write(root.val + " ");
        }

        /*
         * 测试用例：
         * [1,2,3,null,null,4,5]
         * [5,4,8,11,null,13,4,7,2,null,null,null,1]
         * [-10,9,20,null,null,15,7]
         */

    }
}