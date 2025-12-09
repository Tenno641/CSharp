using System.Globalization;

namespace CinemaTicketsAggregator.Cultures;

internal class CultureProvider : ICultureProvider
{
    private Dictionary<string, CultureInfo> _cultures = new()
    {
        [".com"] = new CultureInfo("en-US"),
        [".jp"] = new CultureInfo("ja-JP"),
        [".fr"] = new CultureInfo("fr-Fr")
    };
    public CultureInfo GetCulture(string input)
    {
        if (input.Contains(".com")) return _cultures[".com"];
        else if (input.Contains(".jp")) return _cultures[".jp"];
        else if (input.Contains(".fr")) return _cultures[".fr"];
        return CultureInfo.InvariantCulture;
    }
}
