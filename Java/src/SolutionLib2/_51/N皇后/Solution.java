package SolutionLib2._51.N皇后;

import java.util.ArrayList;
import java.util.List;

class Solution {
    private int n;
    private List<List<String>> res;
    private char[][] board;
    private boolean[] diag1, diag2, column;

    public List<List<String>> solveNQueens(int n) {
        this.n = n;
        res = new ArrayList<>();
        board = new char[n][n];
        diag1 = new boolean[2 * n - 1];
        diag2 = new boolean[2 * n - 1];
        column = new boolean[n];
        for (int i = 0; i < n; i++) {
            for (int j = 0; j < n; j++) {
                board[i][j] = '.';
            }
        }
        backtrack(0);
        return res;
    }

    private void backtrack(int row) {
        if (row == n) {
            res.add(getBoard());
            return;
        }
        for (int col = 0; col < n; col++) {
            if (!isValiad(row, col)) continue;
            int index1 = getIndex(row, col, true), index2 = getIndex(row, col, false);
            board[row][col] = 'Q';
            diag1[index1] = true;
            diag2[index2] = true;
            column[col] = true;
            backtrack(row + 1);
            board[row][col] = '.';
            diag1[index1] = false;
            diag2[index2] = false;
            column[col] = false;
        }
    }

    private boolean isValiad(int row, int col) {
        return !diag1[getIndex(row, col, true)] &&
                !diag2[getIndex(row, col, false)] &&
                !column[col];
    }

    private int getIndex(int row, int col, boolean isDiag1) {
        if (isDiag1) return row + col;
        return row - col + n - 1;
    }

    private List<String> getBoard() {
        List<String> res = new ArrayList<>();
        for (int i = 0; i < n; i++) {
            var sb = new StringBuilder();
            for (int j = 0; j < n; j++) {
                sb.append(board[i][j]);
            }
            res.add(sb.toString());
        }
        return res;
    }
}
