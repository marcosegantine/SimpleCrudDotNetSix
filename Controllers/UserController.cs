using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SimpleCrudDotNetSix.Dtos;
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
        private readonly IMapper _mapper;

        public UserController(IUserRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public IMapper Mapper { get; }


        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var usersDb = await _repository.SerchUsers();
            var userList = _mapper.Map<List<UserDto>>(usersDb);
            return userList.Any()
                ? Ok(userList)
                : NoContent();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var userDb = await _repository.SerchUser(id);
            var userList = _mapper.Map<UserDetailsDto>(userDb);

            return userList != null
                ? Ok(userList)
                : NotFound("Usuario não encontrado");
        }


        [HttpPost]
        public async Task<IActionResult> Post(UserAddDto user)
        {
            var userAdd = _mapper.Map<User>(user);

             _repository.AddUser(userAdd);
             return await _repository.SaveOnChangeAsync()
                ? Ok() 
                : BadRequest("Erro ao adicionar usuario");

        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, UserDto user)
        {
            if (id <= 0) return BadRequest("Usuario não encontrado");

            var userDb = await _repository.SerchUser(id);
            
            userDb.Name = user.Name ?? userDb.Name;
            userDb.DateOfBirth = user.DateOfBirth != new DateTime()
                ? user.DateOfBirth 
                : userDb.DateOfBirth;

            var userUpdate = _mapper.Map<UserDto>(user);

            _repository.UpdateUser(userUpdate);
            return await _repository.SaveOnChangeAsync()
                ? Ok(userDb)
                : BadRequest("Erro ao atualizar usuario");

        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var userToDelete = await _repository.SerchUser(id);
                        
            if (userToDelete == null) return NotFound();

            _repository.DeleteUser(userToDelete);

            return await _repository.SaveOnChangeAsync()
                ? Ok("Usuario deletado") 
                : BadRequest();
        }
    }
}
