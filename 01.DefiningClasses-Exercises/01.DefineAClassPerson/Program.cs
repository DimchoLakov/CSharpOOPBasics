using System;
using System.Reflection;

class Program
{
    static void Main()
    {
        Type personType = typeof(Person);
        FieldInfo[] fields = personType.GetFields(BindingFlags.Public | BindingFlags.Instance);
        int fieldCount = fields.Length;
        Console.WriteLine(fields.Length);

        Person firstPerson = new Person
        {
            Name = "Pesho",
            Age = 20
        };

        Person secondPerson = new Person
        {
            Name = "Gosho",
            Age = 18
        };

        Person thirdPerson = new Person();
        thirdPerson.Name = "Stamat";
        thirdPerson.Age = 43;
    }
}
