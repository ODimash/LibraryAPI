using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LibraryAPI.Models
{
	public class Statistic
	{
		[Key]
		public int Id { get; set; }

		[Required]
		public int UserId { get; set; }

		[Required]
		public User User { get; set; } = null!;

		[Required]
		public required int BooksRead { get; set; }

		[Required]
		public required int ReadingTime { get; set; }

		public Ganre FavoriteGanre { get; set; }

	}
}
