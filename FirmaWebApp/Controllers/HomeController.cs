using Firma.Data.Model;
using FirmaWebApp.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace FirmaWebApp.Controllers
{
    public class HomeController : ControllerWithLoggerAndContext
    {
        public HomeController(ILogger<HomeController> logger, FirmaDbContext context) : base(logger, context)
        {
        }

        public IActionResult Index()
        {
            var typyproduktow = _context.TypyProduktow.ToList();
            ViewData["TypyProduktow"] = typyproduktow;
            return View();
        }
        
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}