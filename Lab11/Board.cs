namespace Lab11;

// Board class that knows its length and width and the current position of the apple (as a Cell)
public class Board
{
    public int Length {get; private set;}
    public int Width {get; private set;}
    public Cell Apple;
    public List<Snake> Snakes = [];
    private readonly Random appleRandomizer = new();

    public Board(int length, int width, Cell apple)
    {
        Length = length;
        Width = width;
        Apple = apple;
    }
    public Board(Cell apple)
    {
        Length = Console.BufferHeight;
        Width = Console.BufferWidth;
        Apple = apple;
    }

    public void moveApple()
    {
        // Can't place an apple onto a snake, check which cells are occupied
        List<(int X, int Y)> offLimits = [];
        foreach (Snake snek in Snakes)
        {
            foreach (Cell cell in snek.OccupiedCells)
            {
                offLimits.Add((cell.X, cell.Y));
            }
        }

        // Track the number of times we're trying to move the apple
        int attemptsAtPlacement = 0;

        while (true)    // Loop until we get a valid apple location
        {
            attemptsAtPlacement++;

            (int X, int Y) newAppleCoordinates = (appleRandomizer.Next(0, Width + 1), appleRandomizer.Next(0, Length + 1));

            // Check if the generated apple coordinates match any snake cells
            if (!offLimits.Contains(newAppleCoordinates))
            {
                // If the coordinates don't, we can safely generate an apple at those coordinates
                Apple = new(newAppleCoordinates.X, newAppleCoordinates.Y);
                Console.WriteLine(attemptsAtPlacement);
                return;
            }

            // This might be unnecessary but I don't like leaving it to try forever
            if (attemptsAtPlacement >= 100)
            {
                throw new TimeoutException("Too many attempts to find a place for the apple!");
            }
        }
    }
}
