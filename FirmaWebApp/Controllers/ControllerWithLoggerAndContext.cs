using Firma.Data.Model;
using Microsoft.AspNetCore.Mvc;

namespace FirmaWebApp.Controllers
{
    public class ControllerWithLoggerAndContext: Controller
    {
        protected readonly ILogger<HomeController> _logger;
        protected readonly FirmaDbContext _context;

        public ControllerWithLoggerAndContext(ILogger<HomeController> logger, FirmaDbContext context)
        {
            _logger = logger;
            _context = context;
        }
    }
}
