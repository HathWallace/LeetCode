using System.Collections.Generic;
using System.Text;

namespace SolutionLib._752._打开转盘锁
{
    public class Solution
    {
        public int OpenLock(string[] deadends, string target)
        {
            int ans = 0;
            var set = new HashSet<string>(deadends);
            var queue = new Queue<string>();
            if (set.Add("0000")) queue.Enqueue("0000");
            while (queue.Count != 0)
            {
                int n = queue.Count;
                for (int i = 0; i < n; i++)
                {
                    var sb = new StringBuilder(queue.Dequeue());
                    if (target == sb.ToString()) return ans;
                    for (int j = 0; j < 4; j++)
                    {
                        char num = sb[j], tmp;
                        tmp = num == '9' ? '0' : (char)(num + 1);
                        sb[j] = tmp;
                        if (set.Add(sb.ToString())) queue.Enqueue(sb.ToString());
                        tmp = num == '0' ? '9' : (char)(num - 1);
                        sb[j] = tmp;
                        if (set.Add(sb.ToString())) queue.Enqueue(sb.ToString());
                        sb[j] = num;
                    }
                }
                ans++;
            }
            return -1;
        }
    }

}