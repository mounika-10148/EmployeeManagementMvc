using Microsoft.AspNetCore.Mvc;

namespace WebApplication3.Controllers
{
    [Route("products")]
    public class ProductsController : Controller
    {
        // GET /products/{id}
        [HttpGet("{id}")]
        public IActionResult GetProduct(int id)
        {
            // Logic to fetch and return product by ID
            return View();
        }

        // GET /products/all
        [HttpGet("all")]
        public IActionResult GetAllProducts()
        {
            // Logic to fetch and return all products
            return View();
        }

}
}
