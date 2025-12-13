using QuoteFinder.Models;
using System.Text.Json;

namespace QuoteFinder.Deserializers
{
    public class DatumSerializer : IDatumSerializer
    {
        public IEnumerable<Datum> DatumDeserializer(string content)
        {
            Root root = JsonSerializer.Deserialize<Root>(content)!;
            IEnumerable<Datum> datums = root.data;
            return datums;
        }
    }
}
