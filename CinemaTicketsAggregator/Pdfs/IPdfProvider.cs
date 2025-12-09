namespace CinemaTicketsAggregator.Pdfs;

internal interface IPdfProvider
{
    IEnumerable<string> GetPdfFiles(string path);
    string GetContent(string filePath);
}
