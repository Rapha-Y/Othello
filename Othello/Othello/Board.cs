using System;
using System.Collections.Generic;
using System.Text;

namespace Othello
{
    class Board
    {
        const int BLACK = 1;
        const int WHITE = -1;

        //8x8 board
        private int[,] GameBoard = new int[8, 8];
        public Board()
        {
            this.InitBoard();
        }
        public void InitBoard()
        {
            //clear board
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    this.GameBoard[i, j] = 0;
                }
            }

            //central stones
            this.GameBoard[3, 3] = WHITE;
            this.GameBoard[3, 4] = BLACK;
            this.GameBoard[4, 3] = BLACK;
            this.GameBoard[4, 4] = WHITE;
        }
        public void ShowBoard()
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            
            int i = 0;
            int j = 0;

            //blank intersection
            Console.Out.Write("   ");

            //column labels
            char utfNumber;
            for (j = 1; j < 9; j++)
            {
                utfNumber = (char)(j + 48);
                Console.Out.Write($"[{utfNumber}]");
            }
            Console.Out.WriteLine();

            char utfChar;
            for (i = 1; i < 9; i++)
            {
                for (j = 0; j < 9; j++)
                {
                    if (j == 0)
                    {
                        //row labels
                        utfChar = (char)(i + 64);
                        Console.Out.Write($"[{utfChar}]");
                    } else
                    {
                        switch(this.GameBoard[i - 1, j - 1])
                        {
                            case -1:
                                Console.Out.Write("[\u25CF]");
                                break;
                            case 0:
                                Console.Out.Write("[ ]");
                                break;
                            case 1:
                                Console.Out.Write("[\u25CB]");
                                break;
                        }
                    }
                }
                Console.Out.WriteLine();
            }
        }
    }
}
