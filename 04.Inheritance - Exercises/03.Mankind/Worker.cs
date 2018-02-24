using System;
using System.Text;

public class Worker : Human
{
    private const int MIN_WORKING_HOURS = 1;
    private const int MAX_WORKING_HOURS = 12;
    private const decimal MIN_WEEK_SALARY = 10m;
    private decimal weekSalary;
    private decimal workHoursPerDay;

    public decimal WeekSalary
    {
        get { return this.weekSalary; }
        set
        {
            if (value <= MIN_WEEK_SALARY)
            {
                throw new ArgumentException($"Expected value mismatch! Argument: {nameof(this.weekSalary)}");
            }
            this.weekSalary = value;
        }
    }

    public decimal WorkHoursPerDay
    {
        get { return this.workHoursPerDay; }
        set
        {
            if (value < MIN_WORKING_HOURS || value > MAX_WORKING_HOURS)
            {
                throw new ArgumentException($"Expected value mismatch! Argument: {nameof(this.workHoursPerDay)}");
            }
            this.workHoursPerDay = value;
        }
    }

    public Worker() : base()
    {
    }

    public Worker(string firstName, string lastName, decimal weekSalary, decimal workHoursPerDay) : base(firstName, lastName)
    {
        this.WeekSalary = weekSalary;
        this.WorkHoursPerDay = workHoursPerDay;
    }

    private decimal GetSalaryPerHour()
    {
        return this.WeekSalary / (this.WorkHoursPerDay * 5.0m);
    }

    public override string ToString()
    {
        StringBuilder sb = new StringBuilder();
        string result = sb
            .Append(base.ToString())
            .AppendLine($"Week Salary: {this.WeekSalary:f2}")
            .AppendLine($"Hours per day: {this.WorkHoursPerDay:f2}")
            .AppendLine($"Salary per hour: {GetSalaryPerHour():f2}")
            .ToString();
        return result;
    }
}