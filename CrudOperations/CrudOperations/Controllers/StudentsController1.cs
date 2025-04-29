using Microsoft.AspNetCore.Mvc;

namespace CrudOperations.Controllers
{
    public class StudentsController1 : Controller
    {
        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }
    }
}
