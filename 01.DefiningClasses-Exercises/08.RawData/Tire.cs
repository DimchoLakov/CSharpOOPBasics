using System.Collections.Generic;

public class Tire
{
    private int age;

    public int Age
    {
        get { return this.age; }
        set { this.age = value; }
    }

    private double pressure;

    public double Pressure
    {
        get { return this.pressure; }
        set { this.pressure = value; }
    }

    public Tire()
    {
    }

    public Tire(int age, double pressure) : this()
    {
        this.age = age;
        this.pressure = pressure;
    }
}
