using System;
using System.Text;

public class Human
{
    private string firstName;
    private string lastName;

    public string FirstName
    {
        get { return this.firstName; }
        set
        {
            if (!IsFirstLeterCapital(value))
            {
                throw new ArgumentException($"Expected upper case letter! Argument: {nameof(this.firstName)}");
            }

            if (value.Length < 4)
            {
                throw new ArgumentException($"Expected length at least 4 symbols! Argument: {nameof(this.firstName)}");
            }
            this.firstName = value;
        }
    }

    public string LastName
    {
        get { return this.lastName; }
        set
        {
            if (!IsFirstLeterCapital(value))
            {
                throw new ArgumentException($"Expected upper case letter! Argument: {nameof(this.lastName)}");
            }

            if (value.Length < 3)
            {
                throw new ArgumentException($"Expected length at least 3 symbols! Argument: {nameof(this.lastName)}");
            }
            this.lastName = value;
        }
    }

    public Human()
    {
    }

    public Human(string firstName, string lastName)
    {
        this.FirstName = firstName;
        this.LastName = lastName;
    }

    private bool IsFirstLeterCapital(string nameInput)
    {
        return char.IsUpper(nameInput[0]);
    }

    public override string ToString()
    {
        StringBuilder sb = new StringBuilder();
        string result = sb
            .AppendLine($"First Name: {this.FirstName}")
            .AppendLine($"Last Name: {this.LastName}")
            .ToString();
        return result;
    }
}