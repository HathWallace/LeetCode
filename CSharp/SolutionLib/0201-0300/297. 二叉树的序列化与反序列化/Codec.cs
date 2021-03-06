using System.Collections.Generic;
using System.Text;

namespace SolutionLib._297._二叉树的序列化与反序列化
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
    public class Codec
    {

        // Encodes a tree to a single string.
        public string serialize(TreeNode root)
        {
            var str = new StringBuilder("[");
            var queue = new Queue<TreeNode>();
            if (root != null) queue.Enqueue(root);
            while (queue.Count != 0)
            {
                var node = queue.Dequeue();
                if (node == null)
                    str.Append("null,");
                else
                {
                    str.Append(node.val + ",");
                    queue.Enqueue(node.left);
                    queue.Enqueue(node.right);
                }
            }
            while (str.Length >= 2)
            {
                int size = str.Length;
                if (size >= 5 && str[size - 5] == 'n')
                    str.Remove(size - 5, 5);
                else
                {
                    str.Remove(str.Length - 1, 1);
                    break;
                }
            }
            str.Append("]");
            return str.ToString();
        }

        // Decodes your encoded data to tree.
        public TreeNode deserialize(string data)
        {
            data = data.Substring(1, data.Length - 2);
            var nodes = data.Split(',');
            if (nodes[0] == "") return null;
            var root = new TreeNode(int.Parse(nodes[0]));
            var queue = new Queue<TreeNode>();
            queue.Enqueue(root);
            for (int i = 1; i < nodes.Length; i += 2)
            {
                var node = queue.Dequeue();
                if (nodes[i] != "null")
                    queue.Enqueue(node.left = new TreeNode(int.Parse(nodes[i])));
                if (i + 1 < nodes.Length && nodes[i + 1] != "null")
                    queue.Enqueue(node.right = new TreeNode(int.Parse(nodes[i + 1])));
            }
            return root;
        }

    }

    // Your Codec object will be instantiated and called as such:
    // Codec ser = new Codec();
    // Codec deser = new Codec();
    // TreeNode ans = deser.deserialize(ser.serialize(root));
}