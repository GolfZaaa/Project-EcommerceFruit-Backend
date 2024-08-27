using ProjectEcommerceFruit.Dtos;
using ProjectEcommerceFruit.Dtos.User;
using ProjectEcommerceFruit.Models;

namespace ProjectEcommerceFruit.Service.UserS
{
    public interface IAuthService
    {
        Task<List<User>> GetUsers();
        Task<User> GetUserByIdAsync(); 
        Task<Object> EditUserAsync(EditUser request);
        Task<UserDto> RegisterAsync(RegisterDto request);
        Task<string> LoginAsync(LoginDto request);
        Task<UserRespone> GetTokenDetail();
    }
}