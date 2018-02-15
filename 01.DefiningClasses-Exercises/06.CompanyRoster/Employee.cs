public class Employee
{
    private string name;

    public string Name
    {
        get { return this.name; }
        set { this.name = value; }
    }

    private decimal salary;

    public decimal Salary
    {
        get { return this.salary; }
        set { this.salary = value; }
    }

    private string position;

    public string Position
    {
        get { return this.position; }
        set { this.position = value; }
    }

    private string department;

    public string Department
    {
        get { return this.department; }
        set { this.department = value; }
    }

    private string email;

    public string Email
    {
        get { return this.email; }
        set { this.email = value; }
    }

    private int age;

    public int Age
    {
        get { return this.age; }
        set { this.age = value; }
    }

    public Employee()
    {
        this.email = "n/a";
        this.age = -1;
    }

    public Employee(string name, decimal salary, string position, string department) : this()
    {
        this.name = name;
        this.salary = salary;
        this.position = position;
        this.department = department;
    }

    public Employee(string name, decimal salary, string position, string department, string email) : this(name, salary, position, department)
    {
        this.email = email;
    }

    public Employee(string name, decimal salary, string position, string department, int age) : this(name, salary, position, department)
    {
        this.age = age;
    }

    public Employee(string name, decimal salary, string position, string department, string email, int age) : this(name, salary, position, department)
    {
        this.email = email;
        this.age = age;
    }
}
