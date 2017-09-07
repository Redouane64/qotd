using System;
using Microsoft.AspNetCore.Mvc.RazorPages;
using QOTD.Services;

namespace Qotd.Pages
{
	public class IndexModel : PageModel
    {
	    private readonly QuotesProvider _provider;

	    public IndexModel(QuotesProvider provider) => _provider = provider;

	    public string Quote { get; private set; }

	    public void OnGet()
	    {
		    Quote = _provider.GetQuote(new Random().Next());
	    }
    }
}