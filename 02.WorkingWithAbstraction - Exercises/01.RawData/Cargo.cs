using System;

public class Cargo
{
    public int cargoWeight;
    public string cargoType;

    public int CargoWeight
    {
        get { return this.cargoWeight; }
        set { this.cargoWeight = value; }
    }

    public string CargoType
    {
        get { return this.cargoType; }
        set { this.cargoType = value; }
    }

    public Cargo()
    {
    }

    public Cargo(int weight, string type)
    {
        this.cargoWeight = weight;
        this.cargoType = type;
    }
}