class minimax
{
    public static int compute(char[] boardState, bool isCrosses)
    {
        int[] validMoves = board.getValidMoves(boardState);
        if (isCrosses) // maximizing player
        {
            if (board.checkForWin(boardState) == 'X')
            {
                return -1;
            }
            else if (board.checkForWin(boardState) == 'O')
            {
                return 1;
            }
            else if (board.checkForWin(boardState) == 'n' && !board.hasValidMoves(validMoves))
            {
                return 0;
            }
            int bestScore = -2;
            int bestMove = -30;
            // Console.WriteLine(String.Join("", validMoves));
            foreach (int move in validMoves)
            {
                if (move == 9) continue;
                boardState = board.makeMove(boardState, move + 1, 'X');
                validMoves = board.getValidMoves(boardState);
                //Console.WriteLine(new string (boardState));
                int score = compute(boardState, false);
                boardState = board.undoMove(boardState, move);
                validMoves = board.getValidMoves(boardState);
                if (score > bestScore)
                {
                    bestScore = score;
                    bestMove = move + 1;
                }
            }
            // Console.WriteLine(bestScore);
            return bestMove;
        }
        else // minimizing player
        {
            if (board.checkForWin(boardState) == 'X')
            {
                return 1;
            }
            else if (board.checkForWin(boardState) == 'O')
            {
                return -1;
            }
            else if (board.checkForWin(boardState) == 'n' && !board.hasValidMoves(validMoves))
            {
                return 0;
            }
            int bestScore = 2;
            int bestMove = 30;
            // Console.WriteLine(String.Join("", validMoves));
            foreach (int move in validMoves)
            {
                if (move == 9) continue;
                boardState = board.makeMove(boardState, move + 1, 'O');
                validMoves = board.getValidMoves(boardState);
                int score = compute(boardState, true);
                boardState = board.undoMove(boardState, move);
                validMoves = board.getValidMoves(boardState);
                if (score < bestScore)
                {
                    bestScore = score;
                    bestMove = move + 1;
                }
            }
            // Console.WriteLine(bestScore);
            return bestMove;
        }
    }
}
