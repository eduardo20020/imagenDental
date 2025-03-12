using Microsoft.AspNetCore.Mvc;
using imagenDental.Services;
using imagenDental.Models;

namespace imagenDental.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly DatabaseService _dbService;

        public AuthController(DatabaseService dbService)
        {
            _dbService = dbService;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] UserLoginDto loginDto)
        {
            var isValidUser = await _dbService.ValidateUserAsync(loginDto.Username, loginDto.Password);

            if (!isValidUser)
                return Unauthorized(new { message = "Credenciales inválidas" });

            // Si es válido, responde con un mensaje (o un token JWT, etc.)
            return Ok(new { message = "Login exitoso" });
        }
    }
}
