using System;
using System.Collections.Generic;
using System.Linq;

namespace SolutionLib._721._账户合并
{
    public class Solution2
    {
        private class UnionFind
        {
            private int[] parent;

            public UnionFind(int len)
            {
                parent = new int[len];
                for (int i = 0; i < len; i++)
                {
                    parent[i] = i;
                }
            }

            public void Insert(int x, int y)
            {
                int rootX = FindParent(x);
                int rootY = FindParent(y);
                if (rootX == rootY) return;
                parent[rootY] = rootX;
            }

            public int FindParent(int x)
            {
                return parent[x] = parent[x] == x ? x : FindParent(parent[x]);
            }

        }

        public IList<IList<string>> AccountsMerge(IList<IList<string>> accounts)
        {
            var emailToIndex = new Dictionary<string, int>();
            var emailToName = new Dictionary<string, string>();
            int emailCount = 0;
            foreach (var account in accounts)
                for (int i = 1; i < account.Count; i++)
                {
                    if (emailToIndex.ContainsKey(account[i]))
                        continue;
                    emailToIndex[account[i]] = emailCount++;
                    emailToName[account[i]] = account[0];
                }

            var uf = new UnionFind(emailCount);
            foreach (var account in accounts)
            {
                int firstIndex = emailToIndex[account[1]];
                for (int i = 2; i < account.Count; i++)
                {
                    int nextIndex = emailToIndex[account[i]];
                    uf.Insert(firstIndex, nextIndex);
                }
            }

            var indexToEmails = new Dictionary<int, List<string>>();
            foreach (var email in emailToIndex.Keys)
            {
                int root = uf.FindParent(emailToIndex[email]);
                if (!indexToEmails.ContainsKey(root))
                    indexToEmails[root] = new List<string>();
                indexToEmails[root].Add(email);
            }

            var res = new List<IList<string>>();
            foreach (var emails in indexToEmails.Values)
            {
                emails.Sort((x, y) => string.Compare(x, y, StringComparison.Ordinal));
                var result = new List<string>();
                result.Add(emailToName[emails[0]]);
                result.AddRange(emails);
                res.Add(result);
            }
            return res;
        }

    }
}