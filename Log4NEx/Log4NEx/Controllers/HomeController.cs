using System.Diagnostics;
using log4net;
using Log4NEx.Models;
using Microsoft.AspNetCore.Mvc;

namespace Log4NetEx.Controllers
{
    public class HomeController : Controller
    {
        //defining log4net logger
        private static readonly ILog log = LogManager.GetLogger(typeof(HomeController));
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            log.Info("HomeController constructor called");
            _logger = logger;
        }

        public IActionResult Index()
        {
            log.Info("Index action called");
            return View();
        }

        public IActionResult Privacy()
        {
            log.Info("Privacy action called");
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            log.Error("Error action called");
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}