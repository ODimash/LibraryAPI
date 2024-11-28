using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LibraryAPI.Controllers
{
	[Route("api/upload")]
	[ApiController]
	[Authorize]
	public class FileUploadController : ControllerBase
	{
		private readonly IWebHostEnvironment _webHostEnvironment;

		public FileUploadController(IWebHostEnvironment webHostEnvironment)
		{
			_webHostEnvironment = webHostEnvironment;
		}

		[HttpPost("book-cover/{BookId}")]
		public async Task<IActionResult> UploadBookCover(int BookId, IFormFile File)
		{
			if (File == null || File.Length == 0)
				return BadRequest("No file uploaded");

			//string RootPath = _webHostEnvironment.WebRootPath ?? _webHostEnvironment.ContentRootPath;
			var DirectoryPath = Path.Combine(Directory.GetCurrentDirectory(), "files", "book-covers");
			var FilePath = Path.Combine(DirectoryPath, File.FileName);


			try
			{
				if (!Directory.Exists(DirectoryPath))
				{
					Directory.CreateDirectory(DirectoryPath);
				}
				using (var stream = new FileStream(FilePath, FileMode.Create))
				{
					await File.CopyToAsync(stream);
				}
				return Ok(new { FilePath = FilePath });
			}
			catch (Exception error)
			{
				return StatusCode(StatusCodes.Status500InternalServerError, "File path not found: " + FilePath + "\n" + error);
			}
		}

		[HttpPost("book-context/{BookId}")]
		public async Task<IActionResult> UploadBookContext(int BookId, IFormFile File)
		{
			if (File == null || File.Length == 0)
				return BadRequest("No file iploaded");

			var DirectoryPath = Path.Combine(Directory.GetCurrentDirectory(), "files", "book-context");
			var FilePath = Path.Combine(DirectoryPath, File.FileName);
			try
			{
				if (!Directory.Exists(DirectoryPath))
				{
					Directory.CreateDirectory(DirectoryPath);
				}
				using (var stream = new FileStream(FilePath, FileMode.Create))
				{
					await File.CopyToAsync(stream);
				}
				return Ok(new { FilePath = FilePath });
			}
			catch (Exception error) 
			{ 
				return StatusCode(500, error.Message);
			}
		}

		[HttpPost("user-photo/{UserId}")]
		public async Task<IActionResult> UploadUserPhoto(int UserId, IFormFile File)
		{
			if (File == null || File.Length == 0)
				return BadRequest("No file uploaded");

			var DirectoryPath = Path.Combine(Directory.GetCurrentDirectory(), "files", "user-photo");
			var FilePath = Path.Combine(DirectoryPath, File.FileName);

			if (!Directory.Exists (DirectoryPath))
			{
				Directory.CreateDirectory(DirectoryPath);
			}

			using (var stream = new FileStream(FilePath, FileMode.Create))
			{
				await File.CopyToAsync(stream);
			}

			return Ok(new { FilePath = FilePath });
		}
	}
}
