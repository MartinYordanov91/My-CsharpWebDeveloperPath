namespace FilterByAge;
using System;
using System.Runtime.ConstrainedExecution;

internal class FilterByAge
{
    private static void Main()
    {
        List<Person> persons = new List<Person>();
        int countOfPersons = int.Parse(Console.ReadLine());

        for (int i = 0; i < countOfPersons; i++)
        {
            string[] curentPerson = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries);
            Person person = new(curentPerson[0], int.Parse(curentPerson[1]));
            persons.Add(person);
        }
        string ageDirection = Console.ReadLine();
        int age = int.Parse(Console.ReadLine());

        Func<Person, bool> filter = p => true;
        if (ageDirection == "older")
        {
            filter = p => p.Age >= age;
        }
        else if (ageDirection == "younger")
        {
            filter = p => p.Age < age;
        }
        else { filter = p => true; }

        List<Person> filteredPersons = persons.Where(filter).ToList();

        string printFrame = Console.ReadLine();
        Func<Person, string> frameFilter = person => $"{person.Name} - {person.Age}";
        if (printFrame == "name age")
        {
            frameFilter = person => $"{person.Name} - {person.Age}"; // Noah - 31
        }
        else if (printFrame == "name")
        {
            frameFilter = person => $"{person.Name}"; // Noah 
        }
        else if (printFrame == "age")
        {
            frameFilter = person => $"{person.Age}";
        }

        List<string> personAsString = filteredPersons.Select(frameFilter).ToList();
        foreach (var person in personAsString)
        {
            Console.WriteLine(person);
        }
    }

}

public class Person
{
    public Person(string name, int age)
    {
        Name = name;
        Age = age;
    }

    public string Name { get; set; }

    public int Age { get; set; }
}