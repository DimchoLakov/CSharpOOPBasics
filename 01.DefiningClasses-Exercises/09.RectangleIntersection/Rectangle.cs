public class Rectangle
{
    private string id;

    public string ID
    {
        get { return this.id; }
        set { this.id = value; }
    }

    private double width;

    public double Width
    {
        get { return this.width; }
        set { this.width = value; }
    }

    private double height;

    public double Height
    {
        get { return this.width; }
        set { this.width = value; }
    }

    private double topLeftX;

    public double TopLeftX
    {
        get { return this.topLeftX; }
        set { this.topLeftX = value; }
    }

    private double topLeftY;

    public double TopLeftY
    {
        get { return this.topLeftY; }
        set { this.topLeftY = value; }
    }

    public Rectangle()
    {
    }

    public Rectangle(string id, double width, double height, double topLeftX, double topLeftY)
    {
        this.id = id;
        this.width = width;
        this.height = height;
        this.topLeftX = topLeftX;
        this.topLeftY = topLeftY;
    }

    public bool Intersects(Rectangle rectangle)
    {
        return this.IsInIntersection(rectangle) || rectangle.IsInIntersection(this);
    }

    private bool IsInIntersection(Rectangle rectangle)
    {
        return (this.topLeftX >= rectangle.topLeftX &&
                this.topLeftX <= rectangle.topLeftX + width &&
                this.topLeftY + height >= rectangle.topLeftY &&
                this.topLeftY + height <= rectangle.topLeftY + height)
               ||
               (this.topLeftX + width >= rectangle.topLeftX &&
                this.topLeftX + width <= rectangle.topLeftX + width &&
                this.topLeftY + width >= rectangle.topLeftY &&
                this.topLeftY + width <= rectangle.topLeftY + height)
               ||
               (this.topLeftX >= rectangle.topLeftX &&
                this.topLeftX <= rectangle.topLeftX + width &&
                this.topLeftY >= rectangle.topLeftY &&
                this.topLeftY <= rectangle.topLeftY + height)
               ||
               (this.topLeftX + width >= rectangle.topLeftX &&
                this.topLeftX + width <= rectangle.topLeftX + width &&
                this.topLeftY + height >= rectangle.topLeftY &&
                this.topLeftY + height <= rectangle.topLeftY + height);
    }
}