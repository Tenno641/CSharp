using QuoteFinder.DataAccess;
using QuoteFinder.Deserializers;
using QuoteFinder.Models;
using QuoteFinder.StringFinders;
using QuoteFinder.UserInteractions;

namespace QuoteFinder.App;

public class QuoteFinderApp
{
    private readonly IStringFinder _stringFinder;
    private readonly IUserInteraction _userInteraction;
    private readonly IQuotesApiDataReader _quotesApiDataReader;
    private readonly IDatumSerializer _datumSerializer;
    public QuoteFinderApp(IStringFinder stringFinder,
        IUserInteraction userInteraction,
        IQuotesApiDataReader quotesApiDataReader,
        IDatumSerializer datumSerializer)
    {
        _stringFinder = stringFinder;
        _userInteraction = userInteraction;
        _quotesApiDataReader = quotesApiDataReader;
        _datumSerializer = datumSerializer;
    }

    public async Task RunAsync()
    {
        string? searchedWord = _userInteraction.InputString("Which word you're looking for");

        if (searchedWord is null) return;

        int pagesNumber = _userInteraction.InputInteger("How many pages you want to search");

        int quotesNumber = _userInteraction.InputInteger("How many quotes per page you want");

        bool shallProcessInParallel = _userInteraction.ReadBool("Do you want process in parallel");

        IEnumerable<string> content = await FetchData(pagesNumber, quotesNumber);

        await ProcessAsync(content, searchedWord, shallProcessInParallel);
    }

    private async Task<IEnumerable<string>> FetchData(int pagesNumber, int quotesNumber)
    {
        List<Task<string>> tasks = [];
        for (int i = 0; i < pagesNumber; i++)
        {
            Task<string> fetchDataTask = _quotesApiDataReader.ReadAsync(quotesNumber);
            tasks.Add(fetchDataTask);
        }
        return await Task.WhenAll(tasks);
    }

    private async Task ProcessAsync(IEnumerable<string> pages, string searchedWord, bool shallProcessInParallel)
    {
        if (shallProcessInParallel)
        {
            var tasks = pages.Select(page => Task.Run(() => ProcessPage(page, searchedWord)));
            await Task.WhenAll(tasks);
        }
        else
        {
            foreach(string page in pages)
            {
                ProcessPage(page, searchedWord);
            }
        }
    }

    private void ProcessPage(string content, string searchedWord)
    {
        IEnumerable<Datum> datums = _datumSerializer.DatumDeserializer(content);
        Datum? foundDatum = _stringFinder.ContainsWord(searchedWord, datums);
        _userInteraction.PrintQuote(foundDatum);
    }

}
