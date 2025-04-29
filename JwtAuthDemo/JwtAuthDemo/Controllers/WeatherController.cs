using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace JwtAuthDemo.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class WeatherController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(new { message = "This is a protected weather endpoint!" });
        }

        [HttpGet("admin")]
        [Authorize(Roles = "Admin")] //only users with Admin role can access
        public IActionResult GetAdmin()
        {
            return Ok("Only admin can access this!");
        }
    }
}
