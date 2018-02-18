using System.Text;

public class Car
{
    private string model;
    private string weight;
    private string color;
    private Engine engine;

    public string Model
    {
        get { return this.model; }
        set { this.model = value; }
    }

    public string Weigh
    {
        get { return this.weight; }
        set { this.weight = value; }
    }

    public string Color
    {
        get { return this.color; }
        set { this.color = value; }
    }

    public Engine Engine
    {
        get { return this.engine; }
        set { this.engine = value; }
    }

    public Car()
    {
        this.weight = "n/a";
        this.color = "n/a";
    }

    public Car(string model, Engine engine) : this()
    {
        this.model = model;
        this.engine = engine;
    }


    public override string ToString()
    {
        StringBuilder sb = new StringBuilder();

        sb.AppendLine($"{this.model}:");
        sb.AppendLine($"{this.engine}");
        sb.AppendLine($"  Weight: {this.weight}");
        sb.Append($"  Color: {this.color}");
        return sb.ToString();
    }
}