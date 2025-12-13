using QuoteFinder.Models;

namespace QuoteFinder.UserInteractions;

public class ConsoleUserInteraction : IUserInteraction
{
    public void ShowMessage(string message)
    {
        Console.WriteLine(message);
    }

    public string? InputString(string message = "")
    {
        Console.WriteLine(message);
        return Console.ReadLine();
    }

    public int InputInteger(string message = "")
    {
        Console.WriteLine(message);
        int.TryParse(Console.ReadLine(), out int quotesNumber);
        return quotesNumber;
    }

    public void PrintQuote(Datum? shortestFilteredDatum)
    {
        if (shortestFilteredDatum is null)
        {
            Console.WriteLine("Sorry, can't find quotes based on your criteria.");
        }
        else
        {
            Console.WriteLine("Founded quotes:");
            Console.WriteLine(shortestFilteredDatum.quoteText);
        }
    }

    public bool ReadBool(string message)
    {
        Console.WriteLine($"{message} ('y' for 'yes', anything else for 'no')");
        string input = Console.ReadLine();
        return input.Equals("y", StringComparison.OrdinalIgnoreCase);
    }

}
