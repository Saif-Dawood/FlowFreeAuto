
namespace FlowFreeGame;



// The Node that is connected by the pipe line in the main game
class Node
{
    // x (column in board)
    // y (row in board)
    private int x, y;
    public Node(int x, int y)
    {
        this.x = x;
        this.y = y;
    }

    public int getX()
    {
        return x;
    }

    public int getY()
    {
        return y;
    }
}
