using System;
using System.Text;

public class Animal : ISoundProducable
{
    private string name;
    private int age;
    private string gender;

    public string Name
    {
        get { return this.name; }
        set
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException("Invalid input!");
            }
            this.name = value;
        }
    }

    public int Age
    {
        get { return this.age; }
        set
        {
            if (value < 0)
            {
                throw new ArgumentException("Invalid input!");
            }
            this.age = value;
        }
    }

    public virtual string Gender
    {
        get { return this.gender; }
        set
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException("Invalid input!");
            }
            this.gender = value;
        }
    }

    public Animal()
    {
    }
    public Animal(string name, int age)
    {
        this.Name = name;
        this.Age = age;
    }

    public Animal(string name, int age, string gender)
    {
        this.Name = name;
        this.Age = age;
        this.Gender = gender;
    }

    public void ProduceSound()
    {
    }

    public override string ToString()
    {
        StringBuilder sb = new StringBuilder();
        string result = sb
            .AppendLine($"{this.GetType().Name}")
            .AppendLine($"{this.Name} {this.Age} {this.Gender}")
            .ToString();
        return result.Trim();
    }
}