class minimax
{
    public int compute(board board, bool isCrosses)
    {
        if (isCrosses) // maximizing player
        {
            if (board.checkForWin() == 'X')
            {
                return -1;
            }
            else if (board.checkForWin() == 'O')
            {
                return 1;
            }
            else if (board.checkForWin() == 'n' && !board.hasValidMoves())
            {
                return 0;
            }
            int bestScore = -int.MaxValue;
            int bestMove = 0;
            // Console.WriteLine(String.Join("", validMoves));
            foreach (int move in board.validMoves)
            {
                if (move == 9) continue;
                board.makeMove(move+1, 'X');
                //Console.WriteLine(new string (boardState));
                int score = compute(board, false);
                board.undoMove(move+1);
                if (score > bestScore)
                {
                    bestScore = score;
                    bestMove = move+1;
                }
            }
            // Console.WriteLine(bestScore);
            return bestMove;
        }
        else // minimizing player
        {
            if (board.checkForWin() == 'X')
            {
                return 1;
            }
            else if (board.checkForWin() == 'O')
            {
                return -1;
            }
            else if (board.checkForWin() == 'n' && !board.hasValidMoves())
            {
                return 0;
            }
            int bestScore = int.MaxValue;
            int bestMove = 30;
            // Console.WriteLine(String.Join("", validMoves));
            foreach (int move in board.validMoves)
            {
                if (move == 9) continue;
                board.makeMove(move+1, 'O');
                int score = compute(board, true);
                board.undoMove(move+1);
                if (score < bestScore)
                {
                    bestScore = score;
                    bestMove = move+1;
                }
            }
            // Console.WriteLine(bestScore);
            return bestMove;
        }
    }
}
