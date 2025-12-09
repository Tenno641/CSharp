namespace CinemaTicketsAggregator.Tickets;

internal interface ITicketsProvider
{
    IEnumerable<Ticket> CreateTickets(string content);
}
