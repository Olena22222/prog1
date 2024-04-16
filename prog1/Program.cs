using System;

public class MyAccessModifiers
{
    private int _birthYear;
    protected string _personalInfo;
    protected internal string _idNumber;
    protected internal static byte _averageMiddleAge = 50;

    public MyAccessModifiers(int birthYear, string idNumber, string personalInfo)
    {
        _birthYear = birthYear;
        _idNumber = idNumber;
        _personalInfo = personalInfo;
    }

    public int Age => DateTime.Now.Year - _birthYear;

    public string PersonalInfo => _personalInfo;

    protected internal string IdNumber => _idNumber;

    public byte AverageAge => _averageMiddleAge;

    public string Name { get; internal set; }

    public string Nickname { get; internal set; }

    protected internal virtual bool LivedHalfLife()
    {
        return Age >= _averageMiddleAge;
    }

    public static bool operator ==(MyAccessModifiers obj1, MyAccessModifiers obj2)
    {
        if (ReferenceEquals(obj1, obj2))
            return true;
        if (obj1 is null || obj2 is null)
            return false;

        bool nameEqual = obj1.Name == obj2.Name;
        bool ageEqual = obj1.Age == obj2.Age;
        bool personalInfoEqual = obj1.PersonalInfo == obj2.PersonalInfo;

        return nameEqual && ageEqual && personalInfoEqual;
    }

    public static bool operator !=(MyAccessModifiers obj1, MyAccessModifiers obj2)
    {
        return !(obj1 == obj2);
    }

    public override bool Equals(object obj)
    {
        if (obj == null || GetType() != obj.GetType())
            return false;

        MyAccessModifiers other = (MyAccessModifiers)obj;
        return Name == other.Name && Age == other.Age && PersonalInfo == other.PersonalInfo;
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(_birthYear, _personalInfo, _idNumber);
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine("Enter birth year:");
        int birthYear = int.Parse(Console.ReadLine());

        Console.WriteLine("Enter personal information:");
        string personalInfo = Console.ReadLine();

        MyAccessModifiers person1 = new MyAccessModifiers(birthYear, "", personalInfo);

        Console.WriteLine("Enter name:");
        person1.Name = Console.ReadLine();

        Console.WriteLine("Enter nickname:");
        person1.Nickname = Console.ReadLine();

        Console.WriteLine($"Name: {person1.Name}");
        Console.WriteLine($"Nickname: {person1.Nickname}");
        Console.WriteLine($"Age: {person1.Age}");
        Console.WriteLine($"Lived half life: {person1.LivedHalfLife()}");

        Console.WriteLine("\nSecond object:");

        Console.WriteLine("Enter birth year:");
        birthYear = int.Parse(Console.ReadLine());

        Console.WriteLine("Enter personal information:");
        personalInfo = Console.ReadLine();

        MyAccessModifiers person2 = new MyAccessModifiers(birthYear, "", personalInfo);

        Console.WriteLine("Enter name:");
        person2.Name = Console.ReadLine();

        Console.WriteLine("Enter nickname:");
        person2.Nickname = Console.ReadLine();

        Console.WriteLine($"Name: {person2.Name}");
        Console.WriteLine($"Nickname: {person2.Nickname}");
        Console.WriteLine($"Age: {person2.Age}");
        Console.WriteLine($"Lived half life: {person2.LivedHalfLife()}");

        // Equality checks
        bool ageEquality = person1.Age == person2.Age;
        bool nameEquality = person1.Name == person2.Name;
        bool personalInfoEquality = person1.PersonalInfo == person2.PersonalInfo;

        Console.WriteLine("\nEquality checks:");
        Console.WriteLine($"Age equality: {ageEquality}");
        Console.WriteLine($"Name equality: {nameEquality}");
        Console.WriteLine($"Personal information equality: {personalInfoEquality}");
        Console.WriteLine($"Overall equality: {(person1 == person2 ? "true" : "false")}");
    }
}
