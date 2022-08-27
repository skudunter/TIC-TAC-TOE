class board
{ //the class for displaying the game board
    public char[] boardState = new char[9] { '#', '#', '#', '#', '#', '#', '#', '#', '#' }; //initialize the board state
    public int[] validMoves = new int[9] { 0, 1, 2, 3, 4, 5, 6, 7, 8 }; //initialize the valid moves array
    public char computerValue;
    public char playerValue;
    public int count = 0;
    public bool gameOver = false; //initialize the gameOver variable
    public minimax engine = new minimax();
    public char[] makeMove(int move, char value)
    { //make a move on the board
        boardState[move - 1] = value;
        return boardState;
    }
    public char[] undoMove(int move)
    { //undo a move on the board
        boardState[move - 1] = '#';
        return boardState;
    }
    public void showBoard()
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
    public void playerMove()
    {
        if (checkForWin() == 'n')
        {
            bool validMove = false; //initialize the validMove variable
            while (!validMove)
            {
                //Console.Clear();
                showBoard(); //show the board
                Console.WriteLine();
                Console.WriteLine("Where would you like to move?(1-9)"); //prompt the user for a move
                string? input = Console.ReadLine(); //get the user's input
                int move = 0; //initialize the move variable
                if (input != null)
                {
                    move = int.Parse(input);
                }
                if (move < 1 || move > 9) //if the input is not between 1 and 9
                {
                    Console.WriteLine("Invalid move"); //print an error message
                }
                else if (boardState[move - 1] != '#') //if the input is already occupied
                {
                    Console.WriteLine("That space is already occupied"); //print an error message
                }
                else
                { //if the input is valid
                    boardState = makeMove(move, playerValue); //set the board state to playervalue
                    validMoves = getValidMoves(); //get the valid moves
                    validMove = true; //set the validMove variable to true
                }
            }
            computerMove();
        }
        else if (checkForWin() == playerValue)
        {
            Console.WriteLine("You win!");
        }
        else if (checkForWin() == computerValue)
        {
            Console.WriteLine("You lose!");
        }
        else
        {
            Console.WriteLine("It's a tie!");
        }
    }
    public void computerMove()
    {
        if (checkForWin() == 'n')
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
            if (computerValue == 'X')
            {
                move = engine.compute(this, true);
            }
            else
            {
                move = engine.compute(this, false);
            }
            Console.WriteLine("Computer Move" + move);
            if (move >= 0 || move <= 8)
            {
                boardState = makeMove(move, computerValue);
                validMoves = getValidMoves();
            }
            playerMove();
        }
        else if (checkForWin() == playerValue)
        {
            Console.WriteLine("You win!");
        }
        else if (checkForWin() == computerValue)
        {
            Console.WriteLine("You lose!");
        }
    }
    public char checkForWin()
    {
        if (boardState[0] == boardState[1] && boardState[1] == boardState[2] && boardState[0] != '#')
        {
            return boardState[0];
        }
        else if (boardState[3] == boardState[4] && boardState[4] == boardState[5] && boardState[3] != '#')
        {
            return boardState[3];
        }
        else if (boardState[6] == boardState[7] && boardState[7] == boardState[8] && boardState[6] != '#')
        {
            return boardState[6];
        }
        else if (boardState[0] == boardState[3] && boardState[3] == boardState[6] && boardState[0] != '#')
        {
            return boardState[0];
        }
        else if (boardState[1] == boardState[4] && boardState[4] == boardState[7] && boardState[1] != '#')
        {
            return boardState[1];
        }
        else if (boardState[2] == boardState[5] && boardState[5] == boardState[8] && boardState[2] != '#')
        {
            return boardState[2];
        }
        else if (boardState[0] == boardState[4] && boardState[4] == boardState[8] && boardState[0] != '#')
        {
            return boardState[0];
        }
        else if (boardState[2] == boardState[4] && boardState[4] == boardState[6] && boardState[2] != '#')
        {
            return boardState[2];
        }
        else
        {
            return 'n';
        }
    }
    public int[] getValidMoves()
    { //get the valid moves
        int[] validMoves = new int[9]; //initialize the validMoves array
        for (int i = 0; i < 9; i++)
        {
            if (boardState[i] == '#')
            {
                validMoves[i] = i;
            }
            else
            {
                validMoves[i] = 9; // out of bounds
            }
        }
        return validMoves;
    }
    public bool hasValidMoves()
    {
        bool valid = false;
        for (int i = 0; i < 9; i++)
        {
            if (validMoves[i] != 9)
            {
                valid = true;
            }
        }
        return valid;
    }
}
