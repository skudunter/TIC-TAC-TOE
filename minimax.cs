
class minimax
{
    public static int compute(char[] boardState, bool isNaughts)
    {
        if (isNaughts)
        {
            if (board.checkForWin() == 'O')
            {
                return 1;
            }
            else if (board.checkForWin() == 'X')
            {
                return -1;
            }
            else if ((board.checkForWin() == 'n') && (board.validMoves.Count() == 0))
            {
                return 0;
            }
            int bestScore = -2;
            int bestMove = -1;
            foreach (int move in board.validMoves)
            {
                board.makeMove(move, 'O');
                int score = compute(boardState, false);
                board.undoMove(move);
                if (score > bestScore)
                {
                    bestScore = score;
                    bestMove = move;
                }
            }
            return bestMove;
        }
        else if (!isNaughts)
        {
            if (board.checkForWin() == 'X')
            {
                return 1;
            }
            else if (board.checkForWin() == 'O')
            {
                return -1;
            }
            else if ((board.checkForWin() == 'n') && (board.validMoves.Count() == 0))
            {
                return 0;
            }
            int bestScore = 2;
            int bestMove = -1;
            foreach (int move in board.validMoves)
            {
                board.makeMove(move, 'X');
                int score = compute(boardState, true);
                board.undoMove(move);
                if (score < bestScore)
                {
                    bestScore = score;
                    bestMove = move;
                }
            }
            return bestMove;
        }
        return 69;//nice
    }
}