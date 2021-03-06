namespace SolutionLib._1489._找到最小生成树里的关键边和伪关键边
{
    public class Test
    {
        public static void Run()
        {
            var s = new Solution_enumerate();
            var ans = s.FindCriticalAndPseudoCriticalEdges(Public.ReadNum(), Public.ReadMatrix());
            foreach (var res in ans)
            {
                Public.Print(res);
            }
        }

        /*
         * 测试用例：
         */

    }
}