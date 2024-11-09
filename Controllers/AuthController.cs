using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace LibraryAPI.Controllers
{
	[Route("[controller]")]
	[ApiController]
	public class AuthController : ControllerBase
	{
		private readonly IConfiguration _configuration;

		public AuthController(IConfiguration configuration) => _configuration = configuration;

		[HttpPost("login")]
		public IActionResult Login([FromBody] LoginRequest request)
		{
			// Проверка пользователя (здесь должна быть ваша логика аутентификации)
			if (request.Username == "your-username" && request.Password == "your-password")
			{
				var token = GenerateJwtToken(request.Username);
				return Ok(new { token });
			}

			return Unauthorized();
		}

		private string GenerateJwtToken(string username)
		{
			var jwtSettings = _configuration.GetSection("JwtSettings");
			var secretKey = jwtSettings["SecretKey"] ?? throw new Exception("SecretKey is cannot be null");
			var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey));
			var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

			var claims = new[]
			{
			new Claim(JwtRegisteredClaimNames.Sub, username),
			new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
		};

			var token = new JwtSecurityToken(
				issuer: jwtSettings["Issuer"],
				audience: jwtSettings["Audience"],
				claims: claims,
				expires: DateTime.UtcNow.AddMinutes(30),
				signingCredentials: creds);

			return new JwtSecurityTokenHandler().WriteToken(token);
		}
	}

	public class LoginRequest
	{
		public required string Username { get; set; }
		public required string Password { get; set; }
	}
}