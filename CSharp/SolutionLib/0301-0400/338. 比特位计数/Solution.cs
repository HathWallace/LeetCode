using System.Collections.Generic;

namespace SolutionLib._338._比特位计数
{
    public class Solution2
    {
        public int[] CountBits(int num)
        {
            var res = new int[num + 1];
            if (num == 0) return res;
            var queue = new Queue<int>();
            res[1] = 1;
            queue.Enqueue(1);
            while (queue.Count != 0)
            {
                int pre = queue.Dequeue(), tmp = pre * 2;
                if (tmp > num) continue;
                res[tmp] = res[pre];
                queue.Enqueue(tmp++);
                if (tmp > num) continue;
                res[tmp] = res[pre] + 1;
                queue.Enqueue(tmp);
            }
            return res;
        }
    }

    public class Solution
    {
        public int[] CountBits(int num)
        {
            var res = new int[num + 1];
            Divide(res, 1, 1);
            return res;
        }

        private void Divide(int[] res, int num, int oneCount)
        {
            if (num >= res.Length) return;
            res[num] = oneCount;
            Divide(res, 2 * num, oneCount);
            Divide(res, 2 * num + 1, oneCount + 1);
        }

    }
}