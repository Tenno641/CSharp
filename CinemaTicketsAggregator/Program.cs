using CinemaTicketsAggregator.App;
using CinemaTicketsAggregator.Cultures;
using CinemaTicketsAggregator.Pdfs;
using CinemaTicketsAggregator.Tickets;

ICultureProvider cultureProvider = new CultureProvider();
ITicketsProvider ticketsProvider = new TicketsProvider(cultureProvider);
IPdfProvider pdfProvider = new PdfProvider();
new TicketsAggregatorApp(ticketsProvider, pdfProvider).Run();
