using LibraryAPI.Models;
using LibraryAPI.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Configuration;
using System.Net;

namespace LibraryAPI.Controllers
{
	[Route("api/upload")]
	[ApiController]
	[Authorize]
	public class FileUploadController : ControllerBase
	{
		private readonly IWebHostEnvironment _webHostEnvironment;
		private readonly IFileUploadService _uploadService;
		IConfigurationSection _bookCoverFileConf;
		IConfigurationSection _bookContextFileConf;
		IConfigurationSection _userPhotoFileConf;

		public FileUploadController(IWebHostEnvironment webHostEnvironment, IConfiguration conf, IFileUploadService uploadService)
		{
			_webHostEnvironment = webHostEnvironment;
			_bookCoverFileConf = conf.GetSection("FileUploadSettings:BookCover");
			_bookContextFileConf = conf.GetSection("FileUploadSettings:BookContext");
			_userPhotoFileConf = conf.GetSection("FileUploadSettings:UserPhoto");
			_uploadService = uploadService;
		}

		[HttpPost("book-cover/{BookId}")]
		public async Task<IActionResult> UploadBookCover(int BookId, IFormFile File)
		{
			_uploadService.ValidateFile(File, _bookCoverFileConf);
			Book foundBook = _uploadService.FindBookById(BookId);
			if (foundBook == null)
			{
				return NotFound("Notfound book with ID " + BookId);
			}

			var DirectoryPath = Path.Combine("files", "book-covers");
			var FullPath = Path.Combine(Directory.GetCurrentDirectory(), DirectoryPath);
			_uploadService.CreateDirectoryIfDoestHas(FullPath);

			var ext = Path.GetExtension(File.FileName).ToLowerInvariant();
			var FileName = BookId.ToString() + ext;
			var FilePath = Path.Combine(FullPath, FileName);
			var FileURI = Path.Combine(DirectoryPath, FileName);

			using (var stream = new FileStream(FilePath, FileMode.Create))
			{
				await File.CopyToAsync(stream);
			}
			return Ok(new { FileURI });
		}

		[HttpPost("book-context/{BookId}")]
		public async Task<IActionResult> UploadBookContext(int BookId, IFormFile File)
		{

			_uploadService.ValidateFile(File, _bookContextFileConf);
			var DirectoryPath = Path.Combine("files", "book-context");
			var FullPath = Path.Combine(Directory.GetCurrentDirectory(), DirectoryPath);
			_uploadService.CreateDirectoryIfDoestHas(FullPath);

			var ext = Path.GetExtension(File.FileName).ToLowerInvariant();
			var FileName = BookId.ToString() + ext;
			var FilePath = Path.Combine(FullPath, FileName);
			var FileURI = Path.Combine(DirectoryPath, FileName);

			using (var stream = new FileStream(FilePath, FileMode.Create))
			{
				await File.CopyToAsync(stream);
			}
			return Ok(new { FileURI });

		}

		[HttpPost("user-photo/{UserId}")]
		public async Task<IActionResult> UploadUserPhoto(int UserId, IFormFile File)
		{
			_uploadService.ValidateFile(File, _userPhotoFileConf);
			var DirectoryPath = Path.Combine("files", "user-photo");
			var FullPath = Path.Combine(Directory.GetCurrentDirectory(), DirectoryPath);
			_uploadService.CreateDirectoryIfDoestHas(FullPath);

			var ext = Path.GetExtension(File.FileName).ToLowerInvariant();
			var FileName = UserId.ToString() + ext;
			var FilePath = Path.Combine(FullPath, FileName);
			var FileURI = Path.Combine(DirectoryPath, FileName);

			using (var stream = new FileStream(FilePath, FileMode.Create))
			{
				await File.CopyToAsync(stream);
			}

			return Ok(new { FileURI });
		}

	}
}
