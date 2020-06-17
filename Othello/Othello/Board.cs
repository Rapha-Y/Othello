using System;
using System.Collections.Generic;
using System.Text;

namespace Othello
{
    class Board
    {
        const int WHITE = -1;
        const int EMPTY = 0;
        const int BLACK = 1;
        const int POSSIBLE = 2;

        //8x8 board
        private int[,] GameBoard = new int[8, 8];
        private int CurrentPlayer;
        private int ConsecutivePasses;

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
                    this.GameBoard[i, j] = EMPTY;
                }
            }

            //central stones
            this.GameBoard[3, 3] = WHITE;
            this.GameBoard[3, 4] = BLACK;
            this.GameBoard[4, 3] = BLACK;
            this.GameBoard[4, 4] = WHITE;

            //set game state
            this.CurrentPlayer = BLACK;
            this.ConsecutivePasses = 0;
        }

        private bool IsMove(int x, int y)
        {
            //left checks
            if (y > 1)
            {
                //top-left check
                if (x > 1)
                {
                    if (this.GameBoard[x - 1, y - 1] == -this.CurrentPlayer)
                    {
                        for (
                            int i = 2; 
                            x - i >= 0 && y - i >= 0 
                            && this.GameBoard[x - i, y - i] != 0 && this.GameBoard[x - i, y - i] != 2;
                            i++
                        ) 
                        {
                            if (this.GameBoard[x - i, y - i] == this.CurrentPlayer)
                            {
                                return true;
                            }
                        }
                    }
                }
                //bottom-left check
                if (x < 6)
                {
                    if (this.GameBoard[x + 1, y - 1] == -this.CurrentPlayer)
                    {
                        for (
                            int i = 2;
                            x - i >= 0 && y + i <= 7
                            && this.GameBoard[x - i, y + i] != 0 && this.GameBoard[x - i, y + i] != 2;
                            i++
                        )
                        {
                            if (this.GameBoard[x - i, y + i] == this.CurrentPlayer)
                            {
                                return true;
                            }
                        }
                    }
                }
                //left check
                if (this.GameBoard[x, y - 1] == -this.CurrentPlayer)
                {
                    for (
                        int i = 2;
                        y - i >= 0
                        && this.GameBoard[x, y - i] != 0 && this.GameBoard[x, y + i] != 2;
                        i++
                    )
                    {
                        if (this.GameBoard[x, y - i] == this.CurrentPlayer)
                        {
                            return true;
                        }
                    }
                }
            }
            //right checks
            if (y < 6)
            {
                //top-right check
                if (x > 1)
                {
                    if (this.GameBoard[x - 1, y + 1] == -this.CurrentPlayer)
                    {
                        for (
                            int i = 2;
                            x - i >= 0 && y + i <= 7
                            && this.GameBoard[x - i, y + i] != 0 && this.GameBoard[x - i, y + i] != 2;
                            i++
                        )
                        {
                            if (this.GameBoard[x - i, y + i] == this.CurrentPlayer)
                            {
                                return true;
                            }
                        }
                    }
                }
                //bottom-right check
                if (x < 6)
                {
                    if (this.GameBoard[x + 1, y + 1] == -this.CurrentPlayer)
                    {
                        for (
                            int i = 2;
                            x + i <= 7 && y + i <= 7
                            && this.GameBoard[x + i, y + i] != 0 && this.GameBoard[x + i, y + i] != 2;
                            i++
                        )
                        {
                            if (this.GameBoard[x + i, y + i] == this.CurrentPlayer)
                            {
                                return true;
                            }
                        }
                    }
                }
                //right check
                if (this.GameBoard[x, y + 1] == -this.CurrentPlayer)
                {
                    for (
                        int i = 2;
                        y + i <= 7
                        && this.GameBoard[x, y + i] != 0 && this.GameBoard[x, y + i] != 2;
                        i++
                    )
                    {
                        if (this.GameBoard[x, y + i] == this.CurrentPlayer)
                        {
                            return true;
                        }
                    }
                }
            }
            //top check
            if (x > 1)
            {
                if (this.GameBoard[x - 1, y] == -this.CurrentPlayer)
                {
                    for (
                        int i = 2;
                        x - 1 >= 0
                        && this.GameBoard[x - i, y] != 0 && this.GameBoard[x - i, y] != 2;
                        i++
                    )
                    {
                        if(this.GameBoard[x - i, y] == this.CurrentPlayer)
                        {
                            return true;
                        }
                    }
                }
            }
            //bottom check
            if (x < 6)
            {
                if (this.GameBoard[x + 1, y] == -this.CurrentPlayer)
                {
                    for (
                        int i = 2;
                        x - 1 <= 7
                        && this.GameBoard[x + i, y] != 0 && this.GameBoard[x + i, y] != 2;
                        i++
                    )
                    {
                        if (this.GameBoard[x + i, y] == this.CurrentPlayer)
                        {
                            return true;
                        }
                    }
                }
            }
            return false;
        }

        public int GetMoves()
        {
            int moveNumber = 0;
            
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    if (this.IsMove(i, j))
                    {
                        this.GameBoard[i, j] = POSSIBLE;
                        moveNumber++;
                    }
                }
            }

            return moveNumber;
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
                    } 
                    else
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
                            case 2:
                                Console.Out.Write("[X]");
                                break;
                        }
                    }
                }
                Console.Out.WriteLine();
            }
        }
    }
}
