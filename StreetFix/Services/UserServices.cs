using Microsoft.EntityFrameworkCore;
using StreetFix.Data;
using StreetFix.Dtos;
using StreetFix.Models;
using StreetFix.Services.Interfaces;

namespace StreetFix.Services
{
    public class UserServices : IUserServices
    {
        private readonly AppDbContext _context;

        public UserServices(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<UserDto>> GetAllUsers()
        {
            return await _context.User
                .OrderBy(u => u.Id)
                .Select(u => new UserDto
                {
                    Id = u.Id,
                    Name = u.Name
                })
                .ToListAsync();
        }

        public async Task<UserDto> GetUserById(int id)
        {
            var user = await _context.User.FindAsync(id);
            if (user == null)
            {
                throw new KeyNotFoundException($"User with ID {id} was not found.");
            }

            return new UserDto
            {
                Id = user.Id,
                Name = user.Name
            };
        }

        public async Task<UserDto> CreateUser(UserDto user)
        {
            ArgumentNullException.ThrowIfNull(user);

            var newUser = new User
            {
                Name = user.Name,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            };

            _context.User.Add(newUser);
            await _context.SaveChangesAsync();

            user.Id = newUser.Id;
            return user;
        }

        public async Task<UserDto> UpdateUser(int id, UserDto user)
        {
            ArgumentNullException.ThrowIfNull(user);

            var existingUser = await _context.User.FindAsync(id);
            if (existingUser == null)
            {
                throw new KeyNotFoundException($"User with ID {id} was not found.");
            }

            existingUser.Name = user.Name;
            existingUser.UpdatedAt = DateTime.UtcNow;

            await _context.SaveChangesAsync();

            return new UserDto
            {
                Id = existingUser.Id,
                Name = existingUser.Name
            };
        }

        public async Task<bool> DeleteUser(int id)
        {
            var user = await _context.User.FindAsync(id);
            if (user == null)
            {
                return false;
            }

            _context.User.Remove(user);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}