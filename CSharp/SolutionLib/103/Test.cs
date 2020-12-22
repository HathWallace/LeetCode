using System;

namespace SolutionLib._103
{
    public class Test
    {
        public static void Run()
        {
            var root = ReadTreeNode(Console.ReadLine());
            

            var s = new Solution2();
            foreach (var list in s.ZigzagLevelOrder(root))
            {
                foreach (var i in list)
                {
                    Console.Write(i + " ");
                }

                Console.WriteLine();
            }
        }

        private static TreeNode ReadTreeNode(string str)
        {
            var nodes = str.Substring(1, str.Length - 2).Split(',');

            var root = new TreeNode(Int32.Parse(nodes[0]));
            var nodeList = new TreeNode[nodes.Length];
            nodeList[0] = root;
            for (int i = 1; i < nodes.Length; i++)
            {
                if (nodes[i] == "null") continue;
                nodeList[i] = new TreeNode(Int32.Parse(nodes[i]));
                if ((i - 1) % 2 == 0)
                {
                    nodeList[(i - 1) / 2].left = nodeList[i];
                }
                else
                {
                    nodeList[(i - 1) / 2].right = nodeList[i];
                }
            }

            return root;
        }
    }
}
