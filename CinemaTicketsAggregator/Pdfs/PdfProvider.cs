using UglyToad.PdfPig;
using UglyToad.PdfPig.Content;
using UglyToad.PdfPig.DocumentLayoutAnalysis.TextExtractor;

namespace CinemaTicketsAggregator.Pdfs;

internal  class PdfProvider : IPdfProvider
{
    public IEnumerable<string> GetPdfFiles(string path)
    {
        return Directory.GetFiles(Environment.CurrentDirectory, "*.pdf");
    }
    public string GetContent(string filePath)
    {
        using PdfDocument pdfDocument = PdfDocument.Open(filePath);
        Page page = pdfDocument.GetPage(1);
        return ContentOrderTextExtractor.GetText(page);
    }
    
}