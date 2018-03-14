using System;

public abstract class Tyre
{
    protected Tyre(double hardness)
    {
        this.Degradation = 100;
        this.Hardness = hardness;
    }

    private string name;

    public virtual string Name
    {
        get { return this.name; }
        protected set { this.name = value; }
    }

    private double hardness;

    public double Hardness
    {
        get { return this.hardness; }
        protected set { this.hardness = value; }
    }

    private double degradation;

    public virtual double Degradation
    {
        get { return this.degradation; }
        protected set
        {
            if (value < 0)
            {
                throw new ArgumentException("Blown Tyre");
            }
            this.degradation = value;
        }
    }

    public virtual void Degradate()
    {
        this.Degradation -= this.Hardness;
    }
}
