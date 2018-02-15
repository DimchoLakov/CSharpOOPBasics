using System.Collections.Generic;

public class Car
{
    private string model;

    public string Model
    {
        get { return this.model; }
        set { this.model = value; }
    }

    public Cargo Cargo { get; set; }

    public Engine Engine { get; set; }
    public List<Tire> Tires { get; set; }

    public Car()
    {
        this.Tires = new List<Tire>();
    }

    public Car(string model, Cargo cargo, Engine engine, List<Tire> tires)
    {
        this.model = model;
        this.Cargo = cargo;
        this.Engine = engine;
        this.Tires = tires;
    }
}
