using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Serilog;
using SerilogProject2.Models;

namespace SerilogProject2.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            Log.Information("📘 HomeController Constructor action called at {Time}", DateTime.Now);
            _logger = logger;
        }

        public IActionResult Index()
        {
            // serilog logger
            Log.Information("📘 Index action called at {Time}", DateTime.Now);
            return View();
        }

        public IActionResult Privacy()
        {
            Log.Information("📘 Privacy action called at {Time}", DateTime.Now);
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            Log.Error("📘 Error action called at {Time}", DateTime.Now);
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}