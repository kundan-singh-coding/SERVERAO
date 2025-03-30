using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SWICN.Data;
using SWICN.Helpers;
using SWICN.Model;

namespace SWICN.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {

        private readonly AppDbContext _context;
        private readonly IConfiguration _configuration;

        public AuthController(AppDbContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] User login)
        {
            var user = await _context.Users
                .FirstOrDefaultAsync(u => u.UserName == login.UserName && u.Password == login.Password);

            if (user == null)
                return Unauthorized("Invalid Credentials");

            var token = TokenServices.GenerateToken(user.UserName,user.Role, _configuration["Jwt:Key"]);

            return Ok(new { Token = token });
        }
    }
}