namespace Lab3CSharp
{
    using System;
using System.Linq;

// Перша частина завдання: клас Triangle
class Triangle
{
    protected int a, b, c; // сторони трикутника
    private int color; // колір трикутника

    // Конструктор
    public Triangle(int sideA, int sideB, int sideC, int triangleColor)
    {
        a = sideA;
        b = sideB;
        c = sideC;
        color = triangleColor;
    }

    // Методи
    public void PrintSides()
    {
        Console.WriteLine($"Сторони трикутника: {a}, {b}, {c}");
    }

    public int CalculatePerimeter()
    {
        return a + b + c;
    }

    // Властивості
    public double Area
    {
        get
        {
            double s = (a + b + c) / 2.0;
            return Math.Sqrt(s * (s - a) * (s - b) * (s - c));
        }
    }

    public int Color => color; // тільки для читання
}

// Друга частина завдання: ієрархія класів
class Employee
{
    public string Name { get; set; }
    public int Age { get; set; }

    public virtual void Show()
    {
        Console.WriteLine($"Ім'я: {Name}, Вік: {Age}");
    }
}

class Clerk : Employee
{
    public int OfficeNumber { get; set; }

    public override void Show()
    {
        base.Show();
        Console.WriteLine($"Номер офісу: {OfficeNumber}");
    }
}

class Manager : Clerk
{
    public int TeamSize { get; set; }

    public override void Show()
    {
        base.Show();
        Console.WriteLine($"Розмір команди: {TeamSize}");
    }
}

class Engineer : Manager
{
    public string Specialization { get; set; }

    public override void Show()
    {
        base.Show();
        Console.WriteLine($"Спеціалізація: {Specialization}");
    }
}

class Program
{
    static void Main(string[] args)
    {
        // Перша частина завдання
        Triangle[] triangles = {
            new Triangle(3, 4, 5, 1),
            new Triangle(5, 12, 13, 2),
            new Triangle(8, 15, 17, 3)
        };

        foreach (var triangle in triangles)
        {
            triangle.PrintSides();
            Console.WriteLine($"Периметр: {triangle.CalculatePerimeter()}");
            Console.WriteLine($"Площа: {triangle.Area}");
            Console.WriteLine($"Колір: {triangle.Color}");
            Console.WriteLine();
        }

        // Друга частина завдання
        Employee[] employees = new Employee[4];
        employees[0] = new Employee { Name = "Іван", Age = 30 };
        employees[1] = new Clerk { Name = "Петро", Age = 25, OfficeNumber = 101 };
        employees[2] = new Manager { Name = "Марія", Age = 35, OfficeNumber = 202, TeamSize = 5 };
        employees[3] = new Engineer { Name = "Олег", Age = 40, OfficeNumber = 303, TeamSize = 3, Specialization = "Software" };

        Console.WriteLine("Дані про співробітників:");
        foreach (var employee in employees.OrderBy(e => e.Age))
        {
            employee.Show();
            Console.WriteLine();
        }
    }
}
}
