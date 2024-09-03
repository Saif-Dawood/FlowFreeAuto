
namespace FlowFreeGame;


// The main game
class Game
{
    // a 2D array for storing what lives in the current cell in the board
    private string[,] board;
    // private int colori = 0;

    public Game(int height, int width, int numPipes, int seed=0)
    {
        // Create a board with height and width
        board = new string[height,width];

        // Check if numPipes is bigger than what could be done
        // TODO
        // For now must be less than 16 (no of colors)
        if (numPipes > 16)
            return;

        // put the pipe's nodes in random positions
        Random rand;
        if (seed == 0)
            rand = new Random();
        else
            rand = new Random(seed);
        // Colors
        var colors = Enum.GetValues(typeof(Color)).Cast<Color>().GetEnumerator();
        for (int i = 0; i < numPipes; ++i)
        {
            int x1, y1, x2, y2;
            do
            {
                x1 = rand.Next(width);
                x2 = rand.Next(width);
                y1 = rand.Next(height);
                y2 = rand.Next(height);
            }while(addPipe(x1, y1, x2, y2, colors.Current) != 0);
            colors.MoveNext();
        }
    }

    // A function for adding a pipe to the board
    public int addPipe(int x1, int y1, int x2, int y2, Color color)
    {
        if (board[x1,y1] != "" || board[x2,y2] != "")
            return Globals.NodeOccupied;
        else if (x1 == x2 || y1 == y2)
            return Globals.StartEqualEnd;
        
        board[x1,y1] = "start" + color.ToString();
        board[x2,y2] = "end" + color.ToString();

        return 0;
    }

}
