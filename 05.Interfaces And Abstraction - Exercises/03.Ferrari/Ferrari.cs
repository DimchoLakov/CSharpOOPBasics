public class Ferrari : IDrivable
{
    private string model;

    public string Model
    {
        get { return "488-Spider"; }
    }

    private string driver;

    public string Driver
    {
        get { return this.driver; }
        set { this.driver = value; }
    }

    public string Brakes()
    {
        return "Brakes!";
    }

    public string Gas()
    {
        return "Zadu6avam sA!";
    }

    public Ferrari(string driverName)
    {
        this.Driver = driverName;
    }

    public override string ToString()
    {
        return $"{this.Model}/{this.Brakes()}/{this.Gas()}/{this.Driver}";
    }
}