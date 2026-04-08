namespace Lab11.Tests;

public class SnakeTests
{
    Board testBoard;
    Snake testSnake;

    [SetUp]
    public void Setup()
    {
        Board testBoard =  new();
        // A snake instance that starts at the top left corner and is facing east
        Snake testSnake = new("testPlayer", [new(0,0), new(0,1), new(0,2)], 'E', ref testBoard);
    }

    // --- Tests for turning each possible direction ---
    [Test]
    public void TurnNorthTest()
    {
        Assert.Pass();
    }

    [Test]
    public void TurnEastTest()
    {
        Assert.Pass();
    }

    [Test]
    public void TurnSouthTest()
    {
        Assert.Pass();
    }

    [Test]
    public void TurnWestTest()
    {
        Assert.Pass();
    }

    // --- Test for moving a snake forward in the direction it's looking ---
    [Test]
    public void MoveForwardTest()
    {
        Assert.Pass();
    }
}