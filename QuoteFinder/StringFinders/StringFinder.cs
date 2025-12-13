using QuoteFinder.Models;

namespace QuoteFinder.StringFinders;

public class StringFinder : IStringFinder
{

    public bool Find(string text, string word)
    {
        if (string.IsNullOrEmpty(text)) return false;
        if (string.IsNullOrEmpty(word)) return false;

        int wordLength = word.Length;
        int index = 0;

        while ((index = text.IndexOf(word, index, StringComparison.InvariantCultureIgnoreCase)) != -1)
        {
            bool isPreWordOk = index == 0 || !char.IsLetterOrDigit(text[index - 1]);

            bool isPostWordOk = index + wordLength == text.Length || !char.IsLetterOrDigit(text[index + wordLength]);

            if (isPreWordOk && isPostWordOk) return true;
            index += 1;
        }
        
        return false;
    }

    public Datum? ContainsWord(string searchedWord, IEnumerable<Datum> datums)
    {
        return datums.Where(datum => Find(datum.quoteText, searchedWord))
                    .MinBy(datum => datum.quoteText.Length);
    }
}   
