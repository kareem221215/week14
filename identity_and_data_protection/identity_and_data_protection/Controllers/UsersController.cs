using identity_and_data_protection.DTOs;
using identity_and_data_protection.Entity;
using identity_and_data_protection.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace identity_and_data_protection.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly IPasswordHasher<User> _passwordHasher;

        public UsersController(AppDbContext context, IPasswordHasher<User> passwordHasher)
        {
            _context = context;
            _passwordHasher = passwordHasher;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(CreateUserRequest request)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var user = new User
            {
                Email = request.Email
            };

            user.PasswordHash = _passwordHasher.HashPassword(user, request.Password);
            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            return Ok("User registered successfully");
        }
    }
}
