using System;
using Microsoft.AspNetCore.Mvc;
using qs = QOTD.Services;
using QOTD.ViewModels;

namespace QOTD.Controllers
{
    public class QOTDController : Controller
    {
        private readonly qs.QOTD _qotd;

        public QOTDController(qs.QOTD qotd)
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