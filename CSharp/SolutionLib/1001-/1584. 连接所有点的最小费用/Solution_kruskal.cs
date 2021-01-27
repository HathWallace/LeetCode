using System;
using System.Collections.Generic;

namespace SolutionLib._1584._连接所有点的最小费用
{
    public class Solution_kruskal
    {
        private int[][] points;

        private class Edge : IComparable<Edge>
        {
            public int I;
            public int J;
            public int Length;

            public Edge(int i, int j, int length)
            {
                I = i;
                J = j;
                Length = length;
            }

            public int CompareTo(Edge other)
            {
                return Length.CompareTo(other.Length);
            }
        }

        private class UnionFind
        {
            private int[] parent;
            private int[] rank;

            public UnionFind(int len)
            {
                parent = new int[len];
                rank = new int[len];
                for (int i = 0; i < len; i++)
                {
                    parent[i] = i;
                    rank[i] = 1;
                }
            }

            public bool Insert(int x, int y)
            {
                int rootX = FindParent(x);
                int rootY = FindParent(y);
                if (rootX == rootY) return false;
                if (rank[rootX] < rank[rootY])
                {
                    parent[rootX] = rootY;
                    rank[rootY]++;
                }
                else
                {
                    parent[rootX] = rootY;
                    rank[rootX]++;
                }
                return true;
            }

            public int FindParent(int x)
            {
                return parent[x] == x ? x : parent[x] = FindParent(parent[x]);
            }

        }

        public int MinCostConnectPoints(int[][] points)
        {
            this.points = points;
            int pointCount = points.Length;
            var edges = new List<Edge>();
            for (int i = 0; i < pointCount - 1; i++)
                for (int j = i + 1; j < pointCount; j++)
                    edges.Add(new Edge(i, j, GetCost(i, j)));
            edges.Sort();
            var uf = new UnionFind(pointCount);
            int ans = 0;
            foreach (var edge in edges)
            {
                if (!uf.Insert(edge.I, edge.J)) continue;
                ans += edge.Length;
            }
            return ans;
        }

        private int GetCost(int i, int j)
        {
            return Math.Abs(points[i][0] - points[j][0]) +
                   Math.Abs(points[i][1] - points[j][1]);
        }
    }
}