using System;

Person person1 = new("Salih", "SELEK", Department.A, 1000, 50);
//Person person2 = new("Saliha", "SELEK", Department.A, 1000, 50);
Person person2 = (Person)person1.Clone();
person2.Name = "Furkan";
person2.Salary = 2000;
Console.WriteLine();


//Concrete Prototype
class Person : ICloneable
{
    public Person(string name, string surname, Department department, int salary, int premium)
    {
        Name = name;
        Surname = surname;
        Department = department;
        Salary = salary;
        Premium = premium;
        Console.WriteLine("Person nesnesi oluşturuldu.");
    }

    public string Name { get; set; }
    public string Surname { get; set; }
    public Department Department { get; set; }
    public int Salary { get; set; }
    public int Premium { get; set; }

    public object Clone()
    {
        return base.MemberwiseClone();
    }
}

enum Department
{
    A, B, C
}