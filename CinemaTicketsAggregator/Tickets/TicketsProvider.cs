using CinemaTicketsAggregator.Cultures;
using System.Globalization;

namespace CinemaTicketsAggregator.Tickets;

internal class TicketsProvider : ITicketsProvider
{
    private readonly ICultureProvider _cultureProvider;

    public TicketsProvider(ICultureProvider cultureProvider)
    {
        _cultureProvider = cultureProvider;
    }

    public IEnumerable<Ticket> CreateTickets(string content)
    {
        string[] split = content.Split(["Title:", "Date:", "Time:", "Visit us:"], StringSplitOptions.TrimEntries);

        CultureInfo culture = _cultureProvider.GetCulture(split[split.Length - 1]);

        for (int i = 1; i < split.Length - 3; i += 3)
        {
            Ticket ticket = new()
            {
                Title = split[i],
                Date = DateOnly.Parse(split[i + 1], culture),
                Time = TimeOnly.Parse(split[i + 2], culture)
            };
            yield return ticket;
        }
    }
}
