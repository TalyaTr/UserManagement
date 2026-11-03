using Microsoft.AspNetCore.Mvc;
using UserManagement.Models;
using UserManagement.Repositories;

namespace UserManagement.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly IUserRepository _repo;

        public UsersController(IUserRepository repo)
        {
            _repo = repo;
        }

        [HttpPost("create")]
        public IActionResult Create(User user)
        {
            var created = _repo.Create(user);
            return Ok(created);
        }

        [HttpDelete("delete/{id}")]
        public IActionResult Delete(int id)
        {
            bool deleted = _repo.Delete(id);
            if (!deleted) return NotFound("User not found");

            return Ok("User deleted");
        }

        [HttpPost("validate")]
        public IActionResult Validate([FromBody] User user)
        {
            var validUser = _repo.Validate(user.UserName, user.UserPassword);
            if (validUser == null) return Unauthorized("Invalid credentials");

            return Ok("User validated");
        }
    }
}
