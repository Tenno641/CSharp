using QuoteFinder.Models;

namespace QuoteFinder.Deserializers;

public interface IDatumSerializer
{
    IEnumerable<Datum> DatumDeserializer(string content);
}
