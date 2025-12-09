using System.Globalization;

namespace CinemaTicketsAggregator.Cultures;

internal interface ICultureProvider
{
    CultureInfo GetCulture(string input);
}
