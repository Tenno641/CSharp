namespace CinemaTicketsAggregator.Tickets;

internal class Ticket
{
    public required string Title { get; set; }
    public required DateOnly Date { get; set; }
    public required TimeOnly Time { get; set; }
    public override string ToString()
    {
        return $"{Title,-20}| {Time}.{Date}";
    }
}
