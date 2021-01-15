using System;

namespace SolutionLib._98._验证二叉搜索树
{
    public class Test
    {
        public static void Run()
        {
            var s = new Solution();
            var root = new TreeNode(1);
            root.left = new TreeNode(1);
            Console.WriteLine(s.IsValidBST(root));
        }

        /*
         * 测试用例：
         */

    }
}