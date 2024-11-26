using LibraryAPI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
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
		private readonly IUserService _userService;

		public AuthController(IConfiguration configuration, IUserService userService)
		{
			_configuration = configuration;
			_userService = userService;
		}

		[HttpPost("login")]
		public IActionResult Login([FromBody] LoginRequest request)
		{
			var User = _userService.Authenticate(request.Email, request.Password);
			if (User == null)
			{
				return Unauthorized();
			}		
			var token = GenerateJwtToken(request.Email);
			return Ok(new { token });
		}

		[HttpPost("register")]
		public IActionResult Register([FromBody] RegisterRequest registerRequest)
		{	
			var User = _userService.Register(registerRequest.Email, registerRequest.Password, registerRequest.Name);
			if (User == null)
			{
				return Unauthorized();
			}

			var token = GenerateJwtToken(User.Email);
			return Ok(new { token });
		}

		private string GenerateJwtToken(string Email)
		{
			var jwtSettings = _configuration.GetSection("JwtSettings");
			var secretKey = jwtSettings["SecretKey"] ?? throw new Exception("SecretKey is cannot be null");
			var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey));
			var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

			var claims = new[]
			{
			new Claim(JwtRegisteredClaimNames.Sub, Email),
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
		public required string Email { get; set; }
		public required string Password { get; set; }
	}

	public class RegisterRequest
	{
		public required string Email { get; set; }
		public required string Name {  get; set; }
		public required string Password { get; set; }
	}
}