using System.Collections;
using System.Collections.Generic;

namespace SolutionLib._399._除法求值
{
    public class Solution
    {
        private Dictionary<string, Dictionary<string, double>> dict = new Dictionary<string, Dictionary<string, double>>();

        public double[] CalcEquation(IList<IList<string>> equations, double[] values, IList<IList<string>> queries)
        {
            var res = new List<double>();
            for (int i = 0; i < equations.Count; i++)
            {
                string numerator = equations[i][0], denominator = equations[i][1];
                if (!dict.ContainsKey(numerator))
                {
                    dict[numerator] = new Dictionary<string, double>();
                    dict[numerator][numerator] = 1;
                }

                if (!dict.ContainsKey(denominator))
                {
                    dict[denominator] = new Dictionary<string, double>();
                    dict[denominator][denominator] = 1;
                }
                dict[numerator][denominator] = values[i];
                dict[denominator][numerator] = 1 / values[i];
            }
            foreach (var query in queries)
                res.Add(Find(query[0], query[1], new HashSet<string>()));
            return res.ToArray();
        }

        private double Find(string numerator, string denominator, HashSet<string> set)
        {
            if (!dict.ContainsKey(numerator) || !dict.ContainsKey(denominator)) return -1;
            if (set.Contains(numerator)) return -1;
            set.Add(numerator);
            if (dict[numerator].ContainsKey(denominator)) return dict[numerator][denominator];
            foreach (var _numerator in dict[numerator].Keys)
            {
                if (dict[numerator][_numerator] < 0) continue;
                var tmp = Find(_numerator, denominator, set);
                if (tmp > 0)
                {
                    double result = dict[numerator][_numerator] * tmp;
                    dict[numerator][denominator] = result;
                    dict[denominator][numerator] = 1 / result;
                    return result;
                }
            }
            dict[numerator][denominator] = -1;
            dict[denominator][numerator] = -1;
            return -1;
        }

    }

    public class __Solution
    {
        private Dictionary<string, Dictionary<string, double>> dict =
            new Dictionary<string, Dictionary<string, double>>();

        public double[] CalcEquation(IList<IList<string>> equations, double[] values, IList<IList<string>> queries)
        {
            var res = new List<double>();
            for (int i = 0; i < equations.Count; i++)
            {
                string numerator = equations[i][0], denominator = equations[i][1];
                if (!dict.ContainsKey(numerator))
                {
                    dict[numerator] = new Dictionary<string, double>();
                    dict[numerator][numerator] = 1.0;
                }

                if (!dict.ContainsKey(denominator))
                {
                    dict[denominator] = new Dictionary<string, double>();
                    dict[denominator][denominator] = 1.0;
                }
                dict[numerator][denominator] = values[i];
                dict[denominator][numerator] = 1.0 / values[i];
            }
            foreach (var query in queries)
                res.Add(Find(query[0], query[1], new HashSet<string>()));
            return res.ToArray();
        }

        private double Find(string numerator, string denominator, HashSet<string> set)
        {
            if (set.Contains(numerator)) return -1.0;
            set.Add(numerator);//防止死循环
            if (!dict.ContainsKey(numerator)) return -1.0;
            if (dict[numerator].ContainsKey(denominator)) return dict[numerator][denominator];
            double res = -1.0;
            foreach (var denom in dict[numerator].Keys)
            {
                var tmp = Find(denom, denominator, set);
                if (tmp > 0)
                {
                    dict[numerator][denominator] = dict[numerator][denom] * tmp;
                    res = dict[numerator][denominator];
                }
                if (res > 0) break;
            }
            return res;
        }

    }

    public class _Solution
    {
        Dictionary<string, KeyValuePair<string, double>> dict = new Dictionary<string, KeyValuePair<string, double>>();

        public double[] CalcEquation(IList<IList<string>> equations, double[] values, IList<IList<string>> queries)
        {
            var res = new List<double>();
            for (int i = 0; i < equations.Count; i++)
                dict[equations[i][0]] = new KeyValuePair<string, double>(equations[i][1], values[i]);
            foreach (var query in queries)
            {
                var result = Find(query[0], query[1]);
                if (result < 0) result = 1.0 / Find(query[1], query[0]);
                res.Add(result);
            }
            return res.ToArray();
        }

        private double Find(string source, string target)
        {
            if (!dict.ContainsKey(source)) return -1;
            if (dict[source].Key == target) return dict[source].Value;
            var res = Find(dict[source].Key, target);
            return res < 0 ? -1 : res * dict[source].Value;
        }

    }
}