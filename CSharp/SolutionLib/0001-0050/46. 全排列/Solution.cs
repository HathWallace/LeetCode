using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace SolutionLib._46._全排列
{
    public class Solution
    {
        public IList<IList<int>> Permute(int[] nums)
        {
            var res = new List<IList<int>>();
            BackTrack(res, new List<int>(), nums);
            return res;
        }

        private void BackTrack(IList<IList<int>> res, IList<int> array, int[] nums)
        {
            if (array.Count == nums.Length)
            {
                res.Add(new List<int>(array));
                return;
            }

            foreach (var num in nums)
            {
                if (array.Contains(num)) continue;
                array.Add(num);
                BackTrack(res, array, nums);
                array.Remove(num);
            }

        }
    }

    public class Solution2
    {
        public IList<IList<int>> Permute(int[] nums)
        {
            var res = new List<IList<int>>();
            var output = new List<int>(nums);
            BackTrack(res, output, 0);
            return res;
        }

        private void BackTrack(IList<IList<int>> res, IList<int> output, int first)
        {
            if (first == output.Count - 1)
            {
                res.Add(new List<int>(output));
                return;
            }

            for (int i = first; i < output.Count; i++)
            {
                Swap(output, first, i);
                BackTrack(res, output, first + 1);
                Swap(output, first, i);
            }
        }

        private void Swap(IList<int> list, int i, int j)
        {
            int tmp = list[i];
            list[i] = list[j];
            list[j] = tmp;
        }

    }
}