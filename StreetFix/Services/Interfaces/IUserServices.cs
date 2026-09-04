using StreetFix.Dtos;

namespace StreetFix.Services.Interfaces
{
    public interface IUserServices
    {
        Task<List<UserDto>> GetAllUsers();
        Task<UserDto> GetUserById(int id);
        Task<UserDto> CreateUser(UserDto user);
        Task<UserDto> UpdateUser(int id, UserDto user);
        Task<bool> DeleteUser(int id);
    }
}