using System.Linq;

namespace SolutionLib._46._全排列
{
    public class Test
    {
        public static void Run()
        {
            var s = new Solution2();
            foreach (var res in s.Permute(Public.ReadNums()))
            {
                Public.Print(res.ToArray());
            }
        }

        /*
         * 测试用例：
         */

    }
}