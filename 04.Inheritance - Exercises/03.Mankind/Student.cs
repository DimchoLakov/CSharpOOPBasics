using System;
using System.Text;

public class Student : Human
{
    private const int MIN_LENGTH_FACULTY_NUMBER = 5;
    private const int MAX_LENGTH_FACULTY_NUMBER = 10;
    private string facultyNumber;

    public string FacultyNumber
    {
        get { return this.facultyNumber; }
        set
        {
            if (value.Length < MIN_LENGTH_FACULTY_NUMBER
                ||
                value.Length > MAX_LENGTH_FACULTY_NUMBER 
                ||
                !IsFacultyNumberValid(value))
            {
                throw new ArgumentException("Invalid faculty number!");
            }
            this.facultyNumber = value;
        }
    }

    public Student() : base()
    {
    }

    public Student(string firstName, string lastName, string facultyNumber) : base(firstName, lastName)
    {
        this.FacultyNumber = facultyNumber;
    }

    private bool IsFacultyNumberValid(string facultyNum)
    {
        for (int i = 0; i < facultyNum.Length; i++)
        {
            if (!char.IsLetterOrDigit(facultyNum[i]))
            {
                return false;
            }
        }

        return true;
    }

    public override string ToString()
    {
        StringBuilder sb = new StringBuilder();
        string result = sb
                .Append(base.ToString())
                .AppendLine($"Faculty number: {this.FacultyNumber}")
                .ToString();
        return result;
    }
}