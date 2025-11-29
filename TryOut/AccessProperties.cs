using System.Reflection;

namespace TryOut;

// PrintType(new Person() { Age = 33, Name = "Defined-Name", birthDate = new DateTime(200, 5, 21) });

internal class AccessProperties
{
    void PrintType(object obj)
    {
        Type type = obj.GetType();
        PropertyInfo[] propertyInfos = type.GetProperties(); // returns array of property info
        IEnumerable<string> results = propertyInfos.Where(property => !property.Name.Contains("Equality"))
            .Select(property => $"{property.Name}: {property.GetValue(obj)}");
        foreach (string value in results)
        {
            Console.WriteLine(value);
        }
    }
}

public class Person
{
    public int Age { get; set; }
    public string Name { get; set; }
    public DateTime birthDate { get; set; }
}
