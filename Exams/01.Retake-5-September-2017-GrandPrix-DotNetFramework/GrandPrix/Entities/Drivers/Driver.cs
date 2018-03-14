public abstract class Driver
{
    protected Driver(string name, Car car)
    {
        this.Name = name;
        this.Car = car;
        this.TotalTime = 0;
    }

    private string name;

    public string Name
    {
        get { return this.name; }
        protected set { this.name = value; }
    }

    private double totalTime;

    public double TotalTime
    {
        get { return this.totalTime; }
        set { this.totalTime = value; }
    }

    private Car car;

    public Car Car
    {
        get { return this.car; }
        private set { this.car = value; }
    }

    private double fuelConsumptionPerKm;

    public double FuelConsumptionPerKm
    {
        get { return this.fuelConsumptionPerKm; }
        protected set { this.fuelConsumptionPerKm = value; }
    }

    public virtual double Speed
    {
        get { return (this.Car.Hp + this.Car.Tyre.Degradation) / this.Car.FuelAmount; }
    }

    public void ReduceFuel(int trackLength)
    {
        this.Car.ReduceFuelAmount(trackLength, this.FuelConsumptionPerKm);
    }
}