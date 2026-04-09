namespace Lab11;

// A Snake class that has the player's name, the List of Cells occupied by the head and tail, 
// a current direction (represented however you want but that indicates one of up, down, left, right), 
// and a reference to a Board.
public class Snake
{

    public string PlayerName { get; private set; }
    public List<Cell> OccupiedCells { get; set; }
    public char CurrentDirection {get; private set; }
    public Board Board { get; private set; }

    public Snake(string playerName, List<Cell> headTail, char currentDirection, ref Board board)
    {
        PlayerName = playerName;
        OccupiedCells = headTail;
        CurrentDirection = currentDirection;
        Board = board;
    }

    public void TurnDirection(char dir) => CurrentDirection = dir;

    // MoveForward: appends the next cell in the current direction to the end of the occupied cell list and removes the first cell in the list (which is the end of the tail)
    public bool MoveForward()
    {
        // Figure out which cell we're trying to move into
        (int X, int Y) targetCell;
        switch (CurrentDirection)
        {
            case 'N':
                targetCell = (OccupiedCells[^1].X, OccupiedCells[^1].Y - 1);
                break;
            case 'E':
                targetCell = (OccupiedCells[^1].X + 1, OccupiedCells[^1].Y);
                break;
            case 'S':
                targetCell = (OccupiedCells[^1].X, OccupiedCells[^1].Y + 1);
                break;
            case 'W':
                targetCell = (OccupiedCells[^1].X - 1, OccupiedCells[^1].Y);
                break;
            default:
                return false;   // If we don't have a valid direction, something has gone very wrong, so just return false
        }

        // If we're exceeding the bounds of the board, we bonk
        if (targetCell.X > Board.Width || targetCell.Y > Board.Length)
            return false;
        if (targetCell.X < 0 || targetCell.Y < 0)
            return false;

        // If we're trying to enter an occupied cell, we bonk (Apple cells aren't "occupied")
        foreach (Snake snek in Board.Snakes)
        {
            foreach (Cell cell in snek.OccupiedCells)
            {
                if (targetCell.X == cell.X && targetCell.Y == cell.Y)
                    return false;
            }
        }

        // We need to add a new cell to the bottom of the list before trying to move the apple,
        // otherwise it won't know the cell isn't available
        OccupiedCells.Add(new(targetCell.X, targetCell.Y));

        // Check if we've entered the same cell as the apple
        if (targetCell.X == Board.Apple.X && targetCell.Y == Board.Apple.Y)
        {
            Board.moveApple();
        }
        else
        {
            OccupiedCells.RemoveAt(0);  // If the snake isn't eating an apple, remove the first entry in the cell list
        }
        return true;
    }
    // a test method (this will be useful to have as a member method so that you can inspect the elements of the list of occupied cells)
    void Test(){}
}