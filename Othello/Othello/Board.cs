using System;
using System.Collections.Generic;
using System.ComponentModel;
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
                            x + i <= 7 && y - i >= 0
                            && this.GameBoard[x + i, y - i] != 0 && this.GameBoard[x + i, y - i] != 2;
                            i++
                        )
                        {
                            if (this.GameBoard[x + i, y - i] == this.CurrentPlayer)
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
                        && this.GameBoard[x, y - i] != 0 && this.GameBoard[x, y - i] != 2;
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
                        if (this.GameBoard[x - i, y] == this.CurrentPlayer)
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
                    if (this.GameBoard[i, j] == EMPTY && this.IsMove(i, j))
                    {
                        this.GameBoard[i, j] = POSSIBLE;
                        moveNumber++;
                    }
                }
            }

            return moveNumber;
        }

        public void ClearMoves()
        {
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    if (this.GameBoard[i, j] == POSSIBLE)
                    {
                        this.GameBoard[i, j] = EMPTY;
                    }
                }
            }
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
                        switch (this.GameBoard[i - 1, j - 1])
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

        public void GetInput(out int x, out int y)
        {
            switch (this.CurrentPlayer)
            {
                case BLACK:
                    Console.Out.Write("Player 1, select your next move: ");
                    break;
                case WHITE:
                    Console.Out.Write("Player 2, select your next move: ");
                    break;
            }

            //both values are replaced during the while loop
            x = -1;
            y = -1;

            string move;
            bool valid_move = false;

            while (!valid_move)
            {
                move = Console.ReadLine();
                while (move.Length != 2)
                {
                    Console.Out.Write("Your move must be the row, followed by the column (i.e.: A1). Try again: ");
                    move = Console.ReadLine();
                }

                char[] move_arr = move.ToCharArray();
                int temp_x = (int)move_arr[0]; //65 to 72 (uppercase) or 97 to 104 (lowercase)
                int temp_y = (int)move_arr[1]; //49 to 57
                if (temp_x < 65 || (temp_x > 72 && temp_x < 97) || temp_x > 104 || temp_y < 49 || temp_y > 57)
                {
                    Console.Out.Write("Your move must be the row, followed by the column (i.e.: A1). Try again: ");
                }
                else //convert char values into its respective int values
                {
                    if (temp_x < 72)
                    {
                        x = temp_x - 65;
                    }
                    else
                    {
                        x = temp_x - 104;
                    }
                    y = temp_y - 49;
                    valid_move = !valid_move;

                }
            }
        }

        public void MakeMove()
        {
            int x;
            int y;

            this.GetInput(out x, out y);

            while (this.GameBoard[x, y] != 2)
            {
                Console.Out.WriteLine("That's not a selectable position, pick a place marked with an X");
                this.GetInput(out x, out y);
            }

            //place stone
            this.GameBoard[x, y] = this.CurrentPlayer;

            int i;
            int flip_number;
            bool flippable;

            //left side flips
            if (y > 1)
            {
                //top-left flips
                if (x > 1)
                {
                    if (this.GameBoard[x - 1, y - 1] == -this.CurrentPlayer)
                    {
                        flip_number = 1;
                        flippable = false;

                        for (
                            i = 2;
                            x - i >= 0 && y - i >= 0 && this.GameBoard[x - i, y - i] == -this.CurrentPlayer;
                            i++
                        )
                        {
                            flip_number++;
                        }

                        if (x - i >= 0 && y - i >= 0 && this.GameBoard[x - i, y - i] == this.CurrentPlayer)
                        {
                            flippable = true;
                        }

                        if (flippable)
                        {
                            for (i = 1; i <= flip_number; i++)
                            {
                                this.GameBoard[x - i, y - i] = this.CurrentPlayer;
                            }
                        }
                    }
                }
                //bottom-left flips
                if (x < 6)
                {
                    if (this.GameBoard[x + 1, y - 1] == -this.CurrentPlayer)
                    {
                        flip_number = 1;
                        flippable = false;

                        for (
                            i = 2;
                            x + i <= 7 && y - i >= 0 && this.GameBoard[x + i, y - i] == -this.CurrentPlayer;
                            i++
                        )
                        {
                            flip_number++;
                        }

                        if (x + i <= 7 && y - i >= 0 && this.GameBoard[x + i, y - i] == this.CurrentPlayer)
                        {
                            flippable = true;
                        }

                        if (flippable)
                        {
                            for (i = 1; i <= flip_number; i++)
                            {
                                this.GameBoard[x + i, y - i] = this.CurrentPlayer;
                            }
                        }
                    }
                }
                //horizontal left flips
                if (this.GameBoard[x, y - 1] == -this.CurrentPlayer)
                {
                    flip_number = 1;
                    flippable = false;

                    for (
                        i = 2;
                        y - i >= 0 && this.GameBoard[x, y - i] == -this.CurrentPlayer;
                        i++
                    )
                    {
                        flip_number++;
                    }

                    if (y - i >= 0 && this.GameBoard[x, y - i] == this.CurrentPlayer)
                    {
                        flippable = true;
                    }

                    if (flippable)
                    {
                        for (i = 1; i <= flip_number; i++)
                        {
                            this.GameBoard[x, y - i] = this.CurrentPlayer;
                        }
                    }
                }
            }
            //right side flips
            if (y < 6)
            {
                //top-right flips
                if (x > 1)
                {
                    if (this.GameBoard[x - 1, y + 1] == -this.CurrentPlayer)
                    {
                        flip_number = 1;
                        flippable = false;

                        for (
                            i = 2;
                            x - i >= 0 && y + i <= 7 && this.GameBoard[x - i, y + i] == -this.CurrentPlayer;
                            i++
                        )
                        {
                            flip_number++;
                        }

                        if (x - i >= 0 && y + i <= 7 && this.GameBoard[x - i, y + i] == this.CurrentPlayer)
                        {
                            flippable = true;
                        }

                        if (flippable)
                        {
                            for (i = 1; i <= flip_number; i++)
                            {
                                this.GameBoard[x - i, y + i] = this.CurrentPlayer;
                            }
                        }
                    }
                }
                //bottom-right flips
                if (x < 6)
                {
                    if (this.GameBoard[x + 1, y + 1] == -this.CurrentPlayer)
                    {
                        flip_number = 1;
                        flippable = false;

                        for (
                            i = 2;
                            x - i <= 7 && y + i <= 7 && this.GameBoard[x + i, y + i] == -this.CurrentPlayer;
                            i++
                        )
                        {
                            flip_number++;
                        }

                        if (x - i <= 7 && y + i <= 7 && this.GameBoard[x + i, y + i] == this.CurrentPlayer)
                        {
                            flippable = true;
                        }

                        if (flippable)
                        {
                            for (i = 1; i <= flip_number; i++)
                            {
                                this.GameBoard[x + i, y + i] = this.CurrentPlayer;
                            }
                        }
                    }
                }
                //horizontal right flips
                if (this.GameBoard[x, y + 1] == -this.CurrentPlayer)
                {
                    flip_number = 1;
                    flippable = false;

                    for (
                        i = 2;
                        y + i <= 7 && this.GameBoard[x, y + i] == -this.CurrentPlayer;
                        i++
                    )
                    {
                        flip_number++;
                    }

                    if (y + i >= 0 && this.GameBoard[x, y + i] == this.CurrentPlayer)
                    {
                        flippable = true;
                    }

                    if (flippable)
                    {
                        for (i = 1; i <= flip_number; i++)
                        {
                            this.GameBoard[x, y + i] = this.CurrentPlayer;
                        }
                    }
                }
            }
            //vertical top flips
            if (x > 1)
            {
                if (this.GameBoard[x - 1, y] == -this.CurrentPlayer)
                {
                    flip_number = 1;
                    flippable = false;

                    for (
                        i = 2;
                        x - i >= 0 && this.GameBoard[x - i, y] == -this.CurrentPlayer;
                        i++
                    )
                    {
                        flip_number++;
                    }

                    if (x - i >= 0 && this.GameBoard[x - i, y] == this.CurrentPlayer)
                    {
                        flippable = true;
                    }

                    if (flippable)
                    {
                        for (i = 1; i <= flip_number; i++)
                        {
                            this.GameBoard[x - i, y] = this.CurrentPlayer;
                        }
                    }
                }
            }
            //vertical bottom flips
            if (x < 6)
            {
                if (this.GameBoard[x + 1, y] == -this.CurrentPlayer)
                {
                    flip_number = 1;
                    flippable = false;

                    for (
                        i = 2;
                        x + i <= 7 && this.GameBoard[x + i, y] == -this.CurrentPlayer;
                        i++
                    )
                    {
                        flip_number++;
                    }

                    if (x + i <= 7 && this.GameBoard[x + i, y] == this.CurrentPlayer)
                    {
                        flippable = true;
                    }

                    if (flippable)
                    {
                        for (i = 1; i <= flip_number; i++)
                        {
                            this.GameBoard[x + i, y] = this.CurrentPlayer;
                        }
                    }
                }
            }
        }

        private void GetScore(out int p1, out int p2)
        {
            int p1_score = 0;
            int p2_score = 0;

            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    if (this.GameBoard[i, j] == BLACK)
                    {
                        p1_score++;
                    } 
                    else if (this.GameBoard[i, j] == WHITE)
                    {
                        p2_score++;
                    }
                }
            }

            p1 = p1_score;
            p2 = p2_score;
        }

        public void PlayGame()
        {
            this.InitBoard();

            while (this.ConsecutivePasses < 2)
            {
                int move_number = this.GetMoves();
                this.ShowBoard();

                int p1_score;
                int p2_score;
                this.GetScore(out p1_score, out p2_score);
                Console.Out.WriteLine($"\nScore - P1: {p1_score} | P2: {p2_score}");

                if (move_number > 0)
                {
                    this.ConsecutivePasses = 0;
                    this.MakeMove();
                    this.ClearMoves();
                } 
                else
                {
                    this.ConsecutivePasses++;
                    switch (this.CurrentPlayer)
                    {
                        case BLACK:
                            Console.Out.WriteLine("P1 is out of moves, P1 passes!");
                            break;
                        case WHITE:
                            Console.Out.WriteLine("P2 is out of moves, P2 passes!");
                            break;
                    }                            
                }
                this.CurrentPlayer = -this.CurrentPlayer;

                Console.Out.WriteLine();
            }

            Console.Out.WriteLine("Game over!");
        }
    }
}
