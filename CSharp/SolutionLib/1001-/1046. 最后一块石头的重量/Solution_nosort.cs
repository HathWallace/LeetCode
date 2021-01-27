//https://leetcode-cn.com/problems/last-stone-weight/solution/fei-pai-xu-fa-by-death-6a-unhi/

namespace SolutionLib._1046._最后一块石头的重量
{
    public class Solution_nosort
    {
        public int LastStoneWeight(int[] stones)
        {
            var mp = new int[1001];
            int value = 0;
            for (int i = 0; i < stones.Length; i++)
                mp[stones[i]]++;
            for (int i = 1000; i > 0; i--)
                if (mp[i] == 0 || value == 0 && mp[i] % 2 == 0) continue;
                else if (value == 0 && mp[i] % 2 == 1)
                    value = i;
                else
                {
                    mp[i]--;
                    mp[value - i]++;
                    if (value - i > i)
                    {
                        i = value - i + 1;
                        value = 0;
                    }
                    else
                        value = mp[i] % 2 == 0 ? 0 : i;
                }
            return value;
        }
    }
}