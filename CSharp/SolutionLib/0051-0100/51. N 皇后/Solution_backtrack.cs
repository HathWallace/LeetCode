using System.Collections.Generic;
using System.Text;

namespace SolutionLib._51._N_皇后
{
    public class Solution_backtrack
    {
        private List<IList<string>> res = new List<IList<string>>();
        private int n;

        public IList<IList<string>> SolveNQueens(int n)
        {
            this.n = n;
            var board = new char[n][];
            for (int i = 0; i < n; i++)
            {
                board[i] = new char[n];
                for (int j = 0; j < n; j++)
                    board[i][j] = '.';
            }
            BackTrack(board, 0);
            return res;
        }

        private void BackTrack(char[][] board, int row)
        {
            if (row == n)
            {
                res.Add(ReadBoard(board));
                return;
            }
            for (int i = 0; i < n; i++)
            {
                if (!IsVaild(board, row, i)) continue;
                board[row][i] = 'Q';
                BackTrack(board, row + 1);
                board[row][i] = '.';
            }
        }

        private IList<string> ReadBoard(char[][] board)
        {
            var result = new List<string>();
            for (int i = 0; i < n; i++)
            {
                var sb = new StringBuilder();
                for (int j = 0; j < n; j++)
                    sb.Append(board[i][j]);
                result.Add(sb.ToString());
            }
            return result;
        }

        private bool IsVaild(char[][] board, int row, int col)
        {
            for (int i = 0; i < row; i++)
                if (board[i][col] == 'Q')
                    return false;
            for (int i = row - 1, j = col - 1; i >= 0 && j >= 0; i--, j--)
                if (board[i][j] == 'Q')
                    return false;
            for (int i = row - 1, j = col + 1; i >= 0 && j < n; i--, j++)
                if (board[i][j] == 'Q')
                    return false;
            return true;
        }

    }
}