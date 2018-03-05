using System;

public class Truck : Vehicle
{
    public Truck(double fuelQuantity, double fuelConsumptionPerKm, double tankCapacity) : base(fuelQuantity, fuelConsumptionPerKm, tankCapacity)
    {
    }

    public override double FuelConsumptionPerKm => base.FuelConsumptionPerKm + 1.6;

    public override void Refuel(double liters)
    {
        if (AreLitersLessThanOne(liters))
        {
            throw new ArgumentException("Fuel must be a positive number");
        }

        if (liters > this.TankCapacity - this.FuelQuantity)
        {
            throw new ArgumentException($"Cannot fit {liters} fuel in the tank");
        }
        this.FuelQuantity += liters * 0.95;
    }
}