using System;
using System.Collections.Generic;
using System.Text;

namespace Othello
{
    class Board
    {
        private int[,] GameBoard = new int[8, 8];
        public Board()
        {
            this.InitBoard();
        }
        public void InitBoard()
        {
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    this.GameBoard[i, j] = 0;
                }
            }
            this.GameBoard[3, 3] = -1;
            this.GameBoard[3, 4] = 1;
            this.GameBoard[4, 3] = 1;
            this.GameBoard[4, 4] = -1;
        }
        public void ShowBoard()
        {
            for(int i = 0; i < 8; i ++)
            {
                for(int j = 0; j < 8; j++)
                {
                    switch(this.GameBoard[i, j])
                    {
                        case -1:
                            Console.Out.Write("[W]");
                            break;
                        case 0:
                            Console.Out.Write("[E]");
                            break;
                        case 1:
                            Console.Out.Write("[B]");
                            break;
                    }
                }
                Console.Out.WriteLine();
            }
        }
    }
}
