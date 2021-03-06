using System.Linq;

namespace SolutionLib._830._较大分组的位置
{
    public class Test
    {
        public static void Run()
        {
            var s = new Solution();
            foreach (var section in s.LargeGroupPositions(Public.ReadStr()))
            {
                Public.Print(section.ToArray());
            }
        }

        /*
         * 测试用例：
         */

    }
}