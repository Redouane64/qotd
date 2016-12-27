using System.IO;
using Microsoft.AspNetCore.Hosting;

namespace QOTD.Services
{
    public class QOTD
    {
        private readonly string qotd_filename;

        public QOTD(IHostingEnvironment env)
        {
            qotd_filename = Path.Combine(env.WebRootPath, "quotes.txt");
        }

        public string GetQuote(int N) {
            var quotes = ReadQuotes();
            return quotes[N % quotes.Length];
        }

        private string[] ReadQuotes() {
            return File.ReadAllLines(qotd_filename);
        }
    }
}
