//https://leetcode-cn.com/problems/sliding-window-maximum/solution/clinkedlist-shuang-duan-dui-lie-by-119-s/
using System.Collections.Generic;

namespace SolutionLib._239._滑动窗口最大值
{
    public class Solution_deque
    {
        public int[] MaxSlidingWindow(int[] nums, int k)
        {
            var res = new List<int>();
            var linkedList = new LinkedList<int>();
            for (int i = 0; i < nums.Length; i++)
            {
                while (linkedList.Count!=0&&nums[linkedList.Last.Value]<=nums[i])
                    linkedList.RemoveLast();
                linkedList.AddLast(i);
                if (i < k - 1) continue;
                while (linkedList.First.Value <= i - k)
                    linkedList.RemoveFirst();
                res.Add(nums[linkedList.First.Value]);
            }
            return res.ToArray();
        }
    }
}