using System;

namespace Othello
{
    class Program
    {
        static void Main(string[] args)
        {
            Board game_board = new Board();
            game_board.GetMoves();
            game_board.ShowBoard();
            game_board.MakeMove();

            game_board.GetMoves();
            game_board.ShowBoard();
            game_board.MakeMove();

            game_board.GetMoves();
            game_board.ShowBoard();
        }
    }
}
