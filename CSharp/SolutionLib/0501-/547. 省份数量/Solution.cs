using System.Collections.Generic;

namespace SolutionLib._547._省份数量
{
    //DFS
    public class Solution
    {
        public int FindCircleNum(int[][] isConnected)
        {
            int ans = 0;
            var flag = new bool[isConnected.Length];
            for (int i = 0; i < isConnected.Length; i++)
            {
                if (flag[i]) continue;
                flag[i] = true;
                DFS(flag, isConnected, i);
                ans++;
            }
            return ans;
        }

        private void DFS(bool[] flag, int[][] isConnected, int city)
        {
            for (int i = 0; i < isConnected.Length; i++)
            {
                if (flag[i] || isConnected[city][i] == 0) continue;
                flag[i] = true;
                DFS(flag, isConnected, i);
            }
        }

    }
}