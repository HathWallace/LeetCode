using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace SolutionLib._1178._猜字谜
{
    public class Solution
    {
        private class TreeNode
        {
            public int Num = 0;

            public TreeNode[] Childs = new TreeNode[26];

        }

        public IList<int> FindNumOfValidWords(string[] words, string[] puzzles)
        {
            var res = new List<int>();
            var root = new TreeNode();
            foreach (var word in words)
            {
                var pre = root;
                var dict = GetCharDict(word);
                for (int i = 0; i < 26; i++)
                {
                    if (!dict[i]) continue;
                    if (pre.Childs[i] == null) pre.Childs[i] = new TreeNode();
                    pre.Childs[i].Num++;
                    pre = pre.Childs[i];
                }
                pre.Num++;
            }
            foreach (var puzzle in puzzles)
            {
                var pt = root;
                var dict = GetCharDict(puzzle);
                int ans = 0, first = puzzle[0] - 'a';
                for (int i = 0; i < 26; i++)
                {
                    if (!dict[i]) continue;
                    pt = pt.Childs[i];
                    if (pt == null) break;
                    if (i >= first) ans += pt.Num;
                }
                res.Add(ans);
            }
            return res;
        }

        private bool[] GetCharDict(string str)
        {
            var dict = new bool[26];
            foreach (var ch in str)
                dict[ch - 'a'] = true;
            return dict;
        }

    }

    //ERROR
    public class __Solution
    {
        public IList<int> FindNumOfValidWords(string[] words, string[] puzzles)
        {
            var res = new int[puzzles.Length];
            var bitMasksList = new ArrayList[26];
            for (int i = 0; i < puzzles.Length; i++)
            {
                var bm = GetBitMask(puzzles[i], new bool[26]);
                bm[5] = i;
                if (bitMasksList[puzzles[i][0] - 'a'] == null)
                    bitMasksList[puzzles[i][0] - 'a'] = new ArrayList();
                bitMasksList[puzzles[i][0] - 'a'].Add(bm);
            }
            foreach (var word in words)
            {
                var dict = new bool[26];
                var wordBM = GetBitMask(word, dict);
                for (int i = 0; i < 26; i++)
                {
                    if (!dict[i] || bitMasksList[i] == null) continue;
                    foreach (int[] puzzleBM in bitMasksList[i])
                    {
                        int x = 4;
                        for (int y = 4; y >= 0 && wordBM[x] <= puzzleBM[y]; x--, y--) ;
                        if (x < 0) res[puzzleBM[5]]++;
                    }
                }
            }
            return res;
        }

        private int[] GetBitMask(string str, bool[] dict)
        {
            var bitMask = new int[27];
            foreach (var ch in str) dict[ch - 'a'] = true;
            for (int i = 0; i < 26; i++)
            {
                if (!dict[i - 1]) continue;
                int index = 4, x = i;
                while (x > 0)
                {
                    if ((x & 1) == 1) bitMask[index]++;
                    x >>= 1;
                    index--;
                }
            }
            return bitMask;
        }

    }

    //超出时间限制
    public class _Solution
    {
        public IList<int> FindNumOfValidWords(string[] words, string[] puzzles)
        {
            var res = new int[puzzles.Length];
            var bitMasksList = new ArrayList[26];
            for (int i = 0; i < puzzles.Length; i++)
            {
                var puzzle = puzzles[i];
                var dict = new bool[26];
                var sb = new StringBuilder();
                if (bitMasksList[puzzle[0] - 'a'] == null) bitMasksList[puzzle[0] - 'a'] = new ArrayList();
                foreach (var ch in puzzle) dict[ch - 'a'] = true;
                sb.Append(i);
                for (int j = 0; j < 26; j++) if (dict[j]) sb.Append((char)('a' + j));
                bitMasksList[puzzle[0] - 'a'].Add(sb.ToString());
            }
            foreach (var word in words)
            {
                var dict = new bool[26];
                var sb = new StringBuilder();
                foreach (var ch in word) dict[ch - 'a'] = true;
                for (int i = 0; i < 26; i++) if (dict[i]) sb.Append((char)('a' + i));
                for (int i = 0; i < 26; i++)
                {
                    if (!dict[i] || bitMasksList[i] == null) continue;
                    foreach (string puzzleBM in bitMasksList[i])
                    {
                        int x = 0, y = 0, index;
                        while (char.IsDigit(puzzleBM[y])) y++;
                        index = int.Parse(puzzleBM.Substring(0, y));
                        while (x < sb.Length && y < puzzleBM.Length)
                        {
                            if (sb[x] != puzzleBM[y]) y++;
                            else
                            {
                                x++;
                                y++;
                            }
                        }
                        if (x == sb.Length) res[index]++;
                    }

                }
            }
            return res;
        }
    }

}