
using System;
using System.Collections.Generic;

public class StudentSystem
{
    private Dictionary<string, Student> repo;

    public StudentSystem()
    {
        this.repo = new Dictionary<string, Student>();
    }

    public void ParseCommand(string input, Action<string> printStudent)
    {
        string[] args = input.Split();
        string command = args[0];

        if (command == "Create")
        {
            string name = args[1];
            string ageAsStr = args[2];
            string gradeAsStr = args[3];

            CreateStudent(name, ageAsStr, gradeAsStr);
        }
        else if (command == "Show")
        {
            string studentName = args[1];
            if (repo.ContainsKey(studentName))
            {
                printStudent(repo[studentName].ToString());
            }
        }
    }

    private void CreateStudent(string studentName, string ageAsString, string gradeAsString)
    {
        string name = studentName;
        int age = int.Parse(ageAsString);
        double grade = double.Parse(gradeAsString);

        if (!repo.ContainsKey(name))
        {
            Student student = new Student(name, age, grade);
            repo[name] = student;
        }
    }


}