board mainBoard = new board(); //initialize the board

Console.Clear();
Console.WriteLine("Computer or player to go first?(C/P)");
string? input = Console.ReadLine();
Console.Clear();
if (input == "C")
{
    board.computerValue = 'O';
    board.playerValue = 'X';
    board.computerMove();
}
else
{
    board.computerValue = 'X';
    board.playerValue = 'O';
    board.playerMove();
}


