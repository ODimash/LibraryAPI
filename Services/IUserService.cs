using LibraryAPI.Models;

namespace LibraryAPI.Services
{
	public interface IUserService
	{
		User? Authenticate(string email, string password);
		User? Register(string email, string password, string name);
	}
}
