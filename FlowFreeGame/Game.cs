
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
        board = new string[width,height];
        for (int j = 0; j < height; ++j)
            for (int i = 0; i < width; ++i)
                board[i,j] = "";

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
        colors.MoveNext();
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
        
        board[x1,y1] = "s" + color.ToString().Substring(0,2);
        board[x2,y2] = "e" + color.ToString().Substring(0,2);

        return 0;
    }

    // A function to view curent board
    public void printBoard()
    {
        int maxwidth = 0;
        for (int j = 0; j < this.board.GetLength(1); ++j)
        {
            int curwidth = 1;
            for (int i = 0; i < this.board.GetLength(0); ++i)
            {
                if (this.board[i,j] == "")curwidth += 3;
                else curwidth += this.board[i,j].Length;
                curwidth += 1;
            }
            maxwidth = Math.Max(maxwidth, curwidth);
        }

        // Draw upper border
        for (int i = 0; i < maxwidth; ++i)
            Console.Write("_");
        Console.Write("\n");

        // Draw the table
        for (int j = 0; j < this.board.GetLength(1); ++j)
        {
            Console.Write("|");
            for (int i = 0; i < this.board.GetLength(0); ++i)
            {
                if (this.board[i,j] == "")
                    Console.Write("   ");
                else
                    Console.Write(this.board[i,j]);
                Console.Write("|");
            }
            Console.Write("\n");
        }

        // Draw lower border
        for (int i = 0; i < maxwidth; ++i)
            Console.Write("_");
        Console.Write("\n");
    }

}
