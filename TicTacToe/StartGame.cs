using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe;

internal class StartGame
{
    public void Start()
    {
        // keeps track of the player playing
        Player player = new Player();
        // keeps track of game moves
        Board board = new Board(3, 3);
        // game status: 2 someone won, 1 draw match, 0 game still running
        byte status = 0;

        while (true)
        {
            GameHeader();
            board.ShowBoard();

            var move = NextMove(player.Active);
            if(move == null) { continue; }

            int col = move.Item1 - 1;
            int row = move.Item2 - 1;

            if (!board.ValidateMove(col, row))
            {
                NotValidMoveMessage();
                continue;
            }

            status = board.SetMove(col, row, player.Mark);

            if(status != 0) { break; }

            player.NextPlayer();
        }

        GameHeader();
        board.ShowBoard();
        ShowStatus(status, player.Active);
    }

    public void GameHeader()
    {
        Console.Clear();
        Console.WriteLine("Player 1: X -- Player 2: O");
        Console.WriteLine("Choose a position for your move by entering a column number separate by a comma and a row number. Ex.: 1,1");
        Console.WriteLine();
    }

    public Tuple<int, int>? NextMove(int player)
    {
        Console.WriteLine();
        Console.Write($"Player {player} turn: ");
        string? move = Console.ReadLine();

        Tuple<int, int> movePos;
        var validMove = IsValidMove(move, out movePos);

        if (!validMove)
        {
            NotValidMoveMessage();
            return null;
        }

        return movePos;
    }

    public bool IsValidMove(string? move, out Tuple<int, int> movePos)
    {
        movePos = new Tuple<int, int>(0,0);
        if (move == null) { return false; }

        var pos = move.Split(",");

        if (pos.Length != 2) { return false; }

        int col;
        if (!int.TryParse(pos[0].Trim(), out col)) { return false; }

        int row;
        if (!int.TryParse(pos[1].Trim(), out row)) { return false; }

        movePos = new Tuple<int, int>(col, row);
        return true;
    }

    public void ShowStatus(byte status, int lastPlayer)
    {
        Console.WriteLine();
        switch (status)
        {
            case 1:
                Console.WriteLine("We have a draw!!!");
                break;
            case 2:
                Console.WriteLine($"Player {lastPlayer} WINS!!! Congratulations!!!");
                break;
            default:
                Console.WriteLine("Ups!!! Something went wrong...");
                break;
        }
    }

    private void NotValidMoveMessage()
    {
        Console.WriteLine("The value entered is not a valid move.");
        Console.WriteLine("Please try again.");
        Thread.Sleep(1000);
    }
}
