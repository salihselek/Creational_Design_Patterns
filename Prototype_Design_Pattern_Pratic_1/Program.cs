Person person1 = new("Salih", "SELEK", Department.A, 1000, 50);
//Person person2 = new("Saliha", "SELEK", Department.A, 1000, 50);
Person person2 = person1.Clone();
person2.Name = "Furkan";

Console.WriteLine();

//Abstract Prototype
interface IPersonClonable
{
    Person Clone();
}

//Concrete Prototype
class Person : IPersonClonable
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

    public Person Clone()
    {
        return (Person)base.MemberwiseClone();
    }
}

enum Department
{
    A, B, C
}