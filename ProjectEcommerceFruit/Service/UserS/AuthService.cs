using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using ProjectEcommerceFruit.Data;
using ProjectEcommerceFruit.Dtos;
using ProjectEcommerceFruit.Dtos.User;
using ProjectEcommerceFruit.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ProjectEcommerceFruit.Service.UserS
{
    public class AuthService : IAuthService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly DataContext _dataContext;
        private readonly IConfiguration _configuration;
        private readonly IMapper _mapper;

        public AuthService(IHttpContextAccessor httpContextAccessor,
            DataContext dataContext,
            IConfiguration configuration,
            IMapper mapper)
        {
            _httpContextAccessor = httpContextAccessor;
            _dataContext = dataContext;
            _configuration = configuration;
            _mapper = mapper;
        }

        public async Task<List<User>> GetUsers()
        {
            return await _dataContext.Users
                .Include(x => x.Stores)
                    .ThenInclude(x => x.ProductGIs)
                        .ThenInclude(x => x.Images)
                .Include(x => x.Addresses)
                .Include(x => x.CartItems).OrderByDescending(x => x.Id).ToListAsync();
        }

        private string GetUserId() => _httpContextAccessor.HttpContext!.User.FindFirstValue(ClaimTypes.Name)!;

        public async Task<User> GetUserByIdAsync()
            => await _dataContext.Users
                .Include(x => x.Stores)
                    .ThenInclude(x => x.ProductGIs)
                        .ThenInclude(x => x.Images)
                .Include(x => x.Addresses).FirstOrDefaultAsync(x => x.Id.Equals(Convert.ToInt32(GetUserId())));

        public async Task<object> EditUserAsync(EditUser request)
        {
            var user = await GetUserByIdAsync();

            if (user == null) return "user is null";

            user.FullName = request.FullName;

            return await _dataContext.SaveChangesAsync() > 0;
        }

        public async Task<UserDto> RegisterAsync(RegisterDto request)
        {

            var result = await _dataContext.Users.FirstOrDefaultAsync(x => x.PhoneNumber.Equals(request.PhoneNumber));

            if (result != null) return null;

            string passwordHash = BCrypt.Net.BCrypt.HashPassword(request.Password);

            var user = new UserDto()
            {
                Username = "",
                PasswordHash = passwordHash,
                RoleId = request.RoleId,
                FullName = request.FullName,
                PhoneNumber = request.PhoneNumber,
            };

            try
            {
                await _dataContext.Users.AddAsync(_mapper.Map<User>(user));
                await _dataContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                return null;
            }

            return user;
        }

        public async Task<string> LoginAsync(LoginDto request)
        {
            var user = await _dataContext.Users.Include(x => x.Role).FirstOrDefaultAsync(x => x.PhoneNumber.Equals(request.PhoneNumber));

            if (user == null) { return "PhoneNumber Wrong"; }

            if (!BCrypt.Net.BCrypt.Verify(request.Password, user.PasswordHash)) { return "Password Wrong"; }

            string token = CreateToken(user);

            return token;
        }

        public async Task<UserRespone> GetTokenDetail()
        {
            var user = await _dataContext.Users.Include(x => x.Stores).FirstOrDefaultAsync(x => x.Id.Equals(Convert.ToInt32(GetUserId())));

            return _mapper.Map<UserRespone>(user);
        }

        private string CreateToken(User user)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["AppSettings:Token"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha512Signature);

            var claims = new[]
            {
                //new Claim(ClaimTypes.Name, user.Username),
                new Claim(ClaimTypes.Name, user.Id.ToString()),
                new Claim(ClaimTypes.Role, user.Role.Name),
            };

            var token = new JwtSecurityToken(
                issuer: _configuration["JWT:Issuer"],
                audience: _configuration["JWT:Audience"],
                claims: claims,
                expires: DateTime.Now.AddDays(1),
                signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}