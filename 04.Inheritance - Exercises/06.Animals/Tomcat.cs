using System;

public class Tomcat : Cat
{
    public override string Gender
    {
        get { return "Male"; }
    }

    public Tomcat(string name, int age) : base(name, age)
    {
    }

    public override void ProduceSound()
    {
        Console.WriteLine("MEOW");
    }
}