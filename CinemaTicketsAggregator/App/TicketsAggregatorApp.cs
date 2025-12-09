using CinemaTicketsAggregator.Pdfs;
using CinemaTicketsAggregator.Tickets;

namespace CinemaTicketsAggregator.App;

internal class TicketsAggregatorApp
{
    private readonly ITicketsProvider _ticketsProvider;
    private readonly IPdfProvider _pdfProvider;
    public TicketsAggregatorApp(ITicketsProvider ticketsProvider, IPdfProvider pdfProvider)
    {
        _ticketsProvider = ticketsProvider;
        _pdfProvider = pdfProvider;
    }

    public void Run()
    {
        IEnumerable<string> pdfFiles = _pdfProvider.GetPdfFiles(Environment.CurrentDirectory);

        List<Ticket> tickets = new();
        foreach (string file in pdfFiles)
        {
            string content = _pdfProvider.GetContent(file);
            tickets.AddRange(_ticketsProvider.CreateTickets(content));
        }
        File.WriteAllText("tickets.txt", string.Join(Environment.NewLine, tickets));
    }
}
