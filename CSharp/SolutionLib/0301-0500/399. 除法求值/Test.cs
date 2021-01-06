using System.Collections;
using System.Collections.Generic;

namespace SolutionLib._399._除法求值
{
    public class Test
    {
        public static void Run()
        {
            var s = new Solution();
            var equations = GetListOfList();
            var values = GetDoubles();
            var queries = GetListOfList();
            Public.PrintNums(s.CalcEquation(equations, values, queries));
        }

        private static IList<IList<string>> GetListOfList()
        {
            string str = Public.ReadStr();
            var res = new List<IList<string>>();
            str = str.Replace("],[", "].[").Substring(1, str.Length - 2);
            foreach (var list in str.Split('.'))
            {
                var varlist = new List<string>();
                foreach (var var in list.Substring(1, list.Length - 2).Split(','))
                {
                    varlist.Add(var.Substring(1, var.Length - 2));
                }
                res.Add(varlist);
            }

            return res;
        }

        private static double[] GetDoubles()
        {
            var res = new List<double>();
            string str = Public.ReadStr();
            str = str.Substring(1, str.Length - 2);
            foreach (var num in str.Split(','))
            {
                if (num == "") continue;
                res.Add(double.Parse(num));
            }

            return res.ToArray();
        }

        /*
         * 测试用例：
         * equations = [["a","b"],["b","c"]], values = [2.0,3.0], queries = [["a","c"],["b","a"],["a","e"],["a","a"],["x","x"]]
         * equations = [["a","b"],["b","c"],["bc","cd"]], values = [1.5,2.5,5.0], queries = [["a","c"],["c","b"],["bc","cd"],["cd","bc"]]
         * equations = [["a","b"]], values = [0.5], queries = [["a","b"],["b","a"],["a","c"],["x","y"]]
         */

    }
}