class board
{ //the class for displaying the game board
    public static char[] boardState = new char[9] { '#', '#', '#', '#', '#', '#', '#', '#', '#' }; //initialize the board state
    public static int[] validMoves = new int[9] { 0, 1, 2, 3, 4, 5, 6, 7, 8 }; //initialize the valid moves array
    public static char computerValue;
    public static char playerValue;
    public static bool gameOver = false; //initialize the gameOver variable
    public static char[] makeMove(char[] bs, int move, char value)
    { //make a move on the board
        bs[move] = value;
        for (int i = 0; i < 9; i++)
        {
            if (move - 1 == i)
            {
                //splice validMoves index i out of the array
                validMoves[i] = validMoves[validMoves.Length - 1];
                Array.Resize(ref validMoves, validMoves.Length - 1);
            }
        }
        return bs;
    }
    public static char[] undoMove(char[] bs, int move)
    { //undo a move on the board
        bs[move] = '#';
        Array.Resize(ref validMoves, validMoves.Length + 1);
        validMoves[validMoves.Length - 1] = move;
        return bs;
    }
    public static void showBoard()
    { //print the board to the console
        for (int i = 0; i < 9; i++)
        {
            if (i % 3 == 0)
            {
                System.Console.WriteLine();
            }
            System.Console.Write(boardState[i] + " ");
        }
    }
    public static void playerMove()
    {
        if (checkForWin(boardState) == 'n')
        {
            bool validMove = false; //initialize the validMove variable
            while (!validMove)
            { //loop until a valid move is made
                Console.Clear();
                showBoard(); //show the board
                Console.WriteLine();
                Console.WriteLine("Where would you like to move?(1-9)"); //prompt the user for a move
                string? input = Console.ReadLine(); //get the user's input
                int move = int.Parse(input); //convert the input to an int
                if (move < 1 || move > 9) //if the input is not between 1 and 9
                {
                    //Console.WriteLine("Invalid move"); //print an error message
                }
                else if (boardState[move - 1] != '#') //if the input is already occupied
                {
                    //Console.WriteLine("That space is already occupied"); //print an error message
                }
                else
                { //if the input is valid
                    makeMove(boardState, move - 1, playerValue); //set the board state to playervalue
                    validMove = true; //set the validMove variable to true
                }
            }
            computerMove();
        }
        else if (checkForWin(boardState) == playerValue)
        {
            Console.WriteLine("You win!");
        }
        else if (checkForWin(boardState) == computerValue)
        {
            Console.WriteLine("You lose!");
        }
        else
        {
            Console.WriteLine("It's a tie!");
        }
        {
            Console.WriteLine("You lose!");
        }
    }
    public static void computerMove()
    {
        if (checkForWin(boardState) == 'n')
        {
            // bool validMove = false; //initialize the validMove variable
            // while (!validMove)
            // { //loop until a valid move is made
            //     Random rnd = new Random(); //initialize the random number generator
            //     int move = rnd.Next(1, 10); //get a random number between 1 and 9
            //     if (boardState[move - 1] == '#') //if the random number is not already occupied
            //     {
            //         boardState[move - 1] = computerValue; //set the board state to X
            //         validMove = true; //set the validMove variable to true
            //     }

            // }
            int move;
            if (computerValue == 'O')
            {
                move = minimax.compute(boardState, true);
            }
            else
            {
                move = minimax.compute(boardState, false);
            }
            makeMove(boardState, move - 1, computerValue);
            playerMove();
        }
        else if (checkForWin(boardState) == playerValue)
        {
            Console.WriteLine("You win!");
        }
        else if (checkForWin(boardState) == computerValue)
        {
            Console.WriteLine("You lose!");
        }
    }
    public static char checkForWin(char[] bs)
    {
        if (bs[0] == bs[1] && bs[1] == bs[2] && bs[0] != '#')
        {
            return bs[0];
        }
        else if (bs[3] == bs[4] && bs[4] == bs[5] && bs[3] != '#')
        {
            return bs[3];
        }
        else if (bs[6] == bs[7] && bs[7] == bs[8] && bs[6] != '#')
        {
            return bs[6];
        }
        else if (bs[0] == bs[3] && bs[3] == bs[6] && bs[0] != '#')
        {
            return bs[0];
        }
        else if (bs[1] == bs[4] && bs[4] == bs[7] && bs[1] != '#')
        {
            return bs[1];
        }
        else if (bs[2] == bs[5] && bs[5] == bs[8] && bs[2] != '#')
        {
            return bs[2];
        }
        else if (bs[0] == bs[4] && bs[4] == bs[8] && bs[0] != '#')
        {
            return bs[0];
        }
        else if (bs[2] == bs[4] && bs[4] == bs[6] && bs[2] != '#')
        {
            return bs[2];
        }
        else
        {
            return 'n';
        }
    }

}
