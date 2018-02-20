public class Person
{
    private string firstName;
    private string lastName;
    private int age;
    private decimal salary;

    public string FirstName
    {
        get { return this.firstName; }
        private set { this.firstName = value; }
    }

    public string LastName
    {
        get { return this.lastName; }
        private set { this.lastName = value; }
    }

    public int Age
    {
        get { return this.age; }
        private set { this.age = value; }
    }

    public decimal Salary
    {
        get { return this.salary; }
        private set { this.salary = value; }
    }

    public Person(string firstName, string lastName, int age)
    {
        this.firstName = firstName;
        this.lastName = lastName;
        this.age = age;
    }

    public Person(string firstName, string lastName, int age, decimal salary) : this (firstName, lastName, age)
    {
        this.salary = salary;
    }

    public void IncreaseSalary(decimal percentage)
    {
        decimal bonus = this.salary * (percentage / (decimal)100m);

        if (this.Age > 30)
        {
            this.salary += bonus;
        }
        else
        {
            this.salary += bonus / 2;
        }
    }

    public override string ToString()
    {
        return $"{this.FirstName} {this.LastName} receives {this.Salary:F2} leva.";
    }
}