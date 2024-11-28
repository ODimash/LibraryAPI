using Microsoft.EntityFrameworkCore;
using LibraryAPI.Models;
using System.Reflection.Metadata;

namespace LibraryAPI.Data
{
	public class LibraryContext : DbContext
	{
		public LibraryContext(DbContextOptions<LibraryContext> options) : base(options)
		{
		}

		public DbSet<User> Users { get; set; }
		public DbSet<Book> Books { get; set; }
		public DbSet<ReadingSession> ReadingSessions { get; set; }


		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);
		}
	}
}
