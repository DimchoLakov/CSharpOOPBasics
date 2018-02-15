using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main()
    {
        List<Employee> employees = new List<Employee>();

        int n = int.Parse(Console.ReadLine());

        for (int i = 0; i < n; i++)
        {
            string[] tokens = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            string name = tokens[0];
            decimal salary = decimal.Parse(tokens[1]);
            string position = tokens[2];
            string department = tokens[3];

            Employee employee = new Employee{Name = name, Salary = salary, Position = position, Department = department};

            if (tokens.Length > 4)
            {
                if (tokens[4].Contains("@"))
                {
                    employee.Email = tokens[4];
                }
                else
                {
                    employee.Age = int.Parse(tokens[4]);
                }
            }

            if (tokens.Length > 5)
            {
                employee.Age = int.Parse(tokens[5]);
            }
            employees.Add(employee);
        }

        var sortedEmployees = employees
            .GroupBy(d => d.Department)
            .Select(e => new
            {
                Department = e.Key,
                AverageSalary = e.Average(ems => ems.Salary),
                Employees = e.OrderByDescending(ems => ems.Salary)
            }).OrderByDescending(s => s.AverageSalary)
            .FirstOrDefault();

        Console.WriteLine($"Highest Average Salary: {sortedEmployees.Department}");

        foreach (Employee employee in sortedEmployees.Employees)
        {
            Console.WriteLine($"{employee.Name} {employee.Salary:f2} {employee.Email} {employee.Age}");
        }
    }
}
