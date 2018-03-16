using System.Text;

public class ShowCar : Car
{
    private int stars;

    public ShowCar(string brand, string model, int yearOfProduction, int horsePower, int acceleration, int suspension, int durability) : base(brand, model, yearOfProduction, horsePower, acceleration, suspension, durability)
    {
        this.Stars = 0;
    }

    public int Stars
    {
        get => this.stars;
        set => this.stars = value;
    }

    public void InreaseStart(int tuneIndex)
    {
        this.Stars += tuneIndex;
    }

    public override string ToString()
    {
        StringBuilder sb = new StringBuilder();

        sb
            .AppendLine(base.ToString())
            .AppendLine($"{this.Stars} *");

        return sb.ToString().Trim();
    }
}