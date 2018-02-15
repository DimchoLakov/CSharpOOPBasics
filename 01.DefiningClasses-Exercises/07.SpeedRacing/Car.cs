using System;

class Car
{
    private string model;

    public string Model
    {
        get { return this.model; }
        set { this.model = value; }
    }

    private double fuelAmount;

    public double FuelAmount
    {
        get { return this.fuelAmount; }
        set { this.fuelAmount = value; }
    }

    private double fuelConsumptionFor1Km;

    public double FuelConsumptionFor1Km
    {
        get { return this.fuelConsumptionFor1Km; }
        set { this.fuelConsumptionFor1Km = value; }
    }

    private double distanceTraveled;

    public double DistanceTraveled
    {
        get { return this.distanceTraveled; }
        set { this.distanceTraveled = value; }
    }

    public Car()
    {
        this.distanceTraveled = 0;
    }

    public Car(string model, double fuelAmount, double fuelConsumptionFor1Km) : this()
    {
        this.model = model;
        this.fuelAmount = fuelAmount;
        this.fuelConsumptionFor1Km = fuelConsumptionFor1Km;
    }

    public void Drive(double amountOfKm)
    {
        if (amountOfKm * fuelConsumptionFor1Km > fuelAmount)
        {
            Console.WriteLine($"Insufficient fuel for the drive");
        }
        else
        {
            fuelAmount -= amountOfKm * fuelConsumptionFor1Km;
            distanceTraveled += amountOfKm;
        }
    }
}
