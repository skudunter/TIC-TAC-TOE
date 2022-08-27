class minimax
{
    public int compute(board board, bool isCrosses)
    {
        int[] validMoves = board.getValidMoves();
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
            int bestScore = -2;
            int bestMove = -30;
            // Console.WriteLine(String.Join("", validMoves));
            foreach (int move in validMoves)
            {
                if (move == 9) continue;
                board.boardState = board.makeMove(move, 'X');
                board.validMoves = board.getValidMoves();
                //Console.WriteLine(new string (boardState));
                int score = compute(board, false);
                board.boardState = board.undoMove(move);
                board.validMoves = board.getValidMoves();
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
            int bestScore = 2;
            int bestMove = 30;
            // Console.WriteLine(String.Join("", validMoves));
            foreach (int move in validMoves)
            {
                if (move == 9) continue;
                board.boardState = board.makeMove(move, 'O');
                validMoves = board.getValidMoves();
                int score = compute(board, true);
                board.boardState = board.undoMove(move);
                board.validMoves = board.getValidMoves();
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
