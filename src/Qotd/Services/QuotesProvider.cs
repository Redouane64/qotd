using System.IO;
using Microsoft.AspNetCore.Hosting;

namespace QOTD.Services
{
    public class QuotesProvider
    {
        private readonly string _qotdFilename;

        public QuotesProvider(IHostingEnvironment env)
        {
            _qotdFilename = Path.Combine(env.WebRootPath, "quotes.txt");
        }

        public string GetQuote(int n) {
            var quotes = ReadQuotes();
            return quotes[n % quotes.Length];
        }

        private string[] ReadQuotes() {
            return File.ReadAllLines(_qotdFilename);
        }
    }
}
