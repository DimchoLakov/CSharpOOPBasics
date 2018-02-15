public class Engine
{
    private int power;

    public int Power
    {
        get { return this.power; }
        set { this.power = value; }
    }

    private int speed;

    public int Speed
    {
        get { return this.speed; }
        set { this.speed = value; }
    }

    public Engine()
    {
    }

    public Engine(int power, int speed)
    {
        this.power = power;
        this.speed = speed;
    }
}
