using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MiddleWare.Models;

namespace MiddleWare.Controllers
{
    public class EmployeeCotroller : Controller
    {
        private readonly BrillioContext brillioContext;

        public EmployeeCotroller(BrillioContext brillioContext)
        {
            this.brillioContext = brillioContext;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            // Fix: Cast brillioContext.Employee to the appropriate DbSet<Employee> type
            var employees = await ((DbSet<Employee>)brillioContext.Employee).ToListAsync();
            return View(employees);
        }
    }
}
