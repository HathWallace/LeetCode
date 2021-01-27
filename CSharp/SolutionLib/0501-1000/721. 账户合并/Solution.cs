using System;
using System.Collections.Generic;
using System.Linq;

namespace SolutionLib._721._账户合并
{
    public class Solution
    {
        private class UnionFind
        {
            private Dictionary<string, string> parent = new Dictionary<string, string>();

            public void Insert(string x, string y = "")
            {
                string rootX = FindParent(x);
                if (y == "") return;
                string rootY = FindParent(y);
                if (rootX == rootY) return;
                parent[rootX] = rootY;
            }

            public string FindParent(string x)
            {
                if (!parent.ContainsKey(x))
                    parent[x] = x;
                return parent[x] = parent[x] == x ? x : FindParent(parent[x]);
            }

            public IList<IList<string>> GetUnionList()
            {
                var result = new List<IList<string>>();
                var dict = new Dictionary<string, List<string>>();
                var keys = new List<string>(parent.Keys);
                foreach (var key in keys)
                {
                    string root = FindParent(key);
                    if (!dict.ContainsKey(root))
                        dict[root] = new List<string>();
                    dict[root].Add(key);
                }
                foreach (var pair in dict)
                {
                    pair.Value.Sort((x, y) => string.Compare(x, y, StringComparison.Ordinal));
                    result.Add(pair.Value.ToList());
                }
                return result;
            }
        }

        public IList<IList<string>> AccountsMerge(IList<IList<string>> accounts)
        {
            var res = new List<IList<string>>();
            var dict = new Dictionary<string, List<IList<string>>>();
            foreach (var account in accounts)
            {
                if (!dict.ContainsKey(account[0]))
                    dict[account[0]] = new List<IList<string>>();
                dict[account[0]].Add(account);
            }
            foreach (var pair in dict)
            {
                var unionFind = new UnionFind();
                foreach (var list in pair.Value)
                {
                    if (list.Count < 2) continue;
                    unionFind.Insert(list[1]);
                    for (int i = 2; i < list.Count; i++)
                        unionFind.Insert(list[i - 1], list[i]);
                }
                foreach (var list in unionFind.GetUnionList())
                {
                    var result = new List<string> { pair.Key };
                    foreach (var email in list)
                        result.Add(email);
                    res.Add(result);
                }
            }
            return res;
        }
    }
}