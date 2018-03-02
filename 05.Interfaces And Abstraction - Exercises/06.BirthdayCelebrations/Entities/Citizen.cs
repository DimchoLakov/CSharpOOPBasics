﻿using System;

public class Citizen : IIdentifyable, IBirthable
{
    public string Name { get; private set; }

    public int Age { get; private set; }

    public string Id { get; private set; }

    public DateTime Birthday { get; private set; }

    public Citizen()
    {
    }

    public Citizen(string name, int age, string id, DateTime birthday) : this()
    {
        this.Name = name;
        this.Age = age;
        this.Id = id;
        this.Birthday = birthday;
    }
}