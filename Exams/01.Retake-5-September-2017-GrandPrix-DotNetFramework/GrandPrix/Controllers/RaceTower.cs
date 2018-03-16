using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class RaceTower
{
    public bool HasRaceFinished { get; set; }
    public string Weather { get; set; }
    public int TrackLength { get; set; }
    public Dictionary<string, Driver> Drivers { get; private set; }
    public Dictionary<Driver, string> DisqualifiedDrivers { get; private set; }
    private int totalLaps;
    private int currentLap;

    public RaceTower()
    {
        this.Weather = "Sunny";
        this.Drivers = new Dictionary<string, Driver>();
        this.DisqualifiedDrivers = new Dictionary<Driver, string>();
        this.currentLap = 0;
    }

    public int TotalLaps
    {
        get { return this.totalLaps; }
        set
        {
            if (value < 0)
            {
                throw new ArgumentException($"There is no time! On lap {this.currentLap}.");
            }

            this.totalLaps = value;
        }
    }
    
    public void SetTrackInfo(int totalLaps, int length)
    {
        this.TotalLaps = totalLaps;
        this.TrackLength = length;
    }

    public void RegisterDriver(List<string> arguments)
    {
        try
        {
            Driver driver = DriverFactory.CreateDriver(arguments);
            this.Drivers[driver.Name] = driver;
        }
        catch (Exception exception)
        {
            Console.WriteLine(exception.Message);
        }
    }

    public void DriverBoxes(List<string> arguments)
    {
        string command = arguments[0];
        string driverName = arguments[1];

        this.Drivers[driverName].TotalTime += 20;

        if (command == "ChangeTyres")
        {
            string tyreType = arguments[2];
            double hardness = double.Parse(arguments[3]);

            if (tyreType == "Ultrasoft")
            {
                double grip = double.Parse(arguments[4]);
                Tyre tyre = new UltrasoftTyre(hardness, grip);
                this.Drivers[driverName].Car.ChangeTyre(tyre);
            }
            else if (tyreType == "Hard")
            {
                Tyre tyre = new HardTyre(hardness);
                this.Drivers[driverName].Car.ChangeTyre(tyre);
            }
        }
        else if (command == "Refuel")
        {
            double fuelAmount = double.Parse(arguments[2]);
            this.Drivers[driverName].Car.Refuel(fuelAmount);
        }
    }

    public string CompleteLaps(List<string> arguments)
    {
        int currentNumberOfLaps = int.Parse(arguments[0]);
        if (this.TotalLaps - this.currentLap < currentNumberOfLaps)
        {
            return $"There is no time! On lap {this.currentLap}.";
        }

        StringBuilder sb = new StringBuilder();

        for (int i = 0; i < currentNumberOfLaps; i++)
        {
            this.currentLap++;

            IncreaseDriversTotalTime();

            DecreaseFuelAndDegradateTyreAndDisqualifyDrivers();

            RemoveDisqualifiedDriversFromRace();

            var orderedDrivers = this.Drivers
                .OrderByDescending(t => t.Value.TotalTime)
                .Select(d => d.Value)
                .ToList();

            string overtakeMessage = Overtake(orderedDrivers);

            if (overtakeMessage != string.Empty)
            {
                sb.AppendLine(overtakeMessage);
            }

            
        }

        if (this.currentLap == this.TotalLaps)
        {
            this.HasRaceFinished = true;
            return GetWinner();
        }

        return sb.ToString().Trim();
    }

    private string Overtake(List<Driver> orderedDrivers)
    {
        StringBuilder sb = new StringBuilder();
        for (int j = 1; j < orderedDrivers.Count; j++)
        {
            Driver driverBehind = orderedDrivers[j - 1];
            Driver driverAhead = orderedDrivers[j];

            double driverBehindTime = driverBehind.TotalTime;
            double driverAheadTime = driverAhead.TotalTime;
            double diff = Math.Abs(driverBehindTime - driverAheadTime);

            string driverBehindType = driverBehind.GetType().Name;
            string driverBehindTyreType = driverBehind.Car.Tyre.Name;

            if (diff <= 3 && driverBehindType == "AggressiveDriver" && driverBehindTyreType == "Ultrasoft")
            {
                if (this.Weather == "Foggy")
                {
                    this.DisqualifiedDrivers[driverBehind] = "Crashed";
                    this.Drivers.Remove(driverBehind.Name);
                    orderedDrivers.Remove(driverBehind);
                    j--;
                }
                else
                {
                    this.Drivers[driverBehind.Name].TotalTime -= 3;

                    this.Drivers[driverAhead.Name].TotalTime += 3;

                    sb.AppendLine($"{driverBehind.Name} has overtaken {driverAhead.Name} on lap {this.currentLap}.");
                }
            }
            else if (diff <= 3 && driverBehindType == "EnduranceDriver" && driverBehindTyreType == "Hard")
            {
                if (this.Weather == "Rainy")
                {
                    this.DisqualifiedDrivers[driverBehind] = "Crashed";
                    this.Drivers.Remove(driverBehind.Name);
                    orderedDrivers.Remove(driverBehind);
                    j--;
                }
                else
                {
                    this.Drivers[driverBehind.Name].TotalTime -= 3;

                    this.Drivers[driverAhead.Name].TotalTime += 3;

                    sb.AppendLine($"{driverBehind.Name} has overtaken {driverAhead.Name} on lap {this.currentLap}.");
                }
            }
            else if (diff <= 2)
            {
                this.Drivers[driverBehind.Name].TotalTime -= 2;

                this.Drivers[driverAhead.Name].TotalTime += 2;

                sb.AppendLine($"{driverBehind.Name} has overtaken {driverAhead.Name} on lap {this.currentLap}.");
            }
        }
        return sb.ToString().Trim();
    }

    private void RemoveDisqualifiedDriversFromRace()
    {
        foreach (KeyValuePair<Driver, string> disqualifiedDriverReasonPair in this.DisqualifiedDrivers)
        {
            Driver currentDriver = disqualifiedDriverReasonPair.Key;
            this.Drivers.Remove(currentDriver.Name);
        }
    }

    private void DecreaseFuelAndDegradateTyreAndDisqualifyDrivers()
    {
        foreach (KeyValuePair<string, Driver> nameDriverPair in this.Drivers)
        {
            Driver currentDriver = nameDriverPair.Value;
            try
            {
                nameDriverPair.Value.ReduceFuel(this.TrackLength);
                nameDriverPair.Value.Car.Tyre.Degradate();
            }
            catch (Exception exception)
            {
                this.DisqualifiedDrivers[currentDriver] = exception.Message;
            }
        }
    }

    private void IncreaseDriversTotalTime()
    {
        foreach (KeyValuePair<string, Driver> nameDriverPair in this.Drivers)
        {
            nameDriverPair.Value.TotalTime +=
                60 / (this.TrackLength / nameDriverPair.Value.Speed);

        }
    }

    public string GetLeaderboard()
    {
        StringBuilder sb = new StringBuilder();
        sb.AppendLine($"Lap {this.currentLap}/{this.TotalLaps}");

        int position = 1;

        foreach (var nameDriverPair in this.Drivers.OrderBy(t => t.Value.TotalTime))
        {
            sb.AppendLine($"{position} {nameDriverPair.Key} {nameDriverPair.Value.TotalTime:f3}");
            position++;
        }

        var disqualifiedDrivers = this.DisqualifiedDrivers.Reverse().ToList();

        foreach (var dsqDriverFailReasonPair in disqualifiedDrivers)
        {
            sb.AppendLine($"{position} {dsqDriverFailReasonPair.Key.Name} {dsqDriverFailReasonPair.Value}");
            position++;
        }

        return sb.ToString().Trim();
    }

    public void ChangeWeather(List<string> arguments)
    {
        string newWeather = arguments[0];
        if (newWeather == "Sunny" || newWeather == "Rainy" || newWeather == "Foggy")
        {
            this.Weather = newWeather;
        }
    }

    private string GetWinner()
    {
        Driver winner = Drivers.OrderBy(d => d.Value.TotalTime).First().Value;

        return $"{winner.Name} wins the race for {winner.TotalTime:f3} seconds.";
    }
}