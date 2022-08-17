
class minimax
{
    public static int compute(char[] boardState, bool isNaughts)
    {
        if (isNaughts)
        {
            if (board.checkForWin(boardState) == 'O')
            {
                return 1;
            }
            else if (board.checkForWin(boardState) == 'X')
            {
                return -1;
            }
            else if ((board.checkForWin(boardState) == 'n') && (board.validMoves.Count() == 0))
            {
                return 0;
            }
            int bestScore = -2;
            int bestMove = -1;
            foreach (int move in board.validMoves)
            {
                boardState = board.makeMove(boardState, move, 'O');
                int score = compute(boardState, false);
                boardState = board.undoMove(boardState, move);
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
            if (board.checkForWin(boardState) == 'X')
            {
                return 1;
            }
            else if (board.checkForWin(boardState) == 'O')
            {
                return -1;
            }
            else if ((board.checkForWin(boardState) == 'n') && (board.validMoves.Count() == 0))
            {
                return 0;
            }
            int bestScore = 2;
            int bestMove = -1;
            foreach (int move in board.validMoves)
            {
                boardState = board.makeMove(boardState, move, 'X');
                int score = compute(boardState, true);
                boardState = board.undoMove(boardState, move);
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
