public class Car
{
    private string model;

    public string Model
    {
        get { return this.model; }
        set { this.model = value; }
    }

    private int speed;

    public int Speed
    {
        get { return this.speed; }
        set { this.speed = value; }
    }

    public Car()
    {
    }

    public Car(string model, int speed)
    {
        this.model = model;
        this.speed = speed;
    }

    public override string ToString()
    {
        return $"{this.model} {this.speed}";
    }
}