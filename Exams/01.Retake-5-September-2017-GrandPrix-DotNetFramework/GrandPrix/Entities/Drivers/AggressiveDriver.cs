public class AggressiveDriver : Driver
{
    public AggressiveDriver(string name, Car car) : base(name, car)
    {
        this.FuelConsumptionPerKm = 2.7;
    }

    public override double Speed
    {
        get { return base.Speed * 1.3; }
    }
}
