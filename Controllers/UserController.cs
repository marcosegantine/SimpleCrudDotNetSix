using Microsoft.AspNetCore.Mvc;
using SimpleCrudDotNetSix.Models;
using SimpleCrudDotNetSix.Repository;
using System.Security.Cryptography.X509Certificates;

namespace SimpleCrudDotNetSix.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _repository;

        public UserController(IUserRepository repository)
        {
            _repository = repository;
        }


        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var usersDb = await _repository.SerchUsers();
            return usersDb.Any()
                ? Ok(usersDb)
                : NoContent();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var userDb = await _repository.SerchUser(id);
            return userDb != null
                ? Ok(userDb)
                : NotFound("Usuario não encontrado");
        }


        [HttpPost]
        public async Task<IActionResult> Post(User user)
        {
            _repository.AddUser(user);
            return await _repository.SaveOnChangeAsync()
                ? Ok(user) 
                : BadRequest("Erro ao adicionar usuario");

        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, User user)
        {
            var userDb = await _repository.SerchUser(id);
            if (userDb == null) return NotFound("Usuario não encontrado");

            userDb.Name = user.Name ?? userDb.Name;
            userDb.DateOfBirth = user.DateOfBirth != new DateTime()
                ? user.DateOfBirth 
                : userDb.DateOfBirth;
            _repository.UpdateUser(userDb);

            return await _repository.SaveOnChangeAsync()
                ? Ok(userDb)
                : BadRequest("Erro ao atualizar usuario");

        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var userDb = await _repository.SerchUser(id);
            
            if (userDb == null) return NotFound();

            _repository.DeleteUser(userDb);

            return await _repository.SaveOnChangeAsync()
                ? Ok("Usuario deletado") 
                : BadRequest();
        }
    }
}
