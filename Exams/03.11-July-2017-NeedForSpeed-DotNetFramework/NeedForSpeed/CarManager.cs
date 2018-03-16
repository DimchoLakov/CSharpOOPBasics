using System.Collections.Generic;
using System.Linq;
using System.Text;

public class CarManager
{
    public Dictionary<int, Car> Cars { get; }
    public Dictionary<int, Race> Races { get; }
    private Garage garage;

    public CarManager()
    {
        this.Cars = new Dictionary<int, Car>();
        this.Races = new Dictionary<int, Race>();
        garage = new Garage();
    }

    public void Register(int id, string type, string brand, string model, int yearOfProduction, int horsePower,
        int acceleration, int suspension, int durability)
    {
        Car car = CarFactory.CreateCar(type, brand, model, yearOfProduction, horsePower, acceleration, suspension,
            durability);
        this.Cars[id] = car;
    }

    public string Check(int id)
    {
        var car = this.Cars[id];
        return car.ToString();
    }

    public void Open(int id, string type, int length, string route, int prizePool)
    {
        Race race = RaceFactory.CreateRace(type, length, route, prizePool);
        this.Races[id] = race;
    }

    public void Open(int id, string type, int length, string route, int prizePool, int lastParameter)
    {
        Race race = RaceFactory.CreateRace(type, length, route, prizePool, lastParameter);
        this.Races[id] = race;
    }

    public void Participate(int carId, int raceId)
    {
        Car car = this.Cars[carId];
        if (!this.garage.ParkedCars.ContainsKey(carId))
        {
            this.Races[raceId].Participants[carId] = car;
        }
    }

    public string Start(int id)
    {
        var race = this.Races[id];

        if (race.Participants.Count == 0)
        {
            return $"Cannot start the race with zero participants.";
        }

        this.Races.Remove(id);

        return race.ToString();
    }

    public void Park(int id)
    {
        Car car = this.Cars[id];
        if (!this.Races.Values.Any(a => a.Participants.ContainsValue(car)))
        {
            this.garage.ParkedCars[id] = car;
        }
    }

    public void Unpark(int id)
    {
        this.garage.ParkedCars.Remove(id);
    }

    public void Tune(int tuneIndex, string addOn)
    {
        if (this.garage.ParkedCars.Count != 0)
        {
            this.garage.ModifyCars(tuneIndex, addOn);
        }
    }
}