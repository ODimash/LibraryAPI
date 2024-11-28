using LibraryAPI.Data;
using LibraryAPI.Models;
using Microsoft.AspNetCore.Identity;

namespace LibraryAPI.Services.Implaments
{
    public class UserService : IUserService
    {
        private readonly LibraryContext _context;
        private readonly IPasswordHasher<User> _passwordHasher;

        public UserService(LibraryContext context, IPasswordHasher<User> passwordHasher)
        {
            _context = context;
            _passwordHasher = passwordHasher;
        }

        public User? Authenticate(string email, string password)
        {
            var user = _context.Users.SingleOrDefault(u => u.Email == email);
            if (user == null || _passwordHasher.VerifyHashedPassword(user, user.Password, password) != PasswordVerificationResult.Success)
            {
                return null;
            }
            return user;
        }

        public User? Register(string email, string password, string name)
        {
            if (_context.Users.Any(u => u.Email == email))
            {
                return null;
            }
			var NewUser = new User { Email = email, Password = password, Name = name };
            NewUser.Statistic = new Statistic { BooksRead = 0, ReadingTime = 0, User = NewUser };
            NewUser.Password = _passwordHasher.HashPassword(NewUser, password);
            _context.Users.Add(NewUser);
            _context.SaveChanges();
            return NewUser;
        }
    }
}
