using System;

public class Dog : Animal
{
    public Dog(string name, int age, string gender) : base(name, age, gender)
    {
    }

    public new void ProduceSound()
    {
        Console.WriteLine("Woof!");
    }
}