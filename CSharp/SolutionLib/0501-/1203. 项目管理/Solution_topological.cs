using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace SolutionLib._1203._项目管理
{
    public class Solution_topological
    {
        public int[] SortItems(int n, int m, int[] group, IList<IList<int>> beforeItems)
        {
            for (int i = 0; i < n; i++)
                if (group[i] == -1)
                    group[i] = m++;

            var groupAdj = new ArrayList[m];
            var itemAdj = new ArrayList[n];
            for (int i = 0; i < m; i++)
                groupAdj[i] = new ArrayList();
            for (int i = 0; i < n; i++)
                itemAdj[i] = new ArrayList();

            var groupsIndegree = new int[m];
            var itemsIndegree = new int[n];
            for (int i = 0; i < n; i++)
            {
                int currentGroup = group[i];
                foreach (var beforeItem in beforeItems[i])
                {
                    int beforeGroup = group[beforeItem];
                    if (beforeGroup == currentGroup) continue;
                    groupAdj[beforeGroup].Add(currentGroup);
                    groupsIndegree[currentGroup]++;
                }
            }
            for (int i = 0; i < n; i++)
                foreach (var item in beforeItems[i])
                {
                    itemAdj[item].Add(i);
                    itemsIndegree[i]++;
                }

            var groupsList = TopologicalSort(groupAdj, groupsIndegree, m);
            var itemsList = TopologicalSort(itemAdj, itemsIndegree, n);
            if (groupsList.Count == 0 || itemsList.Count == 0)
                return new int[] { };

            var group2Items = new Dictionary<int, List<int>>();
            for (int i = 0; i < m; i++)
                group2Items[i] = new List<int>();
            foreach (var item in itemsList)
                group2Items[group[item]].Add(item);

            var res = new List<int>();
            foreach (var groupId in groupsList)
            {
                res = res.Concat(group2Items[groupId]).ToList();
            }
            return res.ToArray();
        }

        private List<int> TopologicalSort(ArrayList[] adj, int[] inDegree, int n)
        {
            var res = new List<int>();
            var queue = new Queue<int>();
            for (int i = 0; i < n; i++)
                if (inDegree[i] == 0)
                    queue.Enqueue(i);
            while (queue.Count != 0)
            {
                int front = queue.Dequeue();
                res.Add(front);
                foreach (int successor in adj[front])
                {
                    inDegree[successor]--;
                    if (inDegree[successor] == 0)
                        queue.Enqueue(successor);
                }
            }
            return res.Count == n ? res : new List<int>();
        }
    }
}
