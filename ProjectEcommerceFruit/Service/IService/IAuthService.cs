using ProjectEcommerceFruit.Dtos;
using ProjectEcommerceFruit.Models;

namespace ProjectEcommerceFruit.Service.IService
{
    public interface IAuthService
    {
        Task<List<User>> GetUsers();
        Task<User> RegisterAsync(RegisterDto request);
        Task<string> LoginAsync(LoginDto request);
        Task<Object> GetTokenDetail();
    }
}
