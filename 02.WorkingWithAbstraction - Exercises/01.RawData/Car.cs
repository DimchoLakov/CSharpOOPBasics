using System.Collections.Generic;

public class Car
{
    private string model;
    private Cargo cargo;
    private Engine engine;
    private List<Tire> tires;

    public string Model
    {
        get { return this.model; }
        set { this.model = value; }
    }

    public Cargo Cargo
    {
        get { return this.cargo; }
        set { this.cargo = value; }
    }
    public Engine Engine
    {
        get { return this.engine; }
        set { this.engine = value; }
    }
    public List<Tire> Tires
    {
        get { return this.tires; }
        set { this.tires = value; }
    }
    public Car()
    {
        this.tires = new List<Tire>();
    }

    public Car(string model, Engine engine, Cargo cargo, List<Tire> tires) : this()
    {
        this.model = model;
        this.engine = engine;
        this.cargo = cargo;
        this.tires = tires;
    }

    public override string ToString()
    {
        return this.Model;
    }
}