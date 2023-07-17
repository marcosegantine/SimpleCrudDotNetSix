using SimpleCrudDotNetSix.Dtos;
using SimpleCrudDotNetSix.Models;

namespace SimpleCrudDotNetSix.Repository
{
    public interface IUserRepository
    {
        Task<IEnumerable<User>> SerchUsers();
        Task<User> SerchUser(int id);
        void AddUser(UserDto user);
        void UpdateUser(UserDto user);
        void DeleteUser(User user);
        Task<bool> SaveOnChangeAsync();
        
    }
}
