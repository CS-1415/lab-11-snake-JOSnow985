// Jaden Olvera, CS-1410, Lab 11: SNAKES!

/*
Assignment tips:
Write the output to the console move the cursor with Console.SetCursorPosition then use Console.Write to print a character at that position. 

I used the following to allow me to check keyboard input and to update characters at arbitrary positions on the screen:
	System.Console.ReadKey
	System.ConsoleKey.UpArrow
	System.ConsoleKey.D
	System.Console.SetCursorPosition
	System.Console.Write

The following might help if you choose to have the snakes advance at time intervals rather than only when a button is pressed:
    System.Console.KeyAvailable 
    System.Threading.Thread.Sleep
*/

using Lab11;

Console.Clear();
Console.WriteLine("Hello, this is a multiplayer snake game!\nThe blue snake is controlled with WASD, the red snake with the arrow keys!\nAvoid the other snake and the walls while eating the apple to grow.\nThe winner will be printed at the end of the game.\n");

// Collect the snake names for later printing
Console.WriteLine("What should the red snake be named?");
string redName = "";
while (redName == "")
{
	redName = Console.ReadLine()!;
}

Console.WriteLine("What should the blue snake be named?");
string blueName = "";
while (blueName == "")
{
	redName = Console.ReadLine()!;
}

// Set up board and snakes
Board gameBoard = new();
Snake redSnake = new(redName, [new(0,0), new(1,0), new(2,0)], 'E', ref gameBoard);
Snake blueSnake = new(blueName, [new(gameBoard.Width,gameBoard.Length), new(gameBoard.Width - 1,gameBoard.Length), new(gameBoard.Width - 2,gameBoard.Length)], 'W', ref gameBoard);
gameBoard.Snakes.Add(redSnake);
gameBoard.Snakes.Add(blueSnake);

