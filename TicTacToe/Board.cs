using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe
{
    internal class Board
    {
        private readonly string[,] _board;

        public Board(int cols, int rows)
        {
            _board = new string[cols, rows];
        }

        public void ShowBoard()
        {
            int cols = _board.GetLength(0);
            int rows = _board.GetLength(1);

            Console.WriteLine("     |  1  |  2  |  3  ");
            Console.WriteLine("-----------------------");

            for (int c = 0; c < cols; c++)
            {
                StringBuilder sb = new StringBuilder($"  {c + 1}  |");

                for (int v = 0; v < rows; v++)
                {
                    sb.Append(string.Format("  {0}  ", _board[c, v] ?? " "));

                    if (v + 1 != rows) { sb.Append("|"); }
                }
                Console.WriteLine(sb.ToString());

                if (c + 1 != cols) { Console.WriteLine("-----------------------"); }
            }
        }

        public bool ValidateMove(int col, int row)
        {
            if(col > _board.GetLength(0)) { return false; }
            if(row > _board.GetLength(1)) { return false; }
            return string.IsNullOrWhiteSpace(_board[col, row]);
        }

        public byte SetMove(int col, int row, string mark)
        {
            if (!ValidateMove(col, row)) { return 0; }

            _board[col, row] = mark;

            return BoardStatus();
        }

        public byte BoardStatus()
        {
            if (GameWon()) { return 2; }
            if (IsDraw()) { return 1; }
            return 0;
        }

        public bool IsDraw()
        {
            return !_board.Cast<string?>().Any(x => string.IsNullOrWhiteSpace(x));
        }

        public bool GameWon()
        {
            if (AreAllElementsInRowEqual()) { return true; }
            if (AreAllElementsInColumnEqual()) { return true; }
            if (AreAllDiagonalElementsEqual()) { return true; }
            return false;
        }

        public bool AreAllElementsInRowEqual()
        {
            int totalRows = _board.GetLength(1);

            for (int i = 0; i < totalRows; i++)
            {
                if (string.IsNullOrWhiteSpace(_board[0, i])) { return false; }

                if (AreAllElementsInRowEqual(i)) { return true; }
            }

            return false;
        }
        public bool AreAllElementsInRowEqual(int row)
        {
            int totalCol = _board.GetLength(0);

            for (int i = 1; i < totalCol; i++)
            {
                if (string.IsNullOrWhiteSpace(_board[i, row])) { return false; }

                if (_board[i, row] != _board[i - 1, row])
                {
                    return false;
                }
            }

            return true;
        }

        public bool AreAllElementsInColumnEqual()
        {
            int totalCols = _board.GetLength(0);
            
            for (int i = 0; i < totalCols; i++)
            {
                if (string.IsNullOrWhiteSpace(_board[i, 0])) { return false; }

                if (AreAllElementsInColumnEqual(i)) { return true; }
            }

            return false;
        }
        public bool AreAllElementsInColumnEqual(int col)
        {
            int totalRow = _board.GetLength(1);

            for (int i = 1; i < totalRow; i++)
            {
                if (string.IsNullOrWhiteSpace(_board[col, i])) { return false; }

                if (_board[col, i] != _board[col, i - 1])
                {
                    return false;
                }
            }

            return true;
        }

        public bool AreAllDiagonalElementsEqual()
        {
            if (CheckLeftDiagonal()) { return true; }
            if (CheckRightDiagonal()) { return true; }
            return false;
        }

        public bool CheckLeftDiagonal()
        {
            string firstElement = _board[0, 0];

            if(string.IsNullOrWhiteSpace(firstElement)) { return false; }

            int totalCols = _board.GetLength(0);

            for (int i = 1; i < totalCols; i++)
            {
                var elem = _board[i, i];

                if(string.IsNullOrWhiteSpace(elem)) { return false; }

                if (elem != firstElement) { return false; }
            }

            return true;
        }
        public bool CheckRightDiagonal()
        {
            int totalCols = _board.GetLength(0);
            int totalRows = _board.GetLength(1);
            string firstElement = _board[0, totalRows-1];

            if (string.IsNullOrWhiteSpace(firstElement)) { return false; }

            for (int i = 1; i < totalCols; i++)
            {
                var elem = _board[i, (totalRows - 1 - i)];

                if (string.IsNullOrWhiteSpace(elem)) { return false; }

                if (elem != firstElement) { return false; }
            }

            return true;
        }
    }
}
