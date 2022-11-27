using System.Text.RegularExpressions;

namespace Task4;

public class Student
{
    public string? Name { get;}
    public string? Group { get;}
    public DateTime DateOfBirth { get;}

    public Student(string name, string group, DateTime dateOfBirth)
    {
        Name = name;
        Group = group;
        DateOfBirth = dateOfBirth;
    }
}