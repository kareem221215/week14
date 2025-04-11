using identity_and_data_protection.Data;
using identity_and_data_protection.DTOs;
using identity_and_data_protection.Entity;
using identity_and_data_protection.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace identity_and_data_protection.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly IPasswordHasher<User> _hasher;
        private readonly TokenService _tokenService;

        public AuthController(AppDbContext context, IPasswordHasher<User> hasher, TokenService tokenService)
        {
            _context = context;
            _hasher = hasher;
            _tokenService = tokenService;
        }

        [HttpPost("login")]
        public IActionResult Login(LoginRequest request)
        {
            var user = _context.Users.FirstOrDefault(u => u.Email == request.Email);
            if (user == null)
                return Unauthorized("Invalid email or password");

            var result = _hasher.VerifyHashedPassword(user, user.PasswordHash, request.Password);
            if (result == PasswordVerificationResult.Failed)
                return Unauthorized("Invalid email or password");

            var token = _tokenService.CreateToken(user);
            return Ok(new { token });
        }
    }
}
