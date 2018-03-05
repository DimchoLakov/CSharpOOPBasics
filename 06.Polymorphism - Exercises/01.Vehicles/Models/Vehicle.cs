using System;

public abstract class Vehicle : IVehicle
{
    private double fuelQuantity;
    private double fuelConsumptionPerKm;
    private double distanceDriven;

    protected Vehicle(double fuelQuantity, double litersFuelConsumptionPerKm)
    {
        this.FuelQuantity = fuelQuantity;
        this.FuelConsumptionPerKm = litersFuelConsumptionPerKm;
    }

    public double FuelQuantity
    {
        get { return this.fuelQuantity; }
        set { this.fuelQuantity = value; }
    }

    public virtual double FuelConsumptionPerKm
    {
        get { return this.fuelConsumptionPerKm; }
        set { this.fuelConsumptionPerKm = value; }
    }
    
    public string Drive(double distance)
    {
        double usedFuel = distance * this.FuelConsumptionPerKm;
        if (usedFuel < this.FuelQuantity)
        {
            this.FuelQuantity -= usedFuel;
            return $"{this.GetType().Name} travelled {distance} km";
        }
        return $"{this.GetType().Name} needs refueling";
    }

    public virtual void Refuel(double liters)
    {
        this.FuelQuantity += liters;
    }

    public override string ToString()
    {
        return $"{this.GetType().Name}: {this.FuelQuantity:f2}";
    }
}