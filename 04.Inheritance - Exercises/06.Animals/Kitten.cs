using System;

public class Kitten : Cat
{
    public override string Gender
    {
        get { return "Female"; }
    }
    public Kitten(string name, int age) : base(name, age)
    {
    }

    public override void ProduceSound()
    {
        Console.WriteLine("Meow");
    }
}