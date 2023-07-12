using Microsoft.EntityFrameworkCore;
using SimpleCrudDotNetSix.Data;
using SimpleCrudDotNetSix.Models;

namespace SimpleCrudDotNetSix.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly SimpleCrudContext _context;

        public UserRepository(SimpleCrudContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<User>> SerchUsers()
        {
            return await _context.Users.ToListAsync();
        }

        public async Task<User> SerchUser(int id)
        {
            return await _context.Users
                .Where(x => x.Id == id).FirstOrDefaultAsync();
        }

        public void AddUser(User user)
        {
            _context.Add(user);
        }

        public void UpdateUser(User user)
        {
            _context.Update(user);
        }

        public void DeleteUser(User user)
        {
            _context.Remove(user);
        }

        public async Task<bool> SaveOnChangeAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }

    }
}
