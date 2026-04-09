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
Console.WriteLine("Hello, this is a multiplayer snake game!\nThe red snake is controlled with WASD, the blue snake with the arrow keys!\nAvoid the other snake and the walls while eating the apple to grow.\nThe winner will be printed at the end of the game.\n");

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
	blueName = Console.ReadLine()!;
}

// Set up board and snakes
Board gameBoard = new();
Snake redSnake = new(redName, [new(0,0), new(1,0), new(2,0)], 'E', ref gameBoard);
Snake blueSnake = new(blueName, [new(gameBoard.Width,gameBoard.Length), new(gameBoard.Width - 1,gameBoard.Length), new(gameBoard.Width - 2,gameBoard.Length)], 'W', ref gameBoard);
gameBoard.Snakes.Add(redSnake);
gameBoard.Snakes.Add(blueSnake);

bool gameOver = false;
string winnerName = "";

// We don't want the cursor to be visible while we're playing
Console.CursorVisible = false;

while (!gameOver)
{
	Console.Clear();
	DrawBoard(gameBoard.Snakes, gameBoard.Apple);

	// Wait a period of time to collect inputs for snake directions or exit
	Thread.Sleep(125);

	// While we have inputs to process, run them through the method to update the Snake directions or exit
	while (Console.KeyAvailable)
	{
		// If someone pressed Escape, we set gameOver to true
		if (!handleKeystroke(Console.ReadKey(true)))
		{
			gameOver = true;
		}
	}

	// Move snakes and capture the booleans from them
	bool redSnakeAlive = redSnake.MoveForward();
	bool blueSnakeAlive = blueSnake.MoveForward();

	if (!redSnakeAlive || !blueSnakeAlive)
	{
		// If either snake bonked, the game is over
		gameOver = true;

		// Deciding who won, currently just who survived the longest
		// Not sure it's currently possible to tie on a head-on collision
		if (!redSnakeAlive && !blueSnakeAlive)
		{
			winnerName = "Neither! It's a tie!";
		}
		else if (redSnakeAlive && !blueSnakeAlive)
		{
			winnerName = $"{redSnake.PlayerName}!";
		}
		else if (!redSnakeAlive && blueSnakeAlive)
		{
			winnerName = $"{blueSnake.PlayerName}!";
		}
	}
}
Console.CursorVisible = true;
Console.BackgroundColor = ConsoleColor.Black;
Console.Clear();
Console.WriteLine($"The winner is... {winnerName}");

// --- Methods ---

// Input Handling, returns false on Escape so we know to exit
bool handleKeystroke(ConsoleKeyInfo keyInfo)
{
	switch (keyInfo.Key)
	{
		// Keys We Want
		// Red Snake
		case ConsoleKey.W:
			redSnake.TurnDirection('N');
			break;
		case ConsoleKey.A:
			redSnake.TurnDirection('W');
			break;
		case ConsoleKey.S:
			redSnake.TurnDirection('S');
			break;
		case ConsoleKey.D:
			redSnake.TurnDirection('E');
			break;
		// Blue Snake
		case ConsoleKey.UpArrow:
			blueSnake.TurnDirection('N');
			break;
		case ConsoleKey.RightArrow:
			blueSnake.TurnDirection('E');
			break;
		case ConsoleKey.DownArrow:
			blueSnake.TurnDirection('S');
			break;
		case ConsoleKey.LeftArrow:
			blueSnake.TurnDirection('W');
			break;
		case ConsoleKey.Escape:
			return false;       // If I have time, have this end the game early and announce the winner based on length instead
		default:
			break;
	}
	return true;
}

void DrawCell(Cell cell, char symbol, ConsoleColor color)
{
	Console.BackgroundColor = color;
	Console.SetCursorPosition(cell.X, cell.Y);
	Console.Write(symbol);
	Console.BackgroundColor = ConsoleColor.Black;
}

void DrawBoard(List<Snake> snakes, Cell apple)
{
	ConsoleColor color;
	char symbol = ' ';
	foreach (Snake snek in snakes)
	{
		// Decide what color we should print the snake's cells in
		if (snek == snakes[0])
			color = ConsoleColor.DarkRed;
		else if (snek == snakes[1])
			color = ConsoleColor.Blue;
		else
			color = ConsoleColor.White;

		foreach (Cell cell in snek.OccupiedCells)
		{
			// Print a different symbol based on if it's the head, body, or tail
			// Head
			if(cell.X == snek.OccupiedCells[^1].X && cell.Y == snek.OccupiedCells[^1].Y)  // Can't compare cells directly without implementing that
			{
				symbol = snek.CurrentDirection switch
				{
					'N' => '^',
					'E' => '>',
					'S' => 'v',
					'W' => '<',
					_ => 'H'
				};
			}
			// Tail
			else if(cell.X == snek.OccupiedCells[0].X && cell.Y == snek.OccupiedCells[0].Y)
				symbol = ':';
			else
				symbol = 'O';

			DrawCell(cell, symbol, color);
		}
	}
	DrawCell(gameBoard.Apple, '@', ConsoleColor.Red);
}