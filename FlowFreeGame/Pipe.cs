


// The Pipes in the main game
class Pipe
{
    Node start, end;
    bool connected;

    public Pipe(int x1, int y1, int x2, int y2)
    {
        this.start = new Node(x1, y1);
        this.end = new Node(x2, y2);
        this.connected = false;
    }
}
