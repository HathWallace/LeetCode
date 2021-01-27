namespace SolutionLib._200._岛屿数量
{
    public class Solution
    {
        private char[][] grid;
        private bool[,] visit;
        private int h, d;

        public int NumIslands(char[][] grid)
        {
            if (grid.Length == 0) return 0;
            this.grid = grid;
            h = grid.Length;
            d = grid[0].Length;
            int ans = 0;
            visit = new bool[h, d];
            for (int i = 0; i < h; i++)
            {
                for (int j = 0; j < d; j++)
                {
                    if (visit[i, j] || grid[i][j] == '0') continue;
                    BFS(i, j);
                    ans++;
                }
            }
            return ans;
        }

        private void BFS(int i, int j)
        {
            if (i < 0 || i >= h || j < 0 || j >= d) return;
            if (visit[i, j] || grid[i][j] == '0') return;
            visit[i, j] = true;
            BFS(i - 1, j);
            BFS(i, j - 1);
            BFS(i + 1, j);
            BFS(i, j + 1);
        }

    }
}