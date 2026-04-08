using NUnit.Framework.Internal;

namespace Lab11.Tests;

public class SnakeTests
{
    Board testBoard;
    Snake testSnake;

    [SetUp]
    public void Setup()
    {
        testBoard = new(5, 5, new(3,3));
        // A snake instance that starts at the top left corner and is facing east
        testSnake = new("testPlayer", [new(0,0), new(1,0), new(2,0)], 'E', ref testBoard);
    }

    // --- Tests for turning each possible direction ---
    [Test]
    public void TurnNorthTest()
    {
        testSnake.TurnDirection('N');
        Assert.That(testSnake.CurrentDirection, Is.EqualTo('N'));
    }

    [Test]
    public void TurnEastTest()
    {
        testSnake.TurnDirection('E');
        Assert.That(testSnake.CurrentDirection, Is.EqualTo('E'));
    }

    [Test]
    public void TurnSouthTest()
    {
        testSnake.TurnDirection('S');
        Assert.That(testSnake.CurrentDirection, Is.EqualTo('S'));
    }

    [Test]
    public void TurnWestTest()
    {
        testSnake.TurnDirection('W');
        Assert.That(testSnake.CurrentDirection, Is.EqualTo('W'));
    }

    // --- Test for moving a snake forward in the direction it's looking ---
    [Test]
    public void MoveForwardTest()
    {
        // With a freshly constructed Snake instance, moving forward should return true (success)
        if (testSnake.MoveForward())
        {
            bool lastCellRemoved = true;
            bool newCellAdded = false;

            foreach (Cell cell in testSnake.OccupiedCells)
            {
                if (cell.X == 0 && cell.Y == 0)
                {
                    lastCellRemoved = false;
                }
                else if (cell.X == 3 && cell.Y == 0)
                {
                    newCellAdded = true;
                }
            }
            if (lastCellRemoved == true && newCellAdded == true)
            {
                Assert.Pass();  // Test passes if the old tail cell has been removed and the new head cell has been added
            }
            else if (lastCellRemoved == false && newCellAdded == true)
            {
                Assert.Fail("The last cell wasn't correctly removed, but a new cell was added.");
            }
            else if (lastCellRemoved == true && newCellAdded == false)
            {
                Assert.Fail("The last cell was removed, but a new cell was not correctly added.");
            }
        }
        else
        {
            Assert.Fail("testSnake.MoveForward() returned false");  // If we got here at all that means the test has failed
        }
    }

    // --- Test for correct behavior when an apple has been eaten ---
    [Test]
    public void AppleEatenTest()
    {
        // Force Apple to cell in front of snake
        testBoard.Apple = new(3,0);

        _ = testSnake.MoveForward();

        bool lastCellRemoved = true;
        bool newCellAdded = false;

        foreach (Cell cell in testSnake.OccupiedCells)
        {
            if (cell.X == 0 && cell.Y == 0)
            {
                lastCellRemoved = false;
            }
            else if (cell.X == 3 && cell.Y == 0)
            {
                newCellAdded = true;
            }
        }
        if (lastCellRemoved == false && newCellAdded == true)
        {
            Assert.Pass();  // This test passes if just a new cell was added
        }
        else
        {
            Assert.Fail("A new cell wasn't added while preserving the last cell.");
        }
    }

    // --- Test for moving a snake forward in the direction it's looking ---
    [Test]
    public void SnakeBonkTest()
    {
        // The snake is on the edge of the board and moving into the wall
        testSnake = new("testPlayer", [new(3,0), new(4,0), new(5,0)], 'E', ref testBoard);
        // MoveForward should return false if the snake runs into a wall
        Assert.That(testSnake.MoveForward(), Is.EqualTo(false));
    }
}