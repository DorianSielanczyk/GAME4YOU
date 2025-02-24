using GAME4YOU.Data;
using GAME4YOU.Entities;
using Microsoft.AspNetCore.Identity;

namespace GAME4YOU.Services
{
    public class AccountService
    {
        private readonly Game4youDbContext _context;
        private readonly IPasswordHasher<Users> _passwordHasher;
        public AccountService(Game4youDbContext context, IPasswordHasher<Users> passwordHasher)
        {
            _context = context;
            _passwordHasher = passwordHasher;
        }
        public async Task<bool> RegisterUser(Users user)
        {

            if (_context.Users.Any(u => u.Email == user.Email))
            {
                return false;
            } 

            var hashedPassword = _passwordHasher.HashPassword(user, user.Password);

            user.Password = hashedPassword;  
            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            return true;
        }
    }
}
