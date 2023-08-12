using HolaMundoAPI.Data;
using HolaMundoAPI.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace HolaMundoAPI.Services
{
    public class UserService : IUserService
    {
        private readonly DBContext _context;

        public UserService(DBContext context)
        {
            _context = context;
        }

        public async Task<User>? GetUserAsync(string username, string password)
        {
            if (_context.Users == null)
            {
                return null;
            }
            var user = await _context.Users.FirstOrDefaultAsync(user => user.UserName == username && user.Password == password);

            return user;
        }
    }
}
