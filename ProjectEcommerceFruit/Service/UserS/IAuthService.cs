using ProjectEcommerceFruit.Dtos;
using ProjectEcommerceFruit.Models;

namespace ProjectEcommerceFruit.Service.UserS
{
    public interface IAuthService
    {
        Task<List<User>> GetUsers();
        Task<User> GetUserByIdAsync();
        Task<User> RegisterAsync(RegisterDto request);
        Task<string> LoginAsync(LoginDto request);
        Task<object> GetTokenDetail();
    }
}
