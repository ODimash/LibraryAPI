using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LibraryAPI.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class TestController : ControllerBase
	{
		public TestController()
		{
		}

		[HttpGet("test")]
		[Authorize]
		public IActionResult Test()
		{
			return Ok("Authorization successful");
		}
	}
}