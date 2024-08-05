using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjectEcommerceFruit.Dtos;
using ProjectEcommerceFruit.Service.UserS;
using System.Security.Claims;

namespace ProjectEcommerceFruit.Controllers
{
    public class AuthController : BaseController
    {
        private readonly IAuthService _authService;
        private readonly IConfiguration _configuration;

        public AuthController(IAuthService authService, IConfiguration configuration)
        {
            _authService = authService;
            _configuration = configuration;
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> Register(RegisterDto request)
        {
            var user = await _authService.RegisterAsync(request);

            if (user == null) return BadRequest("UserName has already");

            return Ok(await _authService.GetUsers());
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> Login(LoginDto request) => Ok(await _authService.LoginAsync(request));

        [HttpGet("[action]"), Authorize(Roles = "Admin")]
        public IActionResult test()
        {
            return Ok("คุณมีสิทธื์การเข้าใช้สู่ระบบ");
        }

        [HttpGet("[action]"), Authorize]
        public async Task<IActionResult> GetTokenDetail()
        {
            var token = await _authService.GetTokenDetail();

            return Ok(token);
        }

        [HttpGet("[action]"), Authorize]
        public async Task<IActionResult> GetToken()
        {
            var token = _authService.GetTokenDetail();

            return Ok(token);
        }

        [HttpGet("[action]"), Authorize]
        public async Task<IActionResult> GetTokenClaim()
        {
            var accessToken = await HttpContext.GetTokenAsync("access_token");
            return Ok(accessToken);
        }
    }
}