using Microsoft.AspNet.Identity;
using Microsoft.EntityFrameworkCore;
using softone_task_management_backend.Domains.Dtos;
using softone_task_management_backend.Domains.Entities;
using softone_task_management_backend.Services.Interfaces;

namespace softone_task_management_backend.Services
{
    public class AuthService : IAuthService
    {
        private readonly ApplicationDbContext _applicableDbContext;
        private readonly IPasswordHasher _passwordHasher;

        public AuthService(
            ApplicationDbContext applicationDbContext,
            IPasswordHasher passwordHasher)
        {
            this._applicableDbContext = applicationDbContext;
            this._passwordHasher = passwordHasher;
        }

        public async Task<UserDto> SignUp(UserDto user)
        {
            var hashedPassword = this._passwordHasher.HashPassword(user.Password);

            var userDetails = new User
            {
                UserName = user.UserName,
                Password = hashedPassword,
                FirstName = user.FirstName,
                LastName = user.LastName,
            };

            this._applicableDbContext.Add(userDetails);
            await _applicableDbContext.SaveChangesAsync();

            return new UserDto
            {
                Id = user.Id,
                UserName = user.UserName,
                Password = hashedPassword,
                FirstName = user.FirstName,
                LastName = user.LastName,
            };
        }

        public async Task<UserDto> SignIn(UserDto user)
        {
            var hashedPassword = this._passwordHasher.HashPassword(user.Password);

            var existingUser = await this._applicableDbContext.Users
                .FirstOrDefaultAsync(u => u.UserName == user.UserName);

            if (existingUser is null)
            {
                throw new Exception("Invalid SignIn credentials");
            }

            if (_passwordHasher.VerifyHashedPassword(existingUser.Password, user.Password) != PasswordVerificationResult.Success)
            {
                throw new Exception("Invalid credentials");
            }

            return new UserDto
            {
                Id = existingUser.Id,
                UserName = existingUser.UserName,
                Password = hashedPassword,
                FirstName = existingUser.FirstName,
                LastName = existingUser.LastName,
            };
        }
    }
}
