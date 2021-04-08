using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace CSharp
{
    class Program
    {
        static void Main(string[] args)
        {
            string line;
            while ((line = Console.ReadLine()) != null)
            {
                var split = line.Split(' ');
                int row = int.Parse(split[0]), col = int.Parse(split[1]), time = int.Parse(split[2]);
                var graph = new int[row][];
                for (int i = 0; i < row; i++)
                {
                    line = Console.ReadLine();
                    graph[i] = new int[col];
                    split = line.Split(' ');
                    for (int j = 0; j < col; j++)
                    {
                        graph[i][j] = int.Parse(split[j]);
                    }

                }
                Console.WriteLine(new Solution().GetBestPath(graph, time));
            }
        }
    }

    class Solution
    {
        private int[][] graph;
        private int ans = -1, row, col, total;

        public int GetBestPath(int[][] graph, int time)
        {
            this.graph = graph;
            row = graph.Length;
            col = graph[0].Length;
            total = time;
            Backtrack(0, 0, time);
            return ans;
        }

        private void Backtrack(int i, int j, int remain)
        {
            if (i == row || j == col) return;
            remain -= graph[i][j];
            if (remain < 0) return;
            if (i == row - 1 && j == col - 1)
            {
                ans = Math.Max(ans, total - remain);
                return;
            }
            Backtrack(i + 1, j, remain);
            Backtrack(i, j + 1, remain);
        }

    }

}