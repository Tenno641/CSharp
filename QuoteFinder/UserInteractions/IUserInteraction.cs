using QuoteFinder.Models;

namespace QuoteFinder.UserInteractions;

public interface IUserInteraction
{
    void ShowMessage(string message);
    string? InputString(string message);
    int InputInteger(string message);
    void PrintQuote(Datum? shortestFilteredDatum);
    bool ReadBool(string message);
}
