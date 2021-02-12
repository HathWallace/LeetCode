namespace SolutionLib._986._区间列表的交集
{
    public class Test
    {
        public static void Run()
        {
            var s = new Solution();
            var res = s.IntervalIntersection(Public.ReadMatrix(), Public.ReadMatrix());
            foreach (var inter in res)
            {
                Public.Print(inter);
            }
        }
    }
}