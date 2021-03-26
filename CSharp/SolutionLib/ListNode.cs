using System.Text;

namespace SolutionLib
{
    public class ListNode : ISerialize<ListNode>
    {
        public int val;

        public ListNode next;

        public ListNode(string data)
        {
            var head = Deserialize(data);
            if (head == null) return;
            val = head.val;
            next = head.next;
        }

        public ListNode(int val = 0, ListNode next = null)
        {
            this.val = val;
            this.next = next;
        }

        public string Serialize(ListNode head)
        {
            var sb = new StringBuilder();
            var pt = head;
            bool flag = false;
            sb.Append('[');
            while (pt != null)
            {
                if (flag) sb.Append(',');
                flag = true;
                sb.Append(pt.val);
                pt = pt.next;
            }
            sb.Append(']');
            return sb.ToString();
        }

        public ListNode Deserialize(string data)
        {
            var split = data.Substring(1, data.Length - 2).Split(',');
            int len = split.Length;
            ListNode pioneer = new ListNode(-1), pt = pioneer;
            foreach (var num in split)
            {
                pt.next = new ListNode(int.Parse(num));
                pt = pt.next;
            }
            return pioneer.next;
        }

    }
}