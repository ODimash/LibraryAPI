using Azure.Core;
using LibraryAPI.Data;
using LibraryAPI.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using System.Linq;

namespace LibraryAPI.Services.Implaments
{
	public class FileUploadService : IFileUploadService
	{
		LibraryContext _context;

		public FileUploadService(LibraryContext context)
		{
			_context = context;
		}



		public void CreateDirectoryIfDoestHas(string directionPath)
		{
			if (!Directory.Exists(directionPath))
			{
				Directory.CreateDirectory(directionPath);
			}
		}



		public Book FindBookById(int id)
		{
			Book? book = _context.Books.Find(id);
			return book == null ? throw new Exception("Not found book with ID " + id) : book;
		}



		public void ValidateFile(IFormFile file, IConfiguration fileConf)
		{
			if (file == null || file.Length == 0)
				throw new Exception("No file uploaded");

			var permittedExtensions = fileConf.GetSection("Extensions").Get<string[]>();
			var mimeTypes = fileConf.GetSection("MimeTypes").Get<string[]>();

			if (permittedExtensions == null || permittedExtensions.Length == 0)
				throw new Exception("Permitted Extensions of book cover cannot be NULL");
			if (mimeTypes == null || mimeTypes.Length == 0)
				throw new Exception("Permitted mime types of book cover cannot be NULL");
			
			var maxSizeMB = fileConf.GetValue<int>("MaxSize", -1);
			if (maxSizeMB != -1)
			{
				int maxSizeByte = maxSizeMB * 1024 * 1024;
				if (file.Length < maxSizeByte)
					throw new Exception($"File size exceeds the limit of {maxSizeMB} MB.");
			} 

			var ext = Path.GetExtension(file.FileName).ToLowerInvariant();
			if (string.IsNullOrEmpty(ext) || !permittedExtensions.Contains(ext))
				throw new Exception("Invalid file type.");

			if (!mimeTypes.Contains(file.ContentType.ToLowerInvariant()))
				throw new Exception("Invalid file MIME type.");
		}
	}
}
