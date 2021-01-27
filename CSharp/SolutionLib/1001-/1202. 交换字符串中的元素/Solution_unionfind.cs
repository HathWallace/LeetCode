using System.Collections.Generic;
using System.Text;

namespace SolutionLib._1202._交换字符串中的元素
{
    public class Solution_unionfind
    {
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

            public void Insert(int x, int y)
            {
                int rootX = FindParent(x);
                int rootY = FindParent(y);
                if (rootX == rootY) return;
                if (rank[rootX] == rank[rootY])
                {
                    parent[rootX] = rootY;
                    rank[rootY]++;
                }
                else if (rank[rootX] < rank[rootY])
                    parent[rootX] = rootY;
                else
                    parent[rootX] = rootY;
            }

            public int FindParent(int x)
            {
                parent[x] = parent[x] == x ? x : FindParent(parent[x]);
                return parent[x];
            }

        }

        public string SmallestStringWithSwaps(string s, IList<IList<int>> pairs)
        {
            int slen = s.Length;
            var sb = new StringBuilder();
            var unionFind = new UnionFind(slen);
            var map = new int[slen, 26];
            foreach (var pair in pairs)
                unionFind.Insert(pair[0], pair[1]);
            for (int i = 0; i < slen; i++)
            {
                int root = unionFind.FindParent(i);
                map[root, s[i] - 'a']++;
            }
            for (int i = 0; i < slen; i++)
            {
                int root = unionFind.FindParent(i);
                int j = 0;
                while (map[root, j] == 0) j++;
                sb.Append((char) ('a' + j));
                map[root, j]--;
            }
            return sb.ToString();
        }
    }

    public class _Solution_unionfind
    {
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

            public void Insert(int x, int y)
            {
                int rootX = FindParent(x);
                int rootY = FindParent(y);
                if (rootX == rootY) return;
                if (rank[rootX] == rank[rootY])
                {
                    parent[rootX] = rootY;
                    rank[rootY]++;
                }
                else if (rank[rootX] < rank[rootY])
                    parent[rootX] = rootY;
                else
                    parent[rootX] = rootY;
            }

            public int FindParent(int x)
            {
                return parent[x] == x ? x : FindParent(parent[x]);
            }

        }

        private class MinHeap
        {
            private List<char> heap = new List<char> { char.MinValue };

            public int Count => heap.Count - 1;

            private void PermeateUp(int child)
            {
                int parent = child / 2;
                if (heap[child] >= heap[parent]) return;
                char tmp = heap[child];
                heap[child] = heap[parent];
                heap[parent] = tmp;
                PermeateUp(parent);
            }

            private void PermeateDown(int parent)
            {
                int child = parent * 2;
                if (child > Count) return;
                if (child + 1 <= Count && heap[child + 1] < heap[child]) child++;
                if (heap[parent] <= heap[child]) return;
                char tmp = heap[child];
                heap[child] = heap[parent];
                heap[parent] = tmp;
                PermeateDown(child);
            }

            public void Push(char num)
            {
                heap.Add(num);
                PermeateUp(Count);
            }

            public char Pop()
            {
                char res = heap[1];
                heap[1] = heap[Count];
                heap.RemoveAt(Count);
                PermeateDown(1);
                return res;
            }

        }

        public string SmallestStringWithSwaps(string s, IList<IList<int>> pairs)
        {
            var sb = new StringBuilder(s.Length);
            int slen = s.Length;
            var unionFind = new UnionFind(slen);
            var dict = new Dictionary<int, MinHeap>();
            foreach (var pair in pairs)
                unionFind.Insert(pair[0], pair[1]);
            for (int i = 0; i < slen; i++)
            {
                int root = unionFind.FindParent(i);
                if (!dict.ContainsKey(root))
                    dict[root] = new MinHeap();
                dict[root].Push(s[i]);
                dict[i] = dict[root];
            }
            for (int i = 0; i < slen; i++)
                sb.Append(dict[i].Pop());
            return sb.ToString();
        }

    }
}
