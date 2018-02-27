using System.Text;

public class Tesla : ICar, IElectricCar
{
    public string Model { get; set; }
    public string Color { get; set; }
    public string Start()
    {
        return "Engine start";
    }

    public string Stop()
    {
        return "Breaaak!";
    }

    public int Battery { get; set; }

    public Tesla(string model, string color, int battery)
    {
        this.Model = model;
        this.Color = color;
        this.Battery = battery;
    }

    public override string ToString()
    {
        StringBuilder sb = new StringBuilder();
        sb
            .AppendLine($"{this.Color} {this.Model} with {this.Battery} batteries")
            .AppendLine(this.Start())
            .AppendLine(this.Stop());
        return sb.ToString().Trim();
    }
}