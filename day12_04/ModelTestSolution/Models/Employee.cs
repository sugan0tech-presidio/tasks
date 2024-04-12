﻿namespace ModelTest.Models;

public class Employee
{
    public int Id { get; set; }
    public string Name { get; set; }

    private double _salary;

    public double Salary
    {
        get => _salary - _salary * 10 / 100;
        set => _salary = value;
    }

    public void Work()
    {
        Console.WriteLine("Working...");
    }
}