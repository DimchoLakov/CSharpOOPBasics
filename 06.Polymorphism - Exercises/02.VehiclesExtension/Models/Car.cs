public class Car : Vehicle
{
    public Car(double fuelQuantity, double fuelConsumptionPerKm, double tankCapacity) : base(fuelQuantity, fuelConsumptionPerKm, tankCapacity)
    {

    }

    public override double FuelConsumptionPerKm => base.FuelConsumptionPerKm + 0.9;
}