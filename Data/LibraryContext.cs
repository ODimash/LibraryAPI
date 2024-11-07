using Microsoft.EntityFrameworkCore;
using Library.Models;

namespace Library.Data
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

            modelBuilder.Entity<Book>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.Author)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.Ganre)
                    .IsRequired();
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(255);
                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(255);
                entity.Property(e => e.Password)
                    .IsRequired();
            });

            modelBuilder.Entity<ReadingSession>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.StartTime)
                    .IsRequired();
                entity.Property(e => e.EndTime)
                    .IsRequired(false);
                entity.Property(e => e.Status)
                    .HasConversion<string>();

                entity.HasOne(e => e.User)
                    .WithMany(u => u.ReadingSessions)
                    .HasForeignKey(e => e.UserId);

                entity.HasOne(e => e.Book)
                    .WithMany(b => b.ReadingSessions)
                    .HasForeignKey(e => e.BookId);
            });
        }
    }
}
