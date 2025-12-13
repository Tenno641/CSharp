using QuoteFinder.App;
using QuoteFinder.DataAccess;
using QuoteFinder.Deserializers;
using QuoteFinder.StringFinders;
using QuoteFinder.UserInteractions;

IUserInteraction userInteraction = new ConsoleUserInteraction();
IStringFinder stringFiner = new StringFinder();
IQuotesApiDataReader quotesApiDataReader = new MockQuotesApiDataReader();
IDatumSerializer datumSerializer = new DatumSerializer();

QuoteFinderApp app = new QuoteFinderApp(stringFiner, userInteraction, quotesApiDataReader, datumSerializer);
await app.RunAsync();

