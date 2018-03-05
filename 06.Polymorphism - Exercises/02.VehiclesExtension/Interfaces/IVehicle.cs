public interface IVehicle
{
    double FuelQuantity { get; }
    double FuelConsumptionPerKm { get; }
    string Drive(double distance);
    void Refuel(double liters);
    double TankCapacity { get; }
    string DriveEmpty(double distance);
}