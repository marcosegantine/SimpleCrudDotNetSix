using Microsoft.AspNetCore.Mvc;
using SimpleCrudDotNetSix.Models;
using System.Security.Cryptography.X509Certificates;

namespace SimpleCrudDotNetSix.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private static List<User> Users()
        {
            return new List<User>
            {
                new User{Name = "Marcos", Id = 1, DateOfBirth = new DateTime(1987,02,15)}
            };
        }
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(Users());
        }

        [HttpPost]
        public IActionResult Post(User user)
        {
            var users = Users();
            users.Add(user);

            if (user == null)
            {
                return BadRequest("Insira um nome válido");
            }
            return Ok(users);

        }

    }
}
