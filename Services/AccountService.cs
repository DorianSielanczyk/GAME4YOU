using GAME4YOU.Data;
using GAME4YOU.Entities;
using GAME4YOU.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace GAME4YOU.Services
{
    public class AccountService
    {
        private readonly Game4youDbContext _context;
        private readonly IPasswordHasher<Users> _passwordHasher;
        private readonly AuthenticationSettings _authenticationSettings;
        public AccountService(Game4youDbContext context, IPasswordHasher<Users> passwordHasher, AuthenticationSettings authenticationSettings)
        {
            _context = context;
            _passwordHasher = passwordHasher;
            _authenticationSettings = authenticationSettings;
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
        public async Task<string> LoginUser(string email, string password)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Email == email);

            if (user == null)
            {
                return null;
            }

            var passwordVerificationResult = _passwordHasher.VerifyHashedPassword(user, user.Password, password);

            if (passwordVerificationResult == PasswordVerificationResult.Failed)
            {
                return null;
            }

            return GenerateJwtToken(user);
        }
        private string GenerateJwtToken(Users user)
        {
            var role = _context.Roles.FirstOrDefault(r => r.Id == user.RoleId);
            string roleName = role != null ? role.Name : "User";

            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.Email),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim("email", user.Email),
                new Claim("role", roleName),
                new Claim("firstName", user.FirstName), 
                new Claim("lastName", user.LastName),
                new Claim("userId", user.Id.ToString())
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_authenticationSettings.JwtKey));
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: _authenticationSettings.JwtIssuer,
                audience: _authenticationSettings.JwtIssuer,
                claims: claims,
                expires: DateTime.Now.AddMinutes(_authenticationSettings.JwtExpireMinutes),
                signingCredentials: credentials
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
        public async Task<bool> UpdateUser(string currentEmail, UserUpdateDto dto)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Email == currentEmail);
            if (user == null)
                return false;

            user.FirstName = dto.FirstName;
            user.LastName = dto.LastName;
            user.Email = dto.Email;

            await _context.SaveChangesAsync();
            return true;
        }
    }
}
