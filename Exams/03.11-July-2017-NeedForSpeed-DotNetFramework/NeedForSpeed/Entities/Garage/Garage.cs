using System.Collections.Generic;

public class Garage
{
    private Dictionary<int, Car> parkedCars;

    public Garage()
    {
        this.parkedCars = new Dictionary<int, Car>();
    }

    public Dictionary<int, Car> ParkedCars
    {
        get => this.parkedCars;
        set => this.parkedCars = value;
    }

    public void ModifyCars(int tuneIndex, string addOn)
    {
        foreach (KeyValuePair<int, Car> idCar in this.parkedCars)
        {
            idCar.Value.HorsePower += tuneIndex;
            idCar.Value.Suspension += tuneIndex / 2;
            if (idCar.Value is PerformanceCar perfCar)
            {
                perfCar.AddOns.Add(addOn);
            }
            else if (idCar.Value is ShowCar showCar)
            {
                showCar.Stars += tuneIndex;
            }
        }
    }
}