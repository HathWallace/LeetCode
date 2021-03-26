using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace SolutionLib
{
    public class TreeNode : ISerialize<TreeNode>
    {
        public int val;
        public TreeNode left;
        public TreeNode right;

        public TreeNode(string str)
        {
            var root = Deserialize(str);
            val = root.val;
            left = root.left;
            right = root.right;
        }

        public TreeNode(int x, TreeNode left = null, TreeNode right = null)
        {
            val = x;
            this.left = left;
            this.right = right;
        }

        public string Serialize(TreeNode root)
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

        public TreeNode Deserialize(string data)
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
}