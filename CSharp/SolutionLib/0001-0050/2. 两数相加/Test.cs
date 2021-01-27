namespace SolutionLib._2._两数相加
{
    public class Test
    {
        public static void Run()
        {
            var s = new Solution();
            Public.Print(s.AddTwoNumbers(
                Public.ReadList(),
                Public.ReadList()),
                true);
        }

        /*
         * 测试用例：
         * [2,4,3],[5,6,4]
         * [2,4,9],[5,6,4,9]
         */

    }
}