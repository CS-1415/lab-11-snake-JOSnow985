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

    public Snake(string playerName, List<Cell> headTail, char currentDirection, Board board)
    {
        PlayerName = playerName;
        OccupiedCells = headTail;
        CurrentDirection = currentDirection;
        Board = board;
    }

    void TurnDirection(char dir){}
    // MoveForward: appends the next cell in the current direction to the end of the occupied cell list and removes the first cell in the list (which is the end of the tail)
    bool MoveForward()
    {
        // if the apple was eaten, then the end of the tail isn't removed
	    // if the head runs into the wall or another player, then return false, otherwise return true)
        return false;
    }
    // a test method (this will be useful to have as a member method so that you can inspect the elements of the list of occupied cells)
    void Test(){}
}