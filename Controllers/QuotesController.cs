using System;
using Microsoft.AspNetCore.Mvc;
using scratch.Services;
using scratch.ViewModels;

namespace scratch.Controllers
{
    public class QOTDController : Controller
    {
        private readonly QOTD _qotd;

        public QOTDController(QOTD qotd)
        {
            _qotd = qotd;
        }

        public IActionResult Index() {
            var random = new Random();
            var model = new QuoteViewModel();
            model.Quote = _qotd.GetQuote(random.Next());
            return View(model);
        }
    }
}