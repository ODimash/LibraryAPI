using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LibraryAPI.Models
{
	public class Statistic
	{
		[Key, ForeignKey("User")]
		public int Id { get; set; }

		[Required]
		public required int BooksRead { get; set; }

		[Required]
		public required int ReadingTime { get; set; }

		public Ganre FavoriteGanre { get; set; }

		[Required]
		public required int PagesRead {  get; set; }
	}
}
