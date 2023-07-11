using Aspose.Pdf;
using Aspose.Pdf.Text;
using MultiDictionary.Stats;
using Document = Aspose.Pdf.Document;

namespace MultiDictionary.IO
{
    public static class PDF
    {
        private const string statisticsDirectory = "Statistics";
        
        public static void CreateStatsFile()
        {
            if (!Directory.Exists(statisticsDirectory)) Directory.CreateDirectory(statisticsDirectory);
            DateTime currentDate = DateTime.Now;
            string fullPath = Path.Combine(statisticsDirectory, $"{statisticsDirectory}_{currentDate:dd-MM-yyyy_HH-mm-ss}.pdf");
            var document = new Document();
            Page page = document.Pages.Add();
            CreatePdfTemplate(currentDate, page);
            WriteLanguageStats(page);
            WriteTotalReferences(page);
            document.Save(fullPath);
        }

        private static void CreatePdfTemplate(DateTime currentDate, Page page)
        {
            var textStampHeader = new TextStamp("Statistics - " + currentDate.ToString("G"))
            {
                TopMargin = 40,
                HorizontalAlignment = HorizontalAlignment.Center,
                VerticalAlignment = VerticalAlignment.Top,
                TextState = { FontSize = 20, Font = FontRepository.FindFont("Times New Roman"), FontStyle = FontStyles.Bold }
            };
            page.AddStamp(textStampHeader);
            page.Paragraphs.Add(new TextFragment
            {
                Text = "Occurrence of words in Multi Dictionary:",
                Margin = new MarginInfo(0, 15, 0, 15),
                TextState = { FontSize = 13, Font = FontRepository.FindFont("Times New Roman") }
            });
        }

        private static void WriteLanguageStats(Page page)
        {
            foreach ((string word, SortedSet<string> language) in Statistics.WordReferences)
            {
                page.Paragraphs.Add(new TextFragment
                {
                    Text = $"- {word}: {string.Join(", " , language)}",
                    Margin = new MarginInfo(0, 5, 0, 5),
                    TextState = { FontSize = 12, Font = FontRepository.FindFont("Times New Roman") }
                });
            }
        }

        private static void WriteTotalReferences(Page page)
        {
            page.Paragraphs.Add(new TextFragment
            {
                Text = $"Total number of word search attempts: {Statistics.TotalReferences}",
                Margin = new MarginInfo(0, 15, 0, 15),
                TextState = { FontSize = 13, Font = FontRepository.FindFont("Times New Roman") }
            });
        }
    }
}