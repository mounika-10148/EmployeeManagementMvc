using CrudDapper.Models;
using Microsoft.AspNetCore.Mvc;

namespace CrudDapper.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly UserRepository _repo;

        public UserController(UserRepository repo)
        {
            _repo = repo;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var users = _repo.GetAll();
            return Ok(users);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var user = _repo.GetById(id);
            if (user == null)
                return NotFound();

            return Ok(user);
        }

        [HttpPost]
        public IActionResult Create(User user)
        {
            _repo.Add(user);
            return Ok(new { message = "User created successfully" });
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, User user)
        {
            var existingUser = _repo.GetById(id);
            if (existingUser == null)
                return NotFound();

            user.Id = id;
            _repo.Update(user);
            return Ok(new { message = "User updated successfully" });
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var user = _repo.GetById(id);
            if (user == null)
                return NotFound();

            _repo.Delete(id);
            return Ok(new { message = "User deleted successfully" });
        }
    }
}
