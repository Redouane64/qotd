using System;
using System.IO;
using Microsoft.AspNetCore.Hosting;

namespace QOTD.Services
{
    public class QuotesProvider
    {
        private readonly string _filename;

        public QuotesProvider(IHostingEnvironment env)
        {
            _filename = Path.Combine(env.WebRootPath, "quotes.txt");
        }

	    public string GetQuote()
	    {
		    var quotes = File.ReadAllLines(_filename);
			return quotes[new Random().Next(0, quotes.Length)];
	    }

    }
}
