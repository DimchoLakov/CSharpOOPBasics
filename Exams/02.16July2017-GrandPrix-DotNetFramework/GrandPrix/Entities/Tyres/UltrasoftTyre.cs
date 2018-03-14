using System;

public class UltrasoftTyre : Tyre
{
    public UltrasoftTyre(double hardness, double grip) : base(hardness)
    {
        this.Grip = grip;
    }

    public override string Name => "Ultrasoft";

    private double grip;

    public double Grip
    {
        get { return this.grip; }
        private set { this.grip = value; }
    }

    private double degradation;

    public override double Degradation
    {
        get { return this.degradation; }
        protected set
        {
            if (value < 30)
            {
                throw new ArgumentException("Blown Tyre");
            }
            this.degradation = value;
        }
    }

    public override void Degradate()
    {
        this.Degradation -= this.Hardness + this.Grip;
    }
}