public class DrawingTool
{
    private Rectangle rectangle;
    private Square square;

    public Rectangle Rectangle
    {
        get { return this.rectangle; }
        set { this.rectangle = value; }
    }

    public Square Sqaure
    {
        get { return this.square; }
        set { this.square = value; }
    }

    public DrawingTool(Rectangle rectangle)
    {
        this.rectangle = rectangle;
    }

    public DrawingTool(Square square)
    {
        this.square = square;
    }
}
