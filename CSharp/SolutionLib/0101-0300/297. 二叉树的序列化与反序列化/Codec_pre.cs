using System.Collections.Generic;
using System.Linq;

namespace SolutionLib._297._二叉树的序列化与反序列化
{
    public class Codec_pre
    {
        public string rserialize(TreeNode root, string str)
        {
            if (root == null)
            {
                str += "None,";
            }
            else
            {
                str += root.val + ",";
                str = rserialize(root.left, str);
                str = rserialize(root.right, str);
            }
            return str;
        }

        public string serialize(TreeNode root)
        {
            return rserialize(root, "");
        }

        public TreeNode rdeserialize(LinkedList<string> l)
        {
            if (l.First() == "null")
            {
                l.RemoveFirst();
                return null;
            }

            TreeNode root = new TreeNode(int.Parse(l.First()));
            l.RemoveFirst();
            root.left = rdeserialize(l);
            root.right = rdeserialize(l);
            return root;
        }

        public TreeNode deserialize(string data)
        {
            string[] data_array = data.Split(',');
            var data_list = new LinkedList<string>(data_array);
            return rdeserialize(data_list);
        }
    }
}