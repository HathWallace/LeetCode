namespace SolutionLib._51._N_皇后
{
    public class Test
    {
        public static void Run()
        {
            var s = new Solution_backtrack();
            var res = s.SolveNQueens(Public.ReadNum());
        }
    }
}