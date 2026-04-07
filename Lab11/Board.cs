namespace Lab11;

// Board class that knows its length and width and the current position of the apple (as a Cell)
public class Board
{
    public int Length {get; private set;}
    public int Width {get; private set;}
    public Cell Apple;
}
