using FiltroDotnet.Config;
using FiltroDotnet.Data;
using FiltroDotnet.Models;
using FiltroDotnet.Repositories;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FiltroDotnet.Controllers.v1.Auth
{
    [ApiController]
    [Route("api/v1/auth/post")]
    public class AuthPostController : AuthController
    {
        private readonly ApplicationDbContext _context;
        private readonly Utilities _utilities;

        public AuthPostController(IUserRepository userRepository, ApplicationDbContext context, IUserRepository utilities)
            : base(userRepository)
        {
            _context = context;
            _utilities = (Utilities?)utilities;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(User newUser)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (_context.Users.Any(u => u.Email == newUser.Email))
            {
                return BadRequest("Email already exists");
            }

            newUser.Password = _utilities.EncryptSHA256(newUser.Password);

            _context.Users.Add(newUser);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(Login), new { id = newUser.Id }, newUser);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var user = await _context.Users.FirstOrDefaultAsync(u => u.Email == request.Email);
            if (user == null)
            {
                return Unauthorized("Invalid email");
            }

            var passwordIsValid = user.Password == _utilities.EncryptSHA256(request.Password);
            if (!passwordIsValid)
            {
                return Unauthorized("Invalid password");
            }

            var token = _utilities.GenerateJwtToken(user);
            return Ok(new
            {
                message = "Please, save this token",
                jwt = token
            });
        }
    }
}