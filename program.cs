board mainBoard = new board(); //initialize the board
// Console.Clear();
Console.WriteLine("Computer or player to go first?(C/P)");
string? input = Console.ReadLine();
// Console.Clear();
if (input == "C")
{
    mainBoard.computerValue = 'X';
    mainBoard.playerValue = 'O';
    mainBoard.computerMove();
}
else
{
    mainBoard.computerValue = 'O';
    mainBoard.playerValue = 'X';
    mainBoard.playerMove();
}


