using System;

public class Car
{
    public Car(int hp, double fuelAmount, Tyre tyre)
    {
        this.FuelAmount = fuelAmount;
        this.Hp = hp;
        this.Tyre = tyre;
    }

    private const double MAX_TANK_CAPACITY = 160d;

    private int hp;

    public int Hp
    {
        get { return this.hp; }
        private set { this.hp = value; }
    }

    private double fuelAmount;

    public double FuelAmount
    {
        get { return this.fuelAmount; }
        private set
        {
            if (value < 0)
            {
                throw new ArgumentException("Out of fuel");
            }

            this.fuelAmount = value > MAX_TANK_CAPACITY ? MAX_TANK_CAPACITY : value;
        }
    }

    private Tyre tyre;

    public Tyre Tyre
    {
        get { return this.tyre; }
        private set { this.tyre = value; }
    }

    public void ReduceFuelAmount(int trackLength, double fuelConsumption)
    {
        this.FuelAmount -= trackLength * fuelConsumption;
    }

    public void Refuel(double fuelAmount)
    {
        this.FuelAmount += fuelAmount;
    }

    public void ChangeTyre(Tyre newTyre)
    {
        this.Tyre = newTyre;
    }
}