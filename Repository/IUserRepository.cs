using SimpleCrudDotNetSix.Models;

namespace SimpleCrudDotNetSix.Repository
{
    public interface IUserRepository
    {
        Task<IEnumerable<User>> SerchUsers();
        Task<User> SerchUser(int id);
        void AddUser(User user);
        void UpdateUser(User user);
        void DeleteUser(User user);
        Task<bool> SaveOnChangeAsync();

    }
}
