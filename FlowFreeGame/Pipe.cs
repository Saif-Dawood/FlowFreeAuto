
namespace FlowFreeGame;


enum Color {
    Red,
    Green,
    Blue,
    Yellow,
    Orange,
    Cyan,
    Magenta,
    Brown,
    Purple,
    White,
    Gray,
    Lime,
    Beige,
    Navy,
    Teal,
    Pink,
};


// The Pipes in the main game
class Pipe
{
    Node start, end;
    Color color;
    bool connected;

    public Pipe(int x1, int y1, int x2, int y2, Color color)
    {
        this.start = new Node(x1, y1);
        this.end = new Node(x2, y2);
        this.color = color;
        this.connected = false;
    }
}
