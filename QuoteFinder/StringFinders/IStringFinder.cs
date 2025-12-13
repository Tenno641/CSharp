using QuoteFinder.Models;

namespace QuoteFinder.StringFinders;

public interface IStringFinder
{
    bool Find(string text, string word);
    Datum? ContainsWord(string searchedWord, IEnumerable<Datum> datums);
}
