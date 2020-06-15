using System;
using System.Collections.Generic;
using System.Text;

namespace Othello
{
    class Board
    {
        //8x8 board w/room for coordinates
        private char[,] GameBoard = new char[9, 9];
        public Board()
        {
            this.InitBoard();
        }
        public void InitBoard()
        {
            //clear board
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    this.GameBoard[i, j] = ' ';
                }
            }

            //letter labels for 1st column
            for (int i = 1; i < 9; i++)
            {
                this.GameBoard[i, 0] = (char) (i+64);
            }

            //number labels for 1st row
            for (int j = 1; j < 9; j++)
            {
                this.GameBoard[0, j] = (char) (j+48);
            }

            //central stones
            this.GameBoard[4, 4] = '\u25CF';
            this.GameBoard[4, 5] = '\u25CB';
            this.GameBoard[5, 4] = '\u25CB';
            this.GameBoard[5, 5] = '\u25CF';
        }
        public void ShowBoard()
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            
            int i = 0;
            int j = 0;

            //empty space
            Console.Out.Write("   ");

            //1st row, only row with a different 1st column
            for (j = 1; j < 9; j++)
            {
                Console.Out.Write($"[{this.GameBoard[i, j]}]");
            }
            Console.Out.WriteLine();

            //2nd to 9th rows
            for (i = 1; i < 9; i++)
            {
                for (j = 0; j < 9; j++)
                {
                    Console.Out.Write($"[{this.GameBoard[i, j]}]");
                }
                Console.Out.WriteLine();
            }
        }
    }
}
