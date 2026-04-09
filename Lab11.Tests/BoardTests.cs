namespace Lab11.Tests;

public class BoardTests
{
    Board testBoard;
    Snake snakeOne;
    Snake snakeTwo;

    [SetUp]
    public void Setup()
    {
        testBoard = new(5, 5, new(3,3));
        snakeOne = new("testOne", [new(0,0), new(1,0), new(2,0)], 'E', ref testBoard);
        testBoard.Snakes.Add(snakeOne);
        snakeTwo = new("testTwo", [new(5,5), new(4,5), new(3,5)], 'W', ref testBoard);
        testBoard.Snakes.Add(snakeTwo);
    }

    [Test]
    public void ConsoleBoundsTest()
    {
        // Board should let us construct an instance without specifying bounds
        // It should find the console's width and height to use as bounds
        Board boundBoard = new(new(3,3));

        // Check that the width and length are equal to console buffer width and height, respectively
        Assert.Multiple(() =>
        {
            Assert.That(boundBoard.Width, Is.EqualTo(Console.BufferWidth));
            Assert.That(boundBoard.Length, Is.EqualTo(Console.BufferHeight));
        });
    }

    // This test might fail if the same location is randomly selected, because a snake isn't occupying that cell yet
    [Test]
    public void MoveAppleTest()
    {
        // Grabs the old Apple's coordinates
        (int X, int Y) oldApple = (testBoard.Apple.X, testBoard.Apple.Y);
        // Tells the board the apple needs to be moved
        testBoard.moveApple();
        // Grab the new Apple's coordinates
        (int X, int Y) newApple = (testBoard.Apple.X, testBoard.Apple.Y);
        // Test that the tuples aren't the same
        Assert.That(newApple, Is.Not.EqualTo(oldApple));
    }

    // This test is probably a bad idea, but the idea is to make sure the apple is never placed on a snake by accident
    [Test]
    public void AppleSpawnTest()
    {
        // Run the move method twice as many times as possible cells we can have
        for (int i = 0; i < testBoard.Length * testBoard.Width * 2; i++)
        {
            // Move the apple to a new location
            testBoard.moveApple();

            // Check occupied cells on the board for a matching cell
            foreach (Snake snek in testBoard.Snakes)
            {
                foreach (Cell cell in snek.OccupiedCells)
                {
                    if (testBoard.Apple.X == cell.X && testBoard.Apple.Y == cell.Y)
                        Assert.Fail("Apple cell was occupied.");
                }
            }
        }
        Assert.Pass();  // If we got through the torture test, the apple was never moved to a bad location
    }
}