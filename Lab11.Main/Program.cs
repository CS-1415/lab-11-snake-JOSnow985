// Jaden Olvera, CS-1410, Lab 11: SNAKES!
Console.WriteLine("Hello, this is a multiplayer snake game!\nOne player will control their snake with WASD, the other with the arrow keys!\nAvoid the other snake and the walls while eating the apple to grow.\nThe winner will be printed at the end of the game.");

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
