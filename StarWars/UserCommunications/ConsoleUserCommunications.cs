using System.Reflection;
using System.Text;

namespace StarWars.UserCommunications;

public class ConsoleUserCommunications : IUserCommunications
{
    private const int CellLength = -20;
    public void PrintMessage(string message)
    {
        Console.WriteLine(message);
    }
    public void PrintAsTable<T>(IEnumerable<T> data) where T: class
    {
        Type type = typeof(T);
        PropertyInfo[] properties = type.GetProperties();
        PrintSeparated(properties, property => $" {property.Name, CellLength}|");
        PrintSeparator(properties.Length, CellLength);
        foreach(T item in data)
        {
            PrintSeparated(properties, property => $" {property.GetValue(item),CellLength}|");
        }
    }
    
    private void PrintSeparated(PropertyInfo[] data, Func<PropertyInfo, string> handler)
    {
        StringBuilder result = new StringBuilder();
        foreach(PropertyInfo propertyInfo in data)
        {
            result.Append(handler(propertyInfo));
        }
        Console.WriteLine(result);
    }
    
    private void PrintSeparator(int cells, int length)
    {
        StringBuilder separator = new StringBuilder();
        for (int i = 0; i < cells; i++)
        {
            for (int j = 0; j < Math.Abs(length) + 1; j++)
            {
                separator.Append('-');
            }
            separator.Append('|');
        }
        Console.WriteLine(separator);
    }

    public void PrintStatisticsOptions()
    {
        PrintMessage(@"The statistics of which property would you like to see?
population
diameter
surface-water
");
    }
}
