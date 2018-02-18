public class Rectangle
{
    private Point topLeft;
    private Point botRight;

    public Point TopLeft
    {
        get { return this.topLeft; }
        set { this.topLeft = value; }
    }

    public Point BotRight
    {
        get { return this.botRight; }
        set { this.botRight = value; }
    }

    public Rectangle()
    {
    }

    public Rectangle(Point topLeft, Point botRight)
    {
        this.topLeft = topLeft;
        this.botRight = botRight;
    }

    public bool Contains(Point point)
    {
        int x = point.X;
        int y = point.Y;

        return
            x >= this.topLeft.X && x <= this.botRight.X
            &&
            y >= this.topLeft.Y && y <= this.botRight.Y;
    }
}