using System;

public class Circle : Shape
{
    public double Radius { get; private set; }

    public Circle(double radius)
    {
        this.Radius = radius;
    }

    public override double CalculatePerimeter()
    {
        return 2 * Math.PI * this.Radius;
    }

    public override double CalculateArea()
    {
        return Math.Pow(this.Radius, 2) * Math.PI;
    }

    public override string Draw()
    {
        return base.Draw() + "Circle";
    }
}