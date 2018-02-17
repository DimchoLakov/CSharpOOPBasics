public class Company
{
    private string name;

    public string Name
    {
        get { return this.name; }
        set { this.name = value; }
    }

    private string department;

    public string Department
    {
        get { return this.department; }
        set { this.department = value; }
    }

    private decimal salary;

    public decimal Salary
    {
        get { return this.salary; }
        set { this.salary = value; }
    }

    public Company()
    {
    }

    public Company(string name, string department, decimal salary)
    {
        this.name = name;
        this.department = department;
        this.salary = salary;
    }

    public override string ToString()
    {
        if (this.salary == 0m)
        {
            return string.Empty;
        }
        return $"{this.name} {this.department} {this.Salary:f2}";
    }
}