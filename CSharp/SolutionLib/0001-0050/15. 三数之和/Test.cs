using System.Collections.Generic;
using System.Linq;

namespace SolutionLib._15._三数之和
{
    public class Test
    {
        public static void Run()
        {
            var s = new Solution_general();
            Print(s.ThreeSum(Public.ReadNums()));
        }

        private static void Print(IList<IList<int>> res)
        {
            foreach (var list in res)
            {
                Public.Print(list.ToArray());
            }
        }

        /*
         * 测试用例：
         */

    }
}