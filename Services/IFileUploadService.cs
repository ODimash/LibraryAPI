using LibraryAPI.Models;

namespace LibraryAPI.Services
{
	public interface IFileUploadService
	{
		Book FindBookById(int id);
		void CreateDirectoryIfDoestHas(string directionPath);
		void ValidateFile(IFormFile file, IConfiguration fileConf);
	}
}
