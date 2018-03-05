public class Truck : Vehicle
{
    public Truck(double fuelQuantity, double fuelConsumptionPerKm) : base(fuelQuantity, fuelConsumptionPerKm)
    {
    }

    public override double FuelConsumptionPerKm => base.FuelConsumptionPerKm + 1.6;

    public override void Refuel(double liters)
    {
        this.FuelQuantity += liters * 0.95;
    }
}