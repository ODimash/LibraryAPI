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
            var newUser = new User { Email = email, Password = password, Name = name, Statistic = new Statistic { BooksRead = 0, PagesRead = 0, ReadingTime = 0 } };
            Console.WriteLine("New user was registred: %s, %s", newUser.Email, newUser.Name);
            newUser.Password = _passwordHasher.HashPassword(newUser, password);
            _context.Users.Add(newUser);
            _context.SaveChanges();
            return newUser;
        }
    }
}
