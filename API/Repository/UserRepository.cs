using API.Data;
using API.Entities;
using API.Interface;
using Microsoft.EntityFrameworkCore;

namespace API.Repository
{
    public class UserRepository : IUserInterface
    {
        private readonly APIContext _context;
        public UserRepository(APIContext context)
        {
            _context = context;
        }
        public async Task<List<User>> GetAllUsers()
        {
            var users = await _context.Users.OrderByDescending(u => u.CreationDate).ToListAsync();
            return users;

        }
    }
}
