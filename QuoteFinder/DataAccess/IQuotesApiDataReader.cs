namespace QuoteFinder.DataAccess;
public interface IQuotesApiDataReader : IDisposable
{
    Task<string> ReadAsync(int quotesPerPage);
}
